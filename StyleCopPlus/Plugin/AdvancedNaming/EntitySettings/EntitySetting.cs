namespace StyleCopPlus.Plugin.AdvancedNaming
{
	/// <summary>
	/// Entity setting.
	/// </summary>
	public abstract class EntitySetting : IEntitySetting
	{
		private const string c_all = "All";
		private const string c_none = "None";

		/// <summary>
		/// Gets help text for current setting.
		/// </summary>
		public abstract string HelpText { get; }

		/// <summary>
		/// Creates definition string from specified entity type.
		/// </summary>
		public string ParseFrom(EntityType entities)
		{
			if (entities == EntityType.None)
				return c_none;

			if (entities == EntityType.All)
				return c_all;

			return ((int)entities).ToString();
		}

		/// <summary>
		/// Creates entity type from definition string.
		/// </summary>
		public EntityType ConvertTo(string ruleDefinition)
		{
			if (ruleDefinition == c_none)
				return EntityType.None;

			if (ruleDefinition == c_all)
				return EntityType.All;

			return (EntityType)int.Parse(ruleDefinition);
		}

		/// <summary>
		/// Gets preview text for entity setting.
		/// </summary>
		public string GetPreviewText(string settingValue)
		{
			EntityType entities = ConvertTo(settingValue);
			return entities.ToString();
		}
	}
}
