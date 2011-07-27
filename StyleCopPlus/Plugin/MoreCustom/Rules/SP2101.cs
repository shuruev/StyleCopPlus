namespace StyleCopPlus.Plugin.MoreCustom
{
	/// <summary>
	/// SP2101 custom rule.
	/// </summary>
	public class SP2101 : CustomRule
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		internal SP2101()
			: base(
				Rules.MethodMustNotContainMoreLinesThan,
				"SP2101",
				"SP2101_Limit",
				CustomRulesResources.DescriptionSP2101,
				CustomRulesResources.ExampleSP2101)
		{
		}

		/// <summary>
		/// Creates control for displaying options.
		/// </summary>
		public override CustomRuleOptions CreateOptionsControl()
		{
			return new LimitOptions(OptionsDataResources.LimitOptionsLineDescription);
		}

		/// <summary>
		/// Creates an empty instance of options data.
		/// </summary>
		public override ICustomRuleOptionsData CreateOptionsData()
		{
			return new LimitOptionsData(
				NumericValue.CreateMethodSize(),
				OptionsDataResources.LimitOptionsLineFormat);
		}
	}
}
