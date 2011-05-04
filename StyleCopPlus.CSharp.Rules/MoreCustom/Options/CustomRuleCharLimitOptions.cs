using System;

namespace StyleCopPlus
{
	/// <summary>
	/// Control displaying char limit options.
	/// </summary>
	public partial class CustomRuleCharLimitOptions : CustomRuleLimitOptions
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public CustomRuleCharLimitOptions()
			: base(CustomRulesResources.LimitOptionsCharDescription)
		{
			InitializeComponent();
		}

		#region Event handlers

		private void textTabSize_TextChanged(object sender, EventArgs e)
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
			CharLimitOptionsData options = (CharLimitOptionsData)data;

			textLimit.Text = options.Limit.Value.ToString();
			textTabSize.Text = options.TabSize.Value.ToString();
		}

		/// <summary>
		/// Gets options data from user interface.
		/// </summary>
		protected override void ParseOptionsData(ICustomRuleOptionsData data)
		{
			CharLimitOptionsData options = (CharLimitOptionsData)data;

			options.Limit.Parse(textLimit.Text);
			options.TabSize.Parse(textTabSize.Text);
		}

		#endregion
	}
}
