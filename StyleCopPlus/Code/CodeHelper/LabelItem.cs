using System.Collections.Generic;
using StyleCop.CSharp;

namespace StyleCopPlus
{
	/// <summary>
	/// Label item.
	/// </summary>
	public class LabelItem
	{
		/// <summary>
		/// Gets or sets label name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets label name.
		/// </summary>
		public IEnumerable<CsToken> Tokens { get; set; }

		/// <summary>
		/// Gets or sets line number.
		/// </summary>
		public int? LineNumber { get; set; }
	}
}
