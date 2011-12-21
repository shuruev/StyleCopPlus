using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StyleCopPlus.Tests.Macro
{
	/// <summary>
	/// Testing naming macro "Upper Only".
	/// </summary>
	[TestClass]
	public class MacroTestUpperOnly : MacroTestBase
	{
		[TestMethod]
		public void Macro_Upper_Only_General()
		{
			Regex regex;

			regex = Build("$(AABB)");
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

			regex = Build("$(AABB)", "A B");
			Assert.IsTrue(regex.IsMatch("STYLE"));
			Assert.IsTrue(regex.IsMatch("STYLECOP"));
			Assert.IsTrue(regex.IsMatch("A"));
		}

		[TestMethod]
		public void Macro_Upper_Only_Single_Letter()
		{
			Regex regex;

			regex = Build("$(AABB)");
			Assert.IsFalse(regex.IsMatch("a"));
			Assert.IsTrue(regex.IsMatch("A"));

			regex = Build("$(AABB)", "A");
			Assert.IsFalse(regex.IsMatch("a"));
			Assert.IsTrue(regex.IsMatch("A"));

			regex = Build("Pre$(AABB)_POST");
			Assert.IsFalse(regex.IsMatch("Prea_POST"));
			Assert.IsTrue(regex.IsMatch("PreA_POST"));

			regex = Build("Pre$(AABB)_POST", "A");
			Assert.IsFalse(regex.IsMatch("Prea_POST"));
			Assert.IsTrue(regex.IsMatch("PreA_POST"));
		}

		[TestMethod]
		public void Macro_Upper_Only_Unicode()
		{
			Regex regex = Build("$(AABB)");
			Assert.IsTrue(regex.IsMatch("СТАЙЛКОП"));
			Assert.IsFalse(regex.IsMatch("стайлкоп"));
		}

		[TestMethod]
		public void Macro_Upper_Only_Digits()
		{
			Regex regex = Build("$(AABB)");
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

		[TestMethod]
		public void Macro_Upper_Only_Empty()
		{
			Regex regex = Build("A$(AABB)Z");
			Assert.IsFalse(regex.IsMatch("AZ"));
			Assert.IsTrue(regex.IsMatch("AXXXZ"));
			Assert.IsTrue(regex.IsMatch("AXXXYYYZ"));
		}
	}
}
