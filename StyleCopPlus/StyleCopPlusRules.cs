using System;
using System.Collections.Generic;
using StyleCop;
using StyleCop.CSharp;
using StyleCopPlus.Plugin.AdvancedNaming;
using StyleCopPlus.Plugin.ExtendedOriginal;
using StyleCopPlus.Plugin.MoreCustom;

namespace StyleCopPlus
{
	/// <summary>
	/// StyleCop+ analyzer.
	/// </summary>
	[SourceAnalyzer(typeof(CsParser))]
	public class StyleCopPlusRules : SourceAnalyzer
	{
		private readonly AdvancedNamingRules m_advancedNamingRules;
		private readonly ExtendedOriginalRules m_extendedOriginalRules;
		private readonly MoreCustomRules m_moreCustomRules;

		/// <summary>
		/// Gets or sets special running parameters.
		/// </summary>
		public SpecialRunningParameters SpecialRunningParameters;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public StyleCopPlusRules()
		{
			m_advancedNamingRules = new AdvancedNamingRules(this);
			m_extendedOriginalRules = new ExtendedOriginalRules(this);
			m_moreCustomRules = new MoreCustomRules(this);
		}

		#region Properties

		/// <summary>
		/// Gets a collection of own settings pages.
		/// </summary>
		public override ICollection<IPropertyControlPage> SettingsPages
		{
			get
			{
				return new IPropertyControlPage[] { new PropertyPage(this) };
			}
		}

		#endregion

		#region Analyzer methods

		/// <summary>
		/// Checks whether specified rule is enabled.
		/// </summary>
		public override bool IsRuleEnabled(CodeDocument document, string ruleName)
		{
			if (SpecialRunningParameters != null)
			{
				if (!String.IsNullOrEmpty(SpecialRunningParameters.OnlyEnabledRule))
				{
					return ruleName == SpecialRunningParameters.OnlyEnabledRule;
				}
			}

			return base.IsRuleEnabled(document, ruleName);
		}

		/// <summary>
		/// Initializes an add-in.
		/// </summary>
		public override void InitializeAddIn()
		{
			m_extendedOriginalRules.InitializeAddIn();
		}

		/// <summary>
		/// Analyzes source document.
		/// </summary>
		public override void AnalyzeDocument(CodeDocument document)
		{
			CsDocument doc = (CsDocument)document;
			if (doc.RootElement == null
				|| doc.RootElement.Generated)
				return;

			if (IsRuleEnabled(document, Rules.AdvancedNamingRules.ToString()))
				m_advancedNamingRules.AnalyzeDocument(document);

			m_extendedOriginalRules.AnalyzeDocument(document);
			m_moreCustomRules.AnalyzeDocument(document);
		}

		#endregion
	}
}
