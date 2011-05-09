using System;
using System.Runtime.InteropServices;

namespace StyleCopPlus
{
	/// <summary>
	/// Native method calls.
	/// </summary>
	internal static class Native
	{
		internal const uint WM_HSCROLL = 0x0114;
		internal const uint WM_VSCROLL = 0x0115;

		[DllImport("User32.dll")]
		internal static extern ulong SendMessage(
			IntPtr hWnd,
			uint msg,
			uint wParam,
			uint lParam);

		internal const uint SB_LINEUP = 0;
		internal const uint SB_LINELEFT = 0;
		internal const uint SB_LINEDOWN = 1;
		internal const uint SB_LINERIGHT = 1;
		internal const uint SB_PAGEUP = 2;
		internal const uint SB_PAGELEFT = 2;
		internal const uint SB_PAGEDOWN = 3;
		internal const uint SB_PAGERIGHT = 3;
		internal const uint SB_THUMBPOSITION = 4;
		internal const uint SB_THUMBTRACK = 5;
		internal const uint SB_TOP = 6;
		internal const uint SB_LEFT = 6;
		internal const uint SB_BOTTOM = 7;
		internal const uint SB_RIGHT = 7;
		internal const uint SB_ENDSCROLL = 8;

		internal const uint SB_HORZ = 0;
		internal const uint SB_VERT = 1;
		internal const uint SB_CTL = 2;
		internal const uint SB_BOTH = 3;

		internal const uint SIF_RANGE = 0x0001;
		internal const uint SIF_PAGE = 0x0002;
		internal const uint SIF_POS = 0x0004;
		internal const uint SIF_DISABLENOSCROLL = 0x0008;
		internal const uint SIF_TRACKPOS = 0x0010;
		internal const uint SIF_ALL = SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS;

		internal struct SCROLLINFO
		{
			internal uint Size;
			internal uint Mask;
			internal int Min;
			internal int Max;
			internal uint Page;
			internal int Pos;
			internal int TrackPos;
		}

		[DllImport("User32.dll")]
		internal static extern bool GetScrollInfo(
			IntPtr hwnd,
			int fnBar,
			ref SCROLLINFO lpsi);

		[DllImport("User32.dll")]
		internal static extern bool SetScrollInfo(
			IntPtr hwnd,
			int fnBar,
			ref SCROLLINFO lpsi,
			bool fRedraw);
	}
}
