using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StyleCopPlus.Plugin.AdvancedNaming;

namespace StyleCopPlus.Tests.SimpleTests
{
	/// <summary>
	/// Testing naming macros work.
	/// </summary>
	[TestClass]
	public class NamingMacroTest
	{
		#region Service methods

		/// <summary>
		/// Builds simple regex.
		/// </summary>
		private static Regex BuildSimple(string ruleDefinition)
		{
			return NamingMacro.BuildRegex(ruleDefinition, String.Empty, String.Empty);
		}

		/// <summary>
		/// Builds regex with abbreviations.
		/// </summary>
		private static Regex BuildWithAbbreviations(string ruleDefinition, string abbreviations)
		{
			return NamingMacro.BuildRegex(ruleDefinition, abbreviations, String.Empty);
		}

		/// <summary>
		/// Builds regex with words.
		/// </summary>
		private static Regex BuildWithWords(string ruleDefinition, string words)
		{
			return NamingMacro.BuildRegex(ruleDefinition, String.Empty, words);
		}

		#endregion

		#region General tests

		[TestMethod]
		public void Apply_Rules_Without_Macros()
		{
			Regex regex;

			regex = BuildSimple("Oleg:Shuruev");
			Assert.IsTrue(regex.IsMatch("Oleg"));
			Assert.IsTrue(regex.IsMatch("Shuruev"));
			Assert.IsFalse(regex.IsMatch("oleg"));
			Assert.IsFalse(regex.IsMatch("shuruev"));
			Assert.IsFalse(regex.IsMatch("olegus"));
			Assert.IsFalse(regex.IsMatch("nonshuruev"));
		}

		[TestMethod]
		public void Apply_Rules_With_Pascal_Macro()
		{
			Regex regex;

			regex = BuildSimple("Pre$(AaBb)_POST");
			Assert.IsFalse(regex.IsMatch("Style"));
			Assert.IsFalse(regex.IsMatch("StyleCop"));
			Assert.IsTrue(regex.IsMatch("PreStyle_POST"));
			Assert.IsTrue(regex.IsMatch("PreStyleCop_POST"));
			Assert.IsFalse(regex.IsMatch("PrestyleCop_POST"));
			Assert.IsFalse(regex.IsMatch("PreStyleCop+_POST"));

			regex = BuildSimple("T:T$(AaBb)");
			Assert.IsTrue(regex.IsMatch("T"));
			Assert.IsTrue(regex.IsMatch("TInput"));
		}

		[TestMethod]
		public void Apply_Rules_With_Any_Macro()
		{
			Regex regex;

			regex = BuildSimple("Pre$(*)_POST");
			Assert.IsFalse(regex.IsMatch("Style"));
			Assert.IsFalse(regex.IsMatch("StyleCop"));
			Assert.IsTrue(regex.IsMatch("PreStyle_POST"));
			Assert.IsFalse(regex.IsMatch("PREStyleCOP+_POST"));
			Assert.IsFalse(regex.IsMatch("PreStyleCOP+POST"));
			Assert.IsFalse(regex.IsMatch("PreStyleCOP+_Post"));
			Assert.IsTrue(regex.IsMatch("PreStyleCOP+_POST"));
		}

		#endregion

		#region Macro "Pascal"

		[TestMethod]
		public void Macro_Pascal_General()
		{
			Regex regex;

			regex = BuildSimple("$(AaBb)");
			Assert.IsTrue(regex.IsMatch("Style"));
			Assert.IsTrue(regex.IsMatch("StyleCop"));
			Assert.IsFalse(regex.IsMatch("styleCop"));
			Assert.IsFalse(regex.IsMatch("StyleCop+"));
			Assert.IsFalse(regex.IsMatch("Style_Cop"));
			Assert.IsFalse(regex.IsMatch("StyleC"));
			Assert.IsFalse(regex.IsMatch("CSharpStyle"));
		}

