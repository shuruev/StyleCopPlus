using StyleCop;
using StyleCop.CSharp;

namespace StyleCopPlus
{
	/// <summary>
	/// Overriding documentation rules analyzer for running in custom mode.
	/// </summary>
	internal class CustomDocumentationRules : DocumentationRules
	{
		/// <summary>
		/// Checks whether specified rule is enabled.
		/// </summary>
		public override bool IsRuleEnabled(CodeDocument document, string ruleName)
		{
			return true;
		}

		/// <summary>
		/// Checks whether specified rule is suppressed.
		/// </summary>
		public override bool IsRuleSuppressed(ICodeElement element, string ruleCheckId, string ruleName, string ruleNamespace)
		{
			return false;
		}
	}
}
