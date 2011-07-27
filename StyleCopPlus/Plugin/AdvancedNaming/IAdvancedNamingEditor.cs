using System;
using System.Windows.Forms;

namespace StyleCopPlus.Plugin.AdvancedNaming
{
	/// <summary>
	/// Interface for advanced naming rule editing dialogs.
	/// </summary>
	public interface IAdvancedNamingEditor : IDisposable
	{
		/// <summary>
		/// Gets or sets object name.
		/// </summary>
		string ObjectName { get; set; }

		/// <summary>
		/// Gets or sets target rule string.
		/// </summary>
		string TargetRule { get; set; }

		/// <summary>
		/// Shows the form as a modal dialog box with the specified owner.
		/// </summary>
		DialogResult ShowDialog(IWin32Window owner);
	}
}
