namespace StyleCopPlus
{
	/// <summary>
	/// Interface for entity setting that is edited in common dialog.
	/// </summary>
	public interface IEntitySetting
	{
		/// <summary>
		/// Gets help text for current setting.
		/// </summary>
		string HelpText { get; }

		/// <summary>
		/// Creates definition string from specified entity type.
		/// </summary>
		string ParseFrom(EntityType entities);

		/// <summary>
		/// Creates entity type from definition string.
		/// </summary>
		EntityType ConvertTo(string ruleDefinition);
	}
}
