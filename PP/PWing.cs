using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PP
{
	public class PWing
	{

		private float m_posY = 0;
		private float m_posX = 0;
		private float m_span = 90;
		private float m_root = 40;
		private float m_tip = 30;
		private float m_Swept = 0;
		private float m_SweptLen = 0;
		// ******************************
		public float PosY
		{
			get
			{
				return m_posY;
			}
			set
			{
				m_posY = value;
				if (m_posY < 0) m_posY = 0;
				Calc();
			}
		}
		// ******************************
		public float PosX
		{
			get
			{
				return m_posX;
			}
			set
			{
				m_posX = value;
				if (m_posX < 0) m_posX = 0;
				Calc();
			}
		}
		// ******************************
		public void SetPosXYRoot(float x, float y,float rt)
		{
			m_posX = x;
			if (m_posX < 0) m_posX = 0;
			m_posY = y;
			if (m_posY < 0) m_posY = 0;
			m_root = rt;
			if (m_root < 10) m_root = 10;
			Calc();
		}
		// ******************************
		public float Span
		{
			get
			{
				return m_span;
			}
			set
			{
				m_span = value;
				if (m_span < 10) m_span = 10;
				Calc();
			}
		}
		// ******************************
		public float Root
		{
			get
			{
				return m_root;
			}
			set
			{
				m_root = value;
				if (m_root < 20) m_root = 20;
				Calc();
			}
		}
		// ******************************
		public float Tip
		{
			get
			{
				return m_tip;
			}
			set
			{
				m_tip = value;
				if (m_tip < 0) m_tip = 0;
				Calc();
			}
		}
		// ******************************
		public float Swept
		{
			get
			{
				return m_Swept;
			}
			set
			{
				SetSwept(value);
			}
		}
		// ******************************
		public float SweptLength
		{
			get
			{
				return m_SweptLen;
			}
			set
			{
				SetSweptLength(value);
			}
		}
		private PPoint [] m_points = new PPoint[4];
		public PointF[] lines(PointF d)
		{
			PointF [] ret = new PointF[4];
			ret[0] = m_points[0].GetPixel(d);
			ret[1] = m_points[1].GetPixel(d);
			ret[2] = m_points[2].GetPixel(d);
			ret[3] = m_points[3].GetPixel(d);
			return ret;
		}
		public float Dpi
		{
			get { return m_points[0].Dpi; }
			set
			{
				float f = value;
				if (f < 72) f = 72;
				m_points[0].SetDPI(f);
				m_points[1].SetDPI(f);
				m_points[2].SetDPI(f);
				m_points[3].SetDPI(f);
			}
		}
	
		public void SetSwept(float r)
		{
			if (r < -60) r = -60;
			else if (r > 60) r = 60;

			bool b = (r < 0);
			r = Math.Abs(r);
			m_Swept = r;
			m_SweptLen =  (float)(m_span* Math.Tan(r*Math.PI/180));
			if (b) { m_SweptLen *= -1; }
			Calc();
		}
		public void SetSweptLength(float len)
		{
			bool b = (len < 0);
			float l = Math.Abs(len);

			float sw = (float)(Math.Atan2(l, m_span) * 180 / Math.PI);
			if (b)
			{
				sw *= -1;
			}
			m_Swept = sw;
			m_SweptLen = len;
			Calc();
		}
		private void Calc()
		{
			m_points[0].Xmm = m_posX;
			m_points[0].Ymm = m_posY;
			m_points[1].Xmm = m_points[0].Xmm + m_span;
			m_points[1].Ymm = m_points[0].Ymm + m_SweptLen;
			m_points[2].Xmm = m_points[1].Xmm;
			m_points[2].Ymm = m_points[1].Ymm + m_tip;
			m_points[3].Xmm = m_points[0].Xmm;
			m_points[3].Ymm = m_points[0].Ymm + m_root;
		}
		public bool IsSelected(int idx)
		{
			if ((idx>=0)&&(idx<4))
			{
				return m_points[idx].Selected;
			}
			else
			{
				return false;
			}
		}
		public PWing()
		{
			m_points[0] = new PPoint();
			m_points[1] = new PPoint();
			m_points[2] = new PPoint();
			m_points[3] = new PPoint();
			Dpi = 83.0f;
			Calc();
		}
		public void SetIndex(int start=0)
		{
			int idx = start;
            for (int i = 0; i < m_points.Length; i++)
            {
				m_points[0].Index = idx;
				idx++;
			}
		}

		public bool IsInPoint(int idx, float x, float y)
		{
			bool ret = false;
			if ((idx >= 0) && (idx < 4))
			{
				ret = m_points[idx].IsIn(x, y);
			}
			return ret;
		}
	}
}
