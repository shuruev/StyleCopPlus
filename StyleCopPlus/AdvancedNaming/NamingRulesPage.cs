using System;
using System.Drawing;
using System.Windows.Forms;
using StyleCopPlus.Properties;

namespace StyleCopPlus
{
	/// <summary>
	/// Control displaying naming rules page.
	/// </summary>
	public partial class NamingRulesPage : UserControl
	{
		private Font m_regular;
		private Font m_bold;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public NamingRulesPage()
		{
			InitializeComponent();

			listRules.SmallImageList = Pictures.GetList();
		}

		#region Properties

		/// <summary>
		/// Gets or sets parent property page.
		/// </summary>
		public PropertyPage Page { get; set; }

		#endregion

		#region Event handlers

		private void NamingRulesPage_Load(object sender, EventArgs e)
		{
			m_regular = new Font(listRules.Font, FontStyle.Regular);
			m_bold = new Font(listRules.Font, FontStyle.Bold);

			UpdateControls();
		}

		private void NamingRulesPage_VisibleChanged(object sender, EventArgs e)
		{
			if (DesignMode)
				return;

			if (!Visible)
				return;

			if (!SettingsGrabber.Initialized)
				return;

			UpdateWarnings();
		}

		private void listRules_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateControls();
		}

		private void listRules_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
				return;

