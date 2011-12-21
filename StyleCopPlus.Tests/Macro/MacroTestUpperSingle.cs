using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StyleCopPlus.Tests.Macro
{
	/// <summary>
	/// Testing naming macro "Upper Single".
	/// </summary>
	[TestClass]
	public class MacroTestUpperSingle : MacroTestBase
	{
		[TestMethod]
		public void Macro_Upper_Single_General()
		{
			Regex regex;

			regex = Build("$(A)");
			Assert.IsTrue(regex.IsMatch("S"));
			Assert.IsFalse(regex.IsMatch("STYLE"));
			Assert.IsFalse(regex.IsMatch("s"));
			Assert.IsFalse(regex.IsMatch("_"));
			Assert.IsFalse(regex.IsMatch("S_"));
		}

		[TestMethod]
		public void Macro_Upper_Single_Abbreviations()
		{
			Regex regex;

			regex = Build("$(A)", "A B");
			Assert.IsTrue(regex.IsMatch("S"));
			Assert.IsTrue(regex.IsMatch("A"));
		}

		[TestMethod]
		public void Macro_Upper_Single_Single_Letter()
		{
			Regex regex;

			regex = Build("$(A)");
			Assert.IsFalse(regex.IsMatch("a"));
			Assert.IsTrue(regex.IsMatch("A"));

			regex = Build("$(A)", "A");
			Assert.IsFalse(regex.IsMatch("a"));
			Assert.IsTrue(regex.IsMatch("A"));

			regex = Build("Pre$(A)_POST");
			Assert.IsFalse(regex.IsMatch("Prea_POST"));
			Assert.IsTrue(regex.IsMatch("PreA_POST"));

			regex = Build("Pre$(A)_POST", "A");
			Assert.IsFalse(regex.IsMatch("Prea_POST"));
			Assert.IsTrue(regex.IsMatch("PreA_POST"));
		}

		[TestMethod]
		public void Macro_Upper_Single_Unicode()
		{
			Regex regex = Build("$(A)");
			Assert.IsTrue(regex.IsMatch("Ж"));
			Assert.IsFalse(regex.IsMatch("ж"));
		}

		[TestMethod]
		public void Macro_Upper_Single_Digits()
		{
			Regex regex = Build("$(A)");
			Assert.IsTrue(regex.IsMatch("1"));
			Assert.IsFalse(regex.IsMatch("123"));
		}

		[TestMethod]
		public void Macro_Upper_Single_Empty()
		{
			Regex regex = Build("A$(A)Z");
			Assert.IsFalse(regex.IsMatch("AZ"));
			Assert.IsTrue(regex.IsMatch("AXZ"));
		}
	}
}