		[TestMethod]
		public void Macro_Pascal_Abbreviations()
		{
			Regex regex;

			regex = BuildWithAbbreviations("$(AaBb)", "C");
			Assert.IsTrue(regex.IsMatch("Style"));
			Assert.IsTrue(regex.IsMatch("StyleCop"));
			Assert.IsFalse(regex.IsMatch("styleCop"));
			Assert.IsFalse(regex.IsMatch("StyleCop+"));
			Assert.IsFalse(regex.IsMatch("Style_Cop"));
			Assert.IsTrue(regex.IsMatch("StyleC"));
			Assert.IsTrue(regex.IsMatch("CSharpStyle"));

			regex = BuildWithAbbreviations("$(AaBb)", "C X");
			Assert.IsTrue(regex.IsMatch("Style"));
			Assert.IsTrue(regex.IsMatch("StyleCop"));
			Assert.IsTrue(regex.IsMatch("StyleCX"));
			Assert.IsTrue(regex.IsMatch("CXSharpStyle"));

			regex = BuildWithAbbreviations("$(AaBb)", String.Empty);
			Assert.IsFalse(regex.IsMatch("Point3D"));

			regex = BuildWithAbbreviations("$(AaBb)", "3D");
			Assert.IsTrue(regex.IsMatch("Point3D"));
		}

		[TestMethod]
		public void Macro_Pascal_Single_Letter()
		{
			Regex regex;

			regex = BuildWithAbbreviations("$(AaBb)", String.Empty);
			Assert.IsFalse(regex.IsMatch("a"));
			Assert.IsTrue(regex.IsMatch("A"));

			regex = BuildWithAbbreviations("$(AaBb)", "A");
			Assert.IsFalse(regex.IsMatch("a"));
			Assert.IsTrue(regex.IsMatch("A"));

			regex = BuildWithAbbreviations("Pre$(AaBb)_POST", String.Empty);
			Assert.IsFalse(regex.IsMatch("Prea_POST"));
			Assert.IsTrue(regex.IsMatch("PreA_POST"));

			regex = BuildWithAbbreviations("Pre$(AaBb)_POST", "A");
			Assert.IsFalse(regex.IsMatch("Prea_POST"));
			Assert.IsTrue(regex.IsMatch("PreA_POST"));
		}

		[TestMethod]
		public void Macro_Pascal_Unicode()
		{
			Regex regex;

			regex = BuildSimple("$(AaBb)");
			Assert.IsTrue(regex.IsMatch("СтайлКоп"));
			Assert.IsFalse(regex.IsMatch("стайлКоп"));
		}

		[TestMethod]
		public void Macro_Pascal_Digits()
		{
			Regex regex;

			regex = BuildSimple("$(AaBb)");
			Assert.IsTrue(regex.IsMatch("1"));
			Assert.IsTrue(regex.IsMatch("123"));
			Assert.IsTrue(regex.IsMatch("123456"));
			Assert.IsTrue(regex.IsMatch("1StyleCop"));
			Assert.IsTrue(regex.IsMatch("Style1Cop"));
			Assert.IsTrue(regex.IsMatch("StyleCop1"));
			Assert.IsTrue(regex.IsMatch("123StyleCop"));
			Assert.IsTrue(regex.IsMatch("Style123Cop"));
			Assert.IsTrue(regex.IsMatch("StyleCop123"));
		}

		#endregion

		#region Macro "Camel"

		[TestMethod]
		public void Macro_Camel_General()
		{
			Regex regex;

			regex = BuildSimple("$(aaBb)");
			Assert.IsTrue(regex.IsMatch("style"));
			Assert.IsTrue(regex.IsMatch("styleCop"));
			Assert.IsTrue(regex.IsMatch("styleCopPlus"));
			Assert.IsFalse(regex.IsMatch("StyleCop"));
			Assert.IsFalse(regex.IsMatch("styleCop+"));
			Assert.IsFalse(regex.IsMatch("style_Cop"));
			Assert.IsFalse(regex.IsMatch("styleC"));
			Assert.IsFalse(regex.IsMatch("styleCSharp"));
		}

		[TestMethod]
		public void Macro_Camel_Abbreviations()
		{
			Regex regex;

			regex = BuildWithAbbreviations("$(aaBb)", "C");
			Assert.IsTrue(regex.IsMatch("style"));
			Assert.IsTrue(regex.IsMatch("styleCop"));
			Assert.IsTrue(regex.IsMatch("styleCopPlus"));
			Assert.IsFalse(regex.IsMatch("StyleCop"));
			Assert.IsFalse(regex.IsMatch("styleCop+"));
			Assert.IsFalse(regex.IsMatch("style_Cop"));
			Assert.IsTrue(regex.IsMatch("styleC"));
			Assert.IsTrue(regex.IsMatch("styleCSharp"));

			regex = BuildWithAbbreviations("$(aaBb)", "C X");
			Assert.IsTrue(regex.IsMatch("style"));
			Assert.IsTrue(regex.IsMatch("styleCop"));
			Assert.IsTrue(regex.IsMatch("styleCX"));
			Assert.IsTrue(regex.IsMatch("styleCXSharp"));

			regex = BuildWithAbbreviations("$(aaBb)", String.Empty);
			Assert.IsFalse(regex.IsMatch("point3D"));

			regex = BuildWithAbbreviations("$(aaBb)", "3D");
			Assert.IsTrue(regex.IsMatch("point3D"));
		}

