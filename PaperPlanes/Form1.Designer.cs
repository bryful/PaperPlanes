namespace PaperPlanes
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
			PaperPlanes.PPWing ppTailVer;
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.exportPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ppPos1 = new PaperPlanes.PPPos();
			this.ppParamsList1 = new PaperPlanes.PPParamsList();
			this.drawWings1 = new PaperPlanes.DrawWings();
			this.ppMain = new PaperPlanes.PPWing();
			this.ppTailHor = new PaperPlanes.PPWing();
			this.ppTwin = new PaperPlanes.PPWing();
			ppTailVer = new PaperPlanes.PPWing();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1100, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exportPDFToolStripMenuItem,
            this.quitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.saveToolStripMenuItem.Text = "Save";
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.saveAsToolStripMenuItem.Text = "SaveAs";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(126, 6);
			// 
			// exportPDFToolStripMenuItem
			// 
			this.exportPDFToolStripMenuItem.Name = "exportPDFToolStripMenuItem";
			this.exportPDFToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.exportPDFToolStripMenuItem.Text = "ExportPDF";
			this.exportPDFToolStripMenuItem.Click += new System.EventHandler(this.exportPDFToolStripMenuItem_Click);
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.quitToolStripMenuItem.Text = "Quit";
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.aboutToolStripMenuItem.Text = "バージョン情報の表示";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 610);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1100, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(10, 529);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(194, 12);
			this.label1.TabIndex = 8;
			this.label1.Text = "ただの棒はMAC85%の位置の重心です。";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Location = new System.Drawing.Point(10, 544);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(253, 12);
			this.label2.TabIndex = 9;
			this.label2.Text = "上矢印の棒はモーメント・アームから求めた重心です。";
			// 
			// backToolStripMenuItem
			// 
			this.backToolStripMenuItem.Name = "backToolStripMenuItem";
			this.backToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
			this.backToolStripMenuItem.Text = "Back";
			this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
			// 
			// ppPos1
			// 
			this.ppPos1.Location = new System.Drawing.Point(12, 559);
			this.ppPos1.Name = "ppPos1";
			this.ppPos1.Size = new System.Drawing.Size(209, 23);
			this.ppPos1.TabIndex = 10;
			this.ppPos1.Text = "ppPos1";
			this.ppPos1.ButttonClick += new System.EventHandler(this.backToolStripMenuItem_Click);
			// 
			// ppParamsList1
			// 
			this.ppParamsList1.Body = 0F;
			this.ppParamsList1.EditMode = PaperPlanes.DrawWings.EDIT_MODE.NORMAL;
			this.ppParamsList1.Location = new System.Drawing.Point(12, 27);
			this.ppParamsList1.MainArea = 51.31384F;
			this.ppParamsList1.Name = "ppParamsList1";
			this.ppParamsList1.SelectWing = 0;
			this.ppParamsList1.Size = new System.Drawing.Size(228, 499);
			this.ppParamsList1.TabIndex = 7;
			this.ppParamsList1.TailHorArea = 0F;
			this.ppParamsList1.TailHorAreaIdeal = 0F;
			this.ppParamsList1.TailHorVolum = 0F;
			this.ppParamsList1.TailVerArea = 0F;
			this.ppParamsList1.TailVerAreaIdeal = 0F;
			this.ppParamsList1.TailVerVolum = 0F;
			this.ppParamsList1.Text = "ppParamsList1";
			this.ppParamsList1.WingDihedral = 15F;
			this.ppParamsList1.WingPos = 40.2F;
			this.ppParamsList1.WingRoot = 33.7F;
			this.ppParamsList1.WingSpan = 178F;
			this.ppParamsList1.WingSpan2 = 0F;
			this.ppParamsList1.WingTip = 16.8F;
			this.ppParamsList1.WingTip2 = 0F;
			this.ppParamsList1.WingTipOffset = 5.2F;
			this.ppParamsList1.WingTipOffset2 = 0F;
			// 
			// drawWings1
			// 
			this.drawWings1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.drawWings1.BackColor = System.Drawing.Color.White;
			this.drawWings1.BaseLine = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
			this.drawWings1.DispLocation = ((System.Drawing.PointF)(resources.GetObject("drawWings1.DispLocation")));
			this.drawWings1.DPI = 82F;
			this.drawWings1.EditMode = PaperPlanes.DrawWings.EDIT_MODE.NORMAL;
			this.drawWings1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
			this.drawWings1.GridColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
			this.drawWings1.ImageFilePath = "";
			this.drawWings1.Location = new System.Drawing.Point(269, 27);
			this.drawWings1.MainWing = this.ppMain;
			this.drawWings1.Name = "drawWings1";
			this.drawWings1.ParamList = this.ppParamsList1;
			this.drawWings1.PPPos = this.ppPos1;
			this.drawWings1.Size = new System.Drawing.Size(819, 580);
			this.drawWings1.TabIndex = 2;
			this.drawWings1.TailH = this.ppTailHor;
			this.drawWings1.TailV = ppTailVer;
			this.drawWings1.Text = "drawWings1";
			this.drawWings1.TwinTail = this.ppTwin;
			// 
			// ppMain
			// 
			this.ppMain.ActiveWing = false;
			this.ppMain.DispLocation = ((System.Drawing.PointF)(resources.GetObject("ppMain.DispLocation")));
			this.ppMain.DPI = 82F;
			this.ppMain.HorColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(100)))));
			this.ppMain.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.ppMain.OriColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.ppMain.Params = new float[] {
        40.2F,
        33.7F,
        16.8F,
        5.2F,
        178F,
        15F,
        15F,
        20F,
        10F};
			this.ppMain.SelectIndex = -1;
			this.ppMain.VerColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(100)))));
			this.ppMain.WingDihedral = 15F;
			this.ppMain.WingPos = 40.2F;
			this.ppMain.WingRoot = 33.7F;
			this.ppMain.WingSpan = 178F;
			this.ppMain.WingSpan2 = 0F;
			this.ppMain.WingTip = 16.8F;
			this.ppMain.WingTip2 = 0F;
			this.ppMain.WingTipOffset = 5.2F;
			this.ppMain.WingTipOffset2 = 0F;
			// 
			// ppTailHor
			// 
			this.ppTailHor.ActiveWing = false;
			this.ppTailHor.DispLocation = ((System.Drawing.PointF)(resources.GetObject("ppTailHor.DispLocation")));
			this.ppTailHor.DPI = 82F;
			this.ppTailHor.HorColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(100)))));
			this.ppTailHor.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.ppTailHor.OriColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.ppTailHor.Params = new float[] {
        147.7F,
        22.9F,
        14.3F,
        10.2F,
        79.3F,
        0F,
        15F,
        20F,
        10F};
			this.ppTailHor.SelectIndex = -1;
			this.ppTailHor.VerColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(100)))));
			this.ppTailHor.WingDihedral = 0F;
			this.ppTailHor.WingPos = 147.7F;
			this.ppTailHor.WingRoot = 22.9F;
			this.ppTailHor.WingSpan = 79.3F;
			this.ppTailHor.WingSpan2 = 0F;
			this.ppTailHor.WingTip = 14.3F;
			this.ppTailHor.WingTip2 = 0F;
			this.ppTailHor.WingTipOffset = 10.2F;
			this.ppTailHor.WingTipOffset2 = 0F;
			// 
			// ppTailVer
			// 
			ppTailVer.ActiveWing = false;
			ppTailVer.DispLocation = ((System.Drawing.PointF)(resources.GetObject("ppTailVer.DispLocation")));
			ppTailVer.DPI = 82F;
			ppTailVer.HorColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(100)))));
			ppTailVer.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			ppTailVer.OriColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			ppTailVer.Params = new float[] {
        127.8F,
        29.5F,
        9.9F,
        24.2F,
        46.1F,
        0F,
        15F,
        20F,
        10F};
			ppTailVer.SelectIndex = -1;
			ppTailVer.VerColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(100)))));
			ppTailVer.WingDihedral = 0F;
			ppTailVer.WingPos = 127.8F;
			ppTailVer.WingRoot = 29.5F;
			ppTailVer.WingSpan = 46.1F;
			ppTailVer.WingSpan2 = 0F;
			ppTailVer.WingTip = 9.9F;
			ppTailVer.WingTip2 = 0F;
			ppTailVer.WingTipOffset = 24.2F;
			ppTailVer.WingTipOffset2 = 0F;
			// 
			// ppTwin
			// 
			this.ppTwin.ActiveWing = false;
			this.ppTwin.DispLocation = ((System.Drawing.PointF)(resources.GetObject("ppTwin.DispLocation")));
			this.ppTwin.DPI = 82F;
			this.ppTwin.HorColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(100)))));
			this.ppTwin.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.ppTwin.OriColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.ppTwin.Params = new float[] {
        137.1F,
        24.8F,
        17F,
        11.2F,
        65.9F,
        0F,
        14.6F,
        7.4F,
        12.7F};
			this.ppTwin.SelectIndex = -1;
			this.ppTwin.VerColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
			this.ppTwin.WingDihedral = 0F;
			this.ppTwin.WingPos = 137.1F;
			this.ppTwin.WingRoot = 24.8F;
			this.ppTwin.WingSpan = 65.9F;
			this.ppTwin.WingSpan2 = 14.6F;
			this.ppTwin.WingTip = 17F;
			this.ppTwin.WingTip2 = 7.4F;
			this.ppTwin.WingTipOffset = 11.2F;
			this.ppTwin.WingTipOffset2 = 12.7F;
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1100, 632);
			this.Controls.Add(this.ppPos1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ppParamsList1);
			this.Controls.Add(this.drawWings1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(800, 570);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private DrawWings drawWings1;
		private PPWing ppMain;
		private PPWing ppTailHor;
		private PPParamsList ppParamsList1;
		private PPWing ppTwin;
		private System.Windows.Forms.ToolStripMenuItem exportPDFToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
		private PPPos ppPos1;
	}
}

