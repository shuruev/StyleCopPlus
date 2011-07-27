#region AdvancedNamingRules // Check length (All)

//# (AdvancedNaming_CheckLength = 31)

//# [ERROR:8]
//# All types have short names.
namespace Sty.Tes
{
	using More.Tests;

	public class Te1 : BaseClass { }

	public class Te2 : BaseStruct { }

	public interface ITe : IBaseInterface { }

	public enum Te3 { }

	public delegate TOu TestDelegate<in TIn, out TOu>(TIn args)
		where TIn : IEnumerable<byte>
		where TOu : IEnumerable<byte>;
}
//# [END]

//# [ERROR:4]
//# All fields have short names.
namespace StyleCopPlus.Tests
{
	public class TestClass
	{
		public int Te1;
		public int Te2 { get; set; }
	}

	public enum TestEnum
	{
		It1,
		It2
	}
}
//# [END]

//# [ERROR:3]
//# All methods have short names.
namespace StyleCopPlus.Tests
{
	public delegate void Te1();

	public class TestClass
	{
		public event Te1 Te2;

		public void Te3()
		{
		}
	}
}
//# [END]

//# [ERROR:6]
//# All parameters have short names.
namespace StyleCopPlus.Tests
{
	public delegate bool TestDelegate(int x, int y);

	public class TestClass
	{
		public TestClass(int x, params string[] y)
		{
			TestDelegate lambda = (a, b) => a == b;
		}
	}
}
//# [END]

//# [ERROR:7]
//# All variables have short names.
namespace StyleCopPlus.Tests
{
	public class TestClass
	{
		public void TestMethod()
		{
			int a = 10;
			const int b = 20;

			la1:
			Thread t = new Thread(() =>
			{
				la2:
				int c = 30;
				const int d = 40;
			});
		}
	}
}
//# [END]

#endregion

#region AdvancedNamingRules // Check length (None)

//# (AdvancedNaming_CheckLength = 0)

//# [OK]
//# All types have short names.
namespace Sty.Tes
{
	using More.Tests;

	public class Te1 : BaseClass { }

	public class Te2 : BaseStruct { }

	public interface ITe : IBaseInterface { }

	public enum Te3 { }

	public delegate TOu TestDelegate<in TIn, out TOu>(TIn args)
		where TIn : IEnumerable<byte>
		where TOu : IEnumerable<byte>;
}
//# [END]

//# [OK]
//# All fields have short names.
namespace StyleCopPlus.Tests
{
	public class TestClass
	{
		public int Te1;
		public int Te2 { get; set; }
	}

	public enum TestEnum
	{
		It1,
		It2
	}
}
//# [END]

//# [OK]
//# All methods have short names.
namespace StyleCopPlus.Tests
{
	public delegate void Te1();

	public class TestClass
	{
		public event Te1 Te2;

		public void Te3()
		{
		}
	}
}
//# [END]

//# [OK]
//# All parameters have short names.
namespace StyleCopPlus.Tests
{
	public delegate bool TestDelegate(int x, int y);

	public class TestClass
	{
		public TestClass(int x, params string[] y)
		{
			TestDelegate lambda = (a, b) => a == b;
		}
	}
}
//# [END]

//# [OK]
//# All variables have short names.
namespace StyleCopPlus.Tests
{
	public class TestClass
	{
		public void TestMethod()
		{
			int a = 10;
			const int b = 20;

			la1:
			Thread t = new Thread(() =>
			{
				la2:
				int c = 30;
				const int d = 40;
			});
		}
	}
}
//# [END]

#endregion
