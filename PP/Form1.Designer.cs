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
			this.pWingEdit3 = new PP.PWingEdit();
			this.pCanvas1 = new PP.PCanvas();
			this.pWingEdit2 = new PP.PWingEdit();
			this.pWingEdit1 = new PP.PWingEdit();
			this.SuspendLayout();
			// 
			// pWingEdit3
			// 
			this.pWingEdit3.Canvas = this.pCanvas1;
			this.pWingEdit3.Captions = new string[] {
        "Pos",
        "Span",
        "Root",
        "Tip",
        "Swept"};
			this.pWingEdit3.EditMode = PP.EditMode.VTail;
			this.pWingEdit3.Location = new System.Drawing.Point(12, 384);
			this.pWingEdit3.Name = "pWingEdit3";
			this.pWingEdit3.Size = new System.Drawing.Size(296, 176);
			this.pWingEdit3.TabIndex = 3;
			this.pWingEdit3.Text = "pWingEdit3";
			// 
			// pCanvas1
			// 
			this.pCanvas1.BackColor = System.Drawing.Color.White;
			this.pCanvas1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
			this.pCanvas1.CanvasSize = new System.Drawing.SizeF(161.2747F, 168.3132F);
			this.pCanvas1.DispF = ((System.Drawing.PointF)(resources.GetObject("pCanvas1.DispF")));
			this.pCanvas1.Dpi = 83F;
			this.pCanvas1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.pCanvas1.GridSize = new System.Drawing.SizeF(5F, 5F);
			this.pCanvas1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.pCanvas1.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.pCanvas1.Location = new System.Drawing.Point(327, 40);
			this.pCanvas1.Name = "pCanvas1";
			this.pCanvas1.Size = new System.Drawing.Size(527, 550);
			this.pCanvas1.TabIndex = 0;
			this.pCanvas1.TailMode = PP.TailMode.Twin;
			// 
			// pWingEdit2
			// 
			this.pWingEdit2.Canvas = this.pCanvas1;
			this.pWingEdit2.Captions = new string[] {
        "Pos",
        "Span",
        "Root",
        "Tip",
        "Swept"};
			this.pWingEdit2.EditMode = PP.EditMode.HTail;
			this.pWingEdit2.Location = new System.Drawing.Point(13, 202);
			this.pWingEdit2.Name = "pWingEdit2";
			this.pWingEdit2.Size = new System.Drawing.Size(296, 176);
			this.pWingEdit2.TabIndex = 2;
			this.pWingEdit2.Text = "pWingEdit2";
			// 
			// pWingEdit1
			// 
			this.pWingEdit1.Canvas = this.pCanvas1;
			this.pWingEdit1.Captions = new string[] {
        "Pos",
        "Span",
        "Root",
        "Tip",
        "Swept"};
			this.pWingEdit1.EditMode = PP.EditMode.Main;
			this.pWingEdit1.Location = new System.Drawing.Point(13, 40);
			this.pWingEdit1.Name = "pWingEdit1";
			this.pWingEdit1.Size = new System.Drawing.Size(296, 176);
			this.pWingEdit1.TabIndex = 1;
			this.pWingEdit1.Text = "pWingEdit1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(866, 602);
			this.Controls.Add(this.pWingEdit3);
			this.Controls.Add(this.pWingEdit2);
			this.Controls.Add(this.pWingEdit1);
			this.Controls.Add(this.pCanvas1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private PCanvas pCanvas1;
		private PWingEdit pWingEdit1;
		private PWingEdit pWingEdit2;
		private PWingEdit pWingEdit3;
	}
}

