using System.Collections.Generic;

namespace StyleCopPlus
{
	/// <summary>
	/// Special parameters for running StyleCop+ plug-in.
	/// </summary>
	public class SpecialRunningParameters
	{
		/// <summary>
		/// Gets or sets the only enabled rule.
		/// </summary>
		public string OnlyEnabledRule { get; set; }

		/// <summary>
		/// Gets or sets custom settings which will override any others.
		/// </summary>
		public Dictionary<string, object> CustomSettings { get; set; }
	}
}
