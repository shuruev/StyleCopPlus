namespace StyleCopPlus.Plugin.AdvancedNaming
{
	/// <summary>
	/// Special setting for using English characters only.
	/// </summary>
	public class EnglishOnly : EntitySetting
	{
		/// <summary>
		/// Gets help text for current setting.
		/// </summary>
		public override string HelpText
		{
			get { return EntitySettingResources.EnglishOnlyHelp; }
		}
	}
}
