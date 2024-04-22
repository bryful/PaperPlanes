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
			PP.PMain pMain1 = new PP.PMain();
			PP.PTail pTail1 = new PP.PTail();
			this.pTailEdit1 = new PP.PTailEdit();
			this.pCanvas1 = new PP.PCanvas();
			this.pMainEdit2 = new PP.PMainEdit();
			this.SuspendLayout();
			// 
			// pTailEdit1
			// 
			this.pTailEdit1.Captions = new string[] {
        "H_Pos",
        "H_Span",
        "H_Root",
        "H_Tip",
        "H_Swept",
        "H_SweptLen",
        "V_Pos",
        "V_Span",
        "V_Root",
        "V_Tip",
        "V_Swept",
        "V_SweptLen"};
			this.pTailEdit1.Location = new System.Drawing.Point(22, 186);
			this.pTailEdit1.Name = "pTailEdit1";
			this.pTailEdit1.PCanvas = this.pCanvas1;
			this.pTailEdit1.Size = new System.Drawing.Size(210, 319);
			this.pTailEdit1.TabIndex = 2;
			this.pTailEdit1.Text = "Tail";
			// 
			// pCanvas1
			// 
			this.pCanvas1.BackColor = System.Drawing.Color.White;
			this.pCanvas1.Dpi = 83F;
			this.pCanvas1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.pCanvas1.GridSize = ((System.Drawing.PointF)(resources.GetObject("pCanvas1.GridSize")));
			this.pCanvas1.Location = new System.Drawing.Point(258, 12);
			pMain1.Dpi = 83F;
			pMain1.Position = 10F;
			pMain1.Root = 40F;
			pMain1.Span = 90F;
			pMain1.Swept = 0F;
			pMain1.SweptLength = 0F;
			pMain1.Tip = 30F;
			this.pCanvas1.Main = pMain1;
			this.pCanvas1.MainPosition = 10F;
			this.pCanvas1.Name = "pCanvas1";
			this.pCanvas1.Size = new System.Drawing.Size(609, 512);
			this.pCanvas1.SizeMM = new System.Drawing.SizeF(186.3687F, 156.6843F);
			this.pCanvas1.TabIndex = 0;
			pTail1.Dpi = 83F;
			pTail1.IsTwin = false;
			pTail1.Position = 100F;
			pTail1.Root = 20F;
			pTail1.Span = 40F;
			pTail1.Swept = 5F;
			pTail1.SweptLength = 3.499547F;
			pTail1.Tip = 10F;
			pTail1.VPosition = 80F;
			pTail1.VRoot = 20F;
			pTail1.VSpan = 30F;
			pTail1.VSwept = 10F;
			pTail1.VSweptLength = 5.289809F;
			pTail1.VTip = 10F;
			this.pCanvas1.Tail = pTail1;
			// 
			// pMainEdit2
			// 
			this.pMainEdit2.Captions = new string[] {
        "位置",
        "幅",
        "翼根長",
        "翼端長",
        "後退角",
        "後退"};
			this.pMainEdit2.Location = new System.Drawing.Point(42, 12);
			this.pMainEdit2.Name = "pMainEdit2";
			this.pMainEdit2.PCanvas = this.pCanvas1;
			this.pMainEdit2.Size = new System.Drawing.Size(190, 168);
			this.pMainEdit2.TabIndex = 1;
			this.pMainEdit2.Text = "Main";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(866, 602);
			this.Controls.Add(this.pTailEdit1);
			this.Controls.Add(this.pMainEdit2);
			this.Controls.Add(this.pCanvas1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private PCanvas pCanvas1;
		private PMainEdit pMainEdit1;
		private PMainEdit pMainEdit2;
		private PTailEdit pTailEdit1;
	}
}

