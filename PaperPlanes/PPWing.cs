using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PaperPlanes
{
	public class PPPoint
	{
		public bool Selected = false;

		private float m_DPI = 82;
		private float m_X = 0;
		private float m_Y = 0;
		private float m_PX = 0;
		private float m_PY = 0;

		public float X { get { return m_X; } }
		public float Y { get { return m_Y; } }
		public float PX { get { return m_PX; } }
		public float PY { get { return m_PY; } }
		// ********************************************************
		private float LimitF(float v)
		{
			int v2 = (int)(v * 10 + 0.5);
			return (float)v2 / 10;
		}
		// ********************************************************
		public PPPoint(float x =0, float y= 0, float dpi = 82)
		{
			m_X = x;
			m_Y = y;
			SetDPI(dpi);
		}
		#region Set
		// ********************************************************
		public void SetDPI(float dpi = 0)
		{
			if(dpi != 0)m_DPI = dpi;
			m_PX = PP.MM2P(m_X, m_DPI);
			m_PY = PP.MM2P(m_Y, m_DPI);
		}
		// ********************************************************
		public void CopyFrom(PPPoint p)
		{
			m_DPI = p.m_DPI;
			m_X = p.m_X;
			m_Y = p.m_Y;
			m_PX = p.m_PX;
			m_PY = p.m_PY;
		}
		// ********************************************************
		public void  SetX(float value, float dpi=0)
		{
			if(dpi != 0)m_DPI = dpi;
			m_X = LimitF(value);
			m_PX = (float)PP.MM2P(value,m_DPI);
		}
		// ********************************************************
		public void  SetY(float value, float dpi=0)
		{
			if(dpi != 0)m_DPI = dpi;
			m_Y = LimitF(value);
			m_PY = (float)PP.MM2P(value,m_DPI);
		}
		// ********************************************************
		public void  SetPX(float value, float dpi=0)
		{
			if(dpi != 0)m_DPI = dpi;
			m_PX = value;
			m_X = LimitF((float)PP.P2MM(value,m_DPI));
		}
		// ********************************************************
		public void  SetPY(float value, float dpi=0)
		{
			if(dpi != 0)m_DPI = dpi;
			m_PY = value;
			m_Y = LimitF((float)PP.P2MM(value,m_DPI));
		}
		#endregion

		// ********************************************************
		public bool InMouseDown(int mx, int my)
		{
			bool ret = false;

			int v = 5;
			ret = ((m_PX - v < mx) && (m_PX + v > mx) && (m_PY - v < my) && (m_PY + v > my));
			Selected = ret;
			return ret;
		}
		// ********************************************************
		public void Draw(Graphics g, SolidBrush sb, Pen p)
		{
			g.FillEllipse(sb, m_PX - 3, m_PY - 3, 6, 6);

			if (Selected == true)
			{
				float pb = p.Width;
				p.Width = 1;
				g.DrawEllipse(p, m_PX - 6, m_PY - 6, 12, 12);
				p.Width = pb;
			}
		}
		// ********************************************************
		public PointF ToPointF
		{
			get { return new PointF(m_PX, m_PY); }
		}
		// ********************************************************

	}

	public class PPWing :Component
	{
		#region mode
		public enum MODE
		{
			POINT4 = 0,
			POINT6
		}
		private MODE m_MODE = MODE.POINT4;
		public MODE Wing_MODE
		{
			get { return m_MODE; }
			set
			{
				if (m_MODE != value)
				{
					m_MODE = value;
					MakePooints();
					SelectIndex = -1;
				}
			}
		}
		#endregion

		private int m_SelectedIndex = -1;
		public int SelectIndex
		{
			get { return m_SelectedIndex; }
			set
			{
				if(m_SelectedIndex != value)
				{
					m_SelectedIndex = value;
					for (int i = 0; i < m_Points.Length; i++) m_Points[i].Selected = false;
					if (m_SelectedIndex>=0)
					{
						m_Points[m_SelectedIndex].Selected = true;
					}
				}
			}
		}

		private PointF m_DispLocasion = new PointF(10,120);
		public PointF DispLocation
		{
			get { return m_DispLocasion; }
			set
			{
				if (m_DispLocasion != value)
				{
					m_DispLocasion = value;
					MakePooints();
				}
			}
		}


		private float m_DPI = 82;
		public float DPI
		{
			get { return m_DPI; }
			set { SetDPI(value,true); }
		}

		public void SetLocDPI(float dpi,PointF loc)
		{
			if ((m_DPI != dpi) || (m_DispLocasion != loc))
			{
				SetDPI(dpi,false);
				m_DispLocasion = loc;
				MakePooints();
			}
		}

		#region Wing params

	
		public float[] Params
		{
			get
			{
				float[] ret = new float[9];
				ret[0] = LimitF(m_WingPos);
				ret[1] = LimitF(m_WingRoot);
				ret[2] = LimitF(m_WingTip);
				ret[3] = LimitF(m_WingTipOffset);
				ret[4] = LimitF(m_WingSpan);
				ret[6] = LimitF(m_WingDihedral);
				ret[5] = LimitF(m_WingSpan2);
				ret[7] = LimitF(m_WingTip2);
				ret[8] = LimitF(m_WingTipOffset2);
				return ret;

			}
			set
			{
				if (value.Length < 9) return;
				bool b = false;
				for (int i = 0; i < 9; i++) value[i] = LimitF(value[i]);
				if (m_WingPos != value[0]) { m_WingPos = value[0]; b = true; }
				if (m_WingRoot != value[1]) { m_WingRoot = value[1]; b = true; }
				if (m_WingTip != value[2]) { m_WingTip = value[2]; b = true; }
				if (m_WingTipOffset != value[3]) { m_WingTipOffset = value[3]; b = true; }
				if (m_WingSpan != value[4]) { m_WingSpan = value[4]; b = true; }
				if (m_WingDihedral != value[5]) { m_WingDihedral = value[5]; b = true; }
				if (m_WingSpan2 != value[6]) { m_WingSpan2 = value[6]; b = true; }
				if (m_WingTip2 != value[7]) { m_WingTip2 = value[7]; b = true; }
				if (m_WingTipOffset2 != value[8]) { m_WingTipOffset2 = value[8]; b = true; }
				if(b) MakePooints();
			}
		}

		/// <summary>
		/// 上反角
		/// </summary>
		private float m_WingDihedral = 15;
		public float WingDihedral
		{
			get { return m_WingDihedral; }
			set
			{
				value = LimitF(value);
				if (m_WingDihedral != value)
				{
					m_WingDihedral = value;
					MakePooints();
				}
			}
		}
		/// <summary>
		/// 翼根
		/// </summary>
		private float m_WingRoot = 50;
		public float WingRoot
		{
			get { return m_WingRoot; }
			set
			{
				value = LimitF(value);
				if (m_WingRoot != value)
				{
					m_WingRoot = value;
					MakePooints();
				}
			}
		}
		/// <summary>
		/// 翼端
		/// </summary>
		private float m_WingTip = 30;
		public float WingTip
		{
			get { return m_WingTip; }
			set
			{
				value = LimitF(value);
			if (m_WingTip != value)
				{
					m_WingTip = value;
					MakePooints();
				}
			}
		}
		/// <summary>
		/// 翼端後退
		/// </summary>
		private float m_WingTipOffset = 10;
		public float WingTipOffset
		{
			get { return m_WingTipOffset; }
			set
			{
				value = LimitF(value);

				if (m_WingTipOffset != value)
				{
					m_WingTipOffset = value;
					MakePooints();
				}
			}
		}
		/// <summary>
		/// 翼長さ
		/// </summary>
		private float m_WingSpan = 180;
		public float WingSpan
		{
			get { return m_WingSpan; }
			set
			{
				value = LimitF(value);

				if (m_WingSpan != value)
				{
					m_WingSpan = value;
					MakePooints();
				}
			}
		}
		/// <summary>
		/// 位置
		/// </summary>
		private float m_WingPos = 50;
		public float WingPos
		{
			get { return m_WingPos; }
			set
			{
				value = LimitF(value);
				if (m_WingPos != value)
				{
					m_WingPos = value;
					MakePooints();
				}
			}
		}

		private float m_WingTip2 = 20;
		public float WingTip2
		{
			get { return m_WingTip2; }
			set
			{
				if (m_MODE == MODE.POINT6)
				{
				value = LimitF(value);
					if (m_WingTip2 != value)
					{
						m_WingTip2 = value;
						MakePooints();
					}
				}
			}
		}
		private float m_WingTipOffset2 = 10;
		public float WingTipOffset2
		{
			get { return m_WingTipOffset2; }
			set
			{
				if (m_MODE == MODE.POINT6)
				{
				value = LimitF(value);
					if (m_WingTipOffset2 != value)
					{
						m_WingTipOffset2 = value;
						MakePooints();
					}
				}
			}
		}
		private float m_WingSpan2 = 10;
		public float WingSpan2
		{
			get { return m_WingSpan2; }
			set
			{
				value = LimitF(value);
				if (m_MODE == MODE.POINT6)
				{
					if (m_WingSpan2 != value)
					{
						m_WingSpan2 = value;
						MakePooints();
					}
				}
			}
		}
		#endregion
		//描画用の配列
		private PPPoint[] m_Points = new PPPoint[6];

		//上反角を反映したポイント配列
		private PPPoint[] m_HorPoints = new PPPoint[4];
		private PPPoint[] m_VerPoints = new PPPoint[4];
		//
		private PPPoint[] m_HorMAC = new PPPoint[2];
		private PPPoint[] m_VerMAC = new PPPoint[2];

		// ******************************************
		public PPWing()
		{
			for (int i = 0; i < m_Points.Length; i++) m_Points[i] = new PPPoint(0,0,m_DPI);
			MakePooints();
		}
		// ******************************************
		public void SetDPI(float dpi,bool refFlag = false)
		{
			if (m_DPI != dpi)
			{
				m_DPI = dpi;
				for (int i = 0; i < m_Points.Length; i++) m_Points[i].SetDPI(dpi);
				if(refFlag)
				{
					MakePooints();
				}
			}
		}
		// ******************************************
		public void MakePooints()
		{
			if(m_MODE == MODE.POINT4)
			{
				float x = m_DispLocasion.X + m_WingPos;
				float y = m_DispLocasion.Y;
				m_Points[0].SetX(x);
				m_Points[0].SetY(y);
				x += m_WingTipOffset;
				y -= m_WingSpan / 2;
				m_Points[1].SetX(x);
				m_Points[1].SetY(y);
				x += m_WingTip;
				m_Points[2].SetX(x);
				m_Points[2].SetY(y);
				x = m_DispLocasion.X + m_WingPos + m_WingRoot;
				y = m_DispLocasion.Y;
				m_Points[3].SetX(x);
				m_Points[3].SetY(y);
			}
			else
			{
				float x = m_DispLocasion.X + m_WingPos;
				float y = m_DispLocasion.Y;
				m_Points[0].SetX(x);
				m_Points[0].SetY(y);
				x += m_WingTipOffset;
				y -= m_WingSpan / 2;
				m_Points[1].SetX(x);
				m_Points[1].SetY(y);

				x += m_WingTipOffset2;
				y -= m_WingSpan2;
				m_Points[2].SetX(x);
				m_Points[2].SetY(y);
				x += m_WingTip2;
				m_Points[3].SetX(x);
				m_Points[3].SetY(y);
				x = m_Points[1].X + m_WingTip;
				y = m_Points[1].Y;
				m_Points[4].SetX(x);
				m_Points[4].SetY(y);

				x = m_DispLocasion.X + m_WingPos + m_WingRoot;
				y = m_DispLocasion.Y;
				m_Points[5].SetX(x);
				m_Points[5].SetY(y);
			}
		}
		public PointF [] OriPoints
		{
			get
			{
				if (m_MODE == MODE.POINT4)
				{
					return new PointF[0];
				}
				else
				{
					PointF[] p = new PointF[2];
					p[0] = m_Points[1].ToPointF;
					p[1] = m_Points[4].ToPointF;
					return p;
				}
			}
		}
		// ******************************************
		public PointF [] Points()
		{
			PointF[] ret = new PointF[0];
			if (m_MODE == MODE.POINT4)
			{
				ret = new PointF[4];
				ret[0] = m_Points[0].ToPointF;
				ret[1] = m_Points[1].ToPointF;
				ret[2] = m_Points[2].ToPointF;
				ret[3] = m_Points[3].ToPointF;
			}
			else
			{
				ret = new PointF[6];
				ret[0] = m_Points[0].ToPointF;
				ret[1] = m_Points[1].ToPointF;
				ret[2] = m_Points[2].ToPointF;
				ret[3] = m_Points[3].ToPointF;
				ret[4] = m_Points[4].ToPointF;
				ret[5] = m_Points[5].ToPointF;

			}

			return ret;
		}
		// ******************************************
		public void Draw(Graphics g,SolidBrush sb, Pen p)
		{
			g.DrawLines(p, Points());

			m_Points[0].Draw(g, sb, p);
			m_Points[1].Draw(g, sb, p);
			m_Points[2].Draw(g, sb, p);
			m_Points[3].Draw(g, sb, p);
			if(m_MODE == PPWing.MODE.POINT6)
			{
				m_Points[4].Draw(g, sb, p);
				m_Points[5].Draw(g, sb, p);
			}

		}
		// ******************************************
		public bool InMouseDow(int mx, int my)
		{
			bool ret = false;
			int cnt = 4;
			if (m_MODE == MODE.POINT4)
			{
				cnt = 4;
			}
			else
			{
				cnt = 6;
			}
			int idx = -1;
			for(int i=0; i<cnt;i++)
			{
				if (m_Points[i].InMouseDown(mx, my)==true)
				{
					ret = true;
					idx = i;
				}
			}
			m_SelectedIndex = idx;
			return ret;
		}
		// ******************************************
		public void SetPointPixel(float x, float y)
		{
			SetPointPixel(new PointF(x, y));
		}
		// ******************************************
		private float LimitF(float v)
		{
			int v2 = (int)(v * 10 + 0.5);

			return (float)v2 / 10;
		}
		// ******************************************
		public void SetPointPixel(PointF pos)
		{
			if (m_SelectedIndex < 0) return;

			float x = PP.P2MM(pos.X,m_DPI) - m_DispLocasion.X;
			float y = m_DispLocasion.Y - PP.P2MM(pos.Y,m_DPI);

			if (m_MODE ==  MODE.POINT4)
			{
				switch (m_SelectedIndex)
				{
					case 0:
						m_WingPos = LimitF(x);
						if (m_WingPos < 0) m_WingPos = 0;
						MakePooints();
						break;
					case 1:
						m_WingTipOffset = LimitF(x - m_WingPos);
						m_WingSpan = LimitF(y * 2);
						if (m_WingSpan < 0) m_WingSpan = 0;
						MakePooints();
						break;
					case 2:
						m_WingTip = LimitF(x - (m_WingPos + m_WingTipOffset));
						if (m_WingTip < 0) m_WingTip = 0;
						MakePooints();
						break;
					case 3:
						m_WingRoot = LimitF(x - m_WingPos);
						MakePooints();
						break;
				}
			}
			else
			{
				switch (m_SelectedIndex)
				{
					case 0:
						m_WingPos = LimitF(x);
						if (m_WingPos < 0) m_WingPos = 0;
						MakePooints();
						break;
					case 1:
						m_WingTipOffset = LimitF(x - m_WingPos);
						m_WingSpan = LimitF(y * 2);
						if (m_WingSpan < 0) m_WingSpan = 0;
						MakePooints();
						break;
					case 2:
						m_WingTipOffset2 = LimitF(x - (m_WingPos+m_WingTipOffset));
						m_WingSpan2 = LimitF(y - (m_WingSpan / 2));
						MakePooints();
						break;
					case 3:
						m_WingTip2 = LimitF(x - (m_WingPos+m_WingTipOffset+m_WingTipOffset2));
						MakePooints();
						break;
					case 4:
						m_WingTip = LimitF(x - (m_WingPos + m_WingTipOffset));
						if (m_WingTip < 0) m_WingTip = 0;
						MakePooints();
						break;
					case 5:
						m_WingRoot = LimitF(x - m_WingPos);
						MakePooints();
						break;
				}
			}
		}
		// ******************************************
		// ******************************************
		
		public void CalcStatus()
		{
			//HorPointsの計算
			if (m_MODE == MODE.POINT4)
			{
				if (m_WingDihedral == 0)
				{
					for (int i = 0; i < 4; i++) m_VerPoints[i] = new PPPoint(0, 0);
					for (int i = 0; i < 2; i++) m_VerMAC[i] = new PPPoint(0, 0);
					for (int i = 0; i < 4; i++) m_HorPoints[i] = m_Points[i];
				}
				else
				{

				}


			}
			else
			{

			}


		}
	}
}
