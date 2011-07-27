using System;

namespace StyleCopPlus.Plugin.MoreCustom
{
	/// <summary>
	/// Indentation options data structure.
	/// </summary>
	public class IndentOptionsData : ICustomRuleOptionsData
	{
		private const IndentMode c_defaultMode = IndentMode.Tabs;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public IndentOptionsData()
		{
			Mode = c_defaultMode;
		}

		#region Properties

		/// <summary>
		/// Gets or sets indentation mode.
		/// </summary>
		public IndentMode Mode { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether space padding is allowed.
		/// </summary>
		public bool AllowPadding { get; set; }

		#endregion

		#region Implementation of ICustomRuleOptionsData

		/// <summary>
		/// Initializes object data from setting value.
		/// </summary>
		public void ConvertFromValue(string settingValue)
		{
			try
			{
				string[] parts = settingValue.Split(':');

				Mode = (IndentMode)Enum.Parse(typeof(IndentMode), parts[0]);
				AllowPadding = Boolean.Parse(parts[1]);
			}
			catch
			{
			}
		}

		/// <summary>
		/// Converts object data to setting value.
		/// </summary>
		public string ConvertToValue()
		{
			return String.Format("{0}:{1}", Mode, AllowPadding);
		}

		/// <summary>
		/// Gets a friendly description for options data.
		/// </summary>
		public string GetDescription()
		{
			string description;
			switch (Mode)
			{
				case IndentMode.Tabs:
					description = OptionsDataResources.IndentOptionsTabs;
					break;
				case IndentMode.Spaces:
					description = OptionsDataResources.IndentOptionsSpaces;
					break;
				case IndentMode.Both:
					description = OptionsDataResources.IndentOptionsBoth;
					break;
				default:
					throw new InvalidOperationException();
			}

			return AllowPadding ?
				String.Format(OptionsDataResources.IndentOptionsPaddingFormat, description) :
				description;
		}

		#endregion

		#region Additional methods

		/// <summary>
		/// Gets objects for constructing context string.
		/// </summary>
		public object[] GetContextValues()
		{
			switch (Mode)
			{
				case IndentMode.Tabs:
					return new object[] { OptionsDataResources.IndentContextTabs };
				case IndentMode.Spaces:
					return new object[] { OptionsDataResources.IndentContextSpaces };
				case IndentMode.Both:
					return new object[] { OptionsDataResources.IndentContextBoth };
				default:
					throw new InvalidOperationException();
			}
		}

		#endregion
	}
}
