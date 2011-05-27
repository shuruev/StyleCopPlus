namespace StyleCopPlus
{
	partial class EntitySettingEditor
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.panelHelpBorder = new System.Windows.Forms.Panel();
			this.labelHelp = new System.Windows.Forms.Label();
			this.checkTypes = new System.Windows.Forms.CheckBox();
			this.groupTypes = new System.Windows.Forms.GroupBox();
			this.groupFields = new System.Windows.Forms.GroupBox();
			this.checkFields = new System.Windows.Forms.CheckBox();
			this.groupMethods = new System.Windows.Forms.GroupBox();
			this.checkMethods = new System.Windows.Forms.CheckBox();
			this.groupParameters = new System.Windows.Forms.GroupBox();
			this.checkParameters = new System.Windows.Forms.CheckBox();
			this.groupVariables = new System.Windows.Forms.GroupBox();
			this.checkVariables = new System.Windows.Forms.CheckBox();
			this.panelHelpBorder.SuspendLayout();
			this.groupTypes.SuspendLayout();
			this.groupFields.SuspendLayout();
			this.groupMethods.SuspendLayout();
			this.groupParameters.SuspendLayout();
			this.groupVariables.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(306, 357);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 5;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(387, 357);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// panelHelpBorder
			// 
			this.panelHelpBorder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelHelpBorder.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panelHelpBorder.Controls.Add(this.labelHelp);
			this.panelHelpBorder.Location = new System.Drawing.Point(12, 12);
			this.panelHelpBorder.Name = "panelHelpBorder";
			this.panelHelpBorder.Size = new System.Drawing.Size(450, 54);
			this.panelHelpBorder.TabIndex = 0;
			// 
			// labelHelp
			// 
			this.labelHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelHelp.BackColor = System.Drawing.SystemColors.Info;
			this.labelHelp.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.labelHelp.Location = new System.Drawing.Point(1, 1);
			this.labelHelp.Margin = new System.Windows.Forms.Padding(1);
			this.labelHelp.Name = "labelHelp";
			this.labelHelp.Padding = new System.Windows.Forms.Padding(2);
			this.labelHelp.Size = new System.Drawing.Size(448, 52);
			this.labelHelp.TabIndex = 0;
			this.labelHelp.Text = "[Help text will be displayed here.]";
			this.labelHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// checkTypes
			// 
			this.checkTypes.AutoSize = true;
			this.checkTypes.Location = new System.Drawing.Point(6, 19);
			this.checkTypes.Name = "checkTypes";
			this.checkTypes.Size = new System.Drawing.Size(368, 17);
			this.checkTypes.TabIndex = 0;
			this.checkTypes.Text = "Namespaces, classes, structs, interfaces, enumerations, type parameters";
			this.checkTypes.UseVisualStyleBackColor = true;
			// 
			// groupTypes
			// 
			this.groupTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupTypes.Controls.Add(this.checkTypes);
			this.groupTypes.Location = new System.Drawing.Point(12, 72);
			this.groupTypes.Name = "groupTypes";
			this.groupTypes.Size = new System.Drawing.Size(450, 48);
			this.groupTypes.TabIndex = 0;
			this.groupTypes.TabStop = false;
			this.groupTypes.Text = "Types";
			// 
			// groupFields
			// 
			this.groupFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupFields.Controls.Add(this.checkFields);
			this.groupFields.Location = new System.Drawing.Point(12, 126);
			this.groupFields.Name = "groupFields";
			this.groupFields.Size = new System.Drawing.Size(450, 48);
			this.groupFields.TabIndex = 1;
			this.groupFields.TabStop = false;
			this.groupFields.Text = "Fields";
			// 
			// checkFields
			// 
			this.checkFields.AutoSize = true;
			this.checkFields.Location = new System.Drawing.Point(6, 19);
			this.checkFields.Name = "checkFields";
			this.checkFields.Size = new System.Drawing.Size(196, 17);
			this.checkFields.TabIndex = 0;
			this.checkFields.Text = "Fields, properties, enumeration items";
			this.checkFields.UseVisualStyleBackColor = true;
			// 
			// groupMethods
			// 
			this.groupMethods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupMethods.Controls.Add(this.checkMethods);
			this.groupMethods.Location = new System.Drawing.Point(12, 180);
			this.groupMethods.Name = "groupMethods";
			this.groupMethods.Size = new System.Drawing.Size(450, 48);
			this.groupMethods.TabIndex = 2;
			this.groupMethods.TabStop = false;
			this.groupMethods.Text = "Methods";
			// 
			// checkMethods
			// 
			this.checkMethods.AutoSize = true;
			this.checkMethods.Location = new System.Drawing.Point(6, 19);
			this.checkMethods.Name = "checkMethods";
			this.checkMethods.Size = new System.Drawing.Size(157, 17);
			this.checkMethods.TabIndex = 0;
			this.checkMethods.Text = "Methods, events, delegates";
			this.checkMethods.UseVisualStyleBackColor = true;
			// 
			// groupParameters
			// 
			this.groupParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupParameters.Controls.Add(this.checkParameters);
			this.groupParameters.Location = new System.Drawing.Point(12, 234);
			this.groupParameters.Name = "groupParameters";
			this.groupParameters.Size = new System.Drawing.Size(450, 48);
			this.groupParameters.TabIndex = 3;
			this.groupParameters.TabStop = false;
			this.groupParameters.Text = "Parameters";
			// 
			// checkParameters
			// 
			this.checkParameters.AutoSize = true;
			this.checkParameters.Location = new System.Drawing.Point(6, 19);
			this.checkParameters.Name = "checkParameters";
			this.checkParameters.Size = new System.Drawing.Size(79, 17);
			this.checkParameters.TabIndex = 0;
			this.checkParameters.Text = "Parameters";
			this.checkParameters.UseVisualStyleBackColor = true;
			// 
			// groupVariables
			// 
			this.groupVariables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupVariables.Controls.Add(this.checkVariables);
			this.groupVariables.Location = new System.Drawing.Point(12, 288);
			this.groupVariables.Name = "groupVariables";
			this.groupVariables.Size = new System.Drawing.Size(450, 48);
			this.groupVariables.TabIndex = 4;
			this.groupVariables.TabStop = false;
			this.groupVariables.Text = "Variables";
			// 
			// checkVariables
			// 
			this.checkVariables.AutoSize = true;
			this.checkVariables.Location = new System.Drawing.Point(6, 19);
			this.checkVariables.Name = "checkVariables";
			this.checkVariables.Size = new System.Drawing.Size(130, 17);
			this.checkVariables.TabIndex = 0;
			this.checkVariables.Text = "Local variables, labels";
			this.checkVariables.UseVisualStyleBackColor = true;
			// 
			// EntitySettingEditor
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(474, 392);
			this.Controls.Add(this.groupVariables);
			this.Controls.Add(this.groupParameters);
			this.Controls.Add(this.groupMethods);
			this.Controls.Add(this.groupFields);
			this.Controls.Add(this.groupTypes);
			this.Controls.Add(this.panelHelpBorder);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EntitySettingEditor";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "[Header Text]";
			this.Load += new System.EventHandler(this.SpecialSettingEditor_Load);
			this.panelHelpBorder.ResumeLayout(false);
			this.groupTypes.ResumeLayout(false);
			this.groupTypes.PerformLayout();
			this.groupFields.ResumeLayout(false);
			this.groupFields.PerformLayout();
			this.groupMethods.ResumeLayout(false);
			this.groupMethods.PerformLayout();
			this.groupParameters.ResumeLayout(false);
			this.groupParameters.PerformLayout();
			this.groupVariables.ResumeLayout(false);
			this.groupVariables.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel panelHelpBorder;
		private System.Windows.Forms.Label labelHelp;
		private System.Windows.Forms.CheckBox checkTypes;
		private System.Windows.Forms.GroupBox groupTypes;
		private System.Windows.Forms.GroupBox groupFields;
		private System.Windows.Forms.CheckBox checkFields;
		private System.Windows.Forms.GroupBox groupMethods;
		private System.Windows.Forms.CheckBox checkMethods;
		private System.Windows.Forms.GroupBox groupParameters;
		private System.Windows.Forms.CheckBox checkParameters;
		private System.Windows.Forms.GroupBox groupVariables;
		private System.Windows.Forms.CheckBox checkVariables;
	}
}