		[TestMethod]
		public void Macro_Camel_Single_Letter()
		{
			Regex regex;

			regex = BuildWithAbbreviations("$(aaBb)", String.Empty);
			Assert.IsTrue(regex.IsMatch("a"));
			Assert.IsFalse(regex.IsMatch("A"));

			regex = BuildWithAbbreviations("$(aaBb)", "A");
			Assert.IsTrue(regex.IsMatch("a"));
			Assert.IsFalse(regex.IsMatch("A"));

			regex = BuildWithAbbreviations("Pre$(aaBb)_POST", String.Empty);
			Assert.IsTrue(regex.IsMatch("Prea_POST"));
			Assert.IsFalse(regex.IsMatch("PreA_POST"));

			regex = BuildWithAbbreviations("Pre$(aaBb)_POST", "A");
			Assert.IsTrue(regex.IsMatch("Prea_POST"));
			Assert.IsFalse(regex.IsMatch("PreA_POST"));
		}

		[TestMethod]
		public void Macro_Camel_Unicode()
		{
			Regex regex;

			regex = BuildSimple("$(aaBb)");
			Assert.IsTrue(regex.IsMatch("стайлКоп"));
			Assert.IsFalse(regex.IsMatch("СтайлКоп"));
		}

		[TestMethod]
		public void Macro_Camel_Digits()
		{
			Regex regex;

			regex = BuildSimple("$(aaBb)");
			Assert.IsTrue(regex.IsMatch("1"));
			Assert.IsTrue(regex.IsMatch("123"));
			Assert.IsTrue(regex.IsMatch("123456"));
			Assert.IsTrue(regex.IsMatch("1StyleCop"));
			Assert.IsTrue(regex.IsMatch("style1Cop"));
			Assert.IsTrue(regex.IsMatch("styleCop1"));
			Assert.IsTrue(regex.IsMatch("123StyleCop"));
			Assert.IsTrue(regex.IsMatch("style123Cop"));
			Assert.IsTrue(regex.IsMatch("styleCop123"));
		}

		#endregion

		#region Macro "Upper Words"

		[TestMethod]
		public void Macro_Upper_Words_General()
		{
			Regex regex;

			regex = BuildSimple("$(AA_BB)");
			Assert.IsTrue(regex.IsMatch("STYLE"));
			Assert.IsTrue(regex.IsMatch("STYLE_COP"));
			Assert.IsFalse(regex.IsMatch("sTYLE_COP"));
			Assert.IsFalse(regex.IsMatch("STYLE_COP+"));
			Assert.IsFalse(regex.IsMatch("STYLE__COP"));
			Assert.IsFalse(regex.IsMatch("_STYLE"));
			Assert.IsFalse(regex.IsMatch("STYLE_"));
			Assert.IsTrue(regex.IsMatch("STYLE_C"));
			Assert.IsTrue(regex.IsMatch("C_SHARP_STYLE"));
		}

		[TestMethod]
		public void Macro_Upper_Words_Abbreviations()
		{
			Regex regex;

			regex = BuildWithAbbreviations("$(AA_BB)", "A B");
			Assert.IsTrue(regex.IsMatch("STYLE"));
			Assert.IsTrue(regex.IsMatch("STYLE_COP"));
		}

		[TestMethod]
		public void Macro_Upper_Words_Single_Letter()
		{
			Regex regex;

			regex = BuildWithAbbreviations("$(AA_BB)", String.Empty);
			Assert.IsFalse(regex.IsMatch("a"));
			Assert.IsTrue(regex.IsMatch("A"));

			regex = BuildWithAbbreviations("$(AA_BB)", "A");
			Assert.IsFalse(regex.IsMatch("a"));
			Assert.IsTrue(regex.IsMatch("A"));

			regex = BuildWithAbbreviations("Pre$(AA_BB)_POST", String.Empty);
			Assert.IsFalse(regex.IsMatch("Prea_POST"));
			Assert.IsTrue(regex.IsMatch("PreA_POST"));

			regex = BuildWithAbbreviations("Pre$(AA_BB)_POST", "A");
			Assert.IsFalse(regex.IsMatch("Prea_POST"));
			Assert.IsTrue(regex.IsMatch("PreA_POST"));
		}

