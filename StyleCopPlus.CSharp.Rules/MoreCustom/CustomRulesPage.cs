using System;
using System.Drawing;
using System.Windows.Forms;
using StyleCopPlus.Properties;

namespace StyleCopPlus
{
	/// <summary>
	/// Control displaying custom rules page.
	/// </summary>
	public partial class CustomRulesPage : UserControl
	{
		private Font m_regular;
		private Font m_bold;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public CustomRulesPage()
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

		private void CustomRulesPage_Load(object sender, EventArgs e)
		{
			m_regular = new Font(listRules.Font, FontStyle.Regular);
			m_bold = new Font(listRules.Font, FontStyle.Bold);

			UpdateControls();
		}

		private void CustomRulesPage_VisibleChanged(object sender, EventArgs e)
		{
			if (DesignMode)
				return;

			if (!Visible)
				return;

			if (!SettingsGrabber.Initialized)
				return;

			UpdateWarnings();
			UpdateAllListItems();
			UpdateControls();
		}

		private void listRules_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateControls();
		}

		private void listRules_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
				return;

			checkEnabled_Click(sender, e);
		}

		private void checkEnabled_Click(object sender, EventArgs e)
		{
			Action_SwitchEnabled_Do();
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
				CustomRuleTag tag = (CustomRuleTag)lvi.Tag;
				if (tag.SettingName != null)
				{
					if (tag.Modified)
					{
						SettingsManager.SetLocalValue(Page, tag.SettingName, tag.MergedValue);
					}
					else
					{
						SettingsManager.ClearLocalValue(Page, tag.SettingName);
					}
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
				CustomRuleTag tag = (CustomRuleTag)lvi.Tag;
				if (tag.SettingName != null)
				{
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

			foreach (string group in CustomRules.GetGroups())
			{
				ListViewGroup lvg = new ListViewGroup(group);
				listRules.Groups.Add(lvg);

				foreach (CustomRule rule in CustomRules.GetByGroup(group))
				{
					CustomRuleTag tag = new CustomRuleTag();
					tag.Rule = rule;
					if (rule.SettingName != null)
					{
						tag.OptionsControl = tag.Rule.CreateOptionsControl();
						tag.OptionsControl.Rule = tag.Rule;
						tag.OptionsControl.OptionsDataChanged += OnOptionsDataChanged;
						tag.OptionsControl.Dock = DockStyle.Fill;

						tag.SettingName = rule.SettingName;
						tag.MergedValue = SettingsManager.GetMergedValue(Page, rule.SettingName);
						tag.InheritedValue = SettingsManager.GetInheritedValue(Page, rule.SettingName);
					}

					ListViewItem lvi = new ListViewItem();
					lvi.Group = lvg;
					lvi.UseItemStyleForSubItems = false;
					lvi.Text = String.Format("{0}: {1}", rule.Code, rule.RuleName);
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
		/// Handles changed options data.
		/// </summary>
		private void OnOptionsDataChanged(object sender, EventArgs e)
		{
			if (listRules.SelectedItems.Count != 1)
				return;

			CustomRuleOptions optionsControl = (CustomRuleOptions)sender;

			ListViewItem lvi = listRules.SelectedItems[0];
			CustomRuleTag tag = (CustomRuleTag)lvi.Tag;

			tag.MergedValue = optionsControl.ParseOptions();

			UpdateListItem(lvi);
			Page.Dirty = true;

			UpdateControls();
		}

		/// <summary>
		/// Updates list item depending on specified properties.
		/// </summary>
		private void UpdateListItem(ListViewItem lvi)
		{
			CustomRuleTag tag = (CustomRuleTag)lvi.Tag;
			ListViewItem.ListViewSubItem sub = lvi.SubItems[1];

			bool enabled = SettingsGrabber.IsRuleEnabled(Page.Analyzer.Id, tag.Rule.RuleName);

			sub.Text = GetOptionsText(enabled, tag.OptionsControl, tag.MergedValue);
			lvi.ImageKey = enabled ? Pictures.RuleEnabled : Pictures.RuleDisabled;

			if (SettingsGrabber.IsRuleBold(Page.Analyzer.Id, tag.Rule.RuleName))
			{
				sub.Font = m_bold;
			}
			else
			{
				sub.Font = tag.Modified ? m_bold : m_regular;
				return;
			}
		}

		/// <summary>
		/// Updates all list items.
		/// </summary>
		private void UpdateAllListItems()
		{
			foreach (ListViewItem lvi in listRules.Items)
			{
				UpdateListItem(lvi);
			}
		}

		/// <summary>
		/// Gets options text for specified custom rule.
		/// </summary>
		private static string GetOptionsText(bool enabled, CustomRuleOptions options, string settingValue)
		{
			if (!enabled)
				return Resources.Disabled;

			if (options == null)
				return Resources.Enabled;

			return options.GetOptionsText(settingValue);
		}

		/// <summary>
		/// Updates controls for all actions.
		/// </summary>
		private void UpdateControls()
		{
			btnReset.Enabled = Action_Reset_IsAvailable();

			UpdateOptions();
			UpdateExample();
		}

		/// <summary>
		/// Updates option panel.
		/// </summary>
		private void UpdateOptions()
		{
			if (listRules.SelectedItems.Count != 1)
			{
				checkEnabled.Enabled = false;
				checkEnabled.Checked = false;
				panelOptions.Controls.Clear();
				return;
			}

			ListViewItem lvi = listRules.SelectedItems[0];
			CustomRuleTag tag = (CustomRuleTag)lvi.Tag;

			bool enabled = SettingsGrabber.IsRuleEnabled(Page.Analyzer.Id, tag.Rule.RuleName);

			checkEnabled.Enabled = true;
			checkEnabled.Checked = enabled;
			panelOptions.Enabled = enabled;

			if (tag.OptionsControl == null)
			{
				panelOptions.Controls.Clear();
				return;
			}

			if (panelOptions.Controls.Count > 0)
			{
				if (panelOptions.Controls[0] == tag.OptionsControl)
				{
					if (tag.OptionsControl.ParseOptions() == tag.MergedValue)
						return;
				}
			}

			panelOptions.Controls.Clear();
			panelOptions.Controls.Add(tag.OptionsControl);
			tag.OptionsControl.DisplayOptions(tag.MergedValue);
		}

		/// <summary>
		/// Updates example panel.
		/// </summary>
		private void UpdateExample()
		{
			if (listRules.SelectedItems.Count != 1)
			{
				displayExample.Clear();
				return;
			}

			ListViewItem lvi = listRules.SelectedItems[0];
			CustomRuleTag tag = (CustomRuleTag)lvi.Tag;

			displayExample.Display(
				tag.Rule.ExampleImage,
				tag.Rule.Description,
				tag.Rule.DetailsUrl);
		}

		#endregion

		#region Actions

		/// <summary>
		/// Does action "Switch Enabled".
		/// </summary>
		private void Action_SwitchEnabled_Do()
		{
			if (!Action_SwitchEnabled_IsAvailable())
				return;

			ListViewItem lvi = listRules.SelectedItems[0];
			CustomRuleTag tag = (CustomRuleTag)lvi.Tag;

			bool enabled = SettingsGrabber.IsRuleEnabled(Page.Analyzer.Id, tag.Rule.RuleName);
			if (enabled)
			{
				SettingsGrabber.DisableRule(Page.Analyzer.Id, tag.Rule.RuleName);
			}
			else
			{
				SettingsGrabber.EnableRule(Page.Analyzer.Id, tag.Rule.RuleName);
			}

			UpdateListItem(lvi);
			Page.Dirty = true;

			UpdateControls();
		}

		/// <summary>
		/// Checks whether action "Switch Enabled" is available.
		/// </summary>
		private bool Action_SwitchEnabled_IsAvailable()
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
			CustomRuleTag tag = (CustomRuleTag)lvi.Tag;

			bool inheritedEnabled = SettingsGrabber.IsRuleEnabled(Page.Analyzer.Id, tag.Rule.RuleName);
			if (SettingsGrabber.IsRuleBold(Page.Analyzer.Id, tag.Rule.RuleName))
			{
				inheritedEnabled = !inheritedEnabled;
			}

			string preview = GetOptionsText(inheritedEnabled, tag.OptionsControl, tag.InheritedValue);
			if (Messages.ShowWarningYesNo(this, Resources.ResetSettingQuestion, preview) != DialogResult.Yes)
				return;

			if (inheritedEnabled)
			{
				SettingsGrabber.EnableRule(Page.Analyzer.Id, tag.Rule.RuleName);
			}
			else
			{
				SettingsGrabber.DisableRule(Page.Analyzer.Id, tag.Rule.RuleName);
			}

			if (tag.SettingName != null)
			{
				tag.MergedValue = tag.InheritedValue;
			}

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
			CustomRuleTag tag = (CustomRuleTag)lvi.Tag;
			if (SettingsGrabber.IsRuleBold(Page.Analyzer.Id, tag.Rule.RuleName))
				return true;

			if (tag.SettingName != null)
			{
				if (tag.Modified)
					return true;
			}

			return false;
		}

		#endregion
	}
}
