namespace StyleCopPlus.Controls
{
	partial class LearnMore
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
			this.pictureIcon = new System.Windows.Forms.PictureBox();
			this.linkDetails = new System.Windows.Forms.LinkLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureIcon
			// 
			this.pictureIcon.BackColor = System.Drawing.Color.White;
			this.pictureIcon.Image = global::StyleCopPlus.Properties.Resources.Help;
			this.pictureIcon.Location = new System.Drawing.Point(0, 0);
			this.pictureIcon.Name = "pictureIcon";
			this.pictureIcon.Size = new System.Drawing.Size(16, 16);
			this.pictureIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureIcon.TabIndex = 10;
			this.pictureIcon.TabStop = false;
			// 
			// linkDetails
			// 
			this.linkDetails.ActiveLinkColor = System.Drawing.Color.ForestGreen;
			this.linkDetails.AutoSize = true;
			this.linkDetails.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.linkDetails.LinkColor = System.Drawing.Color.ForestGreen;
			this.linkDetails.Location = new System.Drawing.Point(17, 1);
			this.linkDetails.Name = "linkDetails";
			this.linkDetails.Size = new System.Drawing.Size(69, 13);
			this.linkDetails.TabIndex = 0;
			this.linkDetails.TabStop = true;
			this.linkDetails.Text = "Learn more...";
			this.linkDetails.VisitedLinkColor = System.Drawing.Color.ForestGreen;
			this.linkDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDetails_LinkClicked);
			// 
			// LearnMore
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.pictureIcon);
			this.Controls.Add(this.linkDetails);
			this.Name = "LearnMore";
			this.Size = new System.Drawing.Size(90, 16);
			((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureIcon;
		private System.Windows.Forms.LinkLabel linkDetails;
	}
}
