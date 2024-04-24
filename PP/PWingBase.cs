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
	public class PWingBase
	{
		public event EventHandler WingChanged;

		protected virtual void OnWingChanged(EventArgs e)
		{
			if (WingChanged != null)
			{
				WingChanged(this, e);
			}
		}
		private enum PRM
		{
			PosY,
			PosX,
			Span,
			Root,
			Tip,
			Swept,
			SweptLen,
			Count,
		}
		private float m_posY = 0;
		private float m_posX = 0;
		private float m_span = 90;
		private float m_root = 40;
		private float m_tip = 30;
		private float m_Swept = 0;
		private float m_SweptLen = 0;

		//private float[] Prm = new float[(int)PRM.Count];
		private float[] PrmBak = new float[(int)PRM.Count]; 

		// ******************************
		public float PosY
		{
			get
			{
				return m_posY;
			}
			set
			{
				if (value < 0) value = 0;
				if (m_posY != value)
				{
					m_posY = value;
					Calc();
					OnWingChanged(new EventArgs());
				}
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
				if (value < 0) value = 0;
				if (m_posX != value)
				{
					m_posX = value;
					Calc();
					OnWingChanged(new EventArgs());
				}
			}
		}
		// ******************************
		public void SetPosXYRoot(float x, float y,float rt)
		{
			if (x<0) x = 0;
			if (y < 0) y = 0;
			if (rt < 10) rt = 10;
			if (m_posX != x || m_posY != y || m_root!=rt) 
			{
				m_posX = x;
				m_posY = y;
				m_root = rt;
				Calc();
				OnWingChanged(new EventArgs());
			}
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
				if (value < 10) value = 10;
				if (m_span != value)
				{
					m_span = value;
					Calc();
					OnWingChanged(new EventArgs());
				}
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
				if (value < 0) value = 0;
				if (m_root != value)
				{
					m_root = value;
					Calc();
					OnWingChanged(new EventArgs()) ;
				}
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
				if (value < 0) value = 0;
				if (m_tip != value)
				{
					m_tip = value;
					Calc();
					OnWingChanged(new EventArgs() );
				}
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
				if (value < -60) value = -60;
				else if (value > 60) value = 60;
				if (m_Swept != value)
				{
					m_Swept = value;
					Calc();
					OnWingChanged(new EventArgs());
				}
			}
		}
		// ******************************
		public float SweptLength
		{
			get
			{
				return m_SweptLen;
			}
		}
		// ******************************
		public void PushPrm()
		{
			PrmBak[(int)PRM.PosX] = m_posX;
			PrmBak[(int)PRM.PosY] = m_posY;
			PrmBak[(int)PRM.Span] = m_span;
			PrmBak[(int)PRM.Root] = m_root;
			PrmBak[(int)PRM.Tip] = m_tip;
			PrmBak[(int)PRM.Swept] = m_Swept;
			PrmBak[(int)PRM.SweptLen] = m_SweptLen;
		}
		// ******************************
		public void AddPosY(float y)
		{
			if (y != 0)
			{
				m_posY = PrmBak[(int)PRM.PosY] + y;
				Calc();
				OnWingChanged(new EventArgs());
			}
		}
		// ******************************
		public void AddWingEdge(float x, float y)
		{
			if (x != 0 || y != 0)
			{
				m_span = PrmBak[(int)PRM.Span] + x;
				if (m_span < 5) m_span = 5;
				float y2 = PrmBak[(int)PRM.SweptLen] + y;
				float y3 = Math.Abs(y2);
				float rr = (float)(Math.Atan(y3 / m_span) * 180 / Math.PI);
				if (y2 < 0) { rr *= -1; }
				m_Swept = rr;
				Calc();
				OnWingChanged(new EventArgs());
			}
		}
		// ******************************
		public void AddTip(float y)
		{
			if (y != 0)
			{
				m_tip = PrmBak[(int)PRM.Tip] + y;
				if (m_tip < 5) m_tip = 5;
				Calc();
				OnWingChanged(new EventArgs());
			}
		}
		// ******************************
		public void AddRoot(float y)
		{
			if (y != 0)
			{
				m_root = PrmBak[(int)PRM.Root] + y;
				if (m_root < 10) m_root = 10;
				Calc();
				OnWingChanged(new EventArgs());
			}
		}
		// ******************************
		private PPoint [] m_points = new PPoint[4];
		public PointF[] Lines(PointF d)
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
	

		private void Calc()
		{
			if (m_Swept < -60) m_Swept = -60;
			else if (m_Swept > 60) m_Swept = 60;
			float r = Math.Abs(m_Swept);
			m_SweptLen = (float)(m_span * Math.Tan(r * Math.PI / 180));
			if (m_Swept < 0) m_SweptLen *= -1;

			if (m_posX < 0) m_posX = 0;
			if (m_span < 5) m_span = 5;
			if (m_root < 5) m_root = 5;
			if (m_tip < 5) m_tip = 5;

			m_points[0].Xmm = m_posX;
			m_points[0].Ymm = m_posY;
			m_points[1].Xmm = m_points[0].Xmm + m_span;
			m_points[1].Ymm = m_points[0].Ymm + m_SweptLen;
			m_points[2].Xmm = m_points[1].Xmm;
			m_points[2].Ymm = m_points[1].Ymm + m_tip;
			m_points[3].Xmm = m_points[0].Xmm;
			m_points[3].Ymm = m_points[0].Ymm + m_root;
		}
		public PWingBase()
		{
			m_points[0] = new PPoint();
			m_points[1] = new PPoint();
			m_points[2] = new PPoint();
			m_points[3] = new PPoint();
			Dpi = 83.0f;
			Calc();
			PushPrm();
		}
		public void CreateIndex(int start=0)
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
