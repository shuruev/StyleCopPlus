using System;

namespace StyleCopPlus.Tests
{
	public class Class1
	{
		public void FalseUsualMethod()
		{
		}

		[SomeAttribute]
		public void FalseUnkownAttribute()
		{
		}

		#region MSTest methods

		[TestMethod]
		public void TrueMSTestMethod()
		{
		}

		[TestMethod()]
		public void TrueMSTestMethodParenthesis()
		{
		}

		[TestMethod("A")]
		public void TrueMSTestMethodParameter()
		{
		}

		[TestMethod("A", "B" = 2)]
		public void TrueMSTestMethodParameters()
		{
		}

		[TestMethodAttribute]
		public void TrueMSTestMethodAttribute()
		{
		}

		[TestMethodAttribute()]
		public void TrueMSTestMethodAttributeParenthesis()
		{
		}

		[TestMethodAttribute("A")]
		public void TrueMSTestMethodAttributeParameter()
		{
		}

		[TestMethodAttribute("A", "B" = 2)]
		public void TrueMSTestMethodAttributeParameters()
		{
		}

		#endregion

		#region NUnit methods

		[Test]
		public void TrueNUnitMethod()
		{
		}

		[Test()]
		public void TrueNUnitMethodParenthesis()
		{
		}

		[Test("A")]
		public void TrueNUnitMethodParameter()
		{
		}

		[Test("A", "B" = 2)]
		public void TrueNUnitMethodParameters()
		{
		}

		[TestAttribute]
		public void TrueNUnitMethodAttribute()
		{
		}

		[TestAttribute()]
		public void TrueNUnitMethodAttributeParenthesis()
		{
		}

		[TestAttribute("A")]
		public void TrueNUnitMethodAttributeParameter()
		{
		}

		[TestAttribute("A", "B" = 2)]
		public void TrueNUnitMethodAttributeParameters()
		{
		}

		#endregion
	}
}
