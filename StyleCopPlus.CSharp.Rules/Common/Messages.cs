using System;
using System.Windows.Forms;
using StyleCopPlus.Properties;

namespace StyleCopPlus
{
	/// <summary>
	/// Displaying messages.
	/// </summary>
	public static class Messages
	{
		/// <summary>
		/// Displays information message.
		/// </summary>
		public static void ShowInformationOk(
			IWin32Window owner,
			string format,
			params object[] args)
		{
			string message = String.Format(format, args);
			MessageBox.Show(
				owner,
				message,
				Resources.CaptionInformation,
				MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}

		/// <summary>
		/// Displays warning message.
		/// </summary>
		public static void ShowWarningOk(
			IWin32Window owner,
			string format,
			params object[] args)
		{
			string message = String.Format(format, args);
			MessageBox.Show(
				owner,
				message,
				Resources.CaptionWarning,
				MessageBoxButtons.OK,
				MessageBoxIcon.Warning);
		}

		/// <summary>
		/// Displays warning message.
		/// </summary>
		public static DialogResult ShowWarningYesNo(
			IWin32Window owner,
			string format,
			params object[] args)
		{
			string message = String.Format(format, args);
			return MessageBox.Show(
				owner,
				message,
				Resources.CaptionWarning,
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Warning);
		}

		/// <summary>
		/// Displays warning message.
		/// </summary>
		public static DialogResult ShowWarningYesNoCancel(
			IWin32Window owner,
			string format,
			params object[] args)
		{
			string message = String.Format(format, args);
			return MessageBox.Show(
				owner,
				message,
				Resources.CaptionWarning,
				MessageBoxButtons.YesNoCancel,
				MessageBoxIcon.Warning);
		}

		/// <summary>
		/// Displays error message.
		/// </summary>
		public static void ShowErrorOk(
			IWin32Window owner,
			string format,
			params object[] args)
		{
			string message = String.Format(format, args);
			MessageBox.Show(
				owner,
				message,
				Resources.CaptionError,
				MessageBoxButtons.OK,
				MessageBoxIcon.Error);
		}
	}
}
