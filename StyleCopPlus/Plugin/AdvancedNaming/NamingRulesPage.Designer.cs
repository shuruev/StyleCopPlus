namespace StyleCopPlus.Plugin.AdvancedNaming
{
	partial class NamingRulesPage
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NamingRulesPage));
			this.warningArea = new StyleCopPlus.WarningArea();
			this.panelMain = new System.Windows.Forms.Panel();
			this.learnMore = new StyleCopPlus.LearnMore();
			this.panelHelpBorder = new System.Windows.Forms.Panel();
			this.labelHelp = new System.Windows.Forms.Label();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.listRules = new System.Windows.Forms.ListView();
			this.columnRule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnPreview = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panelMain.SuspendLayout();
			this.panelHelpBorder.SuspendLayout();
			this.SuspendLayout();
			// 
			// warningArea
			// 
			this.warningArea.AutoSize = true;
			this.warningArea.Dock = System.Windows.Forms.DockStyle.Top;
			this.warningArea.Location = new System.Drawing.Point(0, 0);
			this.warningArea.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.warningArea.Name = "warningArea";
			this.warningArea.Size = new System.Drawing.Size(640, 24);
			this.warningArea.TabIndex = 1;
			// 
			// panelMain
			// 
			this.panelMain.Controls.Add(this.learnMore);
			this.panelMain.Controls.Add(this.panelHelpBorder);
			this.panelMain.Controls.Add(this.btnReset);
			this.panelMain.Controls.Add(this.btnEdit);
			this.panelMain.Controls.Add(this.listRules);
			this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMain.Location = new System.Drawing.Point(0, 24);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(640, 456);
			this.panelMain.TabIndex = 0;
			// 
			// learnMore
			// 
			this.learnMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.learnMore.LinkText = "How does it work?";
			this.learnMore.Location = new System.Drawing.Point(526, 3);
			this.learnMore.Name = "learnMore";
			this.learnMore.TabIndex = 1;
			this.learnMore.TargetUrl = "http://stylecopplus.codeplex.com/wikipage?title=Advanced%20Naming%20Rules";
			// 
			// panelHelpBorder
			// 
			this.panelHelpBorder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelHelpBorder.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panelHelpBorder.Controls.Add(this.labelHelp);
			this.panelHelpBorder.Location = new System.Drawing.Point(478, 54);
			this.panelHelpBorder.Name = "panelHelpBorder";
			this.panelHelpBorder.Size = new System.Drawing.Size(159, 399);
			this.panelHelpBorder.TabIndex = 4;
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
			this.labelHelp.Size = new System.Drawing.Size(157, 397);
			this.labelHelp.TabIndex = 0;
			this.labelHelp.Text = resources.GetString("labelHelp.Text");
			// 
			// btnReset
			// 
			this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReset.Location = new System.Drawing.Point(559, 25);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(75, 23);
			this.btnReset.TabIndex = 3;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Location = new System.Drawing.Point(478, 25);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(75, 23);
			this.btnEdit.TabIndex = 2;
			this.btnEdit.Text = "Edit...";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// listRules
			// 
			this.listRules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listRules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnRule,
            this.columnPreview});
			this.listRules.FullRowSelect = true;
			this.listRules.HideSelection = false;
			this.listRules.Location = new System.Drawing.Point(3, 3);
			this.listRules.Name = "listRules";
			this.listRules.Size = new System.Drawing.Size(469, 450);
			this.listRules.TabIndex = 0;
			this.listRules.UseCompatibleStateImageBehavior = false;
			this.listRules.View = System.Windows.Forms.View.Details;
			this.listRules.SelectedIndexChanged += new System.EventHandler(this.listRules_SelectedIndexChanged);
			this.listRules.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listRules_MouseDoubleClick);
			// 
			// columnRule
			// 
			this.columnRule.Text = "Naming Rule";
			this.columnRule.Width = 200;
			// 
			// columnPreview
			// 
			this.columnPreview.Text = "Preview";
			this.columnPreview.Width = 300;
			// 
			// NamingRulesPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panelMain);
			this.Controls.Add(this.warningArea);
			this.Name = "NamingRulesPage";
			this.Size = new System.Drawing.Size(640, 480);
			this.Load += new System.EventHandler(this.NamingRulesPage_Load);
			this.VisibleChanged += new System.EventHandler(this.NamingRulesPage_VisibleChanged);
			this.panelMain.ResumeLayout(false);
			this.panelHelpBorder.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private StyleCopPlus.WarningArea warningArea;
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.Panel panelHelpBorder;
		private System.Windows.Forms.Label labelHelp;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.ListView listRules;
		private System.Windows.Forms.ColumnHeader columnRule;
		private System.Windows.Forms.ColumnHeader columnPreview;
		private LearnMore learnMore;

	}
}
