using System;

namespace StyleCopPlus.Plugin.MoreCustom
{
	/// <summary>
	/// Char limit options data structure.
	/// </summary>
	public class CharLimitOptionsData : LimitOptionsData
	{
		private readonly NumericValue m_tabSize;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public CharLimitOptionsData()
			: base(
				NumericValue.CreateCharLimit(),
				CustomRulesResources.LimitOptionsCharFormat)
		{
			m_tabSize = NumericValue.CreateTabSize();
		}

		#region Properties

		/// <summary>
		/// Gets tab size.
		/// </summary>
		public NumericValue TabSize
		{
			get { return m_tabSize; }
		}

		#endregion

		#region Implementation of ICustomRuleOptionsData

		/// <summary>
		/// Initializes object data from setting value.
		/// </summary>
		public override void ConvertFromValue(string settingValue)
		{
			try
			{
				string[] parts = settingValue.Split(':');

				Limit.Parse(parts[0]);
				TabSize.Parse(parts[1]);
			}
			catch
			{
			}
		}

		/// <summary>
		/// Converts object data to setting value.
		/// </summary>
		public override string ConvertToValue()
		{
			return String.Format("{0}:{1}", Limit.Value, TabSize.Value);
		}

		/// <summary>
		/// Gets a friendly description for options data.
		/// </summary>
		public override string GetDescription()
		{
			return String.Format(
				CustomRulesResources.CharLimitOptionsFormat,
				base.GetDescription(),
				TabSize.Value);
		}

		#endregion
	}
}
