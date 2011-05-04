using System;
using System.Drawing;
using System.Windows.Forms;
using StyleCopPlus.Properties;

namespace StyleCopPlus
{
	/// <summary>
	/// Dialog for editing naming rule.
	/// </summary>
	public partial class NamingRuleEditor : Form, IAdvancedNamingEditor
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public NamingRuleEditor()
		{
			InitializeComponent();
		}

		#region Properties

		/// <summary>
		/// Gets or sets object name.
		/// </summary>
		public string ObjectName { get; set; }

		/// <summary>
		/// Gets or sets target rule string.
		/// </summary>
		public string TargetRule { get; set; }

		#endregion

		#region Event handlers

		private void NamingRuleEditor_Load(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(ObjectName))
				throw new InvalidOperationException("ObjectName is not set.");

			Text = String.Format(Resources.NamingRuleEditorCaption, ObjectName);

			if (String.IsNullOrEmpty(TargetRule))
			{
				checkDisable.Checked = true;
			}
			else
			{
				textEditor.RichTextBox.Text = NamingMacro.ConvertRuleToText(TargetRule);
			}

			RebuildMacroList();
			UpdateControls();
		}

		private void textEditor_Highlight(object sender, ControlEventArgs e)
		{
			NamingMacro.HighlightRule((RichTextBox)e.Control);
		}

		private void listMacro_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateControls();
		}

		private void listMacro_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
				return;

			Action_Insert_Do();
		}

		private void checkDisable_CheckedChanged(object sender, EventArgs e)
		{
			UpdateControls();
		}

		private void btnInsert_Click(object sender, EventArgs e)
		{
			Action_Insert_Do();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (!NamingMacro.CheckRule(textEditor.RichTextBox.Text))
			{
				Messages.ShowWarningOk(this, Resources.NamingRuleEditorWarning);
				textEditor.Focus();
				return;
			}

			TargetRule = checkDisable.Checked ?
				String.Empty :
				NamingMacro.ParseRuleFromText(textEditor.RichTextBox.Text);

			DialogResult = DialogResult.OK;
		}

		#endregion

		#region User interface

		/// <summary>
		/// Rebuilds macro list.
		/// </summary>
		private void RebuildMacroList()
		{
			listMacro.BeginUpdate();
			listMacro.Items.Clear();

			foreach (string key in NamingMacro.GetKeys())
			{
				string descripion = NamingMacro.GetDescription(key);

				ListViewItem lvi = new ListViewItem();
				lvi.UseItemStyleForSubItems = false;
				lvi.Text = key;

				ListViewItem.ListViewSubItem sub = new ListViewItem.ListViewSubItem(lvi, descripion);
				sub.ForeColor = SystemColors.GrayText;
				lvi.SubItems.Add(sub);

				listMacro.Items.Add(lvi);
			}

			listMacro.EndUpdate();
		}

		/// <summary>
		/// Updates controls for all actions.
		/// </summary>
		private void UpdateControls()
		{
			bool enabled = checkDisable.Checked;
			if (enabled)
			{
				textEditor.ReadOnly = true;
				btnInsert.Enabled = false;
			}
			else
			{
				textEditor.ReadOnly = false;
				btnInsert.Enabled = Action_Insert_IsAvailable();
			}
		}

		#endregion

		#region Actions

		/// <summary>
		/// Does action "Insert".
		/// </summary>
		private void Action_Insert_Do()
		{
			if (!Action_Insert_IsAvailable())
				return;

			ListViewItem lvi = listMacro.SelectedItems[0];
			string key = lvi.Text;
			string text = NamingMacro.GetMarkup(key);

			textEditor.RichTextBox.SelectedText = text;
		}

		/// <summary>
		/// Checks whether action "Insert" is available.
		/// </summary>
		private bool Action_Insert_IsAvailable()
		{
			if (listMacro.SelectedItems.Count == 1)
				return true;

			return false;
		}

		#endregion
	}
}
