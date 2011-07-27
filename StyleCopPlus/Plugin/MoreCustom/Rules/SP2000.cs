namespace StyleCopPlus.Plugin.MoreCustom
{
	/// <summary>
	/// SP2000 custom rule.
	/// </summary>
	public class SP2000 : CustomRule
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		internal SP2000()
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
