using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PP
{
	public class PPoint
	{
		static public float Px2Mm(float p, float dpi)
		{
			return (float)((double)p * 25.4 / (double)dpi);
		}
		static public float Mm2Px(float m, float dpi)
		{
			return (float)(((double)m * (double)dpi / 25.4));
		}

		public bool Selected = false;
		public bool IsIn(float x,float y)
		{
			bool ret = false;
			ret = ((x > m_PF.X - 5)
				&& (x < m_PF.X + 5)
				&& (y > m_PF.Y - 5)
				&& (y < m_PF.Y + 5));
			Selected = ret;
			return ret;
		}
		private float m_Xmm = 0;
		public float Xmm
		{
			get { return m_Xmm; }
			set 
			{ 
				m_Xmm = value;
				m_PF.X = Mm2Px(m_Xmm,m_Dpi);
			}
		}
		private float m_Ymm = 0;
		public float Ymm
		{
			get { return m_Ymm; }
			set
			{
				m_Ymm = value;
				m_PF.Y = Mm2Px(m_Ymm, m_Dpi);
			}
		}
		private float m_Dpi = 83;
		public float Dpi
		{
			get { return m_Dpi; }
		}
		public PointF PointMM
		{
			get { return new PointF(m_Xmm, m_Ymm); }
			set
			{

				m_Xmm = value.X;
				m_Ymm = value.Y;
				m_PF.X = Mm2Px(m_Xmm, m_Dpi);
				m_PF.Y = Mm2Px(m_Ymm, m_Dpi);
			}
		}
		private PointF m_PF = new PointF(0, 0);
		public PointF GetPixel(PointF d)
		{
			float dx = Mm2Px(d.X, m_Dpi);
			float dy = Mm2Px(d.Y, m_Dpi);
			PointF ret = new PointF(dx + m_PF.X, dy + m_PF.Y);
			return ret;
		}
		public PointF PointPX
		{
			get 
			{
				return m_PF;
			}
			set 
			{

				m_Xmm = Px2Mm(value.X,m_Dpi);
				m_Ymm = Px2Mm(value.Y, m_Dpi);
				m_PF.X = Mm2Px(m_Xmm, m_Dpi);
				m_PF.Y = Mm2Px(m_Ymm, m_Dpi);
			}
		}
		public PPoint() 
		{

		}
		public PPoint(float dpi)
		{
			m_Dpi = dpi;
		}
		public void SetDPI(float dpi)
		{
			m_Dpi = dpi;
			m_PF.X = Mm2Px(m_Xmm, m_Dpi);
			m_PF.Y = Mm2Px(m_Ymm, m_Dpi);
		}
		public void Add(PPoint pp)
		{
			m_Xmm += pp.Xmm;
			m_Ymm += pp.Ymm;
			m_PF.X = Mm2Px(m_Xmm, m_Dpi);
			m_PF.Y = Mm2Px(m_Ymm, m_Dpi);
		}
	}
}
