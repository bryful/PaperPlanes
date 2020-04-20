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
			PaperPlanes.PPWing ppVTail;
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
			this.ppHTail = new PaperPlanes.PPWing();
			this.ppMain = new PaperPlanes.PPWing();
			ppVTail = new PaperPlanes.PPWing();
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
			this.ppParamsList1.EditMode = PaperPlanes.DrawWings.EDITMODE.NORMAL;
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
			this.drawWings1.EditMode = PaperPlanes.DrawWings.EDITMODE.NORMAL;
			this.drawWings1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
			this.drawWings1.HTail = this.ppHTail;
			this.drawWings1.Location = new System.Drawing.Point(169, 27);
			this.drawWings1.MainWing = this.ppMain;
			this.drawWings1.Name = "drawWings1";
			this.drawWings1.ParamList = this.ppParamsList1;
			this.drawWings1.Size = new System.Drawing.Size(772, 445);
			this.drawWings1.TabIndex = 2;
			this.drawWings1.Text = "drawWings1";
			this.drawWings1.VTail = ppVTail;
			// 
			// ppHTail
			// 
			this.ppHTail.DispLocation = ((System.Drawing.PointF)(resources.GetObject("ppHTail.DispLocation")));
			this.ppHTail.DPI = 82F;
			this.ppHTail.Params = new float[] {
        182.4F,
        30.3F,
        17F,
        14.2F,
        104.9F,
        15F,
        15F,
        20F,
        10F};
			this.ppHTail.SelectIndex = -1;
			this.ppHTail.Wing_MODE = PaperPlanes.PPWing.MODE.POINT4;
			this.ppHTail.WingDihedral = 15F;
			this.ppHTail.WingPos = 182.4F;
			this.ppHTail.WingRoot = 30.3F;
			this.ppHTail.WingSpan = 104.9F;
			this.ppHTail.WingSpan2 = 15F;
			this.ppHTail.WingTip = 17F;
			this.ppHTail.WingTip2 = 20F;
			this.ppHTail.WingTipOffset = 14.2F;
			this.ppHTail.WingTipOffset2 = 10F;
			// 
			// ppMain
			// 
			this.ppMain.DispLocation = ((System.Drawing.PointF)(resources.GetObject("ppMain.DispLocation")));
			this.ppMain.DPI = 82F;
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
			this.ppMain.Wing_MODE = PaperPlanes.PPWing.MODE.POINT4;
			this.ppMain.WingDihedral = 15F;
			this.ppMain.WingPos = 45F;
			this.ppMain.WingRoot = 50F;
			this.ppMain.WingSpan = 176.2F;
			this.ppMain.WingSpan2 = 15F;
			this.ppMain.WingTip = 23.9F;
			this.ppMain.WingTip2 = 20F;
			this.ppMain.WingTipOffset = 7.9F;
			this.ppMain.WingTipOffset2 = 10F;
			// 
			// ppVTail
			// 
			ppVTail.DispLocation = ((System.Drawing.PointF)(resources.GetObject("ppVTail.DispLocation")));
			ppVTail.DPI = 82F;
			ppVTail.Params = new float[] {
        158.8F,
        31.6F,
        15.8F,
        15.8F,
        55.4F,
        15F,
        15F,
        20F,
        10F};
			ppVTail.SelectIndex = -1;
			ppVTail.Wing_MODE = PaperPlanes.PPWing.MODE.POINT4;
			ppVTail.WingDihedral = 15F;
			ppVTail.WingPos = 158.8F;
			ppVTail.WingRoot = 31.6F;
			ppVTail.WingSpan = 55.4F;
			ppVTail.WingSpan2 = 15F;
			ppVTail.WingTip = 15.8F;
			ppVTail.WingTip2 = 20F;
			ppVTail.WingTipOffset = 15.8F;
			ppVTail.WingTipOffset2 = 10F;
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
		private PPWing ppHTail;
		private PPParamsList ppParamsList1;
	}
}

