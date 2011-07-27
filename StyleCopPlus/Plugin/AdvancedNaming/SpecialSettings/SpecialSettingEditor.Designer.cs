namespace StyleCopPlus.Plugin.AdvancedNaming
{
	partial class SpecialSettingEditor
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
			this.panelEditorBorder = new System.Windows.Forms.Panel();
			this.textEditor = new StyleCopPlus.HighlightTextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.panelHelpBorder = new System.Windows.Forms.Panel();
			this.labelHelp = new System.Windows.Forms.Label();
			this.panelEditorBorder.SuspendLayout();
			this.panelHelpBorder.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelEditorBorder
			// 
			this.panelEditorBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panelEditorBorder.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panelEditorBorder.Controls.Add(this.textEditor);
			this.panelEditorBorder.Location = new System.Drawing.Point(12, 72);
			this.panelEditorBorder.Name = "panelEditorBorder";
			this.panelEditorBorder.Size = new System.Drawing.Size(440, 134);
			this.panelEditorBorder.TabIndex = 1;
			// 
			// textEditor
			// 
			this.textEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textEditor.DefaultColor = System.Drawing.Color.Green;
			this.textEditor.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textEditor.Location = new System.Drawing.Point(1, 1);
			this.textEditor.Margin = new System.Windows.Forms.Padding(1);
			this.textEditor.Name = "textEditor";
			this.textEditor.Size = new System.Drawing.Size(438, 132);
			this.textEditor.TabIndex = 0;
			this.textEditor.Highlight += new System.Windows.Forms.ControlEventHandler(this.textEditor_Highlight);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(296, 212);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(377, 212);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
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
			this.panelHelpBorder.Size = new System.Drawing.Size(440, 54);
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
			this.labelHelp.Size = new System.Drawing.Size(438, 52);
			this.labelHelp.TabIndex = 0;
			this.labelHelp.Text = "[Help text will be displayed here.]";
			this.labelHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SpecialSettingEditor
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(464, 247);
			this.Controls.Add(this.panelHelpBorder);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.panelEditorBorder);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(440, 250);
			this.Name = "SpecialSettingEditor";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "[Header Text]";
			this.Load += new System.EventHandler(this.SpecialSettingEditor_Load);
			this.panelEditorBorder.ResumeLayout(false);
			this.panelHelpBorder.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private HighlightTextBox textEditor;
		private System.Windows.Forms.Panel panelEditorBorder;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel panelHelpBorder;
		private System.Windows.Forms.Label labelHelp;
	}
}