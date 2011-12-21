using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StyleCopPlus.Tests.Macro
{
	/// <summary>
	/// Testing naming macro "Lower Single".
	/// </summary>
	[TestClass]
	public class MacroTestLowerSingle : MacroTestBase
	{
		[TestMethod]
		public void Macro_Lower_Single_General()
		{
			Regex regex;

			regex = Build("$(a)");
			Assert.IsTrue(regex.IsMatch("s"));
			Assert.IsFalse(regex.IsMatch("style"));
			Assert.IsFalse(regex.IsMatch("S"));
			Assert.IsFalse(regex.IsMatch("_"));
			Assert.IsFalse(regex.IsMatch("s_"));
		}

		[TestMethod]
		public void Macro_Lower_Single_Abbreviations()
		{
			Regex regex;

			regex = Build("$(a)", "A B");
			Assert.IsTrue(regex.IsMatch("s"));
			Assert.IsFalse(regex.IsMatch("A"));
		}

		[TestMethod]
		public void Macro_Lower_Single_Single_Letter()
		{
			Regex regex;

			regex = Build("$(a)");
			Assert.IsTrue(regex.IsMatch("a"));
			Assert.IsFalse(regex.IsMatch("A"));

			regex = Build("$(a)", "A");
			Assert.IsTrue(regex.IsMatch("a"));
			Assert.IsFalse(regex.IsMatch("A"));

			regex = Build("Pre$(a)_POST");
			Assert.IsTrue(regex.IsMatch("Prea_POST"));
			Assert.IsFalse(regex.IsMatch("PreA_POST"));

			regex = Build("Pre$(a)_POST", "A");
			Assert.IsTrue(regex.IsMatch("Prea_POST"));
			Assert.IsFalse(regex.IsMatch("PreA_POST"));
		}

		[TestMethod]
		public void Macro_Lower_Single_Unicode()
		{
			Regex regex = Build("$(a)");
			Assert.IsTrue(regex.IsMatch("ж"));
			Assert.IsFalse(regex.IsMatch("Ж"));
		}

		[TestMethod]
		public void Macro_Lower_Single_Digits()
		{
			Regex regex = Build("$(a)");
			Assert.IsTrue(regex.IsMatch("1"));
			Assert.IsFalse(regex.IsMatch("123"));
		}

		[TestMethod]
		public void Macro_Lower_Single_Empty()
		{
			Regex regex = Build("A$(a)Z");
			Assert.IsFalse(regex.IsMatch("AZ"));
			Assert.IsTrue(regex.IsMatch("AxZ"));
		}
	}
}
