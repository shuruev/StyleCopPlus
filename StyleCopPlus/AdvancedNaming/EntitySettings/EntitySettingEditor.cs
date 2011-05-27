using System;
using System.Windows.Forms;
using StyleCopPlus.Properties;

namespace StyleCopPlus
{
	/// <summary>
	/// Dialog for editing entity settings.
	/// </summary>
	public partial class EntitySettingEditor : Form, IAdvancedNamingEditor
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public EntitySettingEditor()
		{
			InitializeComponent();
		}

		#region Properties

		/// <summary>
		/// Gets or sets entity setting to work with.
		/// </summary>
		public IEntitySetting EntitySetting { get; set; }

		/// <summary>
		/// Gets or sets object name.
		/// </summary>
		public string ObjectName { get; set; }

		/// <summary>
		/// Gets or sets target rule string.
		/// </summary>
		public string TargetRule { get; set; }

		#endregion

		#region Event handlers

		private void SpecialSettingEditor_Load(object sender, EventArgs e)
		{
			if (EntitySetting == null)
				throw new InvalidOperationException("EntitySetting is not set.");

			if (String.IsNullOrEmpty(ObjectName))
				throw new InvalidOperationException("ObjectName is not set.");

			Text = String.Format(Resources.SpecialSettingEditorCaption, ObjectName);

			labelHelp.Text = EntitySetting.HelpText;

			EntityType entities = EntitySetting.ConvertTo(TargetRule);

			checkTypes.Checked = entities.Contains(EntityType.Types);
			checkFields.Checked = entities.Contains(EntityType.Fields);
			checkMethods.Checked = entities.Contains(EntityType.Methods);
			checkParameters.Checked = entities.Contains(EntityType.Parameters);
			checkVariables.Checked = entities.Contains(EntityType.Variables);
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			EntityType entities = EntityType.None;

			if (checkTypes.Checked)
				entities |= EntityType.Types;

			if (checkFields.Checked)
				entities |= EntityType.Fields;

			if (checkMethods.Checked)
				entities |= EntityType.Methods;

			if (checkParameters.Checked)
				entities |= EntityType.Parameters;

			if (checkVariables.Checked)
				entities |= EntityType.Variables;

			TargetRule = EntitySetting.ParseFrom(entities);
			DialogResult = DialogResult.OK;
		}

		#endregion
	}
}
