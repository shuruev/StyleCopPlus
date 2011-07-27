using System;
using System.Windows.Forms;
using StyleCopPlus.Properties;

namespace StyleCopPlus
{
	/// <summary>
	/// Notification area that displays warnings.
	/// </summary>
	public partial class WarningArea : UserControl
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public WarningArea()
		{
			InitializeComponent();
		}

		#region Event handlers

		private void WarningArea_Load(object sender, EventArgs e)
		{
			if (DesignMode)
				return;

			Clear();
		}

		#endregion

		#region Displaying warnings

		/// <summary>
		/// Clears all warnings.
		/// </summary>
		public void Clear()
		{
			tableWarnings.Controls.Clear();
			tableWarnings.RowCount = 0;
			tableWarnings.RowStyles.Clear();
		}

		/// <summary>
		/// Adds specified warning.
		/// </summary>
		/// <remarks>
		/// In future this method should be replaced with separate class
		/// holding all different warning types.
		/// </remarks>
		public void Add(string warningCode)
		{
			string warningText;
			if (warningCode == Resources.WarningDisabledAdvancedNamingRulesCode)
			{
				warningText = Resources.WarningDisabledAdvancedNamingRulesDescription;
			}
			else if (warningCode == Resources.WarningDontUseOriginalNamingRulesCode)
			{
				warningText = Resources.WarningDontUseOriginalNamingRulesDescription;
			}
			else
			{
				throw new InvalidOperationException(
					String.Format("Unknown warning code: {0}", warningCode));
			}

			string warningUrl = String.Format(Resources.WarningUrl, warningCode);

			Add(warningText, warningUrl);
		}

		/// <summary>
		/// Adds specified warning.
		/// </summary>
		public void Add(string warningText, string warningUrl)
		{
			tableWarnings.RowStyles.Add(new RowStyle(SizeType.AutoSize));
			tableWarnings.RowCount = tableWarnings.RowCount + 1;

			WarningItem item = new WarningItem(warningText, warningUrl);
			item.Margin = new Padding(4, 2, 4, 2);
			item.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			item.AutoSize = true;
			tableWarnings.Controls.Add(item, 0, tableWarnings.RowCount - 1);
		}

		#endregion
	}
}
