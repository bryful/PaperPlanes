using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using BRY;

using Codeplex.Data;
/// <summary>
/// 基本となるアプリのスケルトン
/// </summary>
namespace PaperPlanes
{
	public partial class Form1 : Form
	{
		private string fileName = "";
		//-------------------------------------------------------------
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Form1()
		{
			InitializeComponent();

			drawWings1.ToParamsList();
		}
		/// <summary>
		/// コントロールの初期化はこっちでやる
		/// </summary>
		protected override void InitLayout()
		{
			base.InitLayout();
		}
		//-------------------------------------------------------------
		/// <summary>
		/// フォーム作成時に呼ばれる
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Load(object sender, EventArgs e)
		{
			//設定ファイルの読み込み
			JsonPref pref = new JsonPref();
			if (pref.Load())
			{
				bool ok = false;
				Size sz = pref.GetSize("Size", out ok);
				if (ok) this.Size = sz;
				Point p = pref.GetPoint("Point", out ok);
				if (ok) this.Location = p;
			}
			this.Text = Path.GetFileNameWithoutExtension(Application.ExecutablePath);

			drawWings1.Init();
			LoadFile(BakFilePath);
			drawWings1.ToParamsList();
		}
		private string BakFilePath
		{
			get { return Path.Combine(Application.UserAppDataPath, "paperplane_def.json"); }
		}
		//-------------------------------------------------------------
		/// <summary>
		/// フォームが閉じられた時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			//設定ファイルの保存
			JsonPref pref = new JsonPref();
			pref.SetSize("Size", this.Size);
			pref.SetPoint("Point", this.Location);

			pref.SetIntArray("IntArray", new int[] { 8, 9, 7 });
			pref.Save();

			SaveFile(BakFilePath);

		}
		//-------------------------------------------------------------
		/// <summary>
		/// ドラッグ＆ドロップの準備
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.All;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}
		/// <summary>
		/// ドラッグ＆ドロップの本体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			//ここでは単純にファイルをリストアップするだけ
			GetCommand(files);
		}
		//-------------------------------------------------------------
		/// <summary>
		/// ダミー関数
		/// </summary>
		/// <param name="cmd"></param>
		public void GetCommand(string[] cmd)
		{
			if (cmd.Length > 0)
			{
				foreach (string s in cmd)
				{
					//listBox1.Items.Add(s);
				}
			}
		}
		/// <summary>
		/// メニューの終了
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		//-------------------------------------------------------------
		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AppInfoDialog.ShowAppInfoDialog();
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();

			sfd.FileName = Path.GetFileName (fileName);
			if (fileName == "")
			{
				sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			}
			else
			{
				sfd.InitialDirectory = Path.GetDirectoryName(fileName);

			}
			sfd.Filter = "Jsonファイル(*.json)|*.json|すべてのファイル(*.*)|*.*";
			sfd.FilterIndex = 1;
			sfd.Title = "保存先のファイルを選択してください";
			sfd.DefaultExt = "json";
			sfd.RestoreDirectory = true;
			sfd.OverwritePrompt = true;
			sfd.CheckPathExists = true;

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				if (SaveFile(sfd.FileName))
				{
					fileName = sfd.FileName;
				}
			}
		}
		public bool SaveFile(string p)
		{
			return drawWings1.Save(p);
		}
		public bool LoadFile(string p)
		{
			return drawWings1.Load(p);
		}
	}
}
