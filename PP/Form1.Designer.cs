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
			this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.openMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.saveMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.quitMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.MainEdit = new PP.PWingEdit();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.HTailEdit = new PP.PWingEdit();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.VTailEdit = new PP.PWingEdit();
			this.navBtn1 = new PP.NavBtn();
			this.tailModeBtns1 = new PP.TailModeBtns();
			this.pWingCalc1 = new PP.PWingCalc();
			this.pCanvas1 = new PP.PCanvas();
			this.button1 = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.helpMenu});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(858, 24);
			this.menuStrip1.TabIndex = 5;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileMenu
			// 
			this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenu,
            this.saveMenu,
            this.saveAsMenu,
            this.quitMenu});
			this.fileMenu.Name = "fileMenu";
			this.fileMenu.Size = new System.Drawing.Size(37, 20);
			this.fileMenu.Text = "File";
			// 
			// openMenu
			// 
			this.openMenu.Name = "openMenu";
			this.openMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openMenu.Size = new System.Drawing.Size(182, 22);
			this.openMenu.Text = "Open";
			this.openMenu.Click += new System.EventHandler(this.openMenu_Click);
			// 
			// saveMenu
			// 
			this.saveMenu.Name = "saveMenu";
			this.saveMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveMenu.Size = new System.Drawing.Size(182, 22);
			this.saveMenu.Text = "Save";
			this.saveMenu.Click += new System.EventHandler(this.saveMenu_Click);
			// 
			// saveAsMenu
			// 
			this.saveAsMenu.Name = "saveAsMenu";
			this.saveAsMenu.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
			this.saveAsMenu.Size = new System.Drawing.Size(182, 22);
			this.saveAsMenu.Text = "SaveAs";
			this.saveAsMenu.Click += new System.EventHandler(this.saveAsMenu_Click);
			// 
			// quitMenu
			// 
			this.quitMenu.Name = "quitMenu";
			this.quitMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.quitMenu.Size = new System.Drawing.Size(182, 22);
			this.quitMenu.Text = "Quit";
			this.quitMenu.Click += new System.EventHandler(this.quitMenu_Click);
			// 
			// editMenu
			// 
			this.editMenu.Name = "editMenu";
			this.editMenu.Size = new System.Drawing.Size(39, 20);
			this.editMenu.Text = "Eidt";
			// 
			// helpMenu
			// 
			this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1});
			this.helpMenu.Name = "helpMenu";
			this.helpMenu.Size = new System.Drawing.Size(44, 20);
			this.helpMenu.Text = "Help";
			// 
			// helpToolStripMenuItem1
			// 
			this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
			this.helpToolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
			this.helpToolStripMenuItem1.Text = "Help";
			this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new System.Drawing.Point(24, 73);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(349, 146);
			this.tabControl1.TabIndex = 15;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.MainEdit);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(341, 120);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "主翼";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// MainEdit
			// 
			this.MainEdit.Captions = new string[] {
        "位置",
        "翼長",
        "翼根",
        "翼端",
        "後退角"};
			this.MainEdit.CaptionWidth = 50;
			this.MainEdit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainEdit.EditWidth = 70;
			this.MainEdit.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.MainEdit.Location = new System.Drawing.Point(3, 3);
			this.MainEdit.Name = "MainEdit";
			this.MainEdit.Params = new float[] {
        0F,
        90F,
        40F,
        30F,
        0F};
			this.MainEdit.Size = new System.Drawing.Size(335, 114);
			this.MainEdit.TabIndex = 7;
			this.MainEdit.Text = "Main";
			this.MainEdit.Text2 = "";
			this.MainEdit.TextVisible = false;
			this.MainEdit.TwinMode = false;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.HTailEdit);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(341, 120);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "水平尾翼";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// HTailEdit
			// 
			this.HTailEdit.Captions = new string[] {
        "位置",
        "翼長",
        "翼根",
        "翼端",
        "後退角"};
			this.HTailEdit.CaptionWidth = 50;
			this.HTailEdit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.HTailEdit.EditWidth = 70;
			this.HTailEdit.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.HTailEdit.Location = new System.Drawing.Point(3, 3);
			this.HTailEdit.Name = "HTailEdit";
			this.HTailEdit.Params = new float[] {
        100F,
        40F,
        20F,
        10F,
        5F};
			this.HTailEdit.Size = new System.Drawing.Size(335, 114);
			this.HTailEdit.TabIndex = 8;
			this.HTailEdit.Text = "HTail";
			this.HTailEdit.Text2 = "";
			this.HTailEdit.TextVisible = false;
			this.HTailEdit.TwinMode = false;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.VTailEdit);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(341, 120);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "垂直尾翼";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// VTailEdit
			// 
			this.VTailEdit.Captions = new string[] {
        "位置",
        "翼長",
        "翼根",
        "翼端",
        "後退角"};
			this.VTailEdit.CaptionWidth = 50;
			this.VTailEdit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.VTailEdit.EditWidth = 70;
			this.VTailEdit.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.VTailEdit.Location = new System.Drawing.Point(3, 3);
			this.VTailEdit.Name = "VTailEdit";
			this.VTailEdit.Params = new float[] {
        80F,
        30F,
        20F,
        10F,
        10F};
			this.VTailEdit.Size = new System.Drawing.Size(335, 114);
			this.VTailEdit.TabIndex = 9;
			this.VTailEdit.Text = "VTail";
			this.VTailEdit.Text2 = "";
			this.VTailEdit.TextVisible = false;
			this.VTailEdit.TwinMode = false;
			// 
			// navBtn1
			// 
			this.navBtn1.Location = new System.Drawing.Point(374, 132);
			this.navBtn1.MaximumSize = new System.Drawing.Size(16, 80);
			this.navBtn1.MinimumSize = new System.Drawing.Size(16, 80);
			this.navBtn1.Name = "navBtn1";
			this.navBtn1.Size = new System.Drawing.Size(16, 80);
			this.navBtn1.TabIndex = 16;
			this.navBtn1.Text = "navBtn1";
			// 
			// tailModeBtns1
			// 
			this.tailModeBtns1.Caption = new string[] {
        "通常垂直尾翼",
        "双垂直尾翼"};
			this.tailModeBtns1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.tailModeBtns1.Location = new System.Drawing.Point(27, 43);
			this.tailModeBtns1.Name = "tailModeBtns1";
			this.tailModeBtns1.PushColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.tailModeBtns1.Size = new System.Drawing.Size(256, 24);
			this.tailModeBtns1.TabIndex = 14;
			this.tailModeBtns1.TabStop = false;
			this.tailModeBtns1.TailMode = PP.TailMode.Normal;
			this.tailModeBtns1.Text = "TailMode";
			// 
			// pWingCalc1
			// 
			this.pWingCalc1.Captions = new string[] {
        "水平尾翼容積比(理想値)",
        "垂直尾翼容積比(理想値)",
        "重心位置",
        "胴体長",
        "主翼面積",
        "主翼-水平尾翼間距離",
        "水平尾翼面積",
        "垂直尾翼容積比(現在)",
        "主翼-垂直尾翼間距離",
        "垂直尾翼面積",
        "垂直尾翼容積比(現在)"};
			this.pWingCalc1.CaptionWidth = 160;
			this.pWingCalc1.EditWidth = 70;
			this.pWingCalc1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.pWingCalc1.Location = new System.Drawing.Point(27, 225);
			this.pWingCalc1.Name = "pWingCalc1";
			this.pWingCalc1.ParamsT = new float[] {
        1.2F,
        0.05F,
        85F};
			this.pWingCalc1.Size = new System.Drawing.Size(342, 254);
			this.pWingCalc1.TabIndex = 13;
			this.pWingCalc1.Text = "pWingCalc1";
			// 
			// pCanvas1
			// 
			this.pCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pCanvas1.BackColor = System.Drawing.Color.White;
			this.pCanvas1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
			this.pCanvas1.CalcEdit = this.pWingCalc1;
			this.pCanvas1.CanvasSize = new System.Drawing.SizeF(137.4048F, 130.0602F);
			this.pCanvas1.DispF = ((System.Drawing.PointF)(resources.GetObject("pCanvas1.DispF")));
			this.pCanvas1.Dpi = 83F;
			this.pCanvas1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.pCanvas1.GridSize = new System.Drawing.SizeF(5F, 5F);
			this.pCanvas1.HTailEdit = this.HTailEdit;
			this.pCanvas1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.pCanvas1.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.pCanvas1.Location = new System.Drawing.Point(397, 43);
			this.pCanvas1.MainEdit = this.MainEdit;
			this.pCanvas1.Name = "pCanvas1";
			this.pCanvas1.NavBtn = this.navBtn1;
			this.pCanvas1.Size = new System.Drawing.Size(449, 425);
			this.pCanvas1.TabIndex = 6;
			this.pCanvas1.TailMode = PP.TailMode.Normal;
			this.pCanvas1.TailModeBtns = this.tailModeBtns1;
			this.pCanvas1.VTailEdit = this.VTailEdit;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(298, 44);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 17;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(858, 480);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.navBtn1);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.tailModeBtns1);
			this.Controls.Add(this.pWingCalc1);
			this.Controls.Add(this.pCanvas1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "PaperPlane";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileMenu;
		private System.Windows.Forms.ToolStripMenuItem openMenu;
		private System.Windows.Forms.ToolStripMenuItem saveMenu;
		private System.Windows.Forms.ToolStripMenuItem quitMenu;
		private System.Windows.Forms.ToolStripMenuItem editMenu;
		private System.Windows.Forms.ToolStripMenuItem helpMenu;
		private PCanvas pCanvas1;
		private PWingEdit MainEdit;
		private PWingEdit HTailEdit;
		private PWingEdit VTailEdit;
		private PWingCalc pWingCalc1;
		private TailModeBtns tailModeBtns1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
		private NavBtn navBtn1;
		private System.Windows.Forms.ToolStripMenuItem saveAsMenu;
		private System.Windows.Forms.Button button1;
	}
}

