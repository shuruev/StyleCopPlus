using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace StyleCopPlus
{
	/// <summary>
	/// Warning notification item.
	/// </summary>
	public partial class WarningItem : UserControl
	{
		private readonly string m_warningUrl;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public WarningItem()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public WarningItem(string warningText, string warningUrl)
			: this()
		{
			m_warningUrl = warningUrl;
			labelWarning.Text = warningText;
		}

		#region Event handlers

		private void linkDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (!String.IsNullOrEmpty(m_warningUrl))
				Process.Start(m_warningUrl);
		}

		#endregion
	}
}
