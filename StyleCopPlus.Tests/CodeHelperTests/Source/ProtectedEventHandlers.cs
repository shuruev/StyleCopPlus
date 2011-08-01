using System;

namespace StyleCopPlus.Tests
{
	public class Class1
	{
		private void FalseMethodIsNotProtected(object sender, EventArgs e)
		{
		}

		protected void FalseFirstArgumentIsNotObject(NotObject sender, EventArgs e)
		{
		}

		protected void FalseFirstArgumentHasWrongName(object notSender, EventArgs e)
		{
		}

		protected void FalseSecondArgumentIsNotEventArgs(object sender, EventArgsWrong e)
		{
		}

		protected void FalseSecondArgumentHasWrongName(object sender, EventArgs notE)
		{
		}

		protected void FalseUseAliasForObject1(Object sender, EventArgs e)
		{
		}

		protected void FalseUseAliasForObject2(System.Object sender, EventArgs e)
		{
		}

		protected int FalseReturnTypeIsNotVoid(object sender, EventArgs e)
		{
		}

		protected void TrueSimple(object sender, EventArgs e)
		{
		}

		protected void TrueComplexEventArgs(object sender, MouseEventArgs e)
		{
		}

		protected void TrueGenericEventArgs(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
		}
	}
}
