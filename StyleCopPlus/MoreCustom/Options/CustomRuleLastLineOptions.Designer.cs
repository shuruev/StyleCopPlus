namespace StyleCopPlus
{
	partial class CustomRuleLastLineOptions
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
			this.labelTitle = new System.Windows.Forms.Label();
			this.radioNotEmpty = new System.Windows.Forms.RadioButton();
			this.radioEmpty = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Location = new System.Drawing.Point(3, 3);
			this.labelTitle.Margin = new System.Windows.Forms.Padding(3);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(94, 13);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "The last code line:";
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// radioNotEmpty
			// 
			this.radioNotEmpty.Location = new System.Drawing.Point(6, 45);
			this.radioNotEmpty.Name = "radioNotEmpty";
			this.radioNotEmpty.Size = new System.Drawing.Size(180, 17);
			this.radioNotEmpty.TabIndex = 2;
			this.radioNotEmpty.TabStop = true;
			this.radioNotEmpty.Text = "Must not be empty";
			this.radioNotEmpty.UseVisualStyleBackColor = true;
			this.radioNotEmpty.CheckedChanged += new System.EventHandler(this.radioMode_CheckedChanged);
			// 
			// radioEmpty
			// 
			this.radioEmpty.Location = new System.Drawing.Point(6, 22);
			this.radioEmpty.Name = "radioEmpty";
			this.radioEmpty.Size = new System.Drawing.Size(180, 17);
			this.radioEmpty.TabIndex = 1;
			this.radioEmpty.TabStop = true;
			this.radioEmpty.Text = "Must be empty";
			this.radioEmpty.UseVisualStyleBackColor = true;
			this.radioEmpty.CheckedChanged += new System.EventHandler(this.radioMode_CheckedChanged);
			// 
			// CustomRuleLastLineOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.radioNotEmpty);
			this.Controls.Add(this.radioEmpty);
			this.Name = "CustomRuleLastLineOptions";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.RadioButton radioNotEmpty;
		private System.Windows.Forms.RadioButton radioEmpty;

	}
}
