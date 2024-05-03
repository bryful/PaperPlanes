using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

using netDxf;
using netDxf.Entities;

namespace PP
{
	public partial class Form1 : Form
	{
		private string m_filename = "";
		HelpForm m_HelpForm = null;
		public Form1()
		{
			InitializeComponent();
		}
		public static string GetProps(Type ct)
		{
			// DateTimeのプロパティ一覧を取得する
			PropertyInfo[] p = ct.GetProperties();

			// 取得した一覧をコンソールに出力する
			string s = "";
			foreach (var a in p)
			{
				if (a.CanWrite == true)
				{
					s += "// **************************************************************\r\n";
					s += $"[Browsable(false)]\r\n";
					s += $"public new {a.PropertyType.ToString()} {a.Name}\r\n";
					s += $"{{\r\n";
					s += $"	get {{ return base.{a.Name}; }}\r\n";
					s += $"	set {{ base.{a.Name} = value; }}\r\n";
					s += "}\r\n";
				}
			}
			return s;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			PrefLoad();
			string[] cmds = System.Environment.GetCommandLineArgs();
			if(cmds.Length>1)
			{
				Open(cmds[1]);
			}
		}
		public void PrefSave()
		{
			PrefFile pf = new PrefFile(this);
			pf.StoreForm();
			pf.Save();

			string p = Path.Combine(pf.FileDirectory, "backup.json");
			pCanvas1.Save(p);
		}
		public void PrefLoad()
		{
			PrefFile pf = new PrefFile(this);
			pf.Load	();
			pf.RestoreForm();

			string p = Path.Combine(pf.FileDirectory, "backup.json");
			pCanvas1.Load(p);
		}
		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			PrefSave();
		}

		private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if(m_HelpForm != null)
			{
				m_HelpForm.Show();
			}
			else
			{
				m_HelpForm = new HelpForm();
				m_HelpForm.Show();
			}
		}
		public bool Save()
		{
			bool ret = false;
			if(m_filename!="")
			{
				ret = Save(m_filename);
			}
			else
			{
				ret = SaveAs();
			}
			return ret;
		}
		public bool Save(string p)
		{
			bool ret = false;

			ret = pCanvas1.Save (p);
			if(ret)
			{
				m_filename = p;
			}
			return ret;
		}
		public bool SaveAs() 
		{
			bool ret = false;
			using (SaveFileDialog dlg = new SaveFileDialog())
			{
				dlg.DefaultExt = ".json";
				dlg.Filter = "*.json|*.json|*.*|*.*";
				if(m_filename!="")
				{
					dlg.InitialDirectory = Path.GetDirectoryName( m_filename);
					dlg.FileName = Path.GetFileName( m_filename );
				}

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ret = Save(dlg.FileName);
				}
			}
			return ret;
		}
		public bool Open(string p)
		{
			bool ret = false;
			ret = pCanvas1.Load(p);
			if (ret)
			{
				m_filename = p;
			}
			return ret;
		}
		public bool Open()
		{
			bool ret = false;
			using (OpenFileDialog dlg = new OpenFileDialog())
			{
				dlg.DefaultExt = ".json";
				dlg.Filter = "*.json|*.json|*.*|*.*";
				if (m_filename != "")
				{
					dlg.InitialDirectory = Path.GetDirectoryName(m_filename);
					dlg.FileName = Path.GetFileName(m_filename);
				}

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ret = Open(dlg.FileName);
				}
			}
			return ret;
		}
		private void saveMenu_Click(object sender, EventArgs e)
		{
			Save();
		}

		private void quitMenu_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void openMenu_Click(object sender, EventArgs e)
		{
			Open();
		}

		private void saveAsMenu_Click(object sender, EventArgs e)
		{
			SaveAs();
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}


		private void resolutionMenu_Click(object sender, EventArgs e)
		{
			pCanvas1.ShowDpiDialog();
		}

		private void exportSVGMenu_Click(object sender, EventArgs e)
		{
			pCanvas1.ExportSVG();
		}

		
		private void exportDXFMenu_Click(object sender, EventArgs e)
		{
			pCanvas1.ExportDXF();
		}
	}
}
