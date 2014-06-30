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

		#region XUnit Methods

		[Fact]
		public void TrueXUnitFactMethod()
		{
		}

		[Fact()]
		public void TrueXUnitFactMethodParenthesis()
		{
		}

		[Fact("A")]
		public void TrueXUnitFactMethodParameter()
		{
		}

		[Fact("A", "B" = 2)]
		public void TrueXUnitFactMethodParameters()
		{
		}

		[FactAttribute]
		public void TrueXUnitFactMethodAttribute()
		{
		}

		[FactAttribute()]
		public void TrueXUnitFactMethodAttributeParenthesis()
		{
		}

		[FactAttribute("A")]
		public void TrueXUnitFactMethodAttributeParameter()
		{
		}

		[FactAttribute("A", "B" = 2)]
		public void TrueXUnitFactMethodAttributeParameters()
		{
		}

		[Theory]
		public void TrueXUnitTheoryMethod()
		{
		}

		[Theory()]
		public void TrueXUnitTheoryMethodParenthesis()
		{
		}

		[Theory("A")]
		public void TrueXUnitTheoryMethodParameter()
		{
		}

		[Theory("A", "B" = 2)]
		public void TrueXUnitTheoryMethodParameters()
		{
		}

		[TheoryAttribute]
		public void TrueXUnitTheoryMethodAttribute()
		{
		}

		[TheoryAttribute()]
		public void TrueXUnitTheoryMethodAttributeParenthesis()
		{
		}

		[TheoryAttribute("A")]
		public void TrueXUnitTheoryMethodAttributeParameter()
		{
		}

		[TheoryAttribute("A", "B" = 2)]
		public void TrueXUnitTheoryMethodAttributeParameters()
		{
		}

		#endregion
	}
}