			Action_Edit_Do();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			Action_Edit_Do();
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			Action_Reset_Do();
		}

		#endregion

		#region Property page methods

		/// <summary>
		/// Initializes the specified property control with the StyleCop settings file.
		/// </summary>
		public void Initialize()
		{
			UpdateWarnings();
			RebuildRuleList();
		}

		/// <summary>
		/// Apply the modifications to the StyleCop settings file.
		/// </summary>
		public bool Apply()
		{
			foreach (ListViewItem lvi in listRules.Items)
			{
				SettingTag tag = (SettingTag)lvi.Tag;
				if (tag.Modified)
				{
					SettingsManager.SetLocalValue(Page, tag.SettingName, tag.MergedValue);
				}
				else
				{
					SettingsManager.ClearLocalValue(Page, tag.SettingName);
				}
			}

			return true;
		}

		/// <summary>
		/// Refreshes the state of the settings override.
		/// </summary>
		public void RefreshSettingsOverrideState()
		{
			foreach (ListViewItem lvi in listRules.Items)
			{
				SettingTag tag = (SettingTag)lvi.Tag;
				if (tag.Modified)
				{
					tag.InheritedValue = SettingsManager.GetInheritedValue(Page, tag.SettingName);
					Page.Dirty = true;
				}
				else
				{
					tag.InheritedValue = SettingsManager.GetInheritedValue(Page, tag.SettingName);
					tag.MergedValue = SettingsManager.GetMergedValue(Page, tag.SettingName);
				}

				UpdateListItem(lvi);
			}

			UpdateControls();
		}

		#endregion

		#region Displaying warnings

		/// <summary>
		/// Updates page warnings.
		/// </summary>
		public void UpdateWarnings()
		{
			warningArea.Clear();

			if (!SettingsGrabber.IsRuleEnabled(Page.Analyzer.Id, Rules.AdvancedNamingRules.ToString()))
			{
				warningArea.Add(Resources.WarningDisabledAdvancedNamingRulesCode);
			}
			else if (SettingsGrabber.IsAnalyzerEnabled(Constants.NamingRulesAnalyzerId))
			{
				warningArea.Add(Resources.WarningDontUseOriginalNamingRulesCode);
			}
		}

		#endregion

		#region User interface

		/// <summary>
		/// Rebuilds rule list.
		/// </summary>
		private void RebuildRuleList()
		{
			listRules.BeginUpdate();
			listRules.Groups.Clear();
			listRules.Items.Clear();

			foreach (string group in NamingSettings.GetGroups())
			{
				ListViewGroup lvg = new ListViewGroup(group);
				listRules.Groups.Add(lvg);

				foreach (string setting in NamingSettings.GetByGroup(group))
				{
					string friendlyName = SettingsManager.GetFriendlyName(Page, setting);
					string mergedValue = SettingsManager.GetMergedValue(Page, setting);
					string inheritedValue = SettingsManager.GetInheritedValue(Page, setting);

					SettingTag tag = new SettingTag();
					tag.SettingName = setting;
					tag.MergedValue = mergedValue;
					tag.InheritedValue = inheritedValue;

					ListViewItem lvi = new ListViewItem();
					lvi.Group = lvg;
					lvi.UseItemStyleForSubItems = false;
					lvi.Text = friendlyName;
					lvi.Tag = tag;

					ListViewItem.ListViewSubItem sub = new ListViewItem.ListViewSubItem();
					lvi.SubItems.Add(sub);

					UpdateListItem(lvi);

					listRules.Items.Add(lvi);
				}
			}

			listRules.EndUpdate();
		}

		/// <summary>
		/// Updates list item depending on specified properties.
		/// </summary>
		private void UpdateListItem(ListViewItem lvi)
		{
			SettingTag tag = (SettingTag)lvi.Tag;
			ListViewItem.ListViewSubItem sub = lvi.SubItems[1];

			sub.Font = tag.Modified ? m_bold : m_regular;
			sub.Text = NamingSettings.GetPreviewText(tag.SettingName, tag.MergedValue);

			string settingName = tag.SettingName;
			bool enabled = !String.IsNullOrEmpty(tag.MergedValue);

			lvi.ImageKey = NamingSettings.GetImageKey(settingName, enabled);
		}

		/// <summary>
		/// Updates controls for all actions.
		/// </summary>
		private void UpdateControls()
		{
			btnEdit.Enabled = Action_Edit_IsAvailable();
			btnReset.Enabled = Action_Reset_IsAvailable();
		}

		#endregion

		#region Actions

		/// <summary>
		/// Does action "Edit".
		/// </summary>
		private void Action_Edit_Do()
		{
			if (!Action_Edit_IsAvailable())
				return;

			ListViewItem lvi = listRules.SelectedItems[0];
			SettingTag tag = (SettingTag)lvi.Tag;

			using (IAdvancedNamingEditor dialog = NamingSettings.GetEditor(tag.SettingName))
			{
				dialog.ObjectName = lvi.Text;
				dialog.TargetRule = tag.MergedValue;
				if (dialog.ShowDialog(this) == DialogResult.OK)
				{
					tag.MergedValue = dialog.TargetRule;
					UpdateListItem(lvi);
					Page.Dirty = true;

					UpdateControls();
				}
			}
		}

		/// <summary>
		/// Checks whether action "Edit" is available.
		/// </summary>
		private bool Action_Edit_IsAvailable()
		{
			if (listRules.SelectedItems.Count == 1)
				return true;

			return false;
		}

		/// <summary>
		/// Does action "Reset".
		/// </summary>
		private void Action_Reset_Do()
		{
			if (!Action_Reset_IsAvailable())
				return;

			ListViewItem lvi = listRules.SelectedItems[0];
			SettingTag tag = (SettingTag)lvi.Tag;

			string preview = NamingSettings.GetPreviewText(tag.SettingName, tag.InheritedValue);
			if (Messages.ShowWarningYesNo(this, Resources.ResetSettingQuestion, preview) != DialogResult.Yes)
				return;

			tag.MergedValue = tag.InheritedValue;
			UpdateListItem(lvi);
			Page.Dirty = true;

			UpdateControls();
		}

		/// <summary>
		/// Checks whether action "Reset" is available.
		/// </summary>
		private bool Action_Reset_IsAvailable()
		{
			if (listRules.SelectedItems.Count != 1)
				return false;

			ListViewItem lvi = listRules.SelectedItems[0];
			SettingTag tag = (SettingTag)lvi.Tag;
			if (tag.Modified)
				return true;

			return false;
		}

		#endregion
	}
}
