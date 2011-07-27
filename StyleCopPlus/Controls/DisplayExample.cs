using System;
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

		private void pictureUpper_Paint(object sender, PaintEventArgs e)
		{
			PictureBox box = (PictureBox)sender;
			e.Graphics.DrawImage(Resources.CurlBottomRightTransparent, box.Width - 72, box.Height - 25);
		}

		private void pictureLower_Paint(object sender, PaintEventArgs e)
		{
			PictureBox box = (PictureBox)sender;

			if (pictureUpper.Image != null)
			{
				e.Graphics.DrawImage(
					pictureUpper.Image,
					new Rectangle(0, 0, box.Width, box.Height),
					0,
					pictureUpper.Height,
					box.Width,
					box.Height,
					GraphicsUnit.Pixel);
			}

			e.Graphics.DrawImage(Resources.CurlBottomRightTransparent, box.Width - 24, box.Height - 78);
		}

		private void backgroundUpper_Paint(object sender, PaintEventArgs e)
		{
			PictureBox box = (PictureBox)sender;
			using (Pen pen = new Pen(s_borderColor))
			{
				e.Graphics.DrawLine(pen, 0, 0, box.Width, 0);
				e.Graphics.DrawLine(pen, 0, 0, 0, box.Height);
			}

			Rectangle rectLeft = new Rectangle(1, 1, box.Width - 105, 35);
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

			string text = (string)Tag;
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

		#endregion

		#region Service methods

		/// <summary>
		/// Invalidate all custom-drawn control areas.
		/// </summary>
		private void InvalidateAll()
		{
			pictureUpper.Invalidate();
			pictureLower.Invalidate();

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
			Tag = null;
			pictureUpper.Image = null;
			learnMore.TargetUrl = null;
			learnMore.Visible = false;

			InvalidateAll();
		}

		/// <summary>
		/// Displays specified example.
		/// </summary>
		public void Display(Image exampleImage, string exampleDescription, string exampleUrl)
		{
			Tag = exampleDescription;
			pictureUpper.Image = exampleImage;
			learnMore.TargetUrl = exampleUrl;
			learnMore.Visible = true;

			InvalidateAll();
		}

		#endregion
	}
}
