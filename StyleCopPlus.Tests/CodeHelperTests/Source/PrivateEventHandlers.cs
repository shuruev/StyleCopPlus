using System;

namespace StyleCopPlus.Tests
{
	public class Class1
	{
		public void FalseMethodIsNotPrivate(object sender, EventArgs e)
		{
		}

		private void FalseFirstArgumentIsNotObject(NotObject sender, EventArgs e)
		{
		}

		private void FalseFirstArgumentHasWrongName(object notSender, EventArgs e)
		{
		}

		private void FalseSecondArgumentIsNotEventArgs(object sender, EventArgsWrong e)
		{
		}

		private void FalseSecondArgumentHasWrongName(object sender, EventArgs notE)
		{
		}

		private void FalseUseAliasForObject1(Object sender, EventArgs e)
		{
		}

		private void FalseUseAliasForObject2(System.Object sender, EventArgs e)
		{
		}

		private int FalseReturnTypeIsNotVoid(object sender, EventArgs e)
		{
		}

		private void TrueSimple(object sender, EventArgs e)
		{
		}

		private void TrueComplexEventArgs(object sender, MouseEventArgs e)
		{
		}

		private void TrueGenericEventArgs(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
		}
	}
}
