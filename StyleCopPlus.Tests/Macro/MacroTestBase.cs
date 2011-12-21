using System;
using System.Text.RegularExpressions;
using StyleCopPlus.Plugin.AdvancedNaming;

namespace StyleCopPlus.Tests.Macro
{
	/// <summary>
	/// Base class for testing naming macros.
	/// </summary>
	public class MacroTestBase
	{
		/// <summary>
		/// Builds simple regex.
		/// </summary>
		protected static Regex Build(string ruleDefinition)
		{
			return NamingMacro.BuildRegex(ruleDefinition, String.Empty);
		}

		/// <summary>
		/// Builds regex with compound words.
		/// </summary>
		protected static Regex Build(string ruleDefinition, string words)
		{
			return NamingMacro.BuildRegex(ruleDefinition, words);
		}
	}
}