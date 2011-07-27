namespace StyleCopPlus.Plugin.AdvancedNaming
{
	partial class NamingRuleEditor
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
			this.listMacro = new System.Windows.Forms.ListView();
			this.columnMacro = new System.Windows.Forms.ColumnHeader();
			this.columnDescription = new System.Windows.Forms.ColumnHeader();
			this.btnInsert = new System.Windows.Forms.Button();
			this.checkDisable = new System.Windows.Forms.CheckBox();
			this.panelEditorBorder.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelEditorBorder
			// 
			this.panelEditorBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panelEditorBorder.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panelEditorBorder.Controls.Add(this.textEditor);
			this.panelEditorBorder.Location = new System.Drawing.Point(12, 12);
			this.panelEditorBorder.Name = "panelEditorBorder";
			this.panelEditorBorder.Size = new System.Drawing.Size(440, 136);
			this.panelEditorBorder.TabIndex = 0;
			// 
			// textEditor
			// 
			this.textEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textEditor.DefaultColor = System.Drawing.Color.Blue;
			this.textEditor.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textEditor.Location = new System.Drawing.Point(1, 1);
			this.textEditor.Margin = new System.Windows.Forms.Padding(1);
			this.textEditor.Name = "textEditor";
			this.textEditor.Size = new System.Drawing.Size(438, 134);
			this.textEditor.TabIndex = 0;
			this.textEditor.Highlight += new System.Windows.Forms.ControlEventHandler(this.textEditor_Highlight);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(296, 297);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(377, 297);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// listMacro
			// 
			this.listMacro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listMacro.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnMacro,
            this.columnDescription});
			this.listMacro.FullRowSelect = true;
			this.listMacro.HideSelection = false;
			this.listMacro.Location = new System.Drawing.Point(12, 154);
			this.listMacro.MultiSelect = false;
			this.listMacro.Name = "listMacro";
			this.listMacro.Size = new System.Drawing.Size(440, 137);
			this.listMacro.TabIndex = 1;
			this.listMacro.UseCompatibleStateImageBehavior = false;
			this.listMacro.View = System.Windows.Forms.View.Details;
			this.listMacro.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listMacro_MouseDoubleClick);
			this.listMacro.SelectedIndexChanged += new System.EventHandler(this.listMacro_SelectedIndexChanged);
			// 
			// columnMacro
			// 
			this.columnMacro.Text = "Macro";
			this.columnMacro.Width = 100;
			// 
			// columnDescription
			// 
			this.columnDescription.Text = "Description";
			this.columnDescription.Width = 260;
			// 
			// btnInsert
			// 
			this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnInsert.Location = new System.Drawing.Point(215, 297);
			this.btnInsert.Name = "btnInsert";
			this.btnInsert.Size = new System.Drawing.Size(75, 23);
			this.btnInsert.TabIndex = 3;
			this.btnInsert.Text = "Insert";
			this.btnInsert.UseVisualStyleBackColor = true;
			this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
			// 
			// checkDisable
			// 
			this.checkDisable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkDisable.AutoSize = true;
			this.checkDisable.Location = new System.Drawing.Point(12, 301);
			this.checkDisable.Name = "checkDisable";
			this.checkDisable.Size = new System.Drawing.Size(102, 17);
			this.checkDisable.TabIndex = 2;
			this.checkDisable.Text = "Turn off this rule";
			this.checkDisable.UseVisualStyleBackColor = true;
			this.checkDisable.CheckedChanged += new System.EventHandler(this.checkDisable_CheckedChanged);
			// 
			// NamingRuleEditor
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(464, 332);
			this.Controls.Add(this.checkDisable);
			this.Controls.Add(this.btnInsert);
			this.Controls.Add(this.listMacro);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.panelEditorBorder);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(440, 340);
			this.Name = "NamingRuleEditor";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "[Header Text]";
			this.Load += new System.EventHandler(this.NamingRuleEditor_Load);
			this.panelEditorBorder.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private HighlightTextBox textEditor;
		private System.Windows.Forms.Panel panelEditorBorder;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ListView listMacro;
		private System.Windows.Forms.Button btnInsert;
		private System.Windows.Forms.ColumnHeader columnMacro;
		private System.Windows.Forms.ColumnHeader columnDescription;
		private System.Windows.Forms.CheckBox checkDisable;
	}
}