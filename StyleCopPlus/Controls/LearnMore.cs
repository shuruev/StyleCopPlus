using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace StyleCopPlus.Controls
{
	/// <summary>
	/// Displays link with more details.
	/// </summary>
	public partial class LearnMore : UserControl
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public LearnMore()
		{
			InitializeComponent();
		}

		#region Properties

		/// <summary>
		/// Gets or sets target URL.
		/// </summary>
		public string TargetUrl { get; set; }

		#endregion

		#region Event handlers

		private void linkDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (!String.IsNullOrEmpty(TargetUrl))
				Process.Start(TargetUrl);
		}

		#endregion
	}
}
