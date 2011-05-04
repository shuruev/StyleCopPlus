namespace StyleCopPlus
{
	partial class WarningArea
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
			this.tableWarnings = new System.Windows.Forms.TableLayoutPanel();
			this.warningExample = new StyleCopPlus.WarningItem();
			this.tableWarnings.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableWarnings
			// 
			this.tableWarnings.AutoSize = true;
			this.tableWarnings.ColumnCount = 1;
			this.tableWarnings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableWarnings.Controls.Add(this.warningExample, 0, 0);
			this.tableWarnings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableWarnings.Location = new System.Drawing.Point(0, 0);
			this.tableWarnings.Margin = new System.Windows.Forms.Padding(0);
			this.tableWarnings.Name = "tableWarnings";
			this.tableWarnings.RowCount = 1;
			this.tableWarnings.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableWarnings.Size = new System.Drawing.Size(400, 24);
			this.tableWarnings.TabIndex = 0;
			// 
			// warningExample
			// 
			this.warningExample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.warningExample.AutoSize = true;
			this.warningExample.Location = new System.Drawing.Point(0, 0);
			this.warningExample.Margin = new System.Windows.Forms.Padding(0);
			this.warningExample.Name = "warningExample";
			this.warningExample.Size = new System.Drawing.Size(400, 24);
			this.warningExample.TabIndex = 0;
			// 
			// WarningArea
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.tableWarnings);
			this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.Name = "WarningArea";
			this.Size = new System.Drawing.Size(400, 24);
			this.Load += new System.EventHandler(this.WarningArea_Load);
			this.tableWarnings.ResumeLayout(false);
			this.tableWarnings.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableWarnings;
		private StyleCopPlus.WarningItem warningExample;
	}
}
