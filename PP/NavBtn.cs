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
	public class NavBtn :Control
	{
		public event EventHandler UpTailChanged;
		public event EventHandler DownTailChanged;
		public event EventHandler UpAllChanged;
		public event EventHandler DownAllChanged;

		protected virtual void OnUpTailChanged(EventArgs e)
		{
			UpTailChanged?.Invoke(this, e);
		}

		protected virtual void OnDownTailChanged(EventArgs e)
		{
			DownTailChanged?.Invoke(this, e);
		}
		protected virtual void OnUpAllChanged(EventArgs e)
		{
			UpAllChanged?.Invoke(this, e);
		}

		protected virtual void OnDownAllChanged(EventArgs e)
		{
			DownAllChanged?.Invoke(this, e);
		}
		private Bitmap[] m_Icons = new Bitmap[4];
		private Bitmap[] m_IconsD = new Bitmap[4];
		public NavBtn()
		{
			this.DoubleBuffered = true;
			m_Icons[0] = Properties.Resources.upTail;
			m_Icons[1] = Properties.Resources.downTail;
			m_Icons[2] = Properties.Resources.upALL;
			m_Icons[3] = Properties.Resources.downAll;
			m_IconsD[0] = Properties.Resources.upTaild;
			m_IconsD[1] = Properties.Resources.downTaild;
			m_IconsD[2] = Properties.Resources.upAlld;
			m_IconsD[3] = Properties.Resources.downAlld;

			this.Size = new Size(16, 16*4+16);
			this.MinimumSize = this.Size;
			this.MaximumSize = this.Size;
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			if (m_md == 0) { g.DrawImage(m_IconsD[0], 0, 0); }
			else { g.DrawImage(m_Icons[0], 0, 0); }

			if (m_md == 1) { g.DrawImage(m_IconsD[1], 0, 16); }
			else { g.DrawImage(m_Icons[1], 0, 16); }

			if (m_md == 2) { g.DrawImage(m_IconsD[2], 0, 48); }
			else { g.DrawImage(m_Icons[2], 0, 48); }

			if (m_md == 3) { g.DrawImage(m_IconsD[3], 0, 64); }
			else { g.DrawImage(m_Icons[3], 0, 64); }

		}
		private int m_md = -1;
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Y<16)
			{
				m_md = 0;
			}else if (e.Y < 32)
			{
				m_md = 1;
			}else if (e.Y <48)
			{
				m_md = -1;
			}
			else if (e.Y < 64)
			{
				m_md = 2;
			}
			else
			{
				m_md = 3;
			}
			if(m_md >= 0)
			{
				this.Refresh();
			}
			else
			{
				base.OnMouseDown(e);

			}
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if(m_md>=0)
			{
				switch(m_md)
				{
					case 0: OnUpTailChanged(new EventArgs()); break;
					case 1: OnDownTailChanged(new EventArgs()); break;
					case 2: OnUpAllChanged(new EventArgs()); break;
					case 3: OnDownAllChanged(new EventArgs()); break;
				}
				m_md = -1;
				this.Refresh();
			}
			else
			{
				base.OnMouseUp(e);
			}
		}
	}
}
