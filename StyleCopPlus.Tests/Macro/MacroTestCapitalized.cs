using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StyleCopPlus.Tests.Macro
{
	/// <summary>
	/// Testing naming macro "Capitalized".
	/// </summary>
	[TestClass]
	public class MacroTestCapitalized : MacroTestBase
	{
		[TestMethod]
		public void Macro_Capitalized_General()
		{
			Regex regex;

			regex = Build("$(Aa_Bb)");
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

			regex = Build("$(Aa_Bb)", "C");
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

			regex = Build("$(Aa_Bb)", "C X");
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

			regex = Build("$(Aa_Bb)", "CX");
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

			regex = Build("$(Aa_Bb)");
			Assert.IsFalse(regex.IsMatch("Point_3D"));

			regex = Build("$(Aa_Bb)", "3D");
			Assert.IsTrue(regex.IsMatch("Point_3D"));
		}

		[TestMethod]
		public void Macro_Capitalized_Single_Letter()
		{
			Regex regex;

			regex = Build("$(Aa_Bb)");
			Assert.IsFalse(regex.IsMatch("a"));
			Assert.IsTrue(regex.IsMatch("A"));

			regex = Build("$(Aa_Bb)", "A");
			Assert.IsFalse(regex.IsMatch("a"));
			Assert.IsTrue(regex.IsMatch("A"));

			regex = Build("Pre$(Aa_Bb)_POST");
			Assert.IsFalse(regex.IsMatch("Prea_POST"));
			Assert.IsTrue(regex.IsMatch("PreA_POST"));

			regex = Build("Pre$(Aa_Bb)_POST", "A");
			Assert.IsFalse(regex.IsMatch("Prea_POST"));
			Assert.IsTrue(regex.IsMatch("PreA_POST"));
		}

		[TestMethod]
		public void Macro_Capitalized_Words()
		{
			Regex regex;

			regex = Build("$(Aa_Bb)");
			Assert.IsFalse(regex.IsMatch("StyleCop"));
			Assert.IsFalse(regex.IsMatch("Test_StyleCop_Features"));
			Assert.IsTrue(regex.IsMatch("Test_Style_Cop_Features"));
			Assert.IsFalse(regex.IsMatch("FxCop"));
			Assert.IsFalse(regex.IsMatch("Test_FxCop_Features"));
			Assert.IsTrue(regex.IsMatch("Test_Fx_Cop_Features"));

			regex = Build("$(Aa_Bb)", "StyleCop");
			Assert.IsTrue(regex.IsMatch("StyleCop"));
			Assert.IsTrue(regex.IsMatch("Test_StyleCop_Features"));
			Assert.IsTrue(regex.IsMatch("Test_Style_Cop_Features"));
			Assert.IsFalse(regex.IsMatch("FxCop"));
			Assert.IsFalse(regex.IsMatch("Test_FxCop_Features"));
			Assert.IsTrue(regex.IsMatch("Test_Fx_Cop_Features"));

			regex = Build("$(Aa_Bb)", "StyleCop FxCop");
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
			Regex regex = Build("$(Aa_Bb)");
			Assert.IsTrue(regex.IsMatch("Стайл_Коп"));
			Assert.IsFalse(regex.IsMatch("стайл_Коп"));
		}

		[TestMethod]
		public void Macro_Capitalized_Digits()
		{
			Regex regex = Build("$(Aa_Bb)");
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

		[TestMethod]
		public void Macro_Capitalized_Empty()
		{
			Regex regex = Build("A$(Aa_Bb)Z");
			Assert.IsFalse(regex.IsMatch("AZ"));
			Assert.IsTrue(regex.IsMatch("AXxxZ"));
			Assert.IsTrue(regex.IsMatch("AXxx_YyyZ"));
		}
	}
}
