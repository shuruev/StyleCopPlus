using System;

namespace StyleCopPlus.Tests.ComplexTests
{
	/// <summary>
	/// Test in test definition file.
	/// </summary>
	public class TestItem
	{
		/// <summary>
		/// A value indicating whether test should be temporarily skipped.
		/// </summary>
		public bool Skip;

		/// <summary>
		/// A number of expected errors.
		/// </summary>
		public int ErrorCount;

		/// <summary>
		/// Test description.
		/// </summary>
		public string Description = String.Empty;

		/// <summary>
		/// Source code.
		/// </summary>
		public string SourceCode = String.Empty;
	}
}
