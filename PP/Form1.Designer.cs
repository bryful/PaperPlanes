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
			this.exportPDFMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.quitMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.navBtn1 = new PP.NavBtn();
			this.MainEdit = new PP.PWingEdit();
			this.HTailEdit = new PP.PWingEdit();
			this.VTailEdit = new PP.PWingEdit();
			this.tailModeBtns1 = new PP.TailModeBtns();
			this.pCanvas1 = new PP.PCanvas();
			this.pWingCalc1 = new PP.PWingCalc();
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
            this.exportPDFMenu,
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
			// exportPDFMenu
			// 
			this.exportPDFMenu.Name = "exportPDFMenu";
			this.exportPDFMenu.Size = new System.Drawing.Size(182, 22);
			this.exportPDFMenu.Text = "ExportPDF";
			this.exportPDFMenu.Click += new System.EventHandler(this.exportPDFMenu_Click);
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
			this.tabControl1.Size = new System.Drawing.Size(349, 163);
			this.tabControl1.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.MainEdit);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(341, 137);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "主翼";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.HTailEdit);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(341, 137);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "水平尾翼";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.VTailEdit);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(341, 137);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "垂直尾翼";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// navBtn1
			// 
			this.navBtn1.Location = new System.Drawing.Point(374, 132);
			this.navBtn1.MaximumSize = new System.Drawing.Size(16, 80);
			this.navBtn1.MinimumSize = new System.Drawing.Size(16, 80);
			this.navBtn1.Name = "navBtn1";
			this.navBtn1.Size = new System.Drawing.Size(16, 80);
			this.navBtn1.TabIndex = 3;
			this.navBtn1.Text = "navBtn1";
			// 
			// MainEdit
			// 
			this.MainEdit.Captions = new string[] {
        "位置",
        "翼長",
        "翼根",
        "翼端",
        "後退角"};
			this.MainEdit.CaptionWidth = 60;
			this.MainEdit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainEdit.EditHeight = 22;
			this.MainEdit.EditWidth = 90;
			this.MainEdit.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.MainEdit.Location = new System.Drawing.Point(3, 3);
			this.MainEdit.Name = "MainEdit";
			this.MainEdit.Params = new float[] {
        50F,
        85F,
        28F,
        16F,
        8F};
			this.MainEdit.Size = new System.Drawing.Size(335, 131);
			this.MainEdit.TabIndex = 7;
			this.MainEdit.Text = "Main";
			this.MainEdit.TwinMode = false;
			// 
			// HTailEdit
			// 
			this.HTailEdit.Captions = new string[] {
        "位置",
        "翼長",
        "翼根",
        "翼端",
        "後退角"};
			this.HTailEdit.CaptionWidth = 60;
			this.HTailEdit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.HTailEdit.EditHeight = 20;
			this.HTailEdit.EditWidth = 90;
			this.HTailEdit.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.HTailEdit.Location = new System.Drawing.Point(3, 3);
			this.HTailEdit.Name = "HTailEdit";
			this.HTailEdit.Params = new float[] {
        160F,
        28.7F,
        19F,
        14.28F,
        13F};
			this.HTailEdit.Size = new System.Drawing.Size(335, 131);
			this.HTailEdit.TabIndex = 8;
			this.HTailEdit.Text = "HTail";
			this.HTailEdit.TwinMode = false;
			// 
			// VTailEdit
			// 
			this.VTailEdit.Captions = new string[] {
        "位置",
        "翼長",
        "翼根",
        "翼端",
        "後退角"};
			this.VTailEdit.CaptionWidth = 60;
			this.VTailEdit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.VTailEdit.EditHeight = 20;
			this.VTailEdit.EditWidth = 90;
			this.VTailEdit.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.VTailEdit.Location = new System.Drawing.Point(3, 3);
			this.VTailEdit.Name = "VTailEdit";
			this.VTailEdit.Params = new float[] {
        166.62F,
        14F,
        14.28F,
        6F,
        40F};
			this.VTailEdit.Size = new System.Drawing.Size(335, 131);
			this.VTailEdit.TabIndex = 9;
			this.VTailEdit.Text = "VTail";
			this.VTailEdit.TwinMode = true;
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
			this.tailModeBtns1.Size = new System.Drawing.Size(346, 24);
			this.tailModeBtns1.TabIndex = 0;
			this.tailModeBtns1.TabStop = false;
			this.tailModeBtns1.TailMode = PP.TailMode.Twin;
			this.tailModeBtns1.Text = "TailMode";
			// 
			// pCanvas1
			// 
			this.pCanvas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pCanvas1.BackColor = System.Drawing.Color.White;
			this.pCanvas1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
			this.pCanvas1.CalcEdit = this.pWingCalc1;
			this.pCanvas1.CanvasSize = new System.Drawing.SizeF(137.4048F, 156.9904F);
			this.pCanvas1.DispF = ((System.Drawing.PointF)(resources.GetObject("pCanvas1.DispF")));
			this.pCanvas1.Dpi = 83F;
			this.pCanvas1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.pCanvas1.GridSize = new System.Drawing.SizeF(5F, 5F);
			this.pCanvas1.HTailEdit = this.HTailEdit;
			this.pCanvas1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.pCanvas1.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.pCanvas1.Location = new System.Drawing.Point(397, 12);
			this.pCanvas1.MainEdit = this.MainEdit;
			this.pCanvas1.Name = "pCanvas1";
			this.pCanvas1.NavBtn = this.navBtn1;
			this.pCanvas1.Size = new System.Drawing.Size(449, 513);
			this.pCanvas1.TabIndex = 6;
			this.pCanvas1.TailMode = PP.TailMode.Twin;
			this.pCanvas1.TailModeBtns = this.tailModeBtns1;
			this.pCanvas1.VTailEdit = this.VTailEdit;
			// 
			// pWingCalc1
			// 
			this.pWingCalc1.Captions = new string[] {
        "!HTail_VRate",
        "!VTail_VR",
        "CenterG",
        "Fuselage",
        "MainArea",
        "DistanceHTail",
        "HTailArea",
        "HTailVR",
        "DistanceVTail",
        "VTailArea",
        "VTailVR"};
			this.pWingCalc1.CaptionWidth = 120;
			this.pWingCalc1.EditHeight = 22;
			this.pWingCalc1.EditWidth = 80;
			this.pWingCalc1.Location = new System.Drawing.Point(31, 243);
			this.pWingCalc1.Name = "pWingCalc1";
			this.pWingCalc1.ParamsT = new float[] {
        1.2F,
        0.05F,
        85F};
			this.pWingCalc1.Size = new System.Drawing.Size(338, 294);
			this.pWingCalc1.TabIndex = 7;
			this.pWingCalc1.Text = "pWingCalc1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(858, 537);
			this.Controls.Add(this.pWingCalc1);
			this.Controls.Add(this.navBtn1);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.tailModeBtns1);
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
		private TailModeBtns tailModeBtns1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
		private NavBtn navBtn1;
		private System.Windows.Forms.ToolStripMenuItem saveAsMenu;
		private System.Windows.Forms.ToolStripMenuItem exportPDFMenu;
		private PWingCalc pWingCalc1;
	}
}

