namespace StyleCopPlus
{
	/// <summary>
	/// Contains extensions for entity types.
	/// </summary>
	public static class EntityTypeExtensions
	{
		/// <summary>
		/// Checks whether specified entity is included into entities instance.
		/// </summary>
		public static bool Contains(this EntityType entities, EntityType entity)
		{
			return (entities & entity) != 0;
		}
	}
}
