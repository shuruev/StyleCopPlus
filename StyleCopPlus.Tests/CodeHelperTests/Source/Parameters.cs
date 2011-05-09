using System;
using System.Collections.Generic;
using System.Threading;

namespace StyleCopPlus.Tests
{
	public delegate bool Delegate1(int x, int y);

	public class Class1
	{
		public Class1(
			IEnumerable<int> list,
			IComparable<string> comparer)
		{
			Delegate1 del = delegate(
				int a,
				int b)
				{ return a == b; };

			Delegate1 lambda = (
				a,
				b) => a == b;

			new Delegate1(delegate(
				int a,
				int b)
				{ return a == b; }).GetHashCode();

			new Delegate1((
				a,
				b) => a == b).Invoke(1, 2);
		}

		public string Property1
		{
			get
			{
				new Delegate1((a, b) => a == b).Invoke(1, 2);
				return null;
			}
			set
			{
				new Delegate1((a, b) => a == b).Invoke(1, 2);
			}
		}

		public int this[int index]
		{
			get
			{
				new Delegate1((a, b) => a == b).Invoke(1, 2);
				return 0;
			}
			set
			{
				new Delegate1((a, b) => a == b).Invoke(1, 2);
			}
		}

		public void Method1(
			int count,
			ref byte size,
			out string text)
		{
			new Delegate1((a, b) => a == b).Invoke(1, 2);
			text = null;
		}

		public void Method2(params string[] args)
		{
			Thread thread = new Thread(
				delegate(object obj)
				{
					Console.WriteLine(obj.GetHashCode());
				});
		}

		public void Method3(string format, params string[] args)
		{
			Thread thread = new Thread(
				obj =>
				{
					Console.WriteLine(obj.GetHashCode());
				});
		}

		public static explicit operator Class1(int x)
		{
			new Delegate1((a, b) => a == b).Invoke(1, 2);
			return null;
		}

		public static implicit operator int(Class1 x)
		{
			new Delegate1((a, b) => a == b).Invoke(1, 2);
			return 0;
		}

		public static bool operator +(Class1 x, Class1 y)
		{
			new Delegate1((a, b) => a == b).Invoke(1, 2);
			return false;
		}
	}
}
