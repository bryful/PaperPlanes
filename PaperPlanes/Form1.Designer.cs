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
			PaperPlanes.PPWing ppTailVer;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.ppParamsList1 = new PaperPlanes.PPParamsList();
			this.drawWings1 = new PaperPlanes.DrawWings();
			this.ppTailHor = new PaperPlanes.PPWing();
			this.ppMain = new PaperPlanes.PPWing();
			this.ppTwin = new PaperPlanes.PPWing();
			this.ppV_Tail = new PaperPlanes.PPWing();
			ppTailVer = new PaperPlanes.PPWing();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ppTailVer
			// 
			ppTailVer.DispLocation = ((System.Drawing.PointF)(resources.GetObject("ppTailVer.DispLocation")));
			ppTailVer.DPI = 82F;
			ppTailVer.HorColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(100)))));
			ppTailVer.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			ppTailVer.OriColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			ppTailVer.Params = new float[] {
        158.8F,
        31.6F,
        15.8F,
        15.8F,
        55.4F,
        15F,
        15F,
        20F,
        10F};
			ppTailVer.SelectIndex = -1;
			ppTailVer.VerColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(100)))));
			ppTailVer.WingDihedral = 15F;
			ppTailVer.WingPos = 158.8F;
			ppTailVer.WingRoot = 31.6F;
			ppTailVer.WingSpan = 55.4F;
			ppTailVer.WingSpan2 = 0F;
			ppTailVer.WingTip = 15.8F;
			ppTailVer.WingTip2 = 0F;
			ppTailVer.WingTipOffset = 15.8F;
			ppTailVer.WingTipOffset2 = 0F;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(983, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.quitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.openToolStripMenuItem.Text = "Open";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.saveToolStripMenuItem.Text = "Save";
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.saveAsToolStripMenuItem.Text = "SaveAs";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.quitToolStripMenuItem.Text = "Quit";
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
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
			this.statusStrip1.Location = new System.Drawing.Point(0, 507);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(983, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// ppParamsList1
			// 
			this.ppParamsList1.EditMode = PaperPlanes.DrawWings.EDIT_MODE.NORMAL;
			this.ppParamsList1.Location = new System.Drawing.Point(12, 27);
			this.ppParamsList1.Name = "ppParamsList1";
			this.ppParamsList1.Size = new System.Drawing.Size(151, 315);
			this.ppParamsList1.TabIndex = 7;
			this.ppParamsList1.TargetWing = 0;
			this.ppParamsList1.Text = "ppParamsList1";
			this.ppParamsList1.WingDihedral = 15F;
			this.ppParamsList1.WingPos = 45F;
			this.ppParamsList1.WingRoot = 50F;
			this.ppParamsList1.WingSpan = 176.2F;
			this.ppParamsList1.WingSpan2 = 15F;
			this.ppParamsList1.WingTip = 23.9F;
			this.ppParamsList1.WingTip2 = 20F;
			this.ppParamsList1.WingTipOffset = 7.9F;
			this.ppParamsList1.WingTipOffset2 = 10F;
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
			this.drawWings1.Location = new System.Drawing.Point(169, 27);
			this.drawWings1.MainWing = this.ppMain;
			this.drawWings1.Name = "drawWings1";
			this.drawWings1.ParamList = this.ppParamsList1;
			this.drawWings1.Size = new System.Drawing.Size(772, 445);
			this.drawWings1.TabIndex = 2;
			this.drawWings1.TailH = this.ppTailHor;
			this.drawWings1.TailV = ppTailVer;
			this.drawWings1.Text = "drawWings1";
			this.drawWings1.TwinTail = this.ppTwin;
			this.drawWings1.V_Tail = this.ppV_Tail;
			// 
			// ppTailHor
			// 
			this.ppTailHor.DispLocation = ((System.Drawing.PointF)(resources.GetObject("ppTailHor.DispLocation")));
			this.ppTailHor.DPI = 82F;
			this.ppTailHor.HorColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(100)))));
			this.ppTailHor.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.ppTailHor.OriColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.ppTailHor.Params = new float[] {
        182.4F,
        30.3F,
        17F,
        14.2F,
        104.9F,
        15F,
        15F,
        20F,
        10F};
			this.ppTailHor.SelectIndex = -1;
			this.ppTailHor.VerColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(100)))));
			this.ppTailHor.WingDihedral = 0F;
			this.ppTailHor.WingPos = 182.4F;
			this.ppTailHor.WingRoot = 30.3F;
			this.ppTailHor.WingSpan = 104.9F;
			this.ppTailHor.WingSpan2 = 0F;
			this.ppTailHor.WingTip = 17F;
			this.ppTailHor.WingTip2 = 0F;
			this.ppTailHor.WingTipOffset = 14.2F;
			this.ppTailHor.WingTipOffset2 = 0F;
			// 
			// ppMain
			// 
			this.ppMain.DispLocation = ((System.Drawing.PointF)(resources.GetObject("ppMain.DispLocation")));
			this.ppMain.DPI = 82F;
			this.ppMain.HorColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(100)))));
			this.ppMain.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.ppMain.OriColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.ppMain.Params = new float[] {
        45F,
        50F,
        23.9F,
        7.9F,
        176.2F,
        15F,
        15F,
        20F,
        10F};
			this.ppMain.SelectIndex = -1;
			this.ppMain.VerColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(100)))));
			this.ppMain.WingDihedral = 0F;
			this.ppMain.WingPos = 45F;
			this.ppMain.WingRoot = 50F;
			this.ppMain.WingSpan = 176.2F;
			this.ppMain.WingSpan2 = 0F;
			this.ppMain.WingTip = 23.9F;
			this.ppMain.WingTip2 = 0F;
			this.ppMain.WingTipOffset = 7.9F;
			this.ppMain.WingTipOffset2 = 0F;
			// 
			// ppTwin
			// 
			this.ppTwin.DispLocation = ((System.Drawing.PointF)(resources.GetObject("ppTwin.DispLocation")));
			this.ppTwin.DPI = 82F;
			this.ppTwin.HorColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(100)))));
			this.ppTwin.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.ppTwin.OriColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.ppTwin.Params = new float[] {
        158.8F,
        31.6F,
        15.8F,
        15.8F,
        55.4F,
        15F,
        15F,
        20F,
        10F};
			this.ppTwin.SelectIndex = -1;
			this.ppTwin.VerColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
			this.ppTwin.WingDihedral = 0F;
			this.ppTwin.WingPos = 158.8F;
			this.ppTwin.WingRoot = 31.6F;
			this.ppTwin.WingSpan = 55.4F;
			this.ppTwin.WingSpan2 = 15F;
			this.ppTwin.WingTip = 15.8F;
			this.ppTwin.WingTip2 = 20F;
			this.ppTwin.WingTipOffset = 15.8F;
			this.ppTwin.WingTipOffset2 = 10F;
			// 
			// ppV_Tail
			// 
			this.ppV_Tail.DispLocation = ((System.Drawing.PointF)(resources.GetObject("ppV_Tail.DispLocation")));
			this.ppV_Tail.DPI = 82F;
			this.ppV_Tail.HorColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(100)))));
			this.ppV_Tail.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.ppV_Tail.OriColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.ppV_Tail.Params = new float[] {
        158.8F,
        31.6F,
        15.8F,
        15.8F,
        55.4F,
        15F,
        15F,
        20F,
        10F};
			this.ppV_Tail.SelectIndex = -1;
			this.ppV_Tail.VerColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
			this.ppV_Tail.WingDihedral = 15F;
			this.ppV_Tail.WingPos = 158.8F;
			this.ppV_Tail.WingRoot = 31.6F;
			this.ppV_Tail.WingSpan = 55.4F;
			this.ppV_Tail.WingSpan2 = 0F;
			this.ppV_Tail.WingTip = 15.8F;
			this.ppV_Tail.WingTip2 = 0F;
			this.ppV_Tail.WingTipOffset = 15.8F;
			this.ppV_Tail.WingTipOffset2 = 0F;
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(983, 529);
			this.Controls.Add(this.ppParamsList1);
			this.Controls.Add(this.drawWings1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
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
		private PPWing ppV_Tail;
	}
}

