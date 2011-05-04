using System.Collections.Generic;
using System.Reflection;
using StyleCop;
using StyleCop.CSharp;

namespace StyleCopPlus
{
	/// <summary>
	/// Contains different methods for compatibility with StyleCop 4.3.
	/// </summary>
	public static class StyleCop43Compatibility
	{
		#region Common methods

		/// <summary>
		/// Checks whether we are working with old StyleCop version.
		/// </summary>
		public static bool IsStyleCop43()
		{
			return false;
		}

		/// <summary>
		/// Modifies source code before running a test.
		/// </summary>
		public static string ModifySourceForTest(string sourceCode)
		{
			return sourceCode;
		}

		#endregion

		#region Working with code elements

		/// <summary>
		/// Gets line number for variable.
		/// </summary>
		public static int? GetVariableLineNumber(Variable variable)
		{
			return variable.Location.LineNumber + variable.Location.LineSpan - 1;
		}

		/// <summary>
		/// Gets first code element at specified line number.
		/// </summary>
		public static ICodeElement GetElementByLine(CsDocument document, int lineNumber)
		{
			return (ICodeElement)CodeHelper.GetElementByLine(document, lineNumber);
		}

		#endregion

		#region Running original analyzers

		/// <summary>
		/// Initializes custom analyzer based on the standard one.
		/// </summary>
		public static void InitializeCustomAnalyzer(
			StyleCopCore originalCore,
			StyleCopCore customCore,
			string originalAnalyzerId,
			SourceAnalyzer customAnalyzer)
		{
			Dictionary<string, SourceAnalyzer> originalAnalyzers = (Dictionary<string, SourceAnalyzer>)typeof(StyleCopCore).InvokeMember(
				"analyzers",
				BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField,
				null,
				originalCore,
				null);

			SourceAnalyzer originalAnalyzer = originalAnalyzers[originalAnalyzerId];

			Dictionary<string, Rule> originalRules = (Dictionary<string, Rule>)typeof(StyleCopAddIn).InvokeMember(
				"rules",
				BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField,
				null,
				originalAnalyzer,
				null);

			typeof(StyleCopAddIn).InvokeMember(
				"core",
				BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetField,
				null,
				customAnalyzer,
				new object[] { customCore });

			Dictionary<string, Rule> customRules = new Dictionary<string, Rule>();
			foreach (KeyValuePair<string, Rule> pair in originalRules)
			{
				Rule originalRule = pair.Value;
				Rule customRule = (Rule)typeof(Rule).InvokeMember(
					"Rule",
					BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.CreateInstance,
					null,
					customCore,
					new object[] { originalRule.Name, originalRule.Namespace, originalRule.CheckId, originalRule.Context, originalRule.Warning, originalRule.Description, originalRule.RuleGroup, true, false });
				customRules[pair.Key] = customRule;
			}

			typeof(StyleCopAddIn).InvokeMember(
				"rules",
				BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetField,
				null,
				customAnalyzer,
				new object[] { customRules });

			CustomCsParser customParser = new CustomCsParser();

			typeof(SourceAnalyzer).InvokeMember(
				"parser",
				BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetField,
				null,
				customAnalyzer,
				new object[] { customParser });
		}

		/// <summary>
		/// Removes violation got from the custom analyzer.
		/// </summary>
		public static void RemoveCustomViolation(ViolationEventArgs e)
		{
			Dictionary<int, Violation> violations = (Dictionary<int, Violation>)typeof(CsElement).InvokeMember(
				"violations",
				BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField,
				null,
				e.Element,
				null);

			violations.Remove(e.Violation.Key);
		}

		#endregion

		#region Calling specific private methods from original analyzers

		/// <summary>
		/// Gets example summary text for constructor.
		/// </summary>
		public static string GetExampleSummaryTextForConstructor(SourceAnalyzer customDocumentationAnalyzer, ICodeUnit constructor)
		{
			string type = (constructor.Parent is Struct) ? "struct" : "class";
			return (string)typeof(DocumentationRules).InvokeMember(
				"GetExampleSummaryTextForConstructorType",
				BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod,
				null,
				customDocumentationAnalyzer,
				new object[] { constructor, type });
		}

		/// <summary>
		/// Gets example summary text for destructor.
		/// </summary>
		public static string GetExampleSummaryTextForDestructor(SourceAnalyzer customDocumentationAnalyzer)
		{
			return (string)typeof(DocumentationRules).InvokeMember(
				"GetExampleSummaryTextForDestructor",
				BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod,
				null,
				customDocumentationAnalyzer,
				null);
		}

		#endregion
	}
}
