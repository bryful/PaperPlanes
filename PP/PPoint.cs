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

		public int Index { get; set; } = -1;
		public bool IsIn(float x,float y)
		{
			bool ret 
				= ((x > m_PF.X - 6)
				&& (x < m_PF.X + 6)
				&& (y > m_PF.Y - 6)
				&& (y < m_PF.Y + 6));
			return ret;
		}
		private float m_Xmm = 0;
		public float Xmm
		{
			get { return m_Xmm; }
			set 
			{ 
				m_Xmm = value;
				m_PF.X = P.Mm2Px(m_Xmm,m_Dpi);
			}
		}
		private float m_Ymm = 0;
		public float Ymm
		{
			get { return m_Ymm; }
			set
			{
				m_Ymm = value;
				m_PF.Y = P.Mm2Px(m_Ymm, m_Dpi);
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
				m_PF.X = P.Mm2Px(m_Xmm, m_Dpi);
				m_PF.Y = P.Mm2Px(m_Ymm, m_Dpi);
			}
		}
		private PointF m_PF = new PointF(0, 0);
		public PointF GetPixel(PointF d)
		{
			float dx = P.Mm2Px(d.X, m_Dpi);
			float dy = P.Mm2Px(d.Y, m_Dpi);
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

				m_Xmm =	P.Px2Mm(value.X,m_Dpi);
				m_Ymm = P.Px2Mm(value.Y, m_Dpi);
				m_PF.X = P.Mm2Px(m_Xmm, m_Dpi);
				m_PF.Y = P.Mm2Px(m_Ymm, m_Dpi);
			}
		}
		public PointF PointPt
		{
			get
			{
				return new PointF(P.Mm2Px(m_Xmm, 72), P.Mm2Px(m_Ymm, 72));
			}
		}
		public PPoint() 
		{

		}
		public PPoint(float dpi)
		{
			m_Dpi = dpi;
		}
		public PPoint(float w, float h,float dpi)
		{
			m_Dpi = dpi;
			m_Xmm = w; 
			m_Ymm = h;
			m_PF.X = P.Mm2Px(m_Xmm, m_Dpi);
			m_PF.Y = P.Mm2Px(m_Ymm, m_Dpi);
		}
		public void SetDPI(float dpi)
		{
			m_Dpi = dpi;
			m_PF.X = P.Mm2Px(m_Xmm, m_Dpi);
			m_PF.Y = P.Mm2Px(m_Ymm, m_Dpi);
		}
		public void SetMM(float xm,float ym)
		{
			m_Xmm = xm;
			m_Ymm = ym;
			m_PF.X = P.Mm2Px(m_Xmm, m_Dpi);
			m_PF.Y = P.Mm2Px(m_Ymm, m_Dpi);
		}

	}
}
