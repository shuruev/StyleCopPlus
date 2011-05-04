using System;
using System.Collections.Generic;
using System.Reflection;
using StyleCop;
using StyleCop.CSharp;
using StyleCopPlus.Properties;

namespace StyleCopPlus
{
	/// <summary>
	/// Rules that are based on the original ones with adding some exception cases.
	/// </summary>
	public class ExtendedOriginalRules
	{
		internal const string AllowConstructorsFor1502 = "SP1502_AllowConstructors";
		internal const string AllowJoinedAccessorsFor1513 = "SP1513_AllowJoinedAccessors";
		internal const string AllowJoinedAccessorsFor1516 = "SP1516_AllowJoinedAccessors";

		private readonly StyleCopPlusRules m_parent;

		private StyleCopCore m_customCore;
		private CustomNamingRules m_customNamingAnalyzer;
		private CustomLayoutRules m_customLayoutAnalyzer;
		private CustomDocumentationRules m_customDocumentationAnalyzer;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public ExtendedOriginalRules(StyleCopPlusRules parent)
		{
			if (parent == null)
				throw new ArgumentNullException("parent");

			m_parent = parent;
		}

		#region Running original analyzers

		/// <summary>
		/// Initializes an add-in.
		/// </summary>
		public void InitializeAddIn()
		{
			m_customCore = new StyleCopCore();
			m_customCore.ViolationEncountered += OnCustomViolationEncountered;

			m_customNamingAnalyzer = new CustomNamingRules();
			m_customLayoutAnalyzer = new CustomLayoutRules();
			m_customDocumentationAnalyzer = new CustomDocumentationRules();

			InitializeCustomAnalyzer(
				m_parent.Core,
				m_customCore,
				Constants.NamingRulesAnalyzerId,
				m_customNamingAnalyzer);

			InitializeCustomAnalyzer(
				m_parent.Core,
				m_customCore,
				Constants.LayoutRulesAnalyzerId,
				m_customLayoutAnalyzer);

			InitializeCustomAnalyzer(
				m_parent.Core,
				m_customCore,
				Constants.DocumentationRulesAnalyzerId,
				m_customDocumentationAnalyzer);
		}

		/// <summary>
		/// Analyzes source document.
		/// </summary>
		public void AnalyzeDocument(CodeDocument document)
		{
			CheckOriginalRule(document, Constants.LayoutRulesAnalyzerId, Rules.ElementMustNotBeOnSingleLine);
			CheckOriginalRule(document, Constants.LayoutRulesAnalyzerId, Rules.ClosingCurlyBracketMustBeFollowedByBlankLine);
			CheckOriginalRule(document, Constants.LayoutRulesAnalyzerId, Rules.ElementsMustBeSeparatedByBlankLine);

			m_customNamingAnalyzer.AnalyzeDocument(document);
			m_customLayoutAnalyzer.AnalyzeDocument(document);
			m_customDocumentationAnalyzer.AnalyzeDocument(document);
		}

		/// <summary>
		/// Handles encountered custom violations.
		/// </summary>
		private void OnCustomViolationEncountered(object sender, ViolationEventArgs e)
		{
			RemoveCustomViolation(e);

			switch (e.Violation.Rule.CheckId)
			{
				case "SA1502":
					Handle1502(e);
					break;

				case "SA1513":
					Handle1513(e);
					break;

				case "SA1516":
					Handle1516(e);
					break;

				case "SA1642":
					Handle1642(e);
					break;

				case "SA1643":
					Handle1643(e);
					break;
			}
		}

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
					new object[]
					{
						originalRule.Name,
						originalRule.Namespace,
						originalRule.CheckId,
						originalRule.Context,
						originalRule.Warning,
						originalRule.Description,
						originalRule.RuleGroup,
						true,
						false
					});
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

		#region Handling original violations

		/// <summary>
		/// Handles SA1502 violation.
		/// </summary>
		private void Handle1502(ViolationEventArgs e)
		{
			CsElement element = (CsElement)e.Element;

			if (ReadSetting(e, AllowConstructorsFor1502))
			{
				if (element.ElementType == ElementType.Constructor)
					return;
			}

			m_parent.AddViolation(
				element,
				e.LineNumber,
				Rules.ElementMustNotBeOnSingleLine,
				element.FriendlyTypeText);
		}

		/// <summary>
		/// Handles SA1513 violation.
		/// </summary>
		private void Handle1513(ViolationEventArgs e)
		{
			CsElement element = (CsElement)e.Element;

			if (ReadSetting(e, AllowJoinedAccessorsFor1513))
			{
				if (element.ElementType == ElementType.Accessor)
					return;
			}

			m_parent.AddViolation(
				element,
				e.LineNumber,
				Rules.ClosingCurlyBracketMustBeFollowedByBlankLine);
		}

		/// <summary>
		/// Handles SA1516 violation.
		/// </summary>
		private void Handle1516(ViolationEventArgs e)
		{
			CsElement element = (CsElement)e.Element;

			if (ReadSetting(e, AllowJoinedAccessorsFor1516))
			{
				if (element.ElementType == ElementType.Accessor)
					return;
			}

			m_parent.AddViolation(
				element,
				Rules.ElementsMustBeSeparatedByBlankLine);
		}

		/// <summary>
		/// Handles SA1642 violation.
		/// </summary>
		private void Handle1642(ViolationEventArgs e)
		{
			CsElement element = (CsElement)e.Element;

			string text = CodeHelper.GetSummaryText(element);
			if (text == Resources.StandardConstructorSummaryText)
				return;

			m_parent.AddViolation(
				element,
				Rules.ConstructorSummaryDocumentationMustBeginWithStandardText,
				new object[] { GetExampleSummaryTextForConstructor(m_customDocumentationAnalyzer, element) });
		}

		/// <summary>
		/// Handles SA1643 violation.
		/// </summary>
		private void Handle1643(ViolationEventArgs e)
		{
			CsElement element = (CsElement)e.Element;

			string text = CodeHelper.GetSummaryText(element);
			if (text == Resources.StandardDestructorSummaryText)
				return;

			m_parent.AddViolation(
				element,
				Rules.DestructorSummaryDocumentationMustBeginWithStandardText,
				new object[] { GetExampleSummaryTextForDestructor(m_customDocumentationAnalyzer) });
		}

		#endregion

		#region Reading custom settings

		/// <summary>
		/// Checks whether original rule is enabled.
		/// </summary>
		private void CheckOriginalRule(CodeDocument document, string analyzerId, Rules rule)
		{
			string ruleName = rule.ToString();

			if (!m_parent.IsRuleEnabled(document, ruleName))
				return;

			SourceAnalyzer analyzer = m_parent.Core.GetAnalyzer(analyzerId);

			if (!analyzer.IsRuleEnabled(document, ruleName))
				return;

			string message = String.Format(
				Resources.ExtendedRuleConflictError,
				m_parent.GetRule(ruleName).CheckId,
				analyzer.GetRule(ruleName).CheckId);

			throw new Exception(message);
		}

		/// <summary>
		/// Reads the value of custom setting.
		/// </summary>
		private bool ReadSetting(ViolationEventArgs e, string settingName)
		{
			return SettingsManager.GetValue<bool>(
				m_parent,
				e.Element.Document.Settings,
				settingName);
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
