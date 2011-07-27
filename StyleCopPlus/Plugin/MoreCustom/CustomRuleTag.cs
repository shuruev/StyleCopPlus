namespace StyleCopPlus.Plugin.MoreCustom
{
	/// <summary>
	/// Tag object for custom rule setting.
	/// </summary>
	internal class CustomRuleTag : SettingTag
	{
		/// <summary>
		/// Gets or sets rule object.
		/// </summary>
		internal CustomRule Rule { get; set; }

		/// <summary>
		/// Gets or sets rule options control.
		/// </summary>
		internal CustomRuleOptions OptionsControl { get; set; }
	}
}
