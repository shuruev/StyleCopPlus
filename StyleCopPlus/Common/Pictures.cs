using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using StyleCopPlus.Properties;

namespace StyleCopPlus
{
	/// <summary>
	/// Managing pictures and image lists.
	/// </summary>
	internal static class Pictures
	{
		#region Picture codes

		internal const string RuleDisabled = "RuleDisabled";
		internal const string RuleEnabled = "RuleEnabled";
		internal const string CapitalLetter = "CapitalLetter";
		internal const string TwoLetters = "TwoLetters";
		internal const string RightArrow = "RightArrow";
		internal const string AtSign = "AtSign";
		internal const string English = "English";
		internal const string NameLength = "NameLength";
		internal const string Warning = "Warning";

		#endregion

		private static readonly Dictionary<string, Image> s_images;

		static Pictures()
		{
			s_images = new Dictionary<string, Image>();

			s_images.Add(RuleDisabled, Resources.RuleDisabled);
			s_images.Add(RuleEnabled, Resources.RuleEnabled);
			s_images.Add(CapitalLetter, Resources.CapitalLetter);
			s_images.Add(TwoLetters, Resources.TwoLetters);
			s_images.Add(RightArrow, Resources.RightArrow);
			s_images.Add(AtSign, Resources.AtSign);
			s_images.Add(English, Resources.English);
			s_images.Add(NameLength, Resources.NameLength);
			s_images.Add(Warning, Resources.Warning);
		}

		#region Accessing pictures

		/// <summary>
		/// Checks whether storage contains specified picture.
		/// </summary>
		public static bool Contains(string key)
		{
			return s_images.ContainsKey(key);
		}

		/// <summary>
		/// Gets picture from specified cache.
		/// </summary>
		public static Image Get(string key)
		{
			return s_images[key];
		}

		/// <summary>
		/// Gets image list with all the pictures.
		/// </summary>
		public static ImageList GetList()
		{
			ImageList list = new ImageList();
			list.ColorDepth = ColorDepth.Depth32Bit;
			list.ImageSize = new Size(16, 16);

			foreach (string key in s_images.Keys)
			{
				Image image = s_images[key];
				list.Images.Add(key, image);
			}

			return list;
		}

		#endregion
	}
}
