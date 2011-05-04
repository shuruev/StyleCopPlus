using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace StyleCopPlus
{
	/// <summary>
	/// Simple text box with highlighting support.
	/// </summary>
	[Description("Simple text box with highlighting support.")]
	public partial class HighlightTextBox : UserControl
	{
		private Color m_defaultColor = Color.Black;
		private bool m_readOnly = false;

		private RichTextBox m_active = null;
		private RichTextBox m_buffer = null;
		private bool m_busy = false;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public HighlightTextBox()
		{
			InitializeComponent();

			m_active = richA;
			m_buffer = richB;

			rich_TextChanged(null, EventArgs.Empty);
		}

		#region Events

		/// <summary>
		/// Occurs when control must highlight its content.
		/// </summary>
		[Description("Occurs when control must highlight its content.")]
		public event ControlEventHandler Highlight;

		/// <summary>
		/// Raises Highlight event.
		/// </summary>
		protected virtual void OnHighlight(ControlEventArgs e)
		{
			if (Highlight != null)
				Highlight(this, e);
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the color that will be used for displaying content.
		/// </summary>
		[Description("Color that will be used for displaying content.")]
		[DefaultValue(typeof(Color), "Black")]
		public Color DefaultColor
		{
			get
			{
				return m_defaultColor;
			}

			set
			{
				m_defaultColor = value;

				rich_TextChanged(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether text in the control is read-only.
		/// </summary>
		[Description("Gets or sets a value indicating whether text in the control is read-only.")]
		[DefaultValue(false)]
		public bool ReadOnly
		{
			get
			{
				return m_readOnly;
			}

			set
			{
				m_readOnly = value;

				m_active.ReadOnly = value;
				m_buffer.ReadOnly = value;

				rich_TextChanged(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// Gets underlying text box control.
		/// </summary>
		public RichTextBox RichTextBox
		{
			get { return m_active; }
		}

		#endregion

		#region Event handlers

		private void rich_TextChanged(object sender, EventArgs e)
		{
			if (m_busy)
				return;

			m_busy = true;

			m_buffer.Text = m_active.Text;

			m_buffer.SelectAll();
			m_buffer.SelectionColor = m_defaultColor;

			ControlEventArgs args = new ControlEventArgs(m_buffer);
			OnHighlight(args);

			m_buffer.SelectionStart = m_active.SelectionStart;
			m_buffer.SelectionLength = m_active.SelectionLength;

			Native.SCROLLINFO si = new Native.SCROLLINFO();
			si.Size = (uint)Marshal.SizeOf(typeof(Native.SCROLLINFO));
			si.Mask = Native.SIF_POS;
			Native.GetScrollInfo(m_active.Handle, (int)Native.SB_VERT, ref si);
			Native.SetScrollInfo(m_buffer.Handle, (int)Native.SB_VERT, ref si, true);

			uint wparam = ((uint)si.Pos << 16) + Native.SB_THUMBPOSITION;
			Native.SendMessage(m_buffer.Handle, Native.WM_VSCROLL, wparam, 0);
			Native.SendMessage(m_buffer.Handle, Native.WM_VSCROLL, Native.SB_ENDSCROLL, 0);

			m_busy = false;

			RichTextBox temp = m_active;
			m_active = m_buffer;
			m_buffer = temp;

			m_active.BringToFront();
			m_active.Show();
			m_buffer.Hide();
			m_active.Focus();
		}

		#endregion
	}
}
