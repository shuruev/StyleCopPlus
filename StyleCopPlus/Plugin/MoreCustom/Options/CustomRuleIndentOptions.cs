using System;

namespace StyleCopPlus.Plugin.MoreCustom
{
	/// <summary>
	/// Control displaying indent options.
	/// </summary>
	public partial class CustomRuleIndentOptions : CustomRuleOptions
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public CustomRuleIndentOptions()
		{
			InitializeComponent();
		}

		#region Event handlers

		private void radioMode_CheckedChanged(object sender, EventArgs e)
		{
			OnOptionsDataChanged(e);
		}

		private void checkPadding_CheckedChanged(object sender, EventArgs e)
		{
			OnOptionsDataChanged(e);
		}

		#endregion

		#region Override methods

		/// <summary>
		/// Displays specified options data.
		/// </summary>
		protected override void DisplayOptionsData(ICustomRuleOptionsData data)
		{
			IndentOptionsData options = (IndentOptionsData)data;

			radioTabs.Checked = options.Mode == IndentMode.Tabs;
			radioSpaces.Checked = options.Mode == IndentMode.Spaces;
			radioBoth.Checked = options.Mode == IndentMode.Both;

			checkPadding.Checked = options.AllowPadding;
		}

		/// <summary>
		/// Gets options data from user interface.
		/// </summary>
		protected override void ParseOptionsData(ICustomRuleOptionsData data)
		{
			IndentOptionsData options = (IndentOptionsData)data;

			if (radioTabs.Checked)
			{
				options.Mode = IndentMode.Tabs;
			}
			else if (radioSpaces.Checked)
			{
				options.Mode = IndentMode.Spaces;
			}
			else if (radioBoth.Checked)
			{
				options.Mode = IndentMode.Both;
			}

			options.AllowPadding = checkPadding.Checked;
		}

		#endregion
	}
}