		[TestMethod]
		public void Macro_Upper_Words_Unicode()
		{
			Regex regex;

			regex = BuildSimple("$(AA_BB)");
			Assert.IsTrue(regex.IsMatch("СТАЙЛ_КОП"));
			Assert.IsFalse(regex.IsMatch("стайл_коп"));
		}

		[TestMethod]
		public void Macro_Upper_Words_Digits()
		{
			Regex regex;

			regex = BuildSimple("$(AA_BB)");
			Assert.IsTrue(regex.IsMatch("1"));
			Assert.IsTrue(regex.IsMatch("123"));
			Assert.IsTrue(regex.IsMatch("123_456"));
			Assert.IsTrue(regex.IsMatch("1_STYLE_COP"));
			Assert.IsTrue(regex.IsMatch("STYLE_1_COP"));
			Assert.IsTrue(regex.IsMatch("STYLE_COP_1"));
			Assert.IsTrue(regex.IsMatch("123_STYLE_COP"));
			Assert.IsTrue(regex.IsMatch("STYLE_123_COP"));
			Assert.IsTrue(regex.IsMatch("STYLE_COP_123"));
		}

		#endregion

		#region Macro "Lower Words"

		[TestMethod]
		public void Macro_Lower_Words_General()
		{
			Regex regex;

			regex = BuildSimple("$(aa_bb)");
			Assert.IsTrue(regex.IsMatch("style"));
			Assert.IsTrue(regex.IsMatch("style_cop"));
			Assert.IsFalse(regex.IsMatch("Style_cop"));
			Assert.IsFalse(regex.IsMatch("style_cop+"));
			Assert.IsFalse(regex.IsMatch("style__cop"));
			Assert.IsFalse(regex.IsMatch("_style"));
			Assert.IsFalse(regex.IsMatch("style_"));
			Assert.IsTrue(regex.IsMatch("style_c"));
			Assert.IsTrue(regex.IsMatch("c_sharp_style"));
		}

		[TestMethod]
		public void Macro_Lower_Words_Abbreviations()
		{
			Regex regex;

			regex = BuildWithAbbreviations("$(aa_bb)", "A B");
			Assert.IsTrue(regex.IsMatch("style"));
			Assert.IsTrue(regex.IsMatch("style_cop"));
		}

		[TestMethod]
		public void Macro_Lower_Words_Single_Letter()
		{
			Regex regex;

			regex = BuildWithAbbreviations("$(aa_bb)", String.Empty);
			Assert.IsTrue(regex.IsMatch("a"));
			Assert.IsFalse(regex.IsMatch("A"));

			regex = BuildWithAbbreviations("$(aa_bb)", "A");
			Assert.IsTrue(regex.IsMatch("a"));
			Assert.IsFalse(regex.IsMatch("A"));

			regex = BuildWithAbbreviations("Pre$(aa_bb)_POST", String.Empty);
			Assert.IsTrue(regex.IsMatch("Prea_POST"));
			Assert.IsFalse(regex.IsMatch("PreA_POST"));

			regex = BuildWithAbbreviations("Pre$(aa_bb)_POST", "A");
			Assert.IsTrue(regex.IsMatch("Prea_POST"));
			Assert.IsFalse(regex.IsMatch("PreA_POST"));
		}

		[TestMethod]
		public void Macro_Lower_Words_Unicode()
		{
			Regex regex;

			regex = BuildSimple("$(aa_bb)");
			Assert.IsTrue(regex.IsMatch("стайл_коп"));
			Assert.IsFalse(regex.IsMatch("СТАЙЛ_КОП"));
		}

