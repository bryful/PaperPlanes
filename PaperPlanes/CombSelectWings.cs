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

namespace PaperPlanes
{
	public class CombSelectWings　:ComboBox
	{
		public CombSelectWings()
		{
			this.DropDownStyle = ComboBoxStyle.DropDownList;
			this.Items.Clear();
			this.Items.Add("主翼");
			this.Items.Add("水平尾翼");
			this.Items.Add("垂直尾翼");
			this.SelectedIndex = 0;
		}
		protected override void InitLayout()
		{
			//base.InitLayout();
			this.Items.Clear();
			this.Items.Add("主翼");
			this.Items.Add("水平尾翼");
			this.Items.Add("垂直尾翼");
			this.SelectedIndex = 0;
		}
		public int SelectWing
		{
			get
			{
				int v = this.SelectedIndex;
				if (v < 0) v = 0;
				return v;
			}
			set
			{
				int v = (int)value;
				if (this.Items.Count > 0)
				{
					this.SelectedIndex = v;
				}
			}
		}
	}
}
