namespace StyleCopPlus.Plugin.MoreCustom
{
	partial class CustomRuleLimitOptions
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
			this.textLimit = new System.Windows.Forms.TextBox();
			this.labelDescription = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textLimit
			// 
			this.textLimit.Location = new System.Drawing.Point(6, 22);
			this.textLimit.Name = "textLimit";
			this.textLimit.Size = new System.Drawing.Size(64, 20);
			this.textLimit.TabIndex = 1;
			this.textLimit.TextChanged += new System.EventHandler(this.textLimit_TextChanged);
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.Location = new System.Drawing.Point(3, 3);
			this.labelDescription.Margin = new System.Windows.Forms.Padding(3);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(69, 13);
			this.labelDescription.TabIndex = 0;
			this.labelDescription.Text = "[Description:]";
			this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CustomRuleLimitOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.textLimit);
			this.Name = "CustomRuleLimitOptions";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelDescription;
		protected System.Windows.Forms.TextBox textLimit;
	}
}
