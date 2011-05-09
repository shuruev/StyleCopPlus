using StyleCop;

namespace StyleCopPlus
{
	/// <summary>
	/// All custom rules settings in current analyzer session.
	/// </summary>
	public class CustomRulesSettings
	{
		/// <summary>
		/// Gets indentation options.
		/// </summary>
		public IndentOptionsData IndentOptions { get; private set; }

		/// <summary>
		/// Gets last line options.
		/// </summary>
		public LastLineOptionsData LastLineOptions { get; private set; }

		/// <summary>
		/// Gets char limit options.
		/// </summary>
		public CharLimitOptionsData CharLimitOptions { get; private set; }

		/// <summary>
		/// Gets method size options.
		/// </summary>
		public LimitOptionsData MethodSizeOptions { get; private set; }

		/// <summary>
		/// Gets property size options.
		/// </summary>
		public LimitOptionsData PropertySizeOptions { get; private set; }

		/// <summary>
		/// Initializes settings from specified document.
		/// </summary>
		public void Initialize(SourceAnalyzer analyzer, CodeDocument document)
		{
			IndentOptions = GetOptionsData<IndentOptionsData>(
				analyzer,
				document,
				Rules.CheckAllowedIndentationCharacters);

			LastLineOptions = GetOptionsData<LastLineOptionsData>(
				analyzer,
				document,
				Rules.CheckWhetherLastCodeLineIsEmpty);

			CharLimitOptions = GetOptionsData<CharLimitOptionsData>(
				analyzer,
				document,
				Rules.CodeLineMustNotBeLongerThan);

			MethodSizeOptions = GetOptionsData<LimitOptionsData>(
				analyzer,
				document,
				Rules.MethodMustNotContainMoreLinesThan);

			PropertySizeOptions = GetOptionsData<LimitOptionsData>(
				analyzer,
				document,
				Rules.PropertyMustNotContainMoreLinesThan);
		}

		/// <summary>
		/// Gets options data for specified rule.
		/// </summary>
		private static T GetOptionsData<T>(SourceAnalyzer analyzer, CodeDocument document, Rules rule) where T : ICustomRuleOptionsData
		{
			CustomRule customRule = CustomRules.Get(rule);
			T data = (T)customRule.CreateOptionsData();

			string settingValue = SettingsManager.GetValue<string>(
				analyzer,
				document.Settings,
				customRule.SettingName);

			data.ConvertFromValue(settingValue);
			return data;
		}
	}
}
