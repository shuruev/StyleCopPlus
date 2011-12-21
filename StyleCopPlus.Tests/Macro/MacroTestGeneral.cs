using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StyleCopPlus.Tests.Macro
{
	/// <summary>
	/// General naming macros tests.
	/// </summary>
	[TestClass]
	public class MacroTestGeneral : MacroTestBase
	{
		[TestMethod]
		public void Apply_Rules_Without_Macros()
		{
			Regex regex;

			regex = Build("Oleg:Shuruev");
			Assert.IsTrue(regex.IsMatch("Oleg"));
			Assert.IsTrue(regex.IsMatch("Shuruev"));
			Assert.IsFalse(regex.IsMatch("oleg"));
			Assert.IsFalse(regex.IsMatch("shuruev"));
			Assert.IsFalse(regex.IsMatch("olegus"));
			Assert.IsFalse(regex.IsMatch("nonshuruev"));
		}

		[TestMethod]
		public void Apply_Rules_With_Pascal_Macro()
		{
			Regex regex;

			regex = Build("Pre$(AaBb)_POST");
			Assert.IsFalse(regex.IsMatch("Style"));
			Assert.IsFalse(regex.IsMatch("StyleCop"));
			Assert.IsTrue(regex.IsMatch("PreStyle_POST"));
			Assert.IsTrue(regex.IsMatch("PreStyleCop_POST"));
			Assert.IsFalse(regex.IsMatch("PrestyleCop_POST"));
			Assert.IsFalse(regex.IsMatch("PreStyleCop+_POST"));

			regex = Build("T:T$(AaBb)");
			Assert.IsTrue(regex.IsMatch("T"));
			Assert.IsTrue(regex.IsMatch("TInput"));
		}

		[TestMethod]
		public void Apply_Rules_With_Any_Macro()
		{
			Regex regex;

			regex = Build("Pre$(*)_POST");
			Assert.IsFalse(regex.IsMatch("Style"));
			Assert.IsFalse(regex.IsMatch("StyleCop"));
			Assert.IsTrue(regex.IsMatch("PreStyle_POST"));
			Assert.IsFalse(regex.IsMatch("PREStyleCOP+_POST"));
			Assert.IsFalse(regex.IsMatch("PreStyleCOP+POST"));
			Assert.IsFalse(regex.IsMatch("PreStyleCOP+_Post"));
			Assert.IsTrue(regex.IsMatch("PreStyleCOP+_POST"));
		}
	}
}
