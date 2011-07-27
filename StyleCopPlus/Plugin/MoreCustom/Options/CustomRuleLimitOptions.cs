using System;

namespace StyleCopPlus.Plugin.MoreCustom
{
	/// <summary>
	/// Control displaying limit options.
	/// </summary>
	public partial class CustomRuleLimitOptions : CustomRuleOptions
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public CustomRuleLimitOptions()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public CustomRuleLimitOptions(string description)
			: this()
		{
			labelDescription.Text = description;
		}

		#region Event handlers

		private void textLimit_TextChanged(object sender, EventArgs e)
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
			LimitOptionsData options = (LimitOptionsData)data;
			textLimit.Text = options.Limit.Value.ToString();
		}

		/// <summary>
		/// Gets options data from user interface.
		/// </summary>
		protected override void ParseOptionsData(ICustomRuleOptionsData data)
		{
			LimitOptionsData options = (LimitOptionsData)data;
			options.Limit.Parse(textLimit.Text);
		}

		#endregion
	}
}
