using System;

namespace StyleCopPlus.Plugin.MoreCustom
{
	/// <summary>
	/// Control displaying last line options.
	/// </summary>
	public partial class CustomRuleLastLineOptions : CustomRuleOptions
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public CustomRuleLastLineOptions()
		{
			InitializeComponent();
		}

		#region Event handlers

		private void radioMode_CheckedChanged(object sender, EventArgs e)
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
			LastLineOptionsData options = (LastLineOptionsData)data;

			radioEmpty.Checked = options.Mode == LastLineMode.Empty;
			radioNotEmpty.Checked = options.Mode == LastLineMode.NotEmpty;
		}

		/// <summary>
		/// Gets options data from user interface.
		/// </summary>
		protected override void ParseOptionsData(ICustomRuleOptionsData data)
		{
			LastLineOptionsData options = (LastLineOptionsData)data;

			if (radioEmpty.Checked)
			{
				options.Mode = LastLineMode.Empty;
				return;
			}

			if (radioNotEmpty.Checked)
			{
				options.Mode = LastLineMode.NotEmpty;
				return;
			}
		}

		#endregion
	}
}
