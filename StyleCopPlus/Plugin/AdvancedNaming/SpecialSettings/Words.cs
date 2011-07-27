using System;

namespace StyleCopPlus.Plugin.AdvancedNaming
{
	/// <summary>
	/// Special setting for complex words.
	/// </summary>
	public class Words : SimpleSpecialSetting
	{
		/// <summary>
		/// Gets help text for current setting.
		/// </summary>
		public override string HelpText
		{
			get { return SpecialSettingResources.WordsHelp; }
		}

		/// <summary>
		/// Gets warning text for invalid definition string.
		/// </summary>
		public override string WarningText
		{
			get { return SpecialSettingResources.WordsWarning; }
		}

		/// <summary>
		/// Checks if specified character is valid.
		/// </summary>
		public override bool IsValidChar(char c)
		{
			if (Char.IsWhiteSpace(c))
				return true;

			if (Char.IsLetterOrDigit(c))
				return true;

			return false;
		}
	}
}
