namespace StyleCopPlus
{
	/// <summary>
	/// Tag object for setting.
	/// </summary>
	internal class SettingTag
	{
		/// <summary>
		/// Gets or sets setting name.
		/// </summary>
		internal string SettingName { get; set; }

		/// <summary>
		/// Gets or sets merged value.
		/// </summary>
		internal string MergedValue { get; set; }

		/// <summary>
		/// Gets or sets inherited value.
		/// </summary>
		internal string InheritedValue { get; set; }

		/// <summary>
		/// Gets a value indicating whether current setting is modified in current instance.
		/// </summary>
		internal bool Modified
		{
			get
			{
				return MergedValue != InheritedValue;
			}
		}
	}
}
