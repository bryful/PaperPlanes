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
	public class SelectWingParts : Control
	{
		public DrawWings.EDIT_MODE EditMode
		{
			get {
				if (m_rbVTail.Visible == true)
				{
					return DrawWings.EDIT_MODE.NORMAL;

				}
				else
				{
					if (SelectWing == 2)
					{
						SelectWing = 0;
					}
					return DrawWings.EDIT_MODE.TWINTAIL;
				}
			}
			set
			{
				m_rbVTail.Visible = (value == DrawWings.EDIT_MODE.NORMAL);
			}
		}
		public event EventHandler SelectChanged;

		protected virtual void OnSelectChanged(EventArgs e)
		{
			if (SelectChanged != null)
			{
				SelectChanged(this, e);
			}
		}
		private RadioButton m_rbMain = new RadioButton();
		private RadioButton m_rbHTail = new RadioButton();
		private RadioButton m_rbVTail = new RadioButton();
		private FlowLayoutPanel fl = new FlowLayoutPanel();
		public SelectWingParts()
		{
			this.Size = new Size(200, 20);
			fl.FlowDirection = FlowDirection.LeftToRight;
			fl.Size = this.Size;
			fl.Location = new Point(0, 0);
			fl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
			this.Controls.Add(fl);

			m_rbMain.Size = new Size(50, 20);
			m_rbMain.AutoSize = true;
			m_rbMain.Checked = true;
			m_rbMain.Text = "Main";

			m_rbHTail.Size = new Size(50, 20);
			m_rbHTail.AutoSize = true;
			m_rbHTail.Checked = false;
			m_rbHTail.Text = "HTail";

			m_rbVTail.Size = new Size(50, 20);
			m_rbVTail.AutoSize = true;
			m_rbVTail.Checked = false;
			m_rbVTail.Text = "VTail";

			fl.Controls.Add(m_rbMain);
			fl.Controls.Add(m_rbHTail);
			fl.Controls.Add(m_rbVTail);

			m_rbMain.CheckedChanged += M_CheckedChanged;
			m_rbHTail.CheckedChanged += M_CheckedChanged;
			m_rbVTail.CheckedChanged += M_CheckedChanged;

		}

		private void M_CheckedChanged(object sender, EventArgs e)
		{
			OnSelectChanged(new EventArgs());
		}

		public int SelectWing
		{
			get
			{
				if (m_rbMain.Checked == true)
				{
					return 0;
				}else if (m_rbHTail.Checked == true)
				{
					return 1;
				}else if (m_rbVTail.Checked == true)
				{
					return 2;

				}
				else
				{
					return 0;
				}
			}
			set
			{
				if (SelectWing !=value)
				{
					switch(value)
					{
						case 2:
							if (EditMode == DrawWings.EDIT_MODE.NORMAL)
							{
								m_rbVTail.Checked = true;
							}
							else
							{
								m_rbMain.Checked = true;
							}
							break;
						case 1:
							m_rbHTail.Checked = true;
							break;
						default:
						case 0:
							m_rbMain.Checked = true;
							break;
					}
				}
			}
		}

	}
}
