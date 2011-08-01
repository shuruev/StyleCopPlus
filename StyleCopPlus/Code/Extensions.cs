namespace StyleCopPlus
{
	/// <summary>
	/// Contains useful extensions.
	/// </summary>
	public static class Extensions
	{
		private const int c_trimExampleLength = 50;

		/// <summary>
		/// Trims example string before using it in error list.
		/// </summary>
		public static string TrimExample(this string example)
		{
			if (example.Length <= c_trimExampleLength)
				return example;

			return example.Substring(0, c_trimExampleLength) + "...";
		}
	}
}
