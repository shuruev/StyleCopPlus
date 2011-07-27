using System.Collections;
using System.Windows.Forms.Design;

namespace StyleCopPlus
{
	/// <summary>
	/// Designer class for LearnMore control.
	/// </summary>
	public class LearnMoreDesigner : ControlDesigner
	{
		public override SelectionRules SelectionRules
		{
			get
			{
				return base.SelectionRules & ~SelectionRules.AllSizeable;
			}
		}

		protected override void PostFilterProperties(IDictionary properties)
		{
			properties.Remove("AutoScroll");
			properties.Remove("AutoScrollMargin");
			properties.Remove("AutoScrollMinSize");
			properties.Remove("BackgroundImage");
			properties.Remove("BackgroundImageLayout");
			properties.Remove("BorderStyle");
			properties.Remove("Margin");
			properties.Remove("MaximumSize");
			properties.Remove("MinimumSize");
			properties.Remove("Padding");
			properties.Remove("Size");
			properties.Remove("TabStop");
			base.PostFilterProperties(properties);
		}
	}
}
