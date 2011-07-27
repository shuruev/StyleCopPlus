namespace StyleCopPlus.Plugin.MoreCustom
{
	partial class CustomRulesPage
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
			this.panelMain = new System.Windows.Forms.Panel();
			this.tableMain = new System.Windows.Forms.TableLayoutPanel();
			this.listRules = new System.Windows.Forms.ListView();
			this.columnRule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnOptions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.displayExample = new StyleCopPlus.DisplayExample();
			this.panelRule = new System.Windows.Forms.Panel();
			this.learnMore = new StyleCopPlus.LearnMore();
			this.groupOptions = new System.Windows.Forms.GroupBox();
			this.btnReset = new System.Windows.Forms.Button();
			this.checkEnabled = new System.Windows.Forms.CheckBox();
			this.panelOptions = new System.Windows.Forms.Panel();
			this.warningArea = new StyleCopPlus.WarningArea();
			this.panelMain.SuspendLayout();
			this.tableMain.SuspendLayout();
			this.panelRule.SuspendLayout();
			this.groupOptions.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelMain
			// 
			this.panelMain.Controls.Add(this.tableMain);
			this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMain.Location = new System.Drawing.Point(0, 24);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(640, 456);
			this.panelMain.TabIndex = 0;
			// 
			// tableMain
			// 
			this.tableMain.ColumnCount = 2;
			this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
			this.tableMain.Controls.Add(this.listRules, 0, 0);
			this.tableMain.Controls.Add(this.displayExample, 0, 1);
			this.tableMain.Controls.Add(this.panelRule, 1, 0);
			this.tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableMain.Location = new System.Drawing.Point(0, 0);
			this.tableMain.Name = "tableMain";
			this.tableMain.RowCount = 2;
			this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 256F));
			this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableMain.Size = new System.Drawing.Size(640, 456);
			this.tableMain.TabIndex = 0;
			this.tableMain.SizeChanged += new System.EventHandler(this.tableMain_SizeChanged);
			// 
			// listRules
			// 
			this.listRules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listRules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnRule,
            this.columnOptions});
			this.listRules.FullRowSelect = true;
			this.listRules.HideSelection = false;
			this.listRules.Location = new System.Drawing.Point(3, 3);
			this.listRules.Name = "listRules";
			this.listRules.Size = new System.Drawing.Size(414, 194);
			this.listRules.TabIndex = 0;
			this.listRules.UseCompatibleStateImageBehavior = false;
			this.listRules.View = System.Windows.Forms.View.Details;
			this.listRules.SelectedIndexChanged += new System.EventHandler(this.listRules_SelectedIndexChanged);
			this.listRules.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listRules_MouseDoubleClick);
			// 
			// columnRule
			// 
			this.columnRule.Text = "Rule";
			this.columnRule.Width = 300;
			// 
			// columnOptions
			// 
			this.columnOptions.Text = "Options";
			this.columnOptions.Width = 150;
			// 
			// displayExample
			// 
			this.displayExample.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableMain.SetColumnSpan(this.displayExample, 2);
			this.displayExample.Location = new System.Drawing.Point(3, 203);
			this.displayExample.MinimumSize = new System.Drawing.Size(245, 125);
			this.displayExample.Name = "displayExample";
			this.displayExample.Size = new System.Drawing.Size(634, 250);
			this.displayExample.TabIndex = 2;
			// 
			// panelRule
			// 
			this.panelRule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelRule.Controls.Add(this.learnMore);
			this.panelRule.Controls.Add(this.groupOptions);
			this.panelRule.Location = new System.Drawing.Point(420, 0);
			this.panelRule.Margin = new System.Windows.Forms.Padding(0);
			this.panelRule.Name = "panelRule";
			this.panelRule.Size = new System.Drawing.Size(220, 200);
			this.panelRule.TabIndex = 1;
			// 
			// learnMore
			// 
			this.learnMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.learnMore.LinkText = "How does it work?";
			this.learnMore.Location = new System.Drawing.Point(106, 3);
			this.learnMore.Name = "learnMore";
			this.learnMore.TabIndex = 0;
			this.learnMore.TargetUrl = "http://stylecopplus.codeplex.com/wikipage?title=More%20Custom%20Rules";
			// 
			// groupOptions
			// 
			this.groupOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupOptions.Controls.Add(this.btnReset);
			this.groupOptions.Controls.Add(this.checkEnabled);
			this.groupOptions.Controls.Add(this.panelOptions);
			this.groupOptions.Location = new System.Drawing.Point(3, 17);
			this.groupOptions.Name = "groupOptions";
			this.groupOptions.Size = new System.Drawing.Size(214, 180);
			this.groupOptions.TabIndex = 1;
			this.groupOptions.TabStop = false;
			this.groupOptions.Text = "Rule Options";
			// 
			// btnReset
			// 
			this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReset.Location = new System.Drawing.Point(133, 19);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(75, 23);
			this.btnReset.TabIndex = 1;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			// 
			// checkEnabled
			// 
			this.checkEnabled.AutoSize = true;
			this.checkEnabled.Location = new System.Drawing.Point(6, 23);
			this.checkEnabled.Name = "checkEnabled";
			this.checkEnabled.Size = new System.Drawing.Size(65, 17);
			this.checkEnabled.TabIndex = 0;
			this.checkEnabled.Text = "Enabled";
			this.checkEnabled.UseVisualStyleBackColor = true;
			// 
			// panelOptions
			// 
			this.panelOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelOptions.Location = new System.Drawing.Point(6, 48);
			this.panelOptions.Name = "panelOptions";
			this.panelOptions.Size = new System.Drawing.Size(202, 126);
			this.panelOptions.TabIndex = 2;
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
			// CustomRulesPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panelMain);
			this.Controls.Add(this.warningArea);
			this.Name = "CustomRulesPage";
			this.Size = new System.Drawing.Size(640, 480);
			this.Load += new System.EventHandler(this.CustomRulesPage_Load);
			this.VisibleChanged += new System.EventHandler(this.CustomRulesPage_VisibleChanged);
			this.panelMain.ResumeLayout(false);
			this.tableMain.ResumeLayout(false);
			this.panelRule.ResumeLayout(false);
			this.groupOptions.ResumeLayout(false);
			this.groupOptions.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private WarningArea warningArea;
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.ListView listRules;
		private System.Windows.Forms.ColumnHeader columnRule;
		private System.Windows.Forms.ColumnHeader columnOptions;
		private DisplayExample displayExample;
		private System.Windows.Forms.TableLayoutPanel tableMain;
		private System.Windows.Forms.Panel panelRule;
		private System.Windows.Forms.GroupBox groupOptions;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.CheckBox checkEnabled;
		private System.Windows.Forms.Panel panelOptions;
		private LearnMore learnMore;
	}
}