		[TestMethod]
		public void Macro_Lower_Words_Digits()
		{
			Regex regex;

			regex = BuildSimple("$(aa_bb)");
			Assert.IsTrue(regex.IsMatch("1"));
			Assert.IsTrue(regex.IsMatch("123"));
			Assert.IsTrue(regex.IsMatch("123_456"));
			Assert.IsTrue(regex.IsMatch("1_style_cop"));
			Assert.IsTrue(regex.IsMatch("style_1_cop"));
			Assert.IsTrue(regex.IsMatch("style_cop_1"));
			Assert.IsTrue(regex.IsMatch("123_style_cop"));
			Assert.IsTrue(regex.IsMatch("style_123_cop"));
			Assert.IsTrue(regex.IsMatch("style_cop_123"));
		}

		#endregion

		#region Macro "Capitalized"

		[TestMethod]
		public void Macro_Capitalized_General()
		{
			Regex regex;

			regex = BuildSimple("$(Aa_Bb)");
			Assert.IsTrue(regex.IsMatch("Style"));
			Assert.IsTrue(regex.IsMatch("Style_Cop"));
			Assert.IsFalse(regex.IsMatch("style_Cop"));
			Assert.IsFalse(regex.IsMatch("styleCop"));
			Assert.IsFalse(regex.IsMatch("StyleCop"));
			Assert.IsFalse(regex.IsMatch("Style_Cop+"));
			Assert.IsFalse(regex.IsMatch("Style__Cop"));
			Assert.IsFalse(regex.IsMatch("_Style"));
			Assert.IsFalse(regex.IsMatch("Style_"));
			Assert.IsFalse(regex.IsMatch("StyleC"));
			Assert.IsFalse(regex.IsMatch("Style_C"));
			Assert.IsFalse(regex.IsMatch("CSharpStyle"));
			Assert.IsFalse(regex.IsMatch("CSharp_Style"));
			Assert.IsFalse(regex.IsMatch("C_Sharp_Style"));
		}

		[TestMethod]
		public void Macro_Capitalized_Abbreviations()
		{
			Regex regex;

			regex = BuildWithAbbreviations("$(Aa_Bb)", "C");
			Assert.IsTrue(regex.IsMatch("Style"));
			Assert.IsTrue(regex.IsMatch("Style_Cop"));
			Assert.IsFalse(regex.IsMatch("style_Cop"));
			Assert.IsFalse(regex.IsMatch("styleCop"));
			Assert.IsFalse(regex.IsMatch("StyleCop"));
			Assert.IsFalse(regex.IsMatch("Style_Cop+"));
			Assert.IsFalse(regex.IsMatch("Style__Cop"));
			Assert.IsFalse(regex.IsMatch("StyleC"));
			Assert.IsTrue(regex.IsMatch("Style_C"));
			Assert.IsFalse(regex.IsMatch("CSharpStyle"));
			Assert.IsFalse(regex.IsMatch("CSharp_Style"));
			Assert.IsTrue(regex.IsMatch("C_Sharp_Style"));

			regex = BuildWithAbbreviations("$(Aa_Bb)", "C X");
			Assert.IsTrue(regex.IsMatch("Style"));
			Assert.IsTrue(regex.IsMatch("Style_Cop"));
			Assert.IsFalse(regex.IsMatch("StyleCX"));
			Assert.IsFalse(regex.IsMatch("Style_CX"));
			Assert.IsTrue(regex.IsMatch("Style_C_X"));
			Assert.IsFalse(regex.IsMatch("StyleC_X"));
			Assert.IsFalse(regex.IsMatch("CXSharpStyle"));
			Assert.IsFalse(regex.IsMatch("C_XSharpStyle"));
			Assert.IsFalse(regex.IsMatch("C_X_SharpStyle"));
			Assert.IsTrue(regex.IsMatch("C_X_Sharp_Style"));
			Assert.IsFalse(regex.IsMatch("CX_Sharp_Style"));
			Assert.IsFalse(regex.IsMatch("CXSharp_Style"));

			regex = BuildWithAbbreviations("$(Aa_Bb)", "CX");
			Assert.IsTrue(regex.IsMatch("Style"));
			Assert.IsTrue(regex.IsMatch("Style_Cop"));
			Assert.IsFalse(regex.IsMatch("StyleCX"));
			Assert.IsTrue(regex.IsMatch("Style_CX"));
			Assert.IsFalse(regex.IsMatch("Style_C_X"));
			Assert.IsFalse(regex.IsMatch("StyleC_X"));
			Assert.IsFalse(regex.IsMatch("CXSharpStyle"));
			Assert.IsFalse(regex.IsMatch("C_XSharpStyle"));
			Assert.IsFalse(regex.IsMatch("C_X_SharpStyle"));
			Assert.IsFalse(regex.IsMatch("C_X_Sharp_Style"));
			Assert.IsTrue(regex.IsMatch("CX_Sharp_Style"));
			Assert.IsFalse(regex.IsMatch("CXSharp_Style"));

			regex = BuildWithAbbreviations("$(Aa_Bb)", String.Empty);
			Assert.IsFalse(regex.IsMatch("Point_3D"));

			regex = BuildWithAbbreviations("$(Aa_Bb)", "3D");
			Assert.IsTrue(regex.IsMatch("Point_3D"));
		}

