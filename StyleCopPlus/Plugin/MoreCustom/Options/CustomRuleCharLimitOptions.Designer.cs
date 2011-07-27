namespace StyleCopPlus.Plugin.MoreCustom
{
	partial class CustomRuleCharLimitOptions
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
			this.labelTabSize = new System.Windows.Forms.Label();
			this.textTabSize = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// labelTabSize
			// 
			this.labelTabSize.AutoSize = true;
			this.labelTabSize.Location = new System.Drawing.Point(3, 48);
			this.labelTabSize.Margin = new System.Windows.Forms.Padding(3);
			this.labelTabSize.Name = "labelTabSize";
			this.labelTabSize.Size = new System.Drawing.Size(50, 13);
			this.labelTabSize.TabIndex = 2;
			this.labelTabSize.Text = "Tab size:";
			this.labelTabSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textTabSize
			// 
			this.textTabSize.Location = new System.Drawing.Point(6, 67);
			this.textTabSize.Name = "textTabSize";
			this.textTabSize.Size = new System.Drawing.Size(32, 20);
			this.textTabSize.TabIndex = 3;
			this.textTabSize.TextChanged += new System.EventHandler(this.textTabSize_TextChanged);
			// 
			// CustomRuleCharLimitOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.labelTabSize);
			this.Controls.Add(this.textTabSize);
			this.Name = "CustomRuleCharLimitOptions";
			this.Controls.SetChildIndex(this.textLimit, 0);
			this.Controls.SetChildIndex(this.textTabSize, 0);
			this.Controls.SetChildIndex(this.labelTabSize, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelTabSize;
		private System.Windows.Forms.TextBox textTabSize;
	}
}
