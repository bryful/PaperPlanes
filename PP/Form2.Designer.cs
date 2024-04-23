namespace PP
{
	partial class Form2
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
			PP.PMain pMain1 = new PP.PMain();
			PP.PTail pTail1 = new PP.PTail();
			this.pCanvas1 = new PP.PCanvas();
			this.pMainEdit1 = new PP.PMainEdit();
			this.pTailEdit1 = new PP.PTailEdit();
			this.SuspendLayout();
			// 
			// pCanvas1
			// 
			this.pCanvas1.BackColor = System.Drawing.Color.White;
			this.pCanvas1.DispPF = ((System.Drawing.PointF)(resources.GetObject("pCanvas1.DispPF")));
			this.pCanvas1.Dpi = 83F;
			this.pCanvas1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.pCanvas1.GridSize = ((System.Drawing.PointF)(resources.GetObject("pCanvas1.GridSize")));
			this.pCanvas1.Location = new System.Drawing.Point(240, 24);
			pMain1.Dpi = 83F;
			pMain1.Position = 0F;
			pMain1.Root = 40F;
			pMain1.Span = 90F;
			pMain1.Swept = 0F;
			pMain1.Tip = 30F;
			this.pCanvas1.Main = pMain1;
			this.pCanvas1.MainPosition = 0F;
			this.pCanvas1.Name = "pCanvas1";
			this.pCanvas1.Size = new System.Drawing.Size(516, 401);
			this.pCanvas1.SizeMM = new System.Drawing.SizeF(157.9084F, 122.7157F);
			this.pCanvas1.TabIndex = 0;
			pTail1.Dpi = 83F;
			pTail1.PosY = 100F;
			pTail1.Root = 20F;
			pTail1.Span = 40F;
			pTail1.Swept = 5F;
			pTail1.TailMode = PP.TailMode.Normal;
			pTail1.Tip = 10F;
			pTail1.VPosY = 80F;
			pTail1.VRoot = 20F;
			pTail1.VSpan = 30F;
			pTail1.VSwept = 10F;
			pTail1.VTip = 10F;
			this.pCanvas1.Tail = pTail1;
			this.pCanvas1.TailMode = PP.TailMode.Normal;
			// 
			// pMainEdit1
			// 
			this.pMainEdit1.Captions = new string[] {
        "Pos",
        "Span",
        "Root",
        "Tip",
        "Swept"};
			this.pMainEdit1.Location = new System.Drawing.Point(32, 24);
			this.pMainEdit1.Name = "pMainEdit1";
			this.pMainEdit1.PCanvas = this.pCanvas1;
			this.pMainEdit1.Size = new System.Drawing.Size(189, 175);
			this.pMainEdit1.TabIndex = 1;
			this.pMainEdit1.Text = "pMainEdit1";
			// 
			// pTailEdit1
			// 
			this.pTailEdit1.Location = new System.Drawing.Point(63, 184);
			this.pTailEdit1.Name = "pTailEdit1";
			this.pTailEdit1.PCanvas = this.pCanvas1;
			this.pTailEdit1.Size = new System.Drawing.Size(158, 188);
			this.pTailEdit1.TabIndex = 2;
			this.pTailEdit1.TailMode = PP.TailMode.Normal;
			this.pTailEdit1.Text = "pTailEdit1";
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.pTailEdit1);
			this.Controls.Add(this.pMainEdit1);
			this.Controls.Add(this.pCanvas1);
			this.Name = "Form2";
			this.Text = "Form2";
			this.ResumeLayout(false);

		}

		#endregion

		private PCanvas pCanvas1;
		private PMainEdit pMainEdit1;
		private PTailEdit pTailEdit1;
	}
}