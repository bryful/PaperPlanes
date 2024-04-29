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
	public class TailModeBtns :Control
	{
		//bool refFlag = false;
		//TimeEventArgs型のオブジェクトを返すようにする
		public delegate void TailModeChangedEventHandler(object sender, TailModeChangedEventArgs e);

		//イベントデリゲートの宣言
		public event TailModeChangedEventHandler TailModeChanged;

		protected virtual void OnTailModeChanged(TailModeChangedEventArgs e)
		{
			if (TailModeChanged != null)
			{
				TailModeChanged(this, e);
			}
		}

		private bool m_IsTwin = true; 
		//private RadioButton m_rbNormal = new RadioButton();
		//private RadioButton m_rbTwin = new RadioButton();
		
		private string[] m_Caption = new string[] { "Normal","Twin"};
		[Category("PaperPlane")]
		public string [] Caption
		{
			get {return m_Caption; }
			set 
			{
				if (value.Length>=2)
				{
					m_Caption[0] = value[0];
					m_Caption[1] = value[1];
				}
			}
		}
		[Category("PaperPlane")]
		public TailMode TailMode
		{
			get 
			{
				if (m_IsTwin)
				{
					return TailMode.Twin;
				}
				else
				{
					return TailMode.Normal;
				}
			}
			set 
			{
				bool isT = (value == TailMode.Twin);
				bool b = (isT != m_IsTwin);
				m_IsTwin = isT;
				this.Invalidate();
				if (b)
				{
					OnTailModeChanged(new TailModeChangedEventArgs(TailMode));
				}
			}
		}

		private Color m_PushColor = Color.FromArgb(200,200,200);
		public Color PushColor
		{
			get { return m_PushColor; }
			set
			{
				m_PushColor = value;
				this.Invalidate();
			}
		}
		public TailModeBtns()
		{
		}
		protected override void OnPaint(PaintEventArgs e)
		{

			using (SolidBrush sb = new SolidBrush(BackColor))
			using (Pen p = new Pen(ForeColor, 1))
			using (StringFormat sf = new StringFormat())
			{
				Graphics g = e.Graphics;
				g.Clear(BackColor);

				Rectangle r0 = new Rectangle(0, 0, Width/2,Height);
				Rectangle r1 = new Rectangle(r0.Right, 0, Width -r0.Width, Height);

				Rectangle rct;
				if (m_IsTwin)
				{
					rct = r1;
				}
				else
				{
					rct = r0;
				}
				sb.Color = m_PushColor;
				g.FillRectangle(sb, rct);
				sf.Alignment = StringAlignment.Center;
				sf.LineAlignment = StringAlignment.Center;
				sb.Color = ForeColor;
				g.DrawString(m_Caption[0], this.Font, sb, r0, sf);
				g.DrawString(m_Caption[1], this.Font, sb, r1, sf);

				p.Color = ForeColor;
				g.DrawRectangle(p, new Rectangle(0,0,this.Width-1,this.Height-1));
			}
		}
		protected override void OnMouseClick(MouseEventArgs e)
		{
			if (e.X < this.Width/2)
			{
				if (m_IsTwin==true)
				{
					m_IsTwin = false;
					OnTailModeChanged(new TailModeChangedEventArgs(TailMode));
					this.Invalidate();
				}
			}
			else
			{
				if (m_IsTwin == false)
				{
					m_IsTwin = true;
					OnTailModeChanged(new TailModeChangedEventArgs(TailMode));
					this.Invalidate();
				}
			}
		}
	}
	// **************************************************************
}
