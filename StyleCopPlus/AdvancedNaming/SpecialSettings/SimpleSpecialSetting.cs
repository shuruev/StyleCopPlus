using System.Windows.Forms;

namespace StyleCopPlus
{
	/// <summary>
	/// Allows to setup simple special setting based on whitespace-delimited text.
	/// </summary>
	public abstract class SimpleSpecialSetting : ISpecialSetting, ICharValidator
	{
		/// <summary>
		/// Gets help text for current setting.
		/// </summary>
		public abstract string HelpText { get; }

		/// <summary>
		/// Gets warning text for invalid definition string.
		/// </summary>
		public abstract string WarningText { get; }

		/// <summary>
		/// Creates definition string from specified text.
		/// </summary>
		public string ParseFrom(string text)
		{
			return NamingMacro.ParseWhitespacedSettingFromText(text);
		}

		/// <summary>
		/// Creates text from definition string.
		/// </summary>
		public string ConvertTo(string ruleDefinition)
		{
			return NamingMacro.ConvertWhitespacedSettingToText(ruleDefinition);
		}

		/// <summary>
		/// Checks if specified text is valid.
		/// </summary>
		public bool IsValidText(string text)
		{
			return NamingMacro.CheckSimpleSetting(text, this);
		}

		/// <summary>
		/// Highlights rich text box with definition string.
		/// </summary>
		public void Highlight(RichTextBox rich)
		{
			NamingMacro.HighlightSimpleSetting(rich, this, this);
		}

		/// <summary>
		/// Checks if specified character is valid.
		/// </summary>
		public abstract bool IsValidChar(char c);
	}
}
