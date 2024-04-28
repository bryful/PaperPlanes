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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.eidtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tailModeBtns1 = new PP.TailModeBtns();
			this.pCanvas1 = new PP.PCanvas();
			this.pWingCalc1 = new PP.PWingCalc();
			this.pWingEdit3 = new PP.PWingEdit();
			this.pWingEdit2 = new PP.PWingEdit();
			this.pWingEdit1 = new PP.PWingEdit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.eidtToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1059, 24);
			this.menuStrip1.TabIndex = 5;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.quitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
			this.loadToolStripMenuItem.Text = "Load";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
			this.saveToolStripMenuItem.Text = "Save";
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
			this.quitToolStripMenuItem.Text = "Quit";
			// 
			// eidtToolStripMenuItem
			// 
			this.eidtToolStripMenuItem.Name = "eidtToolStripMenuItem";
			this.eidtToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.eidtToolStripMenuItem.Text = "Eidt";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// tailModeBtns1
			// 
			this.tailModeBtns1.Canvas = this.pCanvas1;
			this.tailModeBtns1.Caption = new string[] {
        "Normal",
        "Twin"};
			this.tailModeBtns1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.tailModeBtns1.Location = new System.Drawing.Point(355, 237);
			this.tailModeBtns1.Name = "tailModeBtns1";
			this.tailModeBtns1.Size = new System.Drawing.Size(225, 53);
			this.tailModeBtns1.TabIndex = 14;
			this.tailModeBtns1.TabStop = false;
			this.tailModeBtns1.TailMode = PP.TailMode.Normal;
			this.tailModeBtns1.Text = "TailMode";
			// 
			// pCanvas1
			// 
			this.pCanvas1.BackColor = System.Drawing.Color.White;
			this.pCanvas1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
			this.pCanvas1.CanvasSize = new System.Drawing.SizeF(129.7542F, 158.2145F);
			this.pCanvas1.DispF = ((System.Drawing.PointF)(resources.GetObject("pCanvas1.DispF")));
			this.pCanvas1.Dpi = 83F;
			this.pCanvas1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.pCanvas1.GridSize = new System.Drawing.SizeF(5F, 5F);
			this.pCanvas1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.pCanvas1.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.pCanvas1.Location = new System.Drawing.Point(606, 43);
			this.pCanvas1.Name = "pCanvas1";
			this.pCanvas1.Size = new System.Drawing.Size(424, 517);
			this.pCanvas1.TabIndex = 6;
			this.pCanvas1.TailMode = PP.TailMode.Twin;
			// 
			// pWingCalc1
			// 
			this.pWingCalc1.CaptionWidth = 80;
			this.pWingCalc1.EditWidth = 70;
			this.pWingCalc1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.pWingCalc1.Location = new System.Drawing.Point(24, 345);
			this.pWingCalc1.Name = "pWingCalc1";
			this.pWingCalc1.Size = new System.Drawing.Size(329, 264);
			this.pWingCalc1.TabIndex = 13;
			this.pWingCalc1.Text = "pWingCalc1";
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
			this.pWingEdit3.CaptionWidth = 70;
			this.pWingEdit3.EditMode = PP.EditMode.VTail;
			this.pWingEdit3.EditWidth = 70;
			this.pWingEdit3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.pWingEdit3.Location = new System.Drawing.Point(14, 218);
			this.pWingEdit3.Name = "pWingEdit3";
			this.pWingEdit3.Size = new System.Drawing.Size(291, 121);
			this.pWingEdit3.TabIndex = 9;
			this.pWingEdit3.Text = "pWingEdit3";
			this.pWingEdit3.Text2 = "";
			this.pWingEdit3.TextVisible = false;
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
			this.pWingEdit2.CaptionWidth = 70;
			this.pWingEdit2.EditMode = PP.EditMode.HTail;
			this.pWingEdit2.EditWidth = 70;
			this.pWingEdit2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.pWingEdit2.Location = new System.Drawing.Point(309, 69);
			this.pWingEdit2.Name = "pWingEdit2";
			this.pWingEdit2.Size = new System.Drawing.Size(291, 128);
			this.pWingEdit2.TabIndex = 8;
			this.pWingEdit2.Text = "pWingEdit2";
			this.pWingEdit2.Text2 = "";
			this.pWingEdit2.TextVisible = false;
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
			this.pWingEdit1.CaptionWidth = 70;
			this.pWingEdit1.EditMode = PP.EditMode.Main;
			this.pWingEdit1.EditWidth = 70;
			this.pWingEdit1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.pWingEdit1.Location = new System.Drawing.Point(12, 82);
			this.pWingEdit1.Name = "pWingEdit1";
			this.pWingEdit1.Size = new System.Drawing.Size(291, 130);
			this.pWingEdit1.TabIndex = 7;
			this.pWingEdit1.Text = "pWingEdit1";
			this.pWingEdit1.Text2 = "";
			this.pWingEdit1.TextVisible = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1059, 602);
			this.Controls.Add(this.tailModeBtns1);
			this.Controls.Add(this.pWingCalc1);
			this.Controls.Add(this.pWingEdit3);
			this.Controls.Add(this.pWingEdit2);
			this.Controls.Add(this.pWingEdit1);
			this.Controls.Add(this.pCanvas1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem eidtToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private PCanvas pCanvas1;
		private PWingEdit pWingEdit1;
		private PWingEdit pWingEdit2;
		private PWingEdit pWingEdit3;
		private PWingCalc pWingCalc1;
		private TailModeBtns tailModeBtns1;
	}
}