		[TestMethod]
		public void Macro_Capitalized_Single_Letter()
		{
			Regex regex;

			regex = BuildWithAbbreviations("$(Aa_Bb)", String.Empty);
			Assert.IsFalse(regex.IsMatch("a"));
			Assert.IsTrue(regex.IsMatch("A"));

			regex = BuildWithAbbreviations("$(Aa_Bb)", "A");
			Assert.IsFalse(regex.IsMatch("a"));
			Assert.IsTrue(regex.IsMatch("A"));

			regex = BuildWithAbbreviations("Pre$(Aa_Bb)_POST", String.Empty);
			Assert.IsFalse(regex.IsMatch("Prea_POST"));
			Assert.IsTrue(regex.IsMatch("PreA_POST"));

			regex = BuildWithAbbreviations("Pre$(Aa_Bb)_POST", "A");
			Assert.IsFalse(regex.IsMatch("Prea_POST"));
			Assert.IsTrue(regex.IsMatch("PreA_POST"));
		}

		[TestMethod]
		public void Macro_Capitalized_Words()
		{
			Regex regex;

			regex = BuildWithWords("$(Aa_Bb)", String.Empty);
			Assert.IsFalse(regex.IsMatch("StyleCop"));
			Assert.IsFalse(regex.IsMatch("Test_StyleCop_Features"));
			Assert.IsTrue(regex.IsMatch("Test_Style_Cop_Features"));
			Assert.IsFalse(regex.IsMatch("FxCop"));
			Assert.IsFalse(regex.IsMatch("Test_FxCop_Features"));
			Assert.IsTrue(regex.IsMatch("Test_Fx_Cop_Features"));

			regex = BuildWithWords("$(Aa_Bb)", "StyleCop");
			Assert.IsTrue(regex.IsMatch("StyleCop"));
			Assert.IsTrue(regex.IsMatch("Test_StyleCop_Features"));
			Assert.IsTrue(regex.IsMatch("Test_Style_Cop_Features"));
			Assert.IsFalse(regex.IsMatch("FxCop"));
			Assert.IsFalse(regex.IsMatch("Test_FxCop_Features"));
			Assert.IsTrue(regex.IsMatch("Test_Fx_Cop_Features"));

			regex = BuildWithWords("$(Aa_Bb)", "StyleCop FxCop");
			Assert.IsTrue(regex.IsMatch("StyleCop"));
			Assert.IsTrue(regex.IsMatch("Test_StyleCop_Features"));
			Assert.IsTrue(regex.IsMatch("Test_Style_Cop_Features"));
			Assert.IsTrue(regex.IsMatch("FxCop"));
			Assert.IsTrue(regex.IsMatch("Test_FxCop_Features"));
			Assert.IsTrue(regex.IsMatch("Test_Fx_Cop_Features"));
		}

		[TestMethod]
		public void Macro_Capitalized_Unicode()
		{
			Regex regex;

			regex = BuildSimple("$(Aa_Bb)");
			Assert.IsTrue(regex.IsMatch("Стайл_Коп"));
			Assert.IsFalse(regex.IsMatch("стайл_Коп"));
		}

		[TestMethod]
		public void Macro_Capitalized_Digits()
		{
			Regex regex;

			regex = BuildSimple("$(Aa_Bb)");
			Assert.IsTrue(regex.IsMatch("1"));
			Assert.IsTrue(regex.IsMatch("123"));
			Assert.IsTrue(regex.IsMatch("123_456"));
			Assert.IsTrue(regex.IsMatch("1_Style_Cop"));
			Assert.IsTrue(regex.IsMatch("Style_1_Cop"));
			Assert.IsTrue(regex.IsMatch("Style_Cop_1"));
			Assert.IsTrue(regex.IsMatch("123_Style_Cop"));
			Assert.IsTrue(regex.IsMatch("Style_123_Cop"));
			Assert.IsTrue(regex.IsMatch("Style_Cop_123"));
		}

