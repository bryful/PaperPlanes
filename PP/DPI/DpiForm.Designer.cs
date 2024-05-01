namespace PP
{
    partial class DpiForm
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
			this.lbDpi = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.inputPanelcs1 = new PP.InputPanelcs();
			this.inputPanelcs2 = new PP.InputPanelcs();
			this.inputPanelcs3 = new PP.InputPanelcs();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.lbDpiNow = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lbDpi
			// 
			this.lbDpi.AutoSize = true;
			this.lbDpi.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lbDpi.Location = new System.Drawing.Point(232, 179);
			this.lbDpi.Name = "lbDpi";
			this.lbDpi.Size = new System.Drawing.Size(0, 35);
			this.lbDpi.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label2.Location = new System.Drawing.Point(12, 192);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(187, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "ディスプレイの解像度(DPI)";
			// 
			// inputPanelcs1
			// 
			this.inputPanelcs1.Caption = "ディスプレイ横ピクセル数";
			this.inputPanelcs1.IsDecMode = false;
			this.inputPanelcs1.Location = new System.Drawing.Point(10, 38);
			this.inputPanelcs1.MaxValue = new decimal(new int[] {
            6000,
            0,
            0,
            0});
			this.inputPanelcs1.MinValue = new decimal(new int[] {
            640,
            0,
            0,
            0});
			this.inputPanelcs1.Name = "inputPanelcs1";
			this.inputPanelcs1.Size = new System.Drawing.Size(355, 42);
			this.inputPanelcs1.TabIndex = 5;
			this.inputPanelcs1.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
			this.inputPanelcs1.ValueChanged += new System.EventHandler(this.inputPanelcs1_ValueChanged);
			// 
			// inputPanelcs2
			// 
			this.inputPanelcs2.Caption = "ディスプレイ縦ピクセル数";
			this.inputPanelcs2.IsDecMode = false;
			this.inputPanelcs2.Location = new System.Drawing.Point(12, 86);
			this.inputPanelcs2.MaxValue = new decimal(new int[] {
            6000,
            0,
            0,
            0});
			this.inputPanelcs2.MinValue = new decimal(new int[] {
            640,
            0,
            0,
            0});
			this.inputPanelcs2.Name = "inputPanelcs2";
			this.inputPanelcs2.Size = new System.Drawing.Size(355, 42);
			this.inputPanelcs2.TabIndex = 6;
			this.inputPanelcs2.Value = new decimal(new int[] {
            1080,
            0,
            0,
            0});
			this.inputPanelcs2.ValueChanged += new System.EventHandler(this.inputPanelcs1_ValueChanged);
			// 
			// inputPanelcs3
			// 
			this.inputPanelcs3.Caption = "ディスプレイ インチ数";
			this.inputPanelcs3.IsDecMode = true;
			this.inputPanelcs3.Location = new System.Drawing.Point(10, 134);
			this.inputPanelcs3.MaxValue = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.inputPanelcs3.MinValue = new decimal(new int[] {
            7,
            0,
            0,
            0});
			this.inputPanelcs3.Name = "inputPanelcs3";
			this.inputPanelcs3.Size = new System.Drawing.Size(355, 42);
			this.inputPanelcs3.TabIndex = 7;
			this.inputPanelcs3.Value = new decimal(new int[] {
            27,
            0,
            0,
            0});
			this.inputPanelcs3.ValueChanged += new System.EventHandler(this.inputPanelcs1_ValueChanged);
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(238, 225);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(105, 30);
			this.btnOK.TabIndex = 8;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(115, 225);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(105, 30);
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label3.Location = new System.Drawing.Point(112, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(106, 16);
			this.label3.TabIndex = 10;
			this.label3.Text = "現在の解像度";
			// 
			// lbDpiNow
			// 
			this.lbDpiNow.AutoSize = true;
			this.lbDpiNow.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lbDpiNow.Location = new System.Drawing.Point(233, 10);
			this.lbDpiNow.Name = "lbDpiNow";
			this.lbDpiNow.Size = new System.Drawing.Size(84, 27);
			this.lbDpiNow.TabIndex = 11;
			this.lbDpiNow.Text = "label4";
			// 
			// DpiForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(384, 261);
			this.Controls.Add(this.lbDpiNow);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.inputPanelcs3);
			this.Controls.Add(this.inputPanelcs2);
			this.Controls.Add(this.inputPanelcs1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lbDpi);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DpiForm";
			this.ShowInTaskbar = false;
			this.Text = "ディスプレイ解像度 (DPI)";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbDpi;
        private System.Windows.Forms.Label label2;
        private InputPanelcs inputPanelcs1;
        private InputPanelcs inputPanelcs2;
        private InputPanelcs inputPanelcs3;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lbDpiNow;
	}
}

