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
namespace PP
{
	public partial class Form1 : Form
	{
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
	}
}
