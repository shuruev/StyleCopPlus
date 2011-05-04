using System;

namespace StyleCopPlus
{
	/// <summary>
	/// Last line options data structure.
	/// </summary>
	public class LastLineOptionsData : ICustomRuleOptionsData
	{
		private const LastLineMode c_defaultMode = LastLineMode.Empty;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public LastLineOptionsData()
		{
			Mode = c_defaultMode;
		}

		#region Properties

		/// <summary>
		/// Gets or sets last line mode.
		/// </summary>
		public LastLineMode Mode { get; set; }

		#endregion

		#region Implementation of ICustomRuleOptionsData

		/// <summary>
		/// Initializes object data from setting value.
		/// </summary>
		public void ConvertFromValue(string settingValue)
		{
			try
			{
				Mode = (LastLineMode)Enum.Parse(typeof(LastLineMode), settingValue);
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
			return Mode.ToString();
		}

		/// <summary>
		/// Gets a friendly description for options data.
		/// </summary>
		public string GetDescription()
		{
			switch (Mode)
			{
				case LastLineMode.Empty:
					return CustomRulesResources.LastLineOptionsEmpty;
				case LastLineMode.NotEmpty:
					return CustomRulesResources.LastLineOptionsNotEmpty;
				default:
					throw new InvalidOperationException();
			}
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
				case LastLineMode.Empty:
					return new object[] { CustomRulesResources.LastLineContextEmpty };
				case LastLineMode.NotEmpty:
					return new object[] { CustomRulesResources.LastLineContextNotEmpty };
				default:
					throw new InvalidOperationException();
			}
		}

		#endregion
	}
}
