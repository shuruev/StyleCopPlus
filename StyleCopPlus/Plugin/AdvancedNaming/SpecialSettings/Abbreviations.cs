using System;

namespace StyleCopPlus.Plugin.AdvancedNaming
{
	/// <summary>
	/// Special setting for abbreviations.
	/// </summary>
	public class Abbreviations : SimpleSpecialSetting
	{
		/// <summary>
		/// Gets help text for current setting.
		/// </summary>
		public override string HelpText
		{
			get { return SpecialSettingResources.AbbreviationsHelp; }
		}

		/// <summary>
		/// Gets warning text for invalid definition string.
		/// </summary>
		public override string WarningText
		{
			get { return SpecialSettingResources.AbbreviationsWarning; }
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
