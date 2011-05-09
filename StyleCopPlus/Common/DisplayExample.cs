using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using StyleCopPlus.Properties;

namespace StyleCopPlus
{
	/// <summary>
	/// Graphically displays an example for selected rule.
	/// </summary>
	public partial class DisplayExample : UserControl
	{
		private static readonly Color s_borderColor = Color.FromArgb(118, 118, 118);

		private Image m_sample;
		private string m_exampleUrl;
		private string m_exampleDescription;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public DisplayExample()
		{
			InitializeComponent();
			Clear();
		}

		#region Event handlers

		private void DisplayExample_SizeChanged(object sender, EventArgs e)
		{
			InvalidateAll();
		}

		private void DisplayExample_BackColorChanged(object sender, EventArgs e)
		{
			UpdateCurlSample();
			InvalidateAll();
		}

		private void pictureExample_Paint(object sender, PaintEventArgs e)
		{
			if (m_sample == null)
				UpdateCurlSample();

			if (m_sample != null)
			{
				PictureBox box = (PictureBox)sender;
				e.Graphics.DrawImage(m_sample, box.Width - 72, box.Height - 78);
			}
		}

		private void backgroundUpper_Paint(object sender, PaintEventArgs e)
		{
			PictureBox box = (PictureBox)sender;
			using (Pen pen = new Pen(s_borderColor))
			{
				e.Graphics.DrawLine(pen, 0, 0, box.Width, 0);
				e.Graphics.DrawLine(pen, 0, 0, 0, box.Height);
			}

			Rectangle rectLeft = new Rectangle(1, 1, box.Width - 90, 35);
			using (LinearGradientBrush brush = new LinearGradientBrush(
				rectLeft,
				SystemColors.Info,
				Color.White,
				LinearGradientMode.Vertical))
			{
				e.Graphics.FillRectangle(brush, rectLeft);
			}

			Rectangle rectRight = new Rectangle(rectLeft.Right - 150, rectLeft.Top, 150, rectLeft.Height);
			using (LinearGradientBrush brush = new LinearGradientBrush(
				rectRight,
				Color.Transparent,
				Color.White,
				LinearGradientMode.Horizontal))
			{
				e.Graphics.FillRectangle(brush, rectRight);
			}

			using (LinearGradientBrush brush = new LinearGradientBrush(
				new Point(0, 0),
				new Point(Math.Min(400, box.Width - 40), 0),
				s_borderColor,
				Color.White))
			{
				e.Graphics.FillRectangle(brush, 8, 25, Math.Min(380, box.Width - 60), 1);
			}

			string text = m_exampleDescription;
			Color color = SystemColors.ControlText;
			if (String.IsNullOrEmpty(text))
			{
				text = Resources.EmptyExampleDescription;
				color = SystemColors.ControlDarkDark;
			}

			Rectangle bounds = new Rectangle(8, 7, rectLeft.Width, rectLeft.Height);
			using (StringFormat sf = new StringFormat())
			{
				using (SolidBrush brush = new SolidBrush(color))
				{
					sf.Trimming = StringTrimming.EllipsisCharacter;
					sf.FormatFlags = StringFormatFlags.NoWrap;
					e.Graphics.DrawString(text, Font, brush, bounds, sf);
				}
			}
		}

		private void backgroundLower_Paint(object sender, PaintEventArgs e)
		{
			PictureBox box = (PictureBox)sender;
			using (Pen pen = new Pen(s_borderColor))
			{
				e.Graphics.DrawLine(pen, 0, 0, 0, box.Height);
			}
		}

		private void borderBottomLeft_Paint(object sender, PaintEventArgs e)
		{
			using (Pen pen = new Pen(s_borderColor))
			{
				e.Graphics.DrawLine(pen, 0, 6, 32, 6);
				e.Graphics.DrawLine(pen, 0, 0, 0, 6);
			}
		}

		private void borderTopRight_Paint(object sender, PaintEventArgs e)
		{
			using (Pen pen = new Pen(s_borderColor))
			{
				e.Graphics.DrawLine(pen, 0, 0, 5, 0);
				e.Graphics.DrawLine(pen, 5, 0, 5, 32);
			}
		}

		private void linkDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (!String.IsNullOrEmpty(m_exampleUrl))
				Process.Start(m_exampleUrl);
		}

		#endregion

		#region Service methods

		/// <summary>
		/// Updates curl sample using current backgorund color.
		/// </summary>
		private void UpdateCurlSample()
		{
			Point[] points = new Point[7];
			points[0] = new Point(0, 96);
			points[1] = new Point(0, 85);
			points[2] = new Point(16, 85);
			points[3] = new Point(85, 10);
			points[4] = new Point(85, 0);
			points[5] = new Point(96, 0);
			points[6] = new Point(96, 96);

			m_sample = new Bitmap(96, 96);
			using (SolidBrush brush = new SolidBrush(BackColor))
			{
				Graphics graphics = Graphics.FromImage(m_sample);
				graphics.FillPolygon(brush, points);
				graphics.DrawImage(Resources.CurlBottomRightTransparent, 0, 0);
			}
		}

		/// <summary>
		/// Invalidate all custom-drawn control areas.
		/// </summary>
		private void InvalidateAll()
		{
			pictureExample.Invalidate();
			backgroundUpper.Invalidate();
			backgroundLower.Invalidate();
			borderBottomLeft.Invalidate();
			borderTopRight.Invalidate();
		}

		#endregion

		#region Displaying examples

		/// <summary>
		/// Clears example.
		/// </summary>
		public void Clear()
		{
			m_exampleUrl = null;
			m_exampleDescription = null;

			pictureExample.Image = null;
			pictureDetails.Visible = false;
			linkDetails.Visible = false;

			InvalidateAll();
		}

		/// <summary>
		/// Displays specified example.
		/// </summary>
		public void Display(Image exampleImage, string exampleDescription, string exampleUrl)
		{
			m_exampleUrl = exampleUrl;
			m_exampleDescription = exampleDescription;

			pictureExample.Image = exampleImage;
			pictureDetails.Visible = true;
			linkDetails.Visible = true;

			InvalidateAll();
		}

		#endregion
	}
}
