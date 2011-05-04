using System;
using StyleCopPlus.Properties;

namespace StyleCopPlus
{
	/// <summary>
	/// Allows to setup abbreviations setting.
	/// </summary>
	public class AbbreviationsSpecialSetting : SimpleSpecialSetting
	{
		/// <summary>
		/// Gets help text for current setting.
		/// </summary>
		public override string HelpText
		{
			get { return Resources.SpecialSettingEditorHelpAbbreviations; }
		}

		/// <summary>
		/// Gets warning text for invalid definition string.
		/// </summary>
		public override string WarningText
		{
			get { return Resources.SpecialSettingEditorWarningAbbreviations; }
		}

		/// <summary>
		/// Checks if specified character is valid.
		/// </summary>
		public override bool IsValidChar(char c)
		{
			if (Char.IsWhiteSpace(c))
				return true;

			if (Char.IsDigit(c))
				return true;

			if (Char.IsUpper(c))
				return true;

			return false;
		}
	}
}
