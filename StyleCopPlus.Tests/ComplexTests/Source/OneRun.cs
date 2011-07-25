#region AdvancedNamingRules // Blocking @ (All)

//# (AdvancedNaming_BlockAt = All1)

//# [ERROR]
//# Namespace contains @ character.
namespace @StyleCopPlus.Tests
{
	public class TestClass
	{
		public void TestMethod()
		{
		}
	}
}
//# [END]

#endregion
