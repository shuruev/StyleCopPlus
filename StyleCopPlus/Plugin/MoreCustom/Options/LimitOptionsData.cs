using System;

namespace StyleCopPlus.Plugin.MoreCustom
{
	/// <summary>
	/// Limit options data structure.
	/// </summary>
	public class LimitOptionsData : ICustomRuleOptionsData
	{
		private readonly NumericValue m_limit;
		private readonly string m_textFormat;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public LimitOptionsData(NumericValue limit, string textFormat)
		{
			m_limit = limit;
			m_textFormat = textFormat;
		}

		#region Properties

		/// <summary>
		/// Gets limit value.
		/// </summary>
		public NumericValue Limit
		{
			get { return m_limit; }
		}

		#endregion

		#region Implementation of ICustomRuleOptionsData

		/// <summary>
		/// Initializes object data from setting value.
		/// </summary>
		public virtual void ConvertFromValue(string settingValue)
		{
			Limit.Parse(settingValue);
		}

		/// <summary>
		/// Converts object data to setting value.
		/// </summary>
		public virtual string ConvertToValue()
		{
			return Limit.Value.ToString();
		}

		/// <summary>
		/// Gets a friendly description for options data.
		/// </summary>
		public virtual string GetDescription()
		{
			return String.Format(m_textFormat, Limit.Value);
		}

		#endregion
	}
}
