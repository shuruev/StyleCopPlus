using System;
using System.Windows.Forms;

namespace StyleCopPlus
{
	/// <summary>
	/// Control displaying custom rule options.
	/// </summary>
	public partial class CustomRuleOptions : UserControl
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public CustomRuleOptions()
		{
			InitializeComponent();
		}

		#region Properties

		/// <summary>
		/// Gets or sets underlying custom rule.
		/// </summary>
		public CustomRule Rule { get; set; }

		#endregion

		#region Events

		/// <summary>
		/// Occurs when options data is changed.
		/// </summary>
		public event EventHandler OptionsDataChanged;

		/// <summary>
		/// Raises OptionsDataChanged event.
		/// </summary>
		protected virtual void OnOptionsDataChanged(EventArgs e)
		{
			if (OptionsDataChanged != null)
				OptionsDataChanged(this, e);
		}

		#endregion

		#region Common methods

		/// <summary>
		/// Gets options text for specified setting value.
		/// </summary>
		public string GetOptionsText(string settingValue)
		{
			ICustomRuleOptionsData data = Rule.CreateOptionsData();
			data.ConvertFromValue(settingValue);

			return data.GetDescription();
		}

		/// <summary>
		/// Displays specified setting value.
		/// </summary>
		public void DisplayOptions(string settingValue)
		{
			ICustomRuleOptionsData data = Rule.CreateOptionsData();
			data.ConvertFromValue(settingValue);

			DisplayOptionsData(data);
		}

		/// <summary>
		/// Gets setting value from user interface.
		/// </summary>
		public string ParseOptions()
		{
			ICustomRuleOptionsData data = Rule.CreateOptionsData();
			ParseOptionsData(data);

			return data.ConvertToValue();
		}

		#endregion

		#region Methods to be overrided

		/// <summary>
		/// Displays specified options data.
		/// </summary>
		protected virtual void DisplayOptionsData(ICustomRuleOptionsData data)
		{
			throw new InvalidOperationException();
		}

		/// <summary>
		/// Gets options data from user interface.
		/// </summary>
		protected virtual void ParseOptionsData(ICustomRuleOptionsData data)
		{
			throw new InvalidOperationException();
		}

		#endregion
	}
}
