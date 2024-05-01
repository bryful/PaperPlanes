using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace PP
{
	public class PTrackBar :Control
	{
		//デリゲートの宣言
		//TimeEventArgs型のオブジェクトを返すようにする
		public delegate void ValueFChangedEventHandler(object sender, ValueFChangedEventArgs e);

		//イベントデリゲートの宣言
		public event ValueFChangedEventHandler ValueFChanged;
		protected virtual void OnValueFChanged(ValueFChangedEventArgs e)
		{
			if (ValueFChanged != null)
			{
				ValueFChanged(this, e);
			}
		}
		private PNumEdit m_NumEdit = null;
		private float ValueMax = 0;
		private float TrackLength = 0;
		private float BarLength = 10;

		private void SetupEdit()
		{
			if (m_NumEdit == null)return;
			ValueMax = (float)(m_NumEdit.Maximum - m_NumEdit.Minimum);
		}


		[Category("PaperPlane")]
		public PNumEdit NumEdit
		{
			get
			{
				return m_NumEdit;
			}
			set
			{
				m_NumEdit = value;
				if (m_NumEdit !=null)
				{
					SetupEdit();
					m_NumEdit.ValueFChanged += (sender, e) =>
					{
						this.Invalidate();
					};
					this.Invalidate();
				}
			}
		}
		public PTrackBar()
		{
			DoubleBuffered = true;
		}
		protected override void OnResize(EventArgs e)
		{
			TrackLength = this.Width - BarLength;
			if (TrackLength < 0) TrackLength = 0;
			this.Invalidate();
			base.OnResize(e);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			using(SolidBrush sb = new SolidBrush(BackColor))
			using (Pen p = new Pen(ForeColor))
			{
				Graphics g = e.Graphics;
				g.Clear(BackColor);

				g.DrawLine(p,2,this.Height/2,this.Width-4, this.Height / 2);
				g.DrawLine(p, 2, 0, 2, this.Height);
				g.DrawLine(p, this.Width-3, 0, this.Width - 3, this.Height);


				if (m_NumEdit != null )
				{
					RectangleF r = new RectangleF(EValue+2, 0, BarLength,this.Height);
					sb.Color = ForeColor;
					g.FillRectangle(sb, r);
				}

			}
		}
		public float EValue
		{
			get
			{
				float ret = 0;
				if (m_NumEdit != null)
				{
					ValueMax = (m_NumEdit.Maximum - m_NumEdit.Minimum);
					TrackLength = (float)this.Width - BarLength-4;
					ret = (m_NumEdit.Value - m_NumEdit.Minimum) * TrackLength / ValueMax;
				}
				return ret;
			}
		}
		int m_md = -1;
		float m_ev = 0;
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if(m_NumEdit != null)
			{
				int v = (int)EValue +2;
				if ((e.X>=v) && (e.Y<v+BarLength))
				{
					m_md = e.X;
					m_ev = m_NumEdit.Value;
				}
			}
			base.OnMouseDown(e);
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (m_NumEdit != null)
			{
				if (m_md>=0)
				{
					int v = e.X - m_md;
					float d = (float)v * (float)ValueMax / (float)TrackLength + m_ev;
					if (d < m_NumEdit.Minimum) d = m_NumEdit.Minimum;
					else if (d > m_NumEdit.Maximum) d = m_NumEdit.Maximum;
					if (m_NumEdit.Value != d)
					{
						m_NumEdit.Value = d;
						this.Invalidate();
					}
				}
			}
			base.OnMouseMove(e);
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			m_md = -1;
			m_ev = 0;
			base.OnMouseUp(e);
		}
		protected override void OnMouseClick(MouseEventArgs e)
		{
			if(m_NumEdit !=null)
			{
				int v = (int)EValue + 2;
				if (e.X < v)
				{
					if (m_NumEdit.Value > 5)
					{
						m_NumEdit.Value -= 5;
						this.Invalidate();
					}
				}
				else if (e.X > v+ BarLength) 
				{
					if (m_NumEdit.Value < m_NumEdit.Maximum - 5)
					{
						m_NumEdit.Value += 5;
						this.Invalidate();
					}
				}
			}
			base.OnMouseClick(e);
		}
	}
}
