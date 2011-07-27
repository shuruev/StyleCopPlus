using System;

namespace StyleCopPlus.Plugin.AdvancedNaming
{
	/// <summary>
	/// Contains entity types.
	/// </summary>
	[Flags]
	public enum EntityType
	{
		/// <summary>
		/// None.
		/// </summary>
		None = 0,

		/// <summary>
		/// Namespaces, classes, structs, interfaces, enumerations, type parameters.
		/// </summary>
		Types = 1,

		/// <summary>
		/// Fields, properties, enumeration items.
		/// </summary>
		Fields = 2,

		/// <summary>
		/// Methods, events, delegates.
		/// </summary>
		Methods = 4,

		/// <summary>
		/// Parameters.
		/// </summary>
		Parameters = 8,

		/// <summary>
		/// Local variables, labels.
		/// </summary>
		Variables = 16,

		/// <summary>
		/// All.
		/// </summary>
		All = Types
			| Fields
			| Methods
			| Parameters
			| Variables
	}
}
