using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PP
{
	public class PNumEdit : Control
	{
		private Bitmap [] m_bitmap = new Bitmap[6];
		private int m_Value = 0;
		[Category("PaperPlane")]
		public float Value
		{
			get { return (float)m_Value / 1000; }
			set
			{
				m_Value = (int)(value*1000);
				this.Invalidate();
			}
		}
		private int m_AddValue = 1000;
		[Category("PaperPlane")]
		public float AddValue
		{
			get { return (float)m_AddValue / 1000; }
			set
			{
				m_AddValue = (int)(value * 1000);
				if (m_AddValue < 1) m_AddValue = 1;
			}
		}
		private int m_Minimum = 0;
		[Category("PaperPlane")]
		public float Minimum
		{
			get { return (float)m_Minimum / 1000; }
			set
			{
				m_Minimum = (int)(value * 1000);
				if (m_Minimum > m_Maximum) m_Minimum = m_Maximum;
				if (m_Value < m_Minimum) m_Value = m_Minimum;
				this.Invalidate();
			}
		}
		private int m_Maximum = 1000*1000;
		[Category("PaperPlane")]
		public float Maximum
		{
			get { return (float)m_Maximum / 1000; }
			set
			{
				m_Maximum = (int)(value * 1000);
				if (m_Maximum < m_Minimum) m_Maximum = m_Minimum;
				if (m_Value > m_Maximum) m_Value = m_Maximum;
				this.Invalidate();
			}
		}
		private bool m_IsArrowHor = true;
		[Category("PaperPlane")]
		public bool IsArrowHor
		{
			get { return m_IsArrowHor; }
			set 
			{
				m_IsArrowHor = value;
				this.Invalidate();
			}
		}
		private bool m_IsShowArrow = true;
		[Category("PaperPlane")]
		public bool IsShowArrow
		{
			get { return m_IsShowArrow; }
			set
			{
				m_IsShowArrow = value;
				this.Invalidate();
			}
		}

		public PNumEdit()
		{
			DoubleBuffered = true;
			m_bitmap[0] = Properties.Resources.Arrow_0000;
			m_bitmap[1] = Properties.Resources.Arrow_0001;
			m_bitmap[2] = Properties.Resources.Arrow_0002;
			m_bitmap[3] = Properties.Resources.Arrow_0003;
			m_bitmap[4] = Properties.Resources.Arrow_0004;
			m_bitmap[5] = Properties.Resources.Arrow_0005;
			base.BackColor = SystemColors.Window;
		}
		private void ChkValue()
		{
			if (m_Value < m_Minimum) m_Value = m_Minimum;
			if (m_Value>m_Maximum) m_Value = m_Maximum;
		}
		private Color m_ArrowColor = SystemColors.Control;
		private Color m_ArrowColorPushed = SystemColors.ControlDarkDark;

		private int m_md = -1;
		// ************************************************************
		private void DrawArrow(Graphics g,Rectangle rct)
		{
			Rectangle srcRect = new Rectangle(0, 0, 32, 32);
			switch (m_md)
			{
				case -1:
					if (m_IsArrowHor)
					{
						g.DrawImage(m_bitmap[3], rct, srcRect,GraphicsUnit.Pixel);
					}
					else
					{
						g.DrawImage(m_bitmap[0], rct, srcRect, GraphicsUnit.Pixel);
					}
					break;
				case 0:
					if (m_IsArrowHor)
					{
						g.DrawImage(m_bitmap[4], rct, srcRect, GraphicsUnit.Pixel);
					}
					else
					{
						g.DrawImage(m_bitmap[1], rct, srcRect, GraphicsUnit.Pixel);
					}
					break;
				case 1:
					if (m_IsArrowHor)
					{
						g.DrawImage(m_bitmap[5], rct, srcRect, GraphicsUnit.Pixel);
					}
					else
					{
						g.DrawImage(m_bitmap[2], rct, srcRect, GraphicsUnit.Pixel);
					}
					break;
			}


		}
		// ************************************************************
		protected override void OnPaint(PaintEventArgs e)
		{
			using(SolidBrush sb = new SolidBrush(BackColor))
			using (Pen p = new Pen(ForeColor))
			using (StringFormat sf = new StringFormat())
			{
				Graphics g = e.Graphics;
				g.Clear(BackColor);
				Rectangle rct0,rct1;
				if (m_IsShowArrow)
				{
					rct0 = new Rectangle(
						0,
						0,
						this.Width - this.Height,
						this.Height
						);
					rct1 = new Rectangle(
						this.Width - this.Height + 1,
						1,
						this.Height - 1,
						this.Height - 1
						);
					DrawArrow(g, rct1);
				}
				else
				{
					rct0 = new Rectangle(
					0,
					0,
					this.Width - this.Height,
					this.Height
					);
				}
				string s = "";
				s = ((int)(m_Value/1000)).ToString();
				s += ".";
				s += ((int)(m_Value % 1000)).ToString("D3");
				sf.Alignment = StringAlignment.Far;
				sf.LineAlignment = StringAlignment.Center;
				sb.Color = ForeColor;
				g.DrawString(s, this.Font, sb, rct0, sf);

				rct0 = new Rectangle(0, 0, Width-1, Height-1);
				p.Width = 1;
				p.Color = ForeColor;
				g.DrawRectangle(p,rct0);
			}
		}
		// ************************************************************
		protected override void OnMouseDown(MouseEventArgs e)
		{
			int w = this.Width-this.Height;
			m_md = -1;
			if (e.X>w)
			{
				int h = this.Height / 2;
				if (m_IsArrowHor)
				{
					m_md = ((e.X - w) / h) % 2;
				}
				else
				{
					m_md = (e.Y / h) % 2;
				}
				this.Refresh();
			}
			base.OnMouseDown(e);
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (m_md >= 0)
			{
				switch (m_md)
				{
					case 0:
						m_Value -= m_AddValue;
						ChkValue();
						break;
					case 1:
						m_Value += m_AddValue;
						ChkValue();
						break;
				}

				m_md = -1;
				this.Refresh();
			}
			base.OnMouseUp(e);
		}
	}
}
