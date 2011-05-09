using System.Windows.Forms;
using StyleCop;

namespace StyleCopPlus
{
	/// <summary>
	/// Page for StyleCop+ properties.
	/// </summary>
	public partial class PropertyPage : UserControl, IPropertyControlPage
	{
		private readonly SourceAnalyzer m_analyzer;

		private bool m_dirty;
		private PropertyControl m_tabControl;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public PropertyPage()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public PropertyPage(SourceAnalyzer analyzer)
			: this()
		{
			m_analyzer = analyzer;

			namingRulesPage.Page = this;
			customRulesPage.Page = this;
		}

		#region Properties

		/// <summary>
		/// Gets the name of the tab.
		/// </summary>
		public string TabName
		{
			get { return "StyleCop+"; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this control is dirty.
		/// </summary>
		public bool Dirty
		{
			get
			{
				return m_dirty;
			}

			set
			{
				m_dirty = value;
				m_tabControl.DirtyChanged();
			}
		}

		/// <summary>
		/// Gets underlying analyzer.
		/// </summary>
		public SourceAnalyzer Analyzer
		{
			get { return m_analyzer; }
		}

		/// <summary>
		/// Gets underlying tab control.
		/// </summary>
		public PropertyControl TabControl
		{
			get { return m_tabControl; }
		}

		#endregion

		#region Implementation of IPropertyControlPage

		/// <summary>
		/// Initializes the specified property control with the StyleCop settings file.
		/// </summary>
		public void Initialize(PropertyControl propertyControl)
		{
			m_tabControl = propertyControl;

			SettingsGrabber.Initialize(m_tabControl);
			namingRulesPage.Initialize();
			customRulesPage.Initialize();
		}

		/// <summary>
		/// Apply the modifications to the StyleCop settings file.
		/// </summary>
		public bool Apply()
		{
			if (!namingRulesPage.Apply())
				return false;

			if (!customRulesPage.Apply())
				return false;

			return true;
		}

		/// <summary>
		/// Pre apply the changes.
		/// </summary>
		public bool PreApply()
		{
			return true;
		}

		/// <summary>
		/// Post apply the changes.
		/// </summary>
		public void PostApply(bool wasDirty)
		{
			return;
		}

		/// <summary>
		/// Activates the control.
		/// </summary>
		public void Activate(bool activated)
		{
			return;
		}

		/// <summary>
		/// Refreshes the state of the settings override.
		/// </summary>
		public void RefreshSettingsOverrideState()
		{
			SettingsGrabber.Initialize(m_tabControl);

			namingRulesPage.RefreshSettingsOverrideState();
			customRulesPage.RefreshSettingsOverrideState();
		}

		#endregion
	}
}
