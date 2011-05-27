using StyleCopPlus.Properties;

namespace StyleCopPlus
{
	/// <summary>
	/// Special setting for blocking @ character.
	/// </summary>
	public class BlockAtEntitySetting : EntitySetting
	{
		/// <summary>
		/// Gets help text for current setting.
		/// </summary>
		public override string HelpText
		{
			get { return Resources.EntitySettingEditorHelpBlockAt; }
		}
	}
}
