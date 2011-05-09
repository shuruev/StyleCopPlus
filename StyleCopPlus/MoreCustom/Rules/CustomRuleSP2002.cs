namespace StyleCopPlus
{
	/// <summary>
	/// SP2002 custom rule.
	/// </summary>
	public class CustomRuleSP2002 : CustomRule
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		internal CustomRuleSP2002()
			: base(
				Rules.CheckWhetherLastCodeLineIsEmpty,
				"SP2002",
				"SP2002_Mode",
				CustomRulesResources.DescriptionSP2002,
				CustomRulesResources.ExampleSP2002)
		{
		}

		/// <summary>
		/// Creates control for displaying options.
		/// </summary>
		public override CustomRuleOptions CreateOptionsControl()
		{
			return new CustomRuleLastLineOptions();
		}

		/// <summary>
		/// Creates an empty instance of options data.
		/// </summary>
		public override ICustomRuleOptionsData CreateOptionsData()
		{
			return new LastLineOptionsData();
		}
	}
}
