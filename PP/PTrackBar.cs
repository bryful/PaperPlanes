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
		public delegate void FValueChangedEventHandler(object sender, ValueFChangedEventArgs e);

		//イベントデリゲートの宣言
		public event FValueChangedEventHandler FValueChanged;
		protected virtual void OnFValueChanged(ValueFChangedEventArgs e)
		{
			if (FValueChanged != null)
			{
				FValueChanged(this, e);
			}
		}
		private NumericUpDown m_numericUpDown = null;
		private int ValueMax = 0;
		private int TrackLength = 0;
		private int BarLength = 6;

		private void SetupEdit()
		{
			if (m_numericUpDown == null)return;
			ValueMax = (int )(m_numericUpDown.Maximum - m_numericUpDown.Minimum);
		}


		[Category("PaperPlane")]
		public NumericUpDown NumericUpDown
		{
			get
			{
				return m_numericUpDown;
			}
			set
			{
				m_numericUpDown = value;
				if (m_numericUpDown !=null)
				{
					SetupEdit();
					m_numericUpDown.ValueChanged += (sender, e) =>
					{
						this.Invalidate();
					};
					this.Invalidate();
				}
			}
		}
		public PTrackBar()
		{
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

				g.DrawLine(p,0,this.Height/2,this.Width, this.Height / 2);
				g.DrawLine(p, 0, 0, 0, this.Height);
				g.DrawLine(p, this.Width-1, 0, this.Width - 1, this.Height);


				if (m_numericUpDown != null )
				{
					Rectangle r = new Rectangle(EValue, 0, BarLength,this.Height);
					sb.Color = ForeColor;
					g.FillRectangle(sb, r);
				}

			}
		}
		public int EValue
		{
			get
			{
				int ret = 0;
				if (m_numericUpDown != null)
				{
					ValueMax = (int)(m_numericUpDown.Maximum - m_numericUpDown.Minimum);
					TrackLength = this.Width - BarLength;
					ret = (int)(m_numericUpDown.Value - m_numericUpDown.Minimum) * TrackLength / ValueMax;
				}
				return ret;
			}
		}
		int m_md = -1;
		decimal m_ev = 0;
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if(m_numericUpDown != null)
			{
				int v = EValue;
				if ((e.X>=v) && (e.Y<v+BarLength))
				{
					m_md = e.X;
					m_ev = m_numericUpDown.Value;
				}
			}
			base.OnMouseDown(e);
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (m_numericUpDown != null)
			{
				if (m_md>=0)
				{
					int v = e.X - m_md;
					decimal d = (decimal)v * (decimal)ValueMax / (decimal)TrackLength + m_ev;
					if (d < m_numericUpDown.Minimum) d = m_numericUpDown.Minimum;
					else if (d > m_numericUpDown.Maximum) d = m_numericUpDown.Maximum;
					if (m_numericUpDown.Value != d)
					{
						m_numericUpDown.Value = d;
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
			if(m_numericUpDown !=null)
			{
				int v = EValue;
				if (e.X < v)
				{
					if (m_numericUpDown.Value > 5)
					{
						m_numericUpDown.Value -= 5;
						this.Invalidate();
					}
				}
				else if (e.X > v+ BarLength) 
				{
					if (m_numericUpDown.Value < m_numericUpDown.Maximum - 5)
					{
						m_numericUpDown.Value += 5;
						this.Invalidate();
					}
				}
			}
			base.OnMouseClick(e);
		}
	}
}
