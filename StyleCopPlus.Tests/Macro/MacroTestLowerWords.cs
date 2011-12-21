using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StyleCopPlus.Tests.Macro
{
	/// <summary>
	/// Testing naming macro "Lower Words".
	/// </summary>
	[TestClass]
	public class MacroTestLowerWords : MacroTestBase
	{
		[TestMethod]
		public void Macro_Lower_Words_General()
		{
			Regex regex;

			regex = Build("$(aa_bb)");
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

			regex = Build("$(aa_bb)", "A B");
			Assert.IsTrue(regex.IsMatch("style"));
			Assert.IsTrue(regex.IsMatch("style_cop"));
		}

		[TestMethod]
		public void Macro_Lower_Words_Single_Letter()
		{
			Regex regex;

			regex = Build("$(aa_bb)");
			Assert.IsTrue(regex.IsMatch("a"));
			Assert.IsFalse(regex.IsMatch("A"));

			regex = Build("$(aa_bb)", "A");
			Assert.IsTrue(regex.IsMatch("a"));
			Assert.IsFalse(regex.IsMatch("A"));

			regex = Build("Pre$(aa_bb)_POST");
			Assert.IsTrue(regex.IsMatch("Prea_POST"));
			Assert.IsFalse(regex.IsMatch("PreA_POST"));

			regex = Build("Pre$(aa_bb)_POST", "A");
			Assert.IsTrue(regex.IsMatch("Prea_POST"));
			Assert.IsFalse(regex.IsMatch("PreA_POST"));
		}

		[TestMethod]
		public void Macro_Lower_Words_Unicode()
		{
			Regex regex = Build("$(aa_bb)");
			Assert.IsTrue(regex.IsMatch("стайл_коп"));
			Assert.IsFalse(regex.IsMatch("СТАЙЛ_КОП"));
		}

		[TestMethod]
		public void Macro_Lower_Words_Digits()
		{
			Regex regex = Build("$(aa_bb)");
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

		[TestMethod]
		public void Macro_Lower_Words_Empty()
		{
			Regex regex = Build("A$(aa_bb)Z");
			Assert.IsFalse(regex.IsMatch("AZ"));
			Assert.IsTrue(regex.IsMatch("AxxxZ"));
			Assert.IsTrue(regex.IsMatch("Axxx_yyyZ"));
		}
	}
}
