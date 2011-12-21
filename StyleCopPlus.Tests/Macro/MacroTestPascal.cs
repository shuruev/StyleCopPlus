using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StyleCopPlus.Tests.Macro
{
	/// <summary>
	/// Testing naming macro "Pascal".
	/// </summary>
	[TestClass]
	public class MacroTestPascal : MacroTestBase
	{
		[TestMethod]
		public void Macro_Pascal_General()
		{
			Regex regex;

			regex = Build("$(AaBb)");
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

			regex = Build("$(AaBb)", "C");
			Assert.IsTrue(regex.IsMatch("Style"));
			Assert.IsTrue(regex.IsMatch("StyleCop"));
			Assert.IsFalse(regex.IsMatch("styleCop"));
			Assert.IsFalse(regex.IsMatch("StyleCop+"));
			Assert.IsFalse(regex.IsMatch("Style_Cop"));
			Assert.IsTrue(regex.IsMatch("StyleC"));
			Assert.IsTrue(regex.IsMatch("CSharpStyle"));

			regex = Build("$(AaBb)", "C X");
			Assert.IsTrue(regex.IsMatch("Style"));
			Assert.IsTrue(regex.IsMatch("StyleCop"));
			Assert.IsTrue(regex.IsMatch("StyleCX"));
			Assert.IsTrue(regex.IsMatch("CXSharpStyle"));

			regex = Build("$(AaBb)");
			Assert.IsFalse(regex.IsMatch("Point3D"));

			regex = Build("$(AaBb)", "3D");
			Assert.IsTrue(regex.IsMatch("Point3D"));
		}

		[TestMethod]
		public void Macro_Pascal_Single_Letter()
		{
			Regex regex;

			regex = Build("$(AaBb)");
			Assert.IsFalse(regex.IsMatch("a"));
			Assert.IsTrue(regex.IsMatch("A"));

			regex = Build("$(AaBb)", "A");
			Assert.IsFalse(regex.IsMatch("a"));
			Assert.IsTrue(regex.IsMatch("A"));

			regex = Build("Pre$(AaBb)_POST");
			Assert.IsFalse(regex.IsMatch("Prea_POST"));
			Assert.IsTrue(regex.IsMatch("PreA_POST"));

			regex = Build("Pre$(AaBb)_POST", "A");
			Assert.IsFalse(regex.IsMatch("Prea_POST"));
			Assert.IsTrue(regex.IsMatch("PreA_POST"));
		}

		[TestMethod]
		public void Macro_Pascal_Unicode()
		{
			Regex regex = Build("$(AaBb)");
			Assert.IsTrue(regex.IsMatch("СтайлКоп"));
			Assert.IsFalse(regex.IsMatch("стайлКоп"));
		}

		[TestMethod]
		public void Macro_Pascal_Digits()
		{
			Regex regex = Build("$(AaBb)");
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

		[TestMethod]
		public void Macro_Pascal_Empty()
		{
			Regex regex = Build("A$(AaBb)Z");
			Assert.IsFalse(regex.IsMatch("AZ"));
			Assert.IsTrue(regex.IsMatch("AOooZ"));
			Assert.IsTrue(regex.IsMatch("AOooPppZ"));
		}
	}
}
