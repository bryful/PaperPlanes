﻿namespace PP
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.MainEdit = new PP.PWingEdit();
			this.HTailEdit = new PP.PWingEdit();
			this.VTailEdit = new PP.PWingEdit();
			this.tailModeBtns1 = new PP.TailModeBtns();
			this.pWingCalc1 = new PP.PWingCalc();
			this.pCanvas1 = new PP.PCanvas();
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
            this.fileToolStripMenuItem,
            this.eidtToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(810, 24);
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
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
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
			// helpToolStripMenuItem1
			// 
			this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
			this.helpToolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
			this.helpToolStripMenuItem1.Text = "Help";
			this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
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
			// tailModeBtns1
			// 
			this.tailModeBtns1.Caption = new string[] {
        "通常垂直尾翼",
        "双垂直尾翼"};
			this.tailModeBtns1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.tailModeBtns1.Location = new System.Drawing.Point(31, 43);
			this.tailModeBtns1.Name = "tailModeBtns1";
			this.tailModeBtns1.PushColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.tailModeBtns1.Size = new System.Drawing.Size(335, 24);
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
			this.pWingCalc1.Location = new System.Drawing.Point(27, 263);
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
			this.pCanvas1.CanvasSize = new System.Drawing.SizeF(127.612F, 145.0554F);
			this.pCanvas1.DispF = ((System.Drawing.PointF)(resources.GetObject("pCanvas1.DispF")));
			this.pCanvas1.Dpi = 83F;
			this.pCanvas1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.pCanvas1.GridSize = new System.Drawing.SizeF(5F, 5F);
			this.pCanvas1.HTailEdit = this.HTailEdit;
			this.pCanvas1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.pCanvas1.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.pCanvas1.Location = new System.Drawing.Point(379, 43);
			this.pCanvas1.MainEdit = this.MainEdit;
			this.pCanvas1.Name = "pCanvas1";
			this.pCanvas1.Size = new System.Drawing.Size(417, 474);
			this.pCanvas1.TabIndex = 6;
			this.pCanvas1.TailMode = PP.TailMode.Normal;
			this.pCanvas1.TailModeBtns = this.tailModeBtns1;
			this.pCanvas1.VTailEdit = this.VTailEdit;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(810, 529);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.tailModeBtns1);
			this.Controls.Add(this.pWingCalc1);
			this.Controls.Add(this.pCanvas1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
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
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem eidtToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
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
	}
}

