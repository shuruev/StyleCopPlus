using StyleCopPlus.Properties;

namespace StyleCopPlus
{
	/// <summary>
	/// Special setting for using English characters only.
	/// </summary>
	public class EnglishOnlyEntitySetting : EntitySetting
	{
		/// <summary>
		/// Gets help text for current setting.
		/// </summary>
		public override string HelpText
		{
			get { return Resources.EntitySettingEditorHelpEnglishOnly; }
		}
	}
}
