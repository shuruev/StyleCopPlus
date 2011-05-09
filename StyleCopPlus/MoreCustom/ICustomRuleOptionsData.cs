namespace StyleCopPlus
{
	/// <summary>
	/// Interface for holding custom rule options data.
	/// </summary>
	public interface ICustomRuleOptionsData
	{
		/// <summary>
		/// Initializes object data from setting value.
		/// </summary>
		void ConvertFromValue(string settingValue);

		/// <summary>
		/// Converts object data to setting value.
		/// </summary>
		string ConvertToValue();

		/// <summary>
		/// Gets a friendly description for options data.
		/// </summary>
		string GetDescription();
	}
}
