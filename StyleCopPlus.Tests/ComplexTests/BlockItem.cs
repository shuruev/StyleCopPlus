using System;
using System.Collections.Generic;

namespace StyleCopPlus.Tests.ComplexTests
{
	/// <summary>
	/// Block in test definition file.
	/// </summary>
	public class BlockItem
	{
		/// <summary>
		/// Rule being tested at the block.
		/// </summary>
		public string Rule = String.Empty;

		/// <summary>
		/// Rule comment.
		/// </summary>
		public string Comment = String.Empty;

		/// <summary>
		/// Custom settings.
		/// </summary>
		public Dictionary<string, object> CustomSettings = new Dictionary<string, object>();

		/// <summary>
		/// Block content.
		/// </summary>
		public string Content = String.Empty;
	}
}