		#endregion

		#region Macro "Upper Only"

		[TestMethod]
		public void Macro_Upper_Only_General()
		{
			Regex regex;

			regex = BuildSimple("$(AABB)");
			Assert.IsTrue(regex.IsMatch("STYLE"));
			Assert.IsFalse(regex.IsMatch("STYLE_COP"));
			Assert.IsFalse(regex.IsMatch("sTYLECOP"));
			Assert.IsFalse(regex.IsMatch("STYLECOP+"));
			Assert.IsFalse(regex.IsMatch("_STYLE"));
			Assert.IsFalse(regex.IsMatch("STYLE_"));
		}

		[TestMethod]
		public void Macro_Upper_Only_Abbreviations()
		{
			Regex regex;

			regex = BuildWithAbbreviations("$(AABB)", "A B");
			Assert.IsTrue(regex.IsMatch("STYLE"));
			Assert.IsTrue(regex.IsMatch("STYLECOP"));
		}

		[TestMethod]
		public void Macro_Upper_Only_Single_Letter()
		{
			Regex regex;

			regex = BuildWithAbbreviations("$(AABB)", String.Empty);
			Assert.IsFalse(regex.IsMatch("a"));
			Assert.IsTrue(regex.IsMatch("A"));

			regex = BuildWithAbbreviations("$(AABB)", "A");
			Assert.IsFalse(regex.IsMatch("a"));
			Assert.IsTrue(regex.IsMatch("A"));

			regex = BuildWithAbbreviations("Pre$(AABB)_POST", String.Empty);
			Assert.IsFalse(regex.IsMatch("Prea_POST"));
			Assert.IsTrue(regex.IsMatch("PreA_POST"));

			regex = BuildWithAbbreviations("Pre$(AABB)_POST", "A");
			Assert.IsFalse(regex.IsMatch("Prea_POST"));
			Assert.IsTrue(regex.IsMatch("PreA_POST"));
		}

		[TestMethod]
		public void Macro_Upper_Only_Unicode()
		{
			Regex regex;

			regex = BuildSimple("$(AABB)");
			Assert.IsTrue(regex.IsMatch("СТАЙЛКОП"));
			Assert.IsFalse(regex.IsMatch("стайлкоп"));
		}

		[TestMethod]
		public void Macro_Upper_Only_Digits()
		{
			Regex regex;

			regex = BuildSimple("$(AABB)");
			Assert.IsTrue(regex.IsMatch("1"));
			Assert.IsTrue(regex.IsMatch("123"));
			Assert.IsFalse(regex.IsMatch("123_456"));
			Assert.IsTrue(regex.IsMatch("1STYLECOP"));
			Assert.IsTrue(regex.IsMatch("STYLE1COP"));
			Assert.IsTrue(regex.IsMatch("STYLECOP1"));
			Assert.IsTrue(regex.IsMatch("123STYLECOP"));
			Assert.IsTrue(regex.IsMatch("STYLE123COP"));
			Assert.IsTrue(regex.IsMatch("STYLECOP123"));
		}

		#endregion

		#region Macro "Lower Only"

		[TestMethod]
		public void Macro_Lower_Only_General()
		{
			Regex regex;

			regex = BuildSimple("$(aabb)");
			Assert.IsTrue(regex.IsMatch("style"));
			Assert.IsFalse(regex.IsMatch("style_cop"));
			Assert.IsFalse(regex.IsMatch("Stylecop"));
			Assert.IsFalse(regex.IsMatch("stylecop+"));
			Assert.IsFalse(regex.IsMatch("_style"));
			Assert.IsFalse(regex.IsMatch("style_"));
		}

		[TestMethod]
		public void Macro_Lower_Only_Abbreviations()
		{
			Regex regex;

			regex = BuildWithAbbreviations("$(aabb)", "A B");
			Assert.IsTrue(regex.IsMatch("style"));
			Assert.IsTrue(regex.IsMatch("stylecop"));
		}

