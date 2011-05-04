namespace StyleCopPlus
{
	/// <summary>
	/// SP2103 custom rule.
	/// </summary>
	public class CustomRuleSP2103 : CustomRule
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		internal CustomRuleSP2103()
			: base(
				Rules.FileMustNotContainMoreLinesThan,
				"SP2103",
				"SP2103_Limit",
				CustomRulesResources.DescriptionSP2103,
				CustomRulesResources.ExampleSP2103)
		{
		}

		/// <summary>
		/// Creates control for displaying options.
		/// </summary>
		public override CustomRuleOptions CreateOptionsControl()
		{
			return new CustomRuleLimitOptions(CustomRulesResources.LimitOptionsLineDescription);
		}

		/// <summary>
		/// Creates an empty instance of options data.
		/// </summary>
		public override ICustomRuleOptionsData CreateOptionsData()
		{
			return new LimitOptionsData(
				NumericValue.CreatePropertySize(),
				CustomRulesResources.LimitOptionsLineFormat);
		}
	}
}
