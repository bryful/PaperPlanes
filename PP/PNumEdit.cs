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
		private TextBox m_TextBox = null;
		private Bitmap [] m_bitmap = new Bitmap[6];
		
		private int m_MatchValue = 0;
		public float MatchValue
		{
			get { return (float)m_MatchValue / 100; }
			set
			{
				m_MatchValue = (int)(m_MatchValue * 100);
				this.Invalidate();
			}
		}
		private bool m_MatchMode = true;
		[Category("PaperPlane")]
		public bool MatchMode
		{
			get { return m_MatchMode; }
			set
			{
				m_MatchMode = value;
				if (m_MatchMode == true)
				{
					Calc();
					this.Invalidate();
				}
				else
				{
					m_EditColor = m_EditSubColor;
					this.Invalidate();
				}
			}

		}
		private int m_Value = 0;
		[Category("PaperPlane")]
		public float Value
		{
			get { return (float)m_Value / 100; }
			set
			{
				int v = (int)(value * 100);
				SetMValeu(v);
				Calc();
				this.Invalidate();
			}
		}
		public void SetValues(float v,float m)
		{
			m_Value = (int)(v*100);
			if (m_Value < m_Minimum) m_Value = m_Minimum;
			if (m_Value > m_Maximum) m_Value = m_Maximum;
			m_MatchValue = (int)(m*100);
			Calc();
			this.Invalidate ();
			OnValueFChanged(new ValueFChangedEventArgs(m_Value));
		}
		private void SetMValeu(int v)
		{
			if (m_Value != v)
			{
				m_Value = v;
				OnValueFChanged(new ValueFChangedEventArgs(m_Value));
			}
		}
		private int m_AddValue = 100;
		[Category("PaperPlane")]
		public float AddValue
		{
			get { return (float)m_AddValue / 100; }
			set
			{
				m_AddValue = (int)(value * 100);
				if (m_AddValue < 1) m_AddValue = 1;
			}
		}
		private int m_Minimum = 0;
		[Category("PaperPlane")]
		public float Minimum
		{
			get { return (float)m_Minimum / 100; }
			set
			{
				m_Minimum = (int)(value * 100);
				if (m_Minimum > m_Maximum) m_Minimum = m_Maximum;
				if (m_Value < m_Minimum)
				{
					SetMValeu(m_Minimum);
				}
				this.Invalidate();
			}
		}
		private int m_Maximum = 1000*100;
		[Category("PaperPlane")]
		public float Maximum
		{
			get { return (float)m_Maximum / 100; }
			set
			{
				m_Maximum = (int)(value * 100);
				if (m_Maximum < m_Minimum) m_Maximum = m_Minimum;
				if (m_Value > m_Maximum) SetMValeu(m_Maximum);
				this.Invalidate();
			}
		}
		public void SetMinMax(float mn, float mx)
		{
			m_Minimum = (int)(mn * 100);
			m_Maximum = (int)(mx * 100);
			if (Minimum > m_Maximum) 
			{
				int v = m_Minimum;
				m_Minimum = m_Maximum;
				m_Maximum = v;
			}
			if(m_Value < m_Minimum) SetMValeu(m_Minimum);
			if (m_Value > m_Maximum) SetMValeu(m_Maximum);
			
		}

		private int m_MatchBorderIn = 10 * 100;
		[Category("PaperPlane")]
		public float MatchBorderIn
		{
			get { return (float)m_MatchBorderIn / 100; }
			set
			{
				m_MatchBorderIn = (int)(value * 100);
				Calc();
				this.Invalidate();
			}
		}
		private int m_MatchBorderOut = 300 * 100;
		[Category("PaperPlane")]
		public float MatchBorderOut
		{
			get { return (float)m_MatchBorderOut / 100; }
			set
			{
				m_MatchBorderOut = (int)(value * 100);
				Calc();
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
		private bool m_Readonly = false;
		[Category("PaperPlane")]
		public bool ReadOnly 
		{
			get {return m_Readonly; }
			set
			{
				m_Readonly = value;
				this.Invalidate();
			}
		}
		[Category("PaperPlane")]
		public string ValueText
		{
			get
			{
				string s = "";
				s = ((int)(m_Value / 100)).ToString();
				s += ".";
				s += ((int)(m_Value % 100)).ToString("D2");
				return s;
			}
		}
		private bool m_IsShowCaption = true;
		[Category("PaperPlane")]
		public bool IsShowCaption
		{
			get { return m_IsShowCaption; }
			set 
			{
				m_IsShowCaption = value;
				this.Invalidate();
			}
		}
		private int m_CaptionWidth = 80;
		[Category("PaperPlane")]
		public int CaptionWidth
		{
			get { return m_CaptionWidth; }
			set
			{
				m_CaptionWidth = value;
				this.Invalidate();
			}
		}
		[Category("PaperPlane")]
		public int EditWidth
		{
			get { return this.Width - m_CaptionWidth; }
		}
		// *********************************************************
		private Color m_EditColor = SystemColors.Window;
		[Category("PaperPlane")]
		public Color EditColor
		{
			get { return m_EditColor; }
			set
			{
				m_EditColor = value;
				this.Invalidate();
			}
		}
		private Color m_EditSubColor = SystemColors.Window;
		[Category("PaperPlane")]
		public Color EditSubColor
		{
			get { return m_EditSubColor; }
			set
			{
				m_EditSubColor = value;
				this.Invalidate();
			}
		}
		private Color m_MatchColor = Color.Yellow;
		[Category("PaperPlane")]
		public Color MatchColor
		{
			get { return m_MatchColor; }
			set
			{
				m_MatchColor = value;
				this.Invalidate();
			}
		}
		private Color m_BorderOutColor = Color.DimGray;
		[Category("PaperPlane")]
		public Color BorderOutColor
		{
			get { return m_BorderOutColor; }
			set
			{
				m_BorderOutColor = value;
				this.Invalidate();
			}
		}
		private Color m_BorderInColor = Color.LightGray;
		[Category("PaperPlane")]
		public Color BorderInColor
		{
			get { return m_BorderInColor; }
			set
			{
				m_BorderInColor = value;
				this.Invalidate();
			}
		}
		// *********************************************************
		public PNumEdit()
		{
			DoubleBuffered = true;
			this.Size = new Size(160, 24);
			m_bitmap[0] = Properties.Resources.Arrow_0000;
			m_bitmap[1] = Properties.Resources.Arrow_0001;
			m_bitmap[2] = Properties.Resources.Arrow_0002;
			m_bitmap[3] = Properties.Resources.Arrow_0003;
			m_bitmap[4] = Properties.Resources.Arrow_0004;
			m_bitmap[5] = Properties.Resources.Arrow_0005;
			base.BackColor = SystemColors.Control;
			m_EditColor = SystemColors.Window;
			this.SetStyle(
				ControlStyles.Selectable |
				ControlStyles.UserMouse |
				ControlStyles.DoubleBuffer |
				ControlStyles.UserPaint |
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.ResizeRedraw |
				ControlStyles.SupportsTransparentBackColor,
				true);
			Calc();
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
		// ************************************************************
		protected override void OnPaint(PaintEventArgs e)
		{
			using(SolidBrush sb = new SolidBrush(BackColor))
			using (Pen p = new Pen(ForeColor))
			using (StringFormat sf = new StringFormat())
			{
				Graphics g = e.Graphics;
				sb.Color = Color.Transparent;
				g.FillRectangle(sb,this.ClientRectangle);
				Rectangle rct0,rct1,rct2;
				int w = this.Width;
				int l = 0;
				if ((m_CaptionWidth>0)&&(m_IsShowCaption))
				{
					sf.Alignment = StringAlignment.Far;
					sf.LineAlignment = StringAlignment.Center;
					rct0 = new Rectangle(l,0,m_CaptionWidth,this.Height);
					sb.Color = ForeColor;
					g.DrawString(this.Text, this.Font, sb, rct0, sf);
					w = this.Width - m_CaptionWidth;
					l = m_CaptionWidth;
				}
				if ((m_IsShowArrow)&&(m_Readonly==false))
				{
					rct1 = new Rectangle(
						l,
						0,
						w - this.Height,
						this.Height
						);
					rct2 = new Rectangle(
						this.Width - this.Height + 1,
						1,
						this.Height - 1,
						this.Height - 1
						);
					DrawArrow(g, rct2);
				}
				else
				{
					rct1 = new Rectangle(
					l,
					0,
					w,
					this.Height
					);
				}

				sb.Color = m_EditColor;
				g.FillRectangle(sb, rct1);

				if (m_TextBox == null)
				{
					sf.Alignment = StringAlignment.Far;
					sf.LineAlignment = StringAlignment.Center;
					sb.Color = ForeColor;
					g.DrawString(ValueText, this.Font, sb, rct1, sf);
				}
				p.Width = 1;
				if (this.Focused)
				{
					p.Color = Color.Blue;
				}
				else
				{
					p.Color = ForeColor;
				}
				g.DrawRectangle(p,new Rectangle(rct1.Left,rct1.Top,rct1.Width-1,rct1.Height-1));
			}
		}
		// ************************************************************
		private void EditStart()
		{
			if (m_Readonly == true) return;
			if (m_TextBox==null)
			{
				m_TextBox = new TextBox();
				m_TextBox.TextAlign = HorizontalAlignment.Right;
				m_TextBox.BorderStyle = BorderStyle.None;
				m_TextBox.Font = this.Font;
				int l = m_CaptionWidth + 2;
				if (m_IsShowCaption == false) l = 2;
				int t = (this.Height - m_TextBox.Height) / 2;
				int w = this.Width-4;
				if (m_IsShowArrow) w = w - this.Height;
				if (m_IsShowCaption) w -= m_CaptionWidth;
				m_TextBox.Location = new Point(l,t);
				m_TextBox.Size = new Size(w,m_TextBox.Height);
				m_TextBox.PreviewKeyDown += (sender, e) =>
				{
					if(e.KeyCode == Keys.Escape)
					{
						EditChk();
						EditRemove();
					}else if (e.KeyCode == Keys.Enter)
					{
						if (EditChk()) { EditRemove(); }
					}
				};
				m_TextBox.LostFocus += (sender, e) =>
				{
					EditChk();
					EditRemove();
				};
				m_TextBox.MouseDown += (sender, e) =>
				{
					if((e.X<0)|| (e.Y > m_TextBox.Width)
					||(e.Y<0)||(e.X>m_TextBox.Height))
					{
						EditChk();
						EditRemove();
					}
				};
				this.Controls.Add(m_TextBox);
			}
			this.Invalidate();
			m_TextBox.Focus();
			m_TextBox.Text = ValueText;
		}
		private bool EditChk()
		{
			bool ret = false;
			if(m_TextBox==null) return ret;
			float k = 0;
			if (float.TryParse(m_TextBox.Text,out k))
			{
				Value = k;
				ret = true;
			}
			return ret;
		}
		private bool EditRemove()
		{
			bool ret = false;
			if (m_TextBox == null) return ret;
			this.Controls.Remove(m_TextBox);
			m_TextBox = null;
			return ret;
		}
		// ************************************************************
		protected override void OnMouseDown(MouseEventArgs e)
		{
			int w = this.Width-this.Height;
			m_md = -1;
			if (m_Readonly == false)
			{
				if (e.X > w)
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
				else if(e.X>m_CaptionWidth)
				{
					EditStart();
				}
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
						OnValueFChanged(new ValueFChangedEventArgs(m_Value));
						break;
					case 1:
						m_Value += m_AddValue;
						ChkValue();
						OnValueFChanged(new ValueFChangedEventArgs(m_Value));
						break;
				}

				m_md = -1;
				this.Refresh();
			}
			base.OnMouseUp(e);
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				EditStart();
			}
			base.OnKeyDown(e);
		}
		protected override void OnGotFocus(EventArgs e)
		{
			if(m_TextBox != null)
			{
				EditChk();
				EditRemove();
			}
			base.OnGotFocus(e);
			this.Invalidate();
		}
		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			this.Invalidate();
		}
		public void Calc()
		{
			if (m_MatchMode == false) return;
			int ff = Math.Abs(m_Value - m_MatchValue);
			if (ff < m_MatchBorderIn)
			{
				m_EditColor = m_MatchColor;
			}
			else if (ff > m_MatchBorderOut)
			{
				m_EditColor = m_BorderOutColor;
			}
			else
			{
				double ff2 = (ff - (double)m_MatchBorderIn) / ((double)m_MatchBorderOut - (double)m_MatchBorderIn);

				int r = (int)(m_BorderInColor.R + ((float)m_BorderOutColor.R - (float)m_BorderInColor.R) * ff2);
				int g = (int)(m_BorderInColor.G + ((float)m_BorderOutColor.G - (float)m_BorderInColor.G) * ff2);
				int b = (int)(m_BorderInColor.B + ((float)m_BorderOutColor.B - (float)m_BorderInColor.B) * ff2);
				m_EditColor = Color.FromArgb(r, g, b);
			}
		}
	}
}
