using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StyleCopPlus.Tests.Macro
{
	/// <summary>
	/// Testing naming macro "Lower Only".
	/// </summary>
	[TestClass]
	public class MacroTestLowerOnly : MacroTestBase
	{
		[TestMethod]
		public void Macro_Lower_Only_General()
		{
			Regex regex;

			regex = Build("$(aabb)");
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

			regex = Build("$(aabb)", "A B");
			Assert.IsTrue(regex.IsMatch("style"));
			Assert.IsTrue(regex.IsMatch("stylecop"));
			Assert.IsFalse(regex.IsMatch("A"));
		}

		[TestMethod]
		public void Macro_Lower_Only_Single_Letter()
		{
			Regex regex;

			regex = Build("$(aabb)");
			Assert.IsTrue(regex.IsMatch("a"));
			Assert.IsFalse(regex.IsMatch("A"));

			regex = Build("$(aabb)", "A");
			Assert.IsTrue(regex.IsMatch("a"));
			Assert.IsFalse(regex.IsMatch("A"));

			regex = Build("Pre$(aabb)_POST");
			Assert.IsTrue(regex.IsMatch("Prea_POST"));
			Assert.IsFalse(regex.IsMatch("PreA_POST"));

			regex = Build("Pre$(aabb)_POST", "A");
			Assert.IsTrue(regex.IsMatch("Prea_POST"));
			Assert.IsFalse(regex.IsMatch("PreA_POST"));
		}

		[TestMethod]
		public void Macro_Lower_Only_Unicode()
		{
			Regex regex = Build("$(aabb)");
			Assert.IsTrue(regex.IsMatch("стайлкоп"));
			Assert.IsFalse(regex.IsMatch("СТАЙЛКОП"));
		}

		[TestMethod]
		public void Macro_Lower_Only_Digits()
		{
			Regex regex = Build("$(aabb)");
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

		[TestMethod]
		public void Macro_Lower_Only_Empty()
		{
			Regex regex = Build("A$(aabb)Z");
			Assert.IsFalse(regex.IsMatch("AZ"));
			Assert.IsTrue(regex.IsMatch("AoooZ"));
			Assert.IsTrue(regex.IsMatch("AooopppZ"));
		}
	}
}
