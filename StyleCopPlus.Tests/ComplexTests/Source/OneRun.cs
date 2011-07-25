#region AdvancedNamingRules // Blocking @ (Fields)

//# (AdvancedNaming_BlockAt = 2)

//# [ERROR:4]
//# All fields use @ characters.
namespace StyleCopPlus.Tests
{
	public class TestClass
	{
		public int @TestField;
		public int @TestProperty { get; set; }
	}

	public enum TestEnum
	{
		@Item1,
		@Item2
	}
}
//# [END]

//# [OK]
//# Only definitions are blocked, not the usage.
namespace StyleCopPlus.Tests
{
	public class TestClass
	{
		public int TestField;
		public int TestProperty { get; set; }

		public TestClass()
		{
			if (TestEnum.@Item1 == TestEnum.Item2)
			{
				@TestField = @TestProperty;
			}
		}
	}

	public enum TestEnum
	{
		Item1,
		Item2
	}
}
//# [END]

#endregion
