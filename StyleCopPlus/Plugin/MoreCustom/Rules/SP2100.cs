namespace StyleCopPlus.Plugin.MoreCustom
{
	/// <summary>
	/// SP2100 custom rule.
	/// </summary>
	public class SP2100 : CustomRule
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		internal SP2100()
			: base(
				Rules.CodeLineMustNotBeLongerThan,
				"SP2100",
				"SP2100_Limit",
				CustomRulesResources.DescriptionSP2100,
				CustomRulesResources.ExampleSP2100)
		{
		}

		/// <summary>
		/// Creates control for displaying options.
		/// </summary>
		public override CustomRuleOptions CreateOptionsControl()
		{
			return new CharLimitOptions();
		}

		/// <summary>
		/// Creates an empty instance of options data.
		/// </summary>
		public override ICustomRuleOptionsData CreateOptionsData()
		{
			return new CharLimitOptionsData();
		}
	}
}
