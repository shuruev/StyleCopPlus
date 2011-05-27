using System.Windows.Forms;

namespace StyleCopPlus
{
	/// <summary>
	/// Interface for special setting that is edited in common dialog.
	/// </summary>
	public interface ISpecialSetting : ITextValidator
	{
		/// <summary>
		/// Gets help text for current setting.
		/// </summary>
		string HelpText { get; }

		/// <summary>
		/// Gets warning text for invalid definition string.
		/// </summary>
		string WarningText { get; }

		/// <summary>
		/// Creates definition string from specified text.
		/// </summary>
		string ParseFrom(string text);

		/// <summary>
		/// Creates text from definition string.
		/// </summary>
		string ConvertTo(string ruleDefinition);

		/// <summary>
		/// Highlights rich text box with definition string.
		/// </summary>
		void Highlight(RichTextBox rich);
	}
}
