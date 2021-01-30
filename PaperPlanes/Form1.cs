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
		private string m_FileName = "";
		private string m_PdfFileName = "";
		private string m_BackImagePath = "";
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
				string path = pref.GetString("FileName", out ok);
				if (ok) m_FileName = path;
				string pdfpath = pref.GetString("PdfFileName", out ok);
				if (ok) m_PdfFileName = pdfpath;
				string bip = pref.GetString("BackImagePath", out ok);
				if (ok)
				{
					m_BackImagePath = bip;
				}
				PointF pf = pref.GetPointF("BackImagePos", out ok);
				if (ok) ppPos1.XYPosF = pf;
			}
			this.Text = Path.GetFileNameWithoutExtension(Application.ExecutablePath);

			drawWings1.Init();
			drawWings1.ImageFilePath = m_BackImagePath;
			LoadFile(BakFilePath);
			drawWings1.ToParamsList();
		}
		private string BakFilePath
		{
			get { return Path.Combine(JsonPref.PrefDir(), "paperplane_def.json"); }
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
			pref.SetString("FileName", m_FileName);
			pref.SetString("PdfFileName", m_PdfFileName);
			pref.SetString("BackImagePath", m_BackImagePath);
			pref.SetPointF("BackImagePos",ppPos1.XYPosF );

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
					if (LoadFile(s))
					{
						m_FileName = s;
						break;
					}
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

			sfd.FileName = Path.GetFileName (m_FileName);
			if (m_FileName == "")
			{
				sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			}
			else
			{
				sfd.InitialDirectory = Path.GetDirectoryName(m_FileName);

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
					m_FileName = sfd.FileName;
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
		public bool ExpoetPDF(string p)
		{
			return drawWings1.exportPDF(p);
		}

		private void exportPDFToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();

			sfd.FileName = Path.GetFileName (m_PdfFileName);
			if (m_PdfFileName == "")
			{
				sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			}
			else
			{
				sfd.InitialDirectory = Path.GetDirectoryName(m_PdfFileName);

			}
			sfd.Filter = "PDFファイル(*.PDF)|*.PDF|すべてのファイル(*.*)|*.*";
			sfd.FilterIndex = 1;
			sfd.Title = "保存先のファイルを選択してください";
			sfd.DefaultExt = "pdf";
			sfd.RestoreDirectory = true;
			sfd.OverwritePrompt = true;
			sfd.CheckPathExists = true;

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				if (ExpoetPDF(sfd.FileName))
				{
					m_PdfFileName = sfd.FileName;
				}
			}
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();

			dlg.FileName = Path.GetFileName (m_FileName);
			if (m_FileName == "")
			{
				dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			}
			else
			{
				dlg.InitialDirectory = Path.GetDirectoryName(m_FileName);

			}
			dlg.Filter = "Jsonファイル(*.json)|*.json|すべてのファイル(*.*)|*.*";
			dlg.FilterIndex = 1;
			dlg.Title = "保存先のファイルを選択してください";
			dlg.DefaultExt = "json";

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				if (LoadFile(dlg.FileName))
				{
					m_FileName = dlg.FileName;
					drawWings1.Invalidate();
				}
			}
		}

		private void backToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				drawWings1.ImageFilePath = dlg.FileName; 
				m_BackImagePath = dlg.FileName;
			}
		}

		private void ppPos1_ClearButttonClick(object sender, EventArgs e)
		{
			drawWings1.ImageFilePath = "";
			m_BackImagePath = "";

		}
	}
}
