namespace StyleCopPlus
{
	/// <summary>
	/// SP2000 custom rule.
	/// </summary>
	public class CustomRuleSP2000 : CustomRule
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		internal CustomRuleSP2000()
			: base(
				Rules.CodeLineMustNotEndWithWhitespace,
				"SP2000",
				null,
				CustomRulesResources.DescriptionSP2000,
				CustomRulesResources.ExampleSP2000)
		{
		}
	}
}
