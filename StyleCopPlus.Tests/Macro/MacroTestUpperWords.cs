using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StyleCopPlus.Tests.Macro
{
	/// <summary>
	/// Testing naming macro "Upper Words".
	/// </summary>
	[TestClass]
	public class MacroTestUpperWords : MacroTestBase
	{
		[TestMethod]
		public void Macro_Upper_Words_General()
		{
			Regex regex;

			regex = Build("$(AA_BB)");
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

			regex = Build("$(AA_BB)", "A B");
			Assert.IsTrue(regex.IsMatch("STYLE"));
			Assert.IsTrue(regex.IsMatch("STYLE_COP"));
			Assert.IsTrue(regex.IsMatch("A"));
		}

		[TestMethod]
		public void Macro_Upper_Words_Single_Letter()
		{
			Regex regex;

			regex = Build("$(AA_BB)");
			Assert.IsFalse(regex.IsMatch("a"));
			Assert.IsTrue(regex.IsMatch("A"));

			regex = Build("$(AA_BB)", "A");
			Assert.IsFalse(regex.IsMatch("a"));
			Assert.IsTrue(regex.IsMatch("A"));

			regex = Build("Pre$(AA_BB)_POST");
			Assert.IsFalse(regex.IsMatch("Prea_POST"));
			Assert.IsTrue(regex.IsMatch("PreA_POST"));

			regex = Build("Pre$(AA_BB)_POST", "A");
			Assert.IsFalse(regex.IsMatch("Prea_POST"));
			Assert.IsTrue(regex.IsMatch("PreA_POST"));
		}

		[TestMethod]
		public void Macro_Upper_Words_Unicode()
		{
			Regex regex = Build("$(AA_BB)");
			Assert.IsTrue(regex.IsMatch("СТАЙЛ_КОП"));
			Assert.IsFalse(regex.IsMatch("стайл_коп"));
		}

		[TestMethod]
		public void Macro_Upper_Words_Digits()
		{
			Regex regex = Build("$(AA_BB)");
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

		[TestMethod]
		public void Macro_Upper_Words_Empty()
		{
			Regex regex = Build("A$(AA_BB)Z");
			Assert.IsFalse(regex.IsMatch("AZ"));
			Assert.IsTrue(regex.IsMatch("AXXXZ"));
			Assert.IsTrue(regex.IsMatch("AXXX_YYYZ"));
		}
	}
}
