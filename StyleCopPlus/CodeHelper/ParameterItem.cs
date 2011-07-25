using System.Collections.Generic;
using StyleCop.CSharp;

namespace StyleCopPlus
{
	/// <summary>
	/// Parameter item.
	/// </summary>
	public class ParameterItem
	{
		/// <summary>
		/// Gets or sets parameter name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets parameter tokens.
		/// </summary>
		public IEnumerable<CsToken> Tokens { get; set; }

		/// <summary>
		/// Gets or sets line number.
		/// </summary>
		public int? LineNumber { get; set; }
	}
}
