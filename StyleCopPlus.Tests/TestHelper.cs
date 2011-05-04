using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StyleCopPlus.Tests
{
	/// <summary>
	/// Helper methods for testing.
	/// </summary>
	public static class TestHelper
	{
		/// <summary>
		/// Simple delegate for code being tested.
		/// </summary>
		public delegate void TestCode();

		/// <summary>
		/// Checks whether specified code throws exception.
		/// </summary>
		public static void Throws(TestCode action)
		{
			bool throwed = false;

			try
			{
				action();
			}
			catch
			{
				throwed = true;
			}

			if (!throwed)
				throw new AssertFailedException("Expected exception was not thrown.");
		}
	}
}
