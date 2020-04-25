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
	public class EditModeSelect : Control
	{
		public event EventHandler SelectChanged;

		protected virtual void OnSelectChanged(EventArgs e)
		{
			if (SelectChanged != null)
			{
				SelectChanged(this, e);
			}
		}

		private RadioButton m_rbNormal = new RadioButton();
		private RadioButton m_rbTwinTail = new RadioButton();
		private FlowLayoutPanel fl = new FlowLayoutPanel();
		public EditModeSelect()
		{
			this.Size = new Size(200, 20);
			fl.FlowDirection = FlowDirection.LeftToRight;
			fl.Size = this.Size;
			fl.Location = new Point(0, 0);
			fl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
			this.Controls.Add(fl);


			m_rbNormal.Size = new Size(80, 20);
			m_rbNormal.Checked = true;
			m_rbNormal.Text = "通常尾翼";

			m_rbTwinTail.Size = new Size(80, 20);
			m_rbTwinTail.Checked = false;
			m_rbTwinTail.Text = "双尾翼";

			fl.Controls.Add(m_rbNormal);
			fl.Controls.Add(m_rbTwinTail);

			m_rbNormal.CheckedChanged += M_rb_CheckedChanged;
			m_rbTwinTail.CheckedChanged += M_rb_CheckedChanged;

		}
		private void M_rb_CheckedChanged(object sender, EventArgs e)
		{
			OnSelectChanged(new EventArgs());
		}

		public DrawWings.EDIT_MODE  EditMode
		{
			get
			{
				if (m_rbNormal.Checked == true)
				{
					return DrawWings.EDIT_MODE.NORMAL;
				}
				else
				{
					return DrawWings.EDIT_MODE.TWINTAIL;
				}
			}
			set
			{
				if(EditMode != value )
				{
					bool b = (value == DrawWings.EDIT_MODE.NORMAL);
					m_rbNormal.Checked = b;
					m_rbTwinTail.Checked = !b;
				}
			}
		}

	}

}
