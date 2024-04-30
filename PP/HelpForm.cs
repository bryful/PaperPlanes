using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Markdig;
namespace PP
{
	public partial class HelpForm : Form
	{
		public HelpForm()
		{
			InitializeComponent();

			string s = Properties.Resources.HelpText;

			var html = Markdown.ToHtml(s);

			webBrowser1.DocumentText = html;
		}
	}
}
