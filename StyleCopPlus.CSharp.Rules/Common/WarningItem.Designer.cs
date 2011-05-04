namespace StyleCopPlus
{
	partial class WarningItem
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
			this.panelBorder = new System.Windows.Forms.Panel();
			this.panelContent = new System.Windows.Forms.Panel();
			this.tableContent = new System.Windows.Forms.TableLayoutPanel();
			this.pictureIcon = new System.Windows.Forms.PictureBox();
			this.labelWarning = new System.Windows.Forms.Label();
			this.linkDetails = new System.Windows.Forms.LinkLabel();
			this.panelBorder.SuspendLayout();
			this.panelContent.SuspendLayout();
			this.tableContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// panelBorder
			// 
			this.panelBorder.AutoSize = true;
			this.panelBorder.BackColor = System.Drawing.Color.Firebrick;
			this.panelBorder.Controls.Add(this.panelContent);
			this.panelBorder.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelBorder.Location = new System.Drawing.Point(0, 0);
			this.panelBorder.Name = "panelBorder";
			this.panelBorder.Size = new System.Drawing.Size(240, 27);
			this.panelBorder.TabIndex = 0;
			// 
			// panelContent
			// 
			this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panelContent.AutoSize = true;
			this.panelContent.BackColor = System.Drawing.Color.MistyRose;
			this.panelContent.Controls.Add(this.tableContent);
			this.panelContent.Location = new System.Drawing.Point(1, 1);
			this.panelContent.Name = "panelContent";
			this.panelContent.Size = new System.Drawing.Size(238, 25);
			this.panelContent.TabIndex = 0;
			// 
			// tableContent
			// 
			this.tableContent.AutoSize = true;
			this.tableContent.ColumnCount = 4;
			this.tableContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.tableContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
			this.tableContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableContent.Controls.Add(this.pictureIcon, 0, 0);
			this.tableContent.Controls.Add(this.labelWarning, 1, 0);
			this.tableContent.Controls.Add(this.linkDetails, 2, 0);
			this.tableContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableContent.Location = new System.Drawing.Point(0, 0);
			this.tableContent.Name = "tableContent";
			this.tableContent.RowCount = 1;
			this.tableContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableContent.Size = new System.Drawing.Size(238, 25);
			this.tableContent.TabIndex = 0;
			// 
			// pictureIcon
			// 
			this.pictureIcon.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.pictureIcon.Image = global::StyleCopPlus.Properties.Resources.Warning;
			this.pictureIcon.Location = new System.Drawing.Point(8, 4);
			this.pictureIcon.Name = "pictureIcon";
			this.pictureIcon.Size = new System.Drawing.Size(16, 16);
			this.pictureIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureIcon.TabIndex = 1;
			this.pictureIcon.TabStop = false;
			// 
			// labelWarning
			// 
			this.labelWarning.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelWarning.AutoSize = true;
			this.labelWarning.Location = new System.Drawing.Point(32, 3);
			this.labelWarning.Margin = new System.Windows.Forms.Padding(0);
			this.labelWarning.Name = "labelWarning";
			this.labelWarning.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.labelWarning.Size = new System.Drawing.Size(116, 19);
			this.labelWarning.TabIndex = 0;
			this.labelWarning.Text = "[Example warning text.]";
			this.labelWarning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// linkDetails
			// 
			this.linkDetails.ActiveLinkColor = System.Drawing.Color.Firebrick;
			this.linkDetails.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.linkDetails.AutoSize = true;
			this.linkDetails.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.linkDetails.LinkColor = System.Drawing.Color.Firebrick;
			this.linkDetails.Location = new System.Drawing.Point(161, 6);
			this.linkDetails.Name = "linkDetails";
			this.linkDetails.Size = new System.Drawing.Size(69, 13);
			this.linkDetails.TabIndex = 1;
			this.linkDetails.TabStop = true;
			this.linkDetails.Text = "Learn more...";
			this.linkDetails.VisitedLinkColor = System.Drawing.Color.Firebrick;
			this.linkDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDetails_LinkClicked);
			// 
			// WarningItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.panelBorder);
			this.Name = "WarningItem";
			this.Size = new System.Drawing.Size(240, 27);
			this.panelBorder.ResumeLayout(false);
			this.panelBorder.PerformLayout();
			this.panelContent.ResumeLayout(false);
			this.panelContent.PerformLayout();
			this.tableContent.ResumeLayout(false);
			this.tableContent.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panelBorder;
		private System.Windows.Forms.Panel panelContent;
		private System.Windows.Forms.PictureBox pictureIcon;
		private System.Windows.Forms.Label labelWarning;
		private System.Windows.Forms.LinkLabel linkDetails;
		private System.Windows.Forms.TableLayoutPanel tableContent;
	}
}
