using System.Collections.Generic;
using StyleCop.CSharp;

namespace StyleCopPlus
{
	/// <summary>
	/// Type parameter item.
	/// </summary>
	public class TypeParameterItem
	{
		/// <summary>
		/// Gets or sets type parameter name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets type parameter tokens.
		/// </summary>
		public IEnumerable<CsToken> Tokens { get; set; }

		/// <summary>
		/// Gets or sets line number.
		/// </summary>
		public int? LineNumber { get; set; }
	}
}
