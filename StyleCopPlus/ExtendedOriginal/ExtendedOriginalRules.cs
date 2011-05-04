using System;
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
		internal const string AllowNestedCodeBlocksFor1509 = "SP1509_AllowNestedCodeBlocks";
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

			StyleCop43Compatibility.InitializeCustomAnalyzer(
				m_parent.Core,
				m_customCore,
				Constants.NamingRulesAnalyzerId,
				m_customNamingAnalyzer);

			StyleCop43Compatibility.InitializeCustomAnalyzer(
				m_parent.Core,
				m_customCore,
				Constants.LayoutRulesAnalyzerId,
				m_customLayoutAnalyzer);

			StyleCop43Compatibility.InitializeCustomAnalyzer(
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
			CheckOriginalRule(document, Constants.LayoutRulesAnalyzerId, Rules.OpeningCurlyBracketsMustNotBePrecededByBlankLine);
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
			StyleCop43Compatibility.RemoveCustomViolation(e);

			switch (e.Violation.Rule.CheckId)
			{
				case "SA1502":
					Handle1502(e);
					break;

				case "SA1509":
					Handle1509(e);
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
				Rules.OpeningCurlyBracketsMustNotBePrecededByBlankLine,
				element.FriendlyTypeText);
		}

		/// <summary>
		/// Handles SA1509 violation.
		/// </summary>
		private void Handle1509(ViolationEventArgs e)
		{
			CsElement element = (CsElement)e.Element;

			if (ReadSetting(e, AllowNestedCodeBlocksFor1509))
			{
				Node<CsToken> node = CodeHelper.GetNodeByLine((CsDocument)element.Document, e.LineNumber);
				if (node != null)
				{
					Node<CsToken> prev = CodeHelper.FindPreviousValueableNode(node);
					if (prev.Value.CsTokenType == CsTokenType.Semicolon
						|| prev.Value.CsTokenType == CsTokenType.CloseCurlyBracket)
						return;
				}
			}

			m_parent.AddViolation(
				element,
				e.LineNumber,
				Rules.OpeningCurlyBracketsMustNotBePrecededByBlankLine,
				new object[0]);
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

				if (StyleCop43Compatibility.IsStyleCop43())
				{
					Node<CsToken> node = CodeHelper.GetNodeByLine((CsDocument)element.Document, e.LineNumber);
					if (node != null)
					{
						Node<CsToken> next1 = CodeHelper.FindNextValueableNode(node);
						if (next1.Value.CsTokenType == CsTokenType.CloseCurlyBracket)
						{
							Node<CsToken> next2 = CodeHelper.FindNextValueableNode(next1);
							if (next2.Value.CsTokenType == CsTokenType.Get
								|| next2.Value.CsTokenType == CsTokenType.Set)
								return;
						}
					}
				}
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

				if (StyleCop43Compatibility.IsStyleCop43())
				{
					Node<CsToken> node = CodeHelper.GetNodeByLine((CsDocument)element.Document, e.LineNumber);
					if (node != null)
					{
						Node<CsToken> next1 = CodeHelper.FindNextValueableNode(node);
						if (next1.Value.CsTokenType == CsTokenType.CloseCurlyBracket)
						{
							Node<CsToken> next2 = CodeHelper.FindNextValueableNode(next1);
							if (next2.Value.CsTokenType == CsTokenType.Get
								|| next2.Value.CsTokenType == CsTokenType.Set)
								return;
						}
					}
				}
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
				new object[] { StyleCop43Compatibility.GetExampleSummaryTextForConstructor(m_customDocumentationAnalyzer, element) });
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
				new object[] { StyleCop43Compatibility.GetExampleSummaryTextForDestructor(m_customDocumentationAnalyzer) });
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

			if (StyleCop43Compatibility.IsStyleCop43())
			{
				string settingName = String.Format("{0}#Enabled", rule);
				BooleanProperty enabled = (BooleanProperty)analyzer.GetSetting(document.Settings, settingName);
				if (!enabled.Value)
					return;
			}
			else
			{
				if (!analyzer.IsRuleEnabled(document, ruleName))
					return;
			}

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
	}
}
