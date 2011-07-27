namespace StyleCopPlus.Plugin.AdvancedNaming
{
	/// <summary>
	/// Interface for checking character validity.
	/// </summary>
	public interface ICharValidator
	{
		/// <summary>
		/// Checks if specified character is valid.
		/// </summary>
		bool IsValidChar(char c);
	}
}
