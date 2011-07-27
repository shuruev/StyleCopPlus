using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace StyleCopPlus
{
	/// <summary>
	/// Displays link with more details.
	/// </summary>
	[Designer(typeof(LearnMoreDesigner))]
	public partial class LearnMore : UserControl
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public LearnMore()
		{
			TargetUrl = null;
			InitializeComponent();
		}

		#region Properties

		/// <summary>
		/// Gets or sets target URL.
		/// </summary>
		[Description("Gets or sets target URL.")]
		[DefaultValue(null)]
		public string TargetUrl { get; set; }

		/// <summary>
		/// Gets or sets link text.
		/// </summary>
		[Description("Gets or sets link text.")]
		[DefaultValue("Learn more...")]
		public string LinkText
		{
			get
			{
				return linkDetails.Text;
			}

			set
			{
				linkDetails.Text = value;
				Width = 0;
			}
		}

		#endregion

		#region Event handlers

		private void linkDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (!String.IsNullOrEmpty(TargetUrl))
				Process.Start(TargetUrl);
		}

		#endregion

		#region Control behaviour

		/// <summary>
		/// Performs the work of setting the specified bounds of this control.
		/// </summary>
		protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
		{
			base.SetBoundsCore(x, y, linkDetails.Width + 16, height, specified);
		}

		#endregion
	}
}
