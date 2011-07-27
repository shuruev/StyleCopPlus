namespace StyleCopPlus.Plugin.AdvancedNaming
{
	/// <summary>
	/// Special setting for checking name length.
	/// </summary>
	public class CheckLengthEntitySetting : EntitySetting
	{
		/// <summary>
		/// Gets help text for current setting.
		/// </summary>
		public override string HelpText
		{
			get { return EntitySettingResources.HelpCheckLength; }
		}
	}
}
