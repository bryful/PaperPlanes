namespace PP
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			PP.PWing pWing1 = new PP.PWing();
			this.pTailEdit1 = new PP.PTailEdit();
			this.pCanvas1 = new PP.PCanvas();
			this.pMainEdit1 = new PP.PMainEdit();
			this.SuspendLayout();
			// 
			// pTailEdit1
			// 
			this.pTailEdit1.Location = new System.Drawing.Point(13, 219);
			this.pTailEdit1.Name = "pTailEdit1";
			this.pTailEdit1.PCanvas = this.pCanvas1;
			this.pTailEdit1.Size = new System.Drawing.Size(191, 315);
			this.pTailEdit1.TabIndex = 2;
			this.pTailEdit1.TailMode = PP.TailMode.Twin;
			this.pTailEdit1.Text = "pTailEdit1";
			// 
			// pCanvas1
			// 
			this.pCanvas1.BackColor = System.Drawing.Color.White;
			this.pCanvas1.DispPF = ((System.Drawing.PointF)(resources.GetObject("pCanvas1.DispPF")));
			this.pCanvas1.Dpi = 83F;
			this.pCanvas1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.pCanvas1.GridSize = ((System.Drawing.PointF)(resources.GetObject("pCanvas1.GridSize")));
			this.pCanvas1.Location = new System.Drawing.Point(211, 53);
			this.pCanvas1.MainPosition = 0F;
			this.pCanvas1.Name = "pCanvas1";
			this.pCanvas1.Size = new System.Drawing.Size(643, 452);
			this.pCanvas1.SizeMM = new System.Drawing.SizeF(196.7735F, 138.3229F);
			this.pCanvas1.TabIndex = 0;
			this.pCanvas1.TailMode = PP.TailMode.Twin;
			pWing1.Dpi = 83F;
			pWing1.HTailPos = 100F;
			pWing1.HTailRoot = 20F;
			pWing1.HTailSpan = 40F;
			pWing1.HTailSwept = 5F;
			pWing1.HTailTip = 10F;
			pWing1.MainPos = 0F;
			pWing1.MainRoot = 40F;
			pWing1.MainSpan = 90F;
			pWing1.MainSwept = 0F;
			pWing1.MainTip = 30F;
			pWing1.TailMode = PP.TailMode.Twin;
			pWing1.VTailPos = 103.4995F;
			pWing1.VTailRoot = 10F;
			pWing1.VTailSpan = 30F;
			pWing1.VTailSwept = 10F;
			pWing1.VTailTip = 10F;
			this.pCanvas1.Wing = pWing1;
			// 
			// pMainEdit1
			// 
			this.pMainEdit1.Captions = new string[] {
        "Pos",
        "Span",
        "Root",
        "Tip",
        "Swept"};
			this.pMainEdit1.Location = new System.Drawing.Point(13, 53);
			this.pMainEdit1.Name = "pMainEdit1";
			this.pMainEdit1.PCanvas = this.pCanvas1;
			this.pMainEdit1.Size = new System.Drawing.Size(180, 180);
			this.pMainEdit1.TabIndex = 1;
			this.pMainEdit1.Text = "pMainEdit1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(866, 602);
			this.Controls.Add(this.pTailEdit1);
			this.Controls.Add(this.pMainEdit1);
			this.Controls.Add(this.pCanvas1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private PCanvas pCanvas1;
		private PMainEdit pMainEdit1;
		private PTailEdit pTailEdit1;
	}
}

