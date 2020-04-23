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
	public class CombEditMode :ComboBox
	{

		public CombEditMode()
		{
			this.DropDownStyle = ComboBoxStyle.DropDownList;
			this.Items.Clear();
			this.Items.Add("通常尾翼");
			this.Items.Add("双尾翼");
			this.SelectedIndex = 0;
		}
		protected override void InitLayout()
		{
			//base.InitLayout();
			this.Items.Clear();
			this.Items.Add("通常尾翼");
			this.Items.Add("双尾翼");
			this.SelectedIndex = 0;
		}
		public DrawWings.EDIT_MODE  EditMode
		{
			get
			{
				int v = this.SelectedIndex;
				if (v < 0) v = 0;
				return (DrawWings.EDIT_MODE)v;
			}
			set
			{
				int v = (int)value;
				if (v > 1) v = 1;
				if (this.Items.Count > 0)
				{
					this.SelectedIndex = v;
				}
			}
		}

	}
	
}
