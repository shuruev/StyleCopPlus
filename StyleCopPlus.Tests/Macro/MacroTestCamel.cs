using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StyleCopPlus.Tests.Macro
{
	/// <summary>
	/// Testing naming macro "Camel".
	/// </summary>
	[TestClass]
	public class MacroTestCamel : MacroTestBase
	{
		[TestMethod]
		public void Macro_Camel_General()
		{
			Regex regex;

			regex = Build("$(aaBb)");
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

			regex = Build("$(aaBb)", "C");
			Assert.IsTrue(regex.IsMatch("style"));
			Assert.IsTrue(regex.IsMatch("styleCop"));
			Assert.IsTrue(regex.IsMatch("styleCopPlus"));
			Assert.IsFalse(regex.IsMatch("StyleCop"));
			Assert.IsFalse(regex.IsMatch("styleCop+"));
			Assert.IsFalse(regex.IsMatch("style_Cop"));
			Assert.IsTrue(regex.IsMatch("styleC"));
			Assert.IsTrue(regex.IsMatch("styleCSharp"));

			regex = Build("$(aaBb)", "C X");
			Assert.IsTrue(regex.IsMatch("style"));
			Assert.IsTrue(regex.IsMatch("styleCop"));
			Assert.IsTrue(regex.IsMatch("styleCX"));
			Assert.IsTrue(regex.IsMatch("styleCXSharp"));

			regex = Build("$(aaBb)");
			Assert.IsFalse(regex.IsMatch("point3D"));

			regex = Build("$(aaBb)", "3D");
			Assert.IsTrue(regex.IsMatch("point3D"));
		}

		[TestMethod]
		public void Macro_Camel_Single_Letter()
		{
			Regex regex;

			regex = Build("$(aaBb)");
			Assert.IsTrue(regex.IsMatch("a"));
			Assert.IsFalse(regex.IsMatch("A"));

			regex = Build("$(aaBb)", "A");
			Assert.IsTrue(regex.IsMatch("a"));
			Assert.IsFalse(regex.IsMatch("A"));

			regex = Build("Pre$(aaBb)_POST");
			Assert.IsTrue(regex.IsMatch("Prea_POST"));
			Assert.IsFalse(regex.IsMatch("PreA_POST"));

			regex = Build("Pre$(aaBb)_POST", "A");
			Assert.IsTrue(regex.IsMatch("Prea_POST"));
			Assert.IsFalse(regex.IsMatch("PreA_POST"));
		}

		[TestMethod]
		public void Macro_Camel_Unicode()
		{
			Regex regex = Build("$(aaBb)");
			Assert.IsTrue(regex.IsMatch("стайлКоп"));
			Assert.IsFalse(regex.IsMatch("СтайлКоп"));
		}

		[TestMethod]
		public void Macro_Camel_Digits()
		{
			Regex regex = Build("$(aaBb)");
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

		[TestMethod]
		public void Macro_Camel_Empty()
		{
			Regex regex = Build("A$(aaBb)Z");
			Assert.IsFalse(regex.IsMatch("AZ"));
			Assert.IsTrue(regex.IsMatch("AxxxZ"));
			Assert.IsTrue(regex.IsMatch("AxxxYyyZ"));
		}
	}
}
