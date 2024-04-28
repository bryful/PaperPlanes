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
	public class PNumBox : TextBox
	{
		private bool m_MatchMode = true;
		[Category("PaperPlane")]
		public bool MatchMode
		{
			get { return m_MatchMode; }
			set 
			{ 
				m_MatchMode = value; 
				if(m_MatchMode == true)
				{
					Calc();
					this.Invalidate();
				}
				else
				{
					base.BackColor = m_BackColor;
					this.Invalidate();
				}
			}

		}


		private float m_Value = 0;
		[Category("PaperPlane")]
		public float Value
		{
			get { return m_Value; }
			set
			{
				m_Value = value;
				Calc();
				SetText(value);
			}
		}
		private float m_MatchValue = 0;
		[Category("PaperPlane")]
		public float MatchValue
		{
			get { return m_MatchValue; }
			set
			{
				m_MatchValue = value;
				Calc();
				this.Invalidate();
			}
		}
		private float m_MatchBorder = 10;
		[Category("PaperPlane")]
		public float MatchBorder
		{
			get { return m_MatchBorder; }
			set
			{
				m_MatchBorder = value;
				Calc();
				this.Invalidate();
			}
		}
		private float m_CmpBorder = 100;
		[Category("PaperPlane")]
		public float CmpBorder
		{
			get { return m_CmpBorder; }
			set
			{
				m_CmpBorder = value;
				Calc();
				this.Invalidate();
			}
		}
		private Color m_CmpColor = Color.FromArgb(128,128,128);
		private Color m_MatchColor = Color.FromArgb(255, 255, 0);
		[Category("PaperPlane")]
		public Color CmpColor
		{
			get { return m_CmpColor; }
			set
			{
				m_CmpColor = value;
				Calc();
			}
		}
		[Category("PaperPlane")]
		public Color MatchColor
		{
			get { return m_MatchColor; }
			set
			{
				m_MatchColor = value;
				Calc();
			}
		}

		private void SetText(float value)
		{
			int v1 = (int)(value*100);
			float v2 = (float)v1 /100;
			base.Text = $"{v2}";
		}
		[Category("PaperPlane")]
		public new string Text
		{
			get { return base.Text; }
			set
			{

			}
		}
		private Color m_BackColor = SystemColors.Control;
		[Category("PaperPlane")]
		public Color BackColorSub
		{
			get { return m_BackColor; }
			set {
				m_BackColor = value;
			}
		}
		[Category("PaperPlane")]
		public new Color BackColor
		{
			get { return base.BackColor; }
			set
			{
			}
		}
		// *************************************************************
		public void Calc()
		{
			if (m_MatchMode == false) return;
			float ff = Math.Abs(m_Value - m_MatchValue);
			if (ff < m_MatchBorder)
			{
				base.BackColor = m_MatchColor;
			}else if (ff> m_CmpBorder)
			{
				base.BackColor = m_CmpColor;
			}
			else
			{
				float ff2 = (ff - (float)m_MatchBorder)/((float)m_CmpBorder - (float)m_MatchBorder);

				int r = (int)(m_CmpColor.R + ((float)255 - (float)m_CmpColor.R) * ff2);
				int g = (int)(m_CmpColor.G + ((float)255 - (float)m_CmpColor.G) * ff2);
				int b = (int)(m_CmpColor.B + ((float)255 - (float)m_CmpColor.B) * ff2);
				base.BackColor = Color.FromArgb(r, g, b);
			}
		}
		// *************************************************************
		public PNumBox()
		{
			m_BackColor = base.BackColor;
			Calc();
		}
		// *************************************************************
	}
}