		[TestMethod]
		public void Macro_Lower_Only_Single_Letter()
		{
			Regex regex;

			regex = BuildWithAbbreviations("$(aabb)", String.Empty);
			Assert.IsTrue(regex.IsMatch("a"));
			Assert.IsFalse(regex.IsMatch("A"));

			regex = BuildWithAbbreviations("$(aabb)", "A");
			Assert.IsTrue(regex.IsMatch("a"));
			Assert.IsFalse(regex.IsMatch("A"));

			regex = BuildWithAbbreviations("Pre$(aabb)_POST", String.Empty);
			Assert.IsTrue(regex.IsMatch("Prea_POST"));
			Assert.IsFalse(regex.IsMatch("PreA_POST"));

			regex = BuildWithAbbreviations("Pre$(aabb)_POST", "A");
			Assert.IsTrue(regex.IsMatch("Prea_POST"));
			Assert.IsFalse(regex.IsMatch("PreA_POST"));
		}

		[TestMethod]
		public void Macro_Lower_Only_Unicode()
		{
			Regex regex;

			regex = BuildSimple("$(aabb)");
			Assert.IsTrue(regex.IsMatch("стайлкоп"));
			Assert.IsFalse(regex.IsMatch("СТАЙЛКОП"));
		}

		[TestMethod]
		public void Macro_Lower_Only_Digits()
		{
			Regex regex;

			regex = BuildSimple("$(aabb)");
			Assert.IsTrue(regex.IsMatch("1"));
			Assert.IsTrue(regex.IsMatch("123"));
			Assert.IsFalse(regex.IsMatch("123_456"));
			Assert.IsTrue(regex.IsMatch("1stylecop"));
			Assert.IsTrue(regex.IsMatch("style1cop"));
			Assert.IsTrue(regex.IsMatch("stylecop1"));
			Assert.IsTrue(regex.IsMatch("123stylecop"));
			Assert.IsTrue(regex.IsMatch("style123cop"));
			Assert.IsTrue(regex.IsMatch("stylecop123"));
		}

		#endregion

		#region Macro "Any"

		[TestMethod]
		public void Macro_Any_General()
		{
			Regex regex;

			regex = BuildSimple("$(*)");
			Assert.IsTrue(regex.IsMatch("Style"));
			Assert.IsTrue(regex.IsMatch("Style_COP"));
			Assert.IsTrue(regex.IsMatch("style_Cop++CSharp"));
		}

		[TestMethod]
		public void Macro_Any_Abbreviations()
		{
			Regex regex;

			regex = BuildWithAbbreviations("$(*)", String.Empty);
			Assert.IsTrue(regex.IsMatch("Point3D_3D"));

			regex = BuildWithAbbreviations("$(*)", "3D");
			Assert.IsTrue(regex.IsMatch("Point3D_3D"));
		}

		[TestMethod]
		public void Macro_Any_Single_Letter()
		{
			Regex regex;

			regex = BuildWithAbbreviations("$(*)", String.Empty);
			Assert.IsTrue(regex.IsMatch("a"));
			Assert.IsTrue(regex.IsMatch("A"));

			regex = BuildWithAbbreviations("$(*)", "A");
			Assert.IsTrue(regex.IsMatch("a"));
			Assert.IsTrue(regex.IsMatch("A"));

			regex = BuildWithAbbreviations("Pre$(*)_POST", String.Empty);
			Assert.IsTrue(regex.IsMatch("Prea_POST"));
			Assert.IsTrue(regex.IsMatch("PreA_POST"));

			regex = BuildWithAbbreviations("Pre$(*)_POST", "A");
			Assert.IsTrue(regex.IsMatch("Prea_POST"));
			Assert.IsTrue(regex.IsMatch("PreA_POST"));
		}

		[TestMethod]
		public void Macro_Any_Unicode()
		{
			Regex regex;

			regex = BuildSimple("$(*)");
			Assert.IsTrue(regex.IsMatch("Стайл_КОП"));
			Assert.IsTrue(regex.IsMatch("стайл_Коп++СиШарп"));
		}

		[TestMethod]
		public void Macro_Any_Digits()
		{
			Regex regex;

			regex = BuildSimple("$(*)");
			Assert.IsTrue(regex.IsMatch("1"));
			Assert.IsTrue(regex.IsMatch("123"));
			Assert.IsTrue(regex.IsMatch("123_456"));
			Assert.IsTrue(regex.IsMatch("1_Style_COP"));
			Assert.IsTrue(regex.IsMatch("style++_1_Cop"));
			Assert.IsTrue(regex.IsMatch("STYLECOP_1"));
		}

		#endregion
	}
}
