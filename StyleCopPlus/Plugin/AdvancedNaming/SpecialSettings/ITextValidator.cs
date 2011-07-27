namespace StyleCopPlus.Plugin.AdvancedNaming
{
	/// <summary>
	/// Interface for checking text validity.
	/// </summary>
	public interface ITextValidator
	{
		/// <summary>
		/// Checks if specified text is valid.
		/// </summary>
		bool IsValidText(string text);
	}
}
