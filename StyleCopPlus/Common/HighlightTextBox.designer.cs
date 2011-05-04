namespace StyleCopPlus
{
	partial class HighlightTextBox
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
			this.richA = new System.Windows.Forms.RichTextBox();
			this.richB = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// richA
			// 
			this.richA.AcceptsTab = true;
			this.richA.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richA.DetectUrls = false;
			this.richA.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richA.HideSelection = false;
			this.richA.Location = new System.Drawing.Point(0, 0);
			this.richA.Name = "richA";
			this.richA.Size = new System.Drawing.Size(150, 150);
			this.richA.TabIndex = 0;
			this.richA.Text = "";
			this.richA.TextChanged += new System.EventHandler(this.rich_TextChanged);
			// 
			// richB
			// 
			this.richB.AcceptsTab = true;
			this.richB.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richB.DetectUrls = false;
			this.richB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richB.HideSelection = false;
			this.richB.Location = new System.Drawing.Point(0, 0);
			this.richB.Name = "richB";
			this.richB.Size = new System.Drawing.Size(150, 150);
			this.richB.TabIndex = 1;
			this.richB.Text = "";
			this.richB.Visible = false;
			this.richB.TextChanged += new System.EventHandler(this.rich_TextChanged);
			// 
			// HighlightTextBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.richA);
			this.Controls.Add(this.richB);
			this.Name = "HighlightTextBox";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox richA;
		private System.Windows.Forms.RichTextBox richB;
	}
}
