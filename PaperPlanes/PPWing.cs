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
	

	public class PPWing :Component
	{
		public enum WING_MODE
		{
			MAIN=0,
			HOR_TAIL,
			VER_TAIL,
			TWIN_TAIL,
			V_TAIL

		}
		#region event
		/// <summary>
		/// リドロウリクエスト
		/// </summary>
		public event EventHandler RequestRedraw;

		protected virtual void OnRequestRedraw(EventArgs e)
		{
			if (RequestRedraw != null)
			{
				RequestRedraw(this, e);
			}
		}
		#endregion
		#region mode
		private WING_MODE m_WingMode = WING_MODE.MAIN;

		/// <summary>
		/// この翼の種類
		/// </summary>
		public WING_MODE Wing_MODE
		{
			get { return m_WingMode; }
		}
		public void SetWingMode(WING_MODE value)
		{
			if (m_WingMode != value)
			{
				m_WingMode = value;
				MakePooints();
				SelectIndex = -1;
			}

		}
		#endregion

		private int m_SelectedIndex = -1;
		/// <summary>
		/// マウスで選ばれた点
		/// </summary>
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

		private Color m_LineColor = Color.FromArgb(0,0,0);
		/// <summary>
		/// 紙線の色
		/// </summary>
		public Color LineColor { get { return m_LineColor; } set { m_LineColor = value; OnRequestRedraw(new EventArgs()); } }
		private Color m_OriColor = Color.FromArgb(128,128,128);
		/// <summary>
		/// TwinTail時の折り曲げ線の色
		/// </summary>
		public Color OriColor { get { return m_OriColor; } set { m_OriColor = value; OnRequestRedraw(new EventArgs()); } }


		private Color m_HorColor = Color.FromArgb(150,150,100);
		/// <summary>
		/// 水平成分の線の色
		/// </summary>
		public Color HorColor { get { return m_HorColor; } set { m_HorColor = value; OnRequestRedraw(new EventArgs()); } }

		private Color m_VerColor = Color.FromArgb(100,150,150);
		/// <summary>
		/// 垂直成分の線の色
		/// </summary>
		public Color VerColor { get { return m_VerColor; } set { m_VerColor = value; OnRequestRedraw(new EventArgs()); } }

		private PointF m_DispLocasion = new PointF(10,120);

		/// <summary>
		/// 描画の基本位置
		/// </summary>
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
		/// <summary>
		/// 印刷解像度
		/// </summary>
		public float DPI
		{
			get { return m_DPI; }
			set { SetDPI(value,true); }
		}
		/// <summary>
		/// 基準位置と解像度を設定
		/// </summary>
		/// <param name="dpi"></param>
		/// <param name="loc"></param>
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
				ret[5] = LimitF(m_WingDihedral);
				ret[6] = LimitF(m_WingSpan2);
				ret[7] = LimitF(m_WingTip2);
				ret[8] = LimitF(m_WingTipOffset2);
				return ret;

			}
			set
			{
				if (value.Length < 9) return;
				bool b = false;
				for (int i = 0; i < 9; i++) value[i] = LimitF(value[i]);
				if (m_WingPos != value[0])       { m_WingPos = value[0]; b = true; }
				if (m_WingRoot != value[1])      { m_WingRoot = value[1]; b = true; }
				if (m_WingTip != value[2])       { m_WingTip = value[2]; b = true; }
				if (m_WingTipOffset != value[3]) { m_WingTipOffset = value[3]; b = true; }
				if (m_WingSpan != value[4])      { m_WingSpan = value[4]; b = true; }
				if (m_WingDihedral != value[5])  { m_WingDihedral = value[5]; b = true; }
				if (m_WingSpan2 != value[6])     { m_WingSpan2 = value[6]; b = true; }
				if (m_WingTip2 != value[7])      { m_WingTip2 = value[7]; b = true; }
				if (m_WingTipOffset2 != value[8]){ m_WingTipOffset2 = value[8]; b = true; }
				if(b) MakePooints();
			}
		}

		/// <summary>
		/// 上反角
		/// </summary>
		///
		#region WingDihedral
		private float m_WingDihedral = 15;
		public float WingDihedral
		{
			get
			{
				switch(m_WingMode)
				{
					case WING_MODE.MAIN:
					case WING_MODE.V_TAIL:
						return m_WingDihedral;
					default:
						return 0;
				}
			}
			set
			{
				switch(m_WingMode)
				{
					case WING_MODE.MAIN:
					case WING_MODE.V_TAIL:
						value = LimitF(value);
						if (m_WingDihedral != value)
						{
							m_WingDihedral = value;
							if (m_WingDihedral < 0) m_WingDihedral = 0;
							MakePooints();
						}
						break;
					default:
						m_WingDihedral = 0;
						break;
				}
			}
		}
		#endregion
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
					if (m_WingRoot < 10) m_WingRoot = 10;
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
			get
			{
				if (m_WingMode == WING_MODE.TWIN_TAIL)
				{
					return m_WingTip2;
				}
				else
				{
					return 0;
				}
			}
			set
			{
				if (m_WingMode ==WING_MODE.TWIN_TAIL)
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
			get
			{
				if (m_WingMode == WING_MODE.TWIN_TAIL)
				{
					return m_WingTipOffset2;
				}
				else
				{
					return 0;
				}
			}
			set
			{
				if (m_WingMode == WING_MODE.TWIN_TAIL)
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
			get
			{
				if (m_WingMode == WING_MODE.TWIN_TAIL)
				{
					return m_WingSpan2;
				}
				else
				{
					return 0;
				}
			}
			set
			{
				if (m_WingMode == WING_MODE.TWIN_TAIL)
				{
					value = LimitF(value);
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
		/// <summary>
		/// 紙の切り線の描画点配列
		/// </summary>
		private PPPoint[] m_Points = new PPPoint[6];

		//上反角を反映したポイント配列
		private PPPoint[] m_HorPoints = new PPPoint[4];
		private PPPoint[] m_VerPoints = new PPPoint[4];
		//
		private PPPoint[] m_HorMAC = new PPPoint[2];
		public PPPoint[] HorMAC
		{
			get { return m_HorMAC; }
		}
		private PPPoint[] m_VerMAC = new PPPoint[2];
		public PPPoint[] VerMAC
		{
			get { return m_VerMAC; }
		}
		/// <summary>
		/// 水平成分のMACの長さ
		/// </summary>
		public float HorMacLength
		{
			get { return m_HorMAC[1].X - m_HorMAC[0].X; }
		}
		/// <summary>
		/// 垂直成分のMACの長さ
		/// </summary>
		public float VerMacLength
		{
			get { return m_VerMAC[1].X - m_VerMAC[0].X; }
		}

		private float m_HorArea = 0;
		public float HorArea
		{
			get { return m_HorArea; }
		}
		private float m_VerArea = 0;
		public float VerArea
		{
			get { return m_VerArea; }
		}

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
		private void MakePooints_4Points()
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

			MAC mm = new MAC(m_WingSpan, m_WingRoot, m_WingTip, m_WingTipOffset);
			m_HorMAC[0] = new PPPoint(m_WingPos + m_DispLocasion.X + mm.MacLine[0].X, m_DispLocasion.Y - mm.MacLine[0].Y);
			m_HorMAC[1] = new PPPoint(m_WingPos + m_DispLocasion.X + mm.MacLine[1].X, m_DispLocasion.Y - mm.MacLine[1].Y);

			m_HorArea = (m_WingTip + m_WingRoot) * (m_WingSpan / 2);/* *2/2 */
			m_VerArea = 0;

		}
		// ******************************************
		private void MakePooints_6Points()
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

			MAC mm = new MAC(m_WingSpan, m_WingRoot, m_WingTip, m_WingTipOffset);
			m_HorMAC[0] = new PPPoint(m_WingPos+ m_DispLocasion.X + mm.MacLine[0].X, m_DispLocasion.Y - mm.MacLine[0].Y);
			m_HorMAC[1] = new PPPoint(m_WingPos+ m_DispLocasion.X + mm.MacLine[1].X, m_DispLocasion.Y - mm.MacLine[1].Y);


			x = m_DispLocasion.X + m_WingPos + m_WingTipOffset;
			y = m_DispLocasion.Y;
			m_VerPoints[0].SetX(x);
			m_VerPoints[0].SetY(y);
			x += m_WingTipOffset2;
			y -= m_WingSpan2;
			m_VerPoints[1].SetX(x);
			m_VerPoints[1].SetY(y);
			x += m_WingTip2;
			m_VerPoints[2].SetX(x);
			m_VerPoints[2].SetY(y);
			x = m_DispLocasion.X + m_WingPos + +m_WingTipOffset+ m_WingTip;
			y = m_DispLocasion.Y;
			m_VerPoints[3].SetX(x);
			m_VerPoints[3].SetY(y);

			mm = new MAC(m_WingSpan2*2, m_WingTip, m_WingTip2, m_WingTipOffset2);
			m_VerMAC[0] = new PPPoint(m_WingTipOffset + m_WingPos+ m_DispLocasion.X +  mm.MacLine[0].X, m_DispLocasion.Y - mm.MacLine[0].Y);
			m_VerMAC[1] = new PPPoint(m_WingTipOffset + m_WingPos+ m_DispLocasion.X +  mm.MacLine[1].X, m_DispLocasion.Y - mm.MacLine[1].Y);

			m_HorArea = (m_WingTip + m_WingRoot) * (m_WingSpan / 2); /* *2/2 */
			m_VerArea = (m_WingTip + m_WingTip2) *m_WingSpan2; /* *2/2 */

		}
		// ******************************************
		private void MakePooints_HorPoint()
		{
			float spanH = (float)((m_WingSpan/2) * Math.Cos(m_WingDihedral * Math.PI / 180));

			float x = m_DispLocasion.X + m_WingPos;
			float y = m_DispLocasion.Y;
			m_HorPoints[0].SetX(x);
			m_HorPoints[0].SetY(y);
			x += m_WingTipOffset;
			y -= spanH;
			m_HorPoints[1].SetX(x);
			m_HorPoints[1].SetY(y);
			x += m_WingTip;
			m_HorPoints[2].SetX(x);
			m_HorPoints[2].SetY(y);
			x = m_DispLocasion.X + m_WingPos + m_WingRoot;
			y = m_DispLocasion.Y;
			m_HorPoints[3].SetX(x);
			m_HorPoints[3].SetY(y);

			MAC mm = new MAC(spanH * 2, m_WingRoot, m_WingTip, m_WingTipOffset);
			m_HorMAC[0] = new PPPoint(m_WingPos+ m_DispLocasion.X +  mm.MacLine[0].X, m_DispLocasion.Y - mm.MacLine[0].Y);
			m_HorMAC[1] = new PPPoint(m_WingPos+  m_DispLocasion.X +  mm.MacLine[1].X,m_DispLocasion.Y - mm.MacLine[1].Y);

			m_HorArea = (m_WingTip + m_WingRoot) * (spanH); /* *2/2 */

		}
			// ******************************************
		private void MakePooints_VerPoint()
		{
			float spanV = (float)((m_WingSpan/2) * Math.Sin(m_WingDihedral * Math.PI / 180));
			float x = m_DispLocasion.X + m_WingPos;
			float y = m_DispLocasion.Y;
			m_VerPoints[0].SetX(x);
			m_VerPoints[0].SetY(y);
			x += m_WingTipOffset;
			y -= spanV;
			m_VerPoints[1].SetX(x);
			m_VerPoints[1].SetY(y);
			x += m_WingTip;
			m_VerPoints[2].SetX(x);
			m_VerPoints[2].SetY(y);
			x = m_DispLocasion.X + m_WingPos + m_WingRoot;
			y = m_DispLocasion.Y;
			m_VerPoints[3].SetX(x);
			m_VerPoints[3].SetY(y);

			MAC mm = new MAC(spanV * 2, m_WingRoot, m_WingTip, m_WingTipOffset);
			m_VerMAC[0] = new PPPoint(m_WingPos+ m_DispLocasion.X +  mm.MacLine[0].X, m_DispLocasion.Y - mm.MacLine[0].Y);
			m_VerMAC[1] = new PPPoint(m_WingPos+  m_DispLocasion.X +  mm.MacLine[1].X,m_DispLocasion.Y - mm.MacLine[1].Y);

			m_VerArea = (m_WingTip + m_WingRoot) * (spanV); /* *2/2 */


		}
		// ******************************************
		public void MakePooints()
		{
			for (int i = 0; i < 2; i++) m_HorMAC[i] = new PPPoint(0, 0);
			for (int i = 0; i < 2; i++) m_VerMAC[i] = new PPPoint(0, 0);
			for (int i = 0; i < 4; i++) m_VerPoints[i] = new PPPoint(0, 0);
			for (int i = 0; i < 4; i++) m_HorPoints[i] = new PPPoint(0, 0);

			m_HorArea = 0;
			m_VerArea = 0;
			switch(m_WingMode)
			{
				case WING_MODE.MAIN:
					MakePooints_4Points();
					MakePooints_HorPoint();
					break;
				case WING_MODE.HOR_TAIL:
				case WING_MODE.VER_TAIL:
					MakePooints_4Points();
					break;
				case WING_MODE.TWIN_TAIL:
					MakePooints_6Points();
					break;
				case WING_MODE.V_TAIL:
					MakePooints_4Points();
					MakePooints_HorPoint();
					MakePooints_VerPoint();
					break;
			}
		}
		
		// ******************************************
		public PointF [] OriPoints()
		{
			if (m_WingMode == PPWing.WING_MODE.TWIN_TAIL)
			{
				PointF[] p = new PointF[2];
				p[0] = m_Points[1].ToPointF;
				p[1] = m_Points[4].ToPointF;
				return p;
			}
			else
			{
				return new PointF[0];
			}
		}
		// ******************************************
		public PointF [] Points()
		{
			PointF[] ret = new PointF[0];
			if (m_WingMode != WING_MODE.TWIN_TAIL)
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
		public PointF [] VerPoints()
		{
			PointF[] ret = new PointF[4];
			ret[0] = m_VerPoints[0].ToPointF;
			ret[1] = m_VerPoints[1].ToPointF;
			ret[2] = m_VerPoints[2].ToPointF;
			ret[3] = m_VerPoints[3].ToPointF;
			return ret;
		}
		public PointF [] HorPoints()
		{
			PointF[] ret = new PointF[4];
			ret[0] = m_HorPoints[0].ToPointF;
			ret[1] = m_HorPoints[1].ToPointF;
			ret[2] = m_HorPoints[2].ToPointF;
			ret[3] = m_HorPoints[3].ToPointF;
			return ret;
		}
		// ******************************************
		public void Draw(Graphics g,SolidBrush sb, Pen p)
		{

			switch(m_WingMode)
			{
				case WING_MODE.MAIN:
					//hor
					p.Color = m_HorColor;
					p.Width = 1;
					g.DrawLine(p, m_HorMAC[0].ToPointF,m_HorMAC[1].ToPointF);
					g.DrawLines(p, HorPoints());
					p.Color = m_LineColor;
					g.DrawLines(p, Points());

					break;

				case WING_MODE.HOR_TAIL:
				case WING_MODE.VER_TAIL:
					p.Color = m_HorColor;
					p.Width = 1;
					g.DrawLine(p, m_HorMAC[0].ToPointF,m_HorMAC[1].ToPointF);
					p.Color = m_LineColor;
					g.DrawLines(p, Points());
					break;
				case WING_MODE.TWIN_TAIL:
					p.Color = m_VerColor;
					g.DrawLine(p, m_VerMAC[0].ToPointF,m_VerMAC[1].ToPointF);
					g.DrawLine(p, m_HorMAC[0].ToPointF,m_HorMAC[1].ToPointF);
					g.DrawLines(p, VerPoints());
					p.Color = m_OriColor;
					p.Width = 1;
					g.DrawLines(p, OriPoints());
					p.Color = m_LineColor;
					g.DrawLines(p, Points());
					break;
				case WING_MODE.V_TAIL:
					p.Width = 1;
					p.Color = m_VerColor;
					g.DrawLine(p, m_VerMAC[0].ToPointF,m_VerMAC[1].ToPointF);
					g.DrawLines(p, VerPoints());
					p.Color = m_HorColor;
					g.DrawLine(p, m_HorMAC[0].ToPointF,m_HorMAC[1].ToPointF);
					g.DrawLines(p, HorPoints());
					p.Color = m_LineColor;
					g.DrawLines(p, Points());
					break;
			}


			sb.Color = m_LineColor;
			m_Points[0].Draw(g, sb, p);
			m_Points[1].Draw(g, sb, p);
			m_Points[2].Draw(g, sb, p);
			m_Points[3].Draw(g, sb, p);
			if (m_WingMode == PPWing.WING_MODE.TWIN_TAIL)
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
			if (m_WingMode == WING_MODE.TWIN_TAIL)
			{
				cnt = 6;
			}
			else
			{
				cnt = 4;
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

			if (m_WingMode !=  PPWing.WING_MODE.TWIN_TAIL)
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
		
		
	}
}
