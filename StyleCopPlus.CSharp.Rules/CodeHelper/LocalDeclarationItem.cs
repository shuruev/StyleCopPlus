namespace StyleCopPlus
{
	/// <summary>
	/// Local declaration item.
	/// </summary>
	public class LocalDeclarationItem
	{
		/// <summary>
		/// Gets or sets local declaration name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether local declaration is a constant.
		/// </summary>
		public bool IsConstant { get; set; }

		/// <summary>
		/// Gets or sets line number.
		/// </summary>
		public int? LineNumber { get; set; }
	}
}
