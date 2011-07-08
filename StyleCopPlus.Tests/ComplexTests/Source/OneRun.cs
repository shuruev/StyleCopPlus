#region AdvancedNamingRules // Blocking @ (All)

//# (AdvancedNaming_BlockAt = All)

//# [ERROR]
//# Namespace contains @ character.
namespace StyleC\u006FpPlus.Tests
{
	public delegate bool @Delegate3<in @TInput>(@TInput @args)
		where TInput : IEnumerable<byte>;

	public class TestClass
	{
		public void TestMethod()
		{
		}
	}
}
//# [END]

#endregion
