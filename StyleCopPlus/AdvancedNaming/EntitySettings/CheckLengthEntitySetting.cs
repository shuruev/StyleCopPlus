using StyleCopPlus.Properties;

namespace StyleCopPlus
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
			get { return Resources.EntitySettingEditorHelpCheckLength; }
		}
	}
}
