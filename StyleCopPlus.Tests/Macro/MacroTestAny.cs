using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StyleCopPlus.Tests.Macro
{
	/// <summary>
	/// Testing naming macro "Any".
	/// </summary>
	[TestClass]
	public class MacroTestAny : MacroTestBase
	{
		[TestMethod]
		public void Macro_Any_General()
		{
			Regex regex;

			regex = Build("$(*)");
			Assert.IsTrue(regex.IsMatch("Style"));
			Assert.IsTrue(regex.IsMatch("Style_COP"));
			Assert.IsTrue(regex.IsMatch("style_Cop++CSharp"));
		}

		[TestMethod]
		public void Macro_Any_Abbreviations()
		{
			Regex regex;

			regex = Build("$(*)");
			Assert.IsTrue(regex.IsMatch("Point3D_3D"));

			regex = Build("$(*)", "3D");
			Assert.IsTrue(regex.IsMatch("Point3D_3D"));
		}

		[TestMethod]
		public void Macro_Any_Single_Letter()
		{
			Regex regex;

			regex = Build("$(*)");
			Assert.IsTrue(regex.IsMatch("a"));
			Assert.IsTrue(regex.IsMatch("A"));

			regex = Build("$(*)", "A");
			Assert.IsTrue(regex.IsMatch("a"));
			Assert.IsTrue(regex.IsMatch("A"));

			regex = Build("Pre$(*)_POST");
			Assert.IsTrue(regex.IsMatch("Prea_POST"));
			Assert.IsTrue(regex.IsMatch("PreA_POST"));

			regex = Build("Pre$(*)_POST", "A");
			Assert.IsTrue(regex.IsMatch("Prea_POST"));
			Assert.IsTrue(regex.IsMatch("PreA_POST"));
		}

		[TestMethod]
		public void Macro_Any_Unicode()
		{
			Regex regex = Build("$(*)");
			Assert.IsTrue(regex.IsMatch("Стайл_КОП"));
			Assert.IsTrue(regex.IsMatch("стайл_Коп++СиШарп"));
		}

		[TestMethod]
		public void Macro_Any_Digits()
		{
			Regex regex = Build("$(*)");
			Assert.IsTrue(regex.IsMatch("1"));
			Assert.IsTrue(regex.IsMatch("123"));
			Assert.IsTrue(regex.IsMatch("123_456"));
			Assert.IsTrue(regex.IsMatch("1_Style_COP"));
			Assert.IsTrue(regex.IsMatch("style++_1_Cop"));
			Assert.IsTrue(regex.IsMatch("STYLECOP_1"));
		}

		[TestMethod]
		public void Macro_Any_Empty()
		{
			Regex regex = Build("A$(*)Z");
			Assert.IsFalse(regex.IsMatch("AZ"));
			Assert.IsTrue(regex.IsMatch("AoooZ"));
			Assert.IsTrue(regex.IsMatch("Aooo___Z"));
		}
	}
}
