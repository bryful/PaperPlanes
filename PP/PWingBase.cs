using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PP
{
	public class PWingBase
	{
		public event EventHandler WingChanged;

		protected virtual void OnWingChanged(EventArgs e)
		{
			Debug.WriteLine("OnWingChanged1");
			if (WingChanged != null)
			{
				Debug.WriteLine("OnWingChanged2");
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
		private float m_swept = 0;
		private float m_tipOffset = 0;


		private float m_area = 0;
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
				bool b = (m_posY != value);
				m_posY = value;
				Calc();
				//if (b)
				//{
					OnWingChanged(new EventArgs());
				//}
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
				bool b = (m_posX != value);
				m_posX = value;
				Calc();
				if (b) 
				{
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
			bool b = (m_posX != x || m_posY != y || m_root != rt);
			m_posX = x;
			m_posY = y;
			m_root = rt;
			Calc();
			if (b) 
			{
				//OnWingChanged(new EventArgs());
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
				return m_swept;
			}
			set
			{
				if (value < -60) value = -60;
				else if (value > 60) value = 60;
				if (m_swept != value)
				{
					m_swept = value;
					Calc();
					OnWingChanged(new EventArgs());
				}
			}
		}
		// ******************************
		public float[] Params
		{
			get
			{
				float[]ret =  new float[]
				{
					m_posY,
					m_span,
					m_root,
					m_tip,
					m_swept
				};
				return ret;
			}
			set
			{
				if (value.Length<5) return;
				bool b = false;
				if (m_posY != value[0]) { m_posY = value[0]; b = true; }
				if (m_span != value[1]) { m_span = value[1]; b = true; }
				if (m_root != value[2]) { m_root = value[2]; b = true; }
				if (m_tip != value[3]) { m_tip = value[3]; b = true; }
				if (m_swept != value[4]) { m_swept = value[4]; b = true; }
				Calc();
				if(b) { OnWingChanged(new EventArgs()); }
			}
		}
		// ******************************
		public float TipOffset
		{
			get
			{
				return m_tipOffset;
			}
		}

		// ******************************
		public float Area
		{
			get
			{
				return m_area;
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
			PrmBak[(int)PRM.Swept] = m_swept;
			PrmBak[(int)PRM.SweptLen] = m_tipOffset;
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
				m_swept = rr;
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
		private PPoint [] m_lines = new PPoint[4];
		public PPoint[] Lines
		{
			get { return m_lines; }
		}
		public PointF[] GetLines(PointF d)
		{
			PointF [] ret = new PointF[4];
			ret[0] = m_lines[0].GetPixel(d);
			ret[1] = m_lines[1].GetPixel(d);
			ret[2] = m_lines[2].GetPixel(d);
			ret[3] = m_lines[3].GetPixel(d);
			return ret;
		}
		public PointF[] GetMMLine(PointF d)
		{
			PointF[] ret = new PointF[4];
			ret[0] = new PointF(m_lines[0].Xmm + d.X, m_lines[0].Ymm + d.Y);
			ret[1] = new PointF(m_lines[1].Xmm + d.X, m_lines[1].Ymm + d.Y);
			ret[2] = new PointF(m_lines[2].Xmm + d.X, m_lines[2].Ymm + d.Y);
			ret[3] = new PointF(m_lines[3].Xmm + d.X, m_lines[3].Ymm + d.Y);
			return ret;
		}
		private PPoint[] m_MACLine = new PPoint[2];
		public PPoint[] MACLine
		{
			get { return (m_MACLine); }
		}
		private float m_MACLineLength = 0;
		public float MACLineLength
		{
			get { return m_MACLineLength; }
		}
		public PointF[] GetMACLines(PointF d)
		{
			PointF[] ret = new PointF[2];
			ret[0] = m_MACLine[0].GetPixel(d);
			ret[1] = m_MACLine[1].GetPixel(d);
			return ret;
		}
		private PPoint m_AC = new PPoint();
		public PointF GetAC(PointF d)
		{
			PointF ret = new PointF();
			ret = m_AC.GetPixel(d);
			return ret;
		}
		public PPoint AC
		{
			get { return (m_AC); }
		}

		public float Dpi
		{
			get { return m_lines[0].Dpi; }
			set
			{
				float f = value;
				if (f < 72) f = 72;
				m_lines[0].SetDPI(f);
				m_lines[1].SetDPI(f);
				m_lines[2].SetDPI(f);
				m_lines[3].SetDPI(f);
				m_MACLine[0].SetDPI(f);
				m_MACLine[1].SetDPI(f);
				m_AC.SetDPI(f);
			}
		}
	

		private void Calc()
		{
			// 値の確認
			if (m_span < 5) m_span = 5;
			if (m_root < 5) m_root = 5;
			if (m_tip < 5) m_tip = 5;

			if (m_swept < -60) m_swept = -60;
			else if (m_swept > 60) m_swept = 60;
			float r = Math.Abs(m_swept);
			m_tipOffset = (float)(m_span * Math.Tan(r * Math.PI / 180));
			if (m_swept < 0) m_tipOffset *= -1;

			// 線
			m_lines[0].Xmm = m_posX;
			m_lines[0].Ymm = m_posY;
			m_lines[1].Xmm = m_lines[0].Xmm + m_span;
			m_lines[1].Ymm = m_lines[0].Ymm + m_tipOffset;
			m_lines[2].Xmm = m_lines[1].Xmm;
			m_lines[2].Ymm = m_lines[1].Ymm + m_tip;
			m_lines[3].Xmm = m_lines[0].Xmm;
			m_lines[3].Ymm = m_lines[0].Ymm + m_root;

			// 面積
			m_area = (m_root + m_tip) * (m_span )/2;

			// MAC
			CalcMAC();
			
		}
		private void CalcMAC()
		{
			m_MACLine[0].SetMM(0, 0);
			m_MACLine[1].SetMM(0, 0);

			PointF[] Line0 = new PointF[2];
			Line0[0] = new PointF(0,m_root / 2);
			Line0[1] = new PointF(m_span,m_tipOffset + m_tip / 2);

			PointF[] Line1 = new PointF[2];
			Line1[0] = new PointF(0,m_root + m_tip);
			Line1[1] = new PointF(m_span,m_tipOffset - m_root);
			//交点を求める
			PointF mc = new PointF(0, 0);
			if (CrossPoint(Line0, Line1, ref mc) == false)
			{
				return;
			}
			//交点の水平線と翼の交点を求めてMACを得る
			Line0[0] = new PointF(mc.X, -m_root*2);
			Line0[1] = new PointF(mc.X, m_root * 3);

			Line1[0] = new PointF(0, 0);
			Line1[1] = new PointF(m_span, m_tipOffset);
			PointF mc0 = new PointF(0, 0);
			if (CrossPoint(Line0, Line1, ref mc0) == false)
			{
				return;
			}
			Line1[0] = new PointF(0,m_root);
			Line1[1] = new PointF(m_span, m_tipOffset + m_tip);
			PointF mc1 = new PointF(0, 0);
			if (CrossPoint(Line0, Line1, ref mc1) == false)
			{
				return;
			}
			m_MACLine[0].SetMM(mc0.X+ m_posX, mc0.Y+m_posY);
			m_MACLine[1].SetMM(mc1.X + m_posX, mc1.Y + m_posY);
			m_MACLineLength = mc1.Y - mc0.Y;
			m_AC.SetMM(m_MACLine[0].Xmm, (float)(m_MACLine[0].Ymm + m_MACLineLength * 0.25));
		}
		public PWingBase()
		{
			m_lines[0] = new PPoint();
			m_lines[1] = new PPoint();
			m_lines[2] = new PPoint();
			m_lines[3] = new PPoint();
			m_MACLine[0] = new PPoint();
			m_MACLine[1] = new PPoint();
			Dpi = 83.0f;
			Calc();
			PushPrm();
		}
		public void CreateIndex(int start=0)
		{
			int idx = start;
            for (int i = 0; i < m_lines.Length; i++)
            {
				m_lines[0].Index = idx;
				idx++;
			}
		}

		public bool IsInPoint(int idx, float x, float y)
		{
			bool ret = false;
			if ((idx >= 0) && (idx < 4))
			{
				ret = m_lines[idx].IsIn(x, y);
			}
			return ret;
		}
		// *********************************************************
		private bool CrossPoint(PointF [] la, PointF [] lb, ref PointF R)
		{
			float a1 = la[1].Y - la[0].Y;
			float b1 = la[0].X - la[1].X;
			float c1 = a1 * la[0].X + b1 * la[0].Y;

			float a2 = lb[1].Y - lb[0].Y;
			float b2 = lb[0].X - lb[1].X;
			float c2 = a2 * lb[0].X + b2 * lb[0].Y;

			float det = a1 * b2 - a2 * b1;

			if (det == 0)
			{
				return false;
			}
			else
			{
				R = new PointF((b2 * c1 - b1 * c2) / det, (a1 * c2 - a2 * c1) / det);
				return true;
			}
		}
		public JsonObject  JObj
		{
			get
			{
				JsonObject obj = new JsonObject();
				obj.Add("PosY", m_posY);
				obj.Add("PosX", m_posX);
				obj.Add("Span", m_span);
				obj.Add("Root", m_root);
				obj.Add("Tip", m_tip);
				obj.Add("Swept", m_swept);

				return obj;
			}
			set
			{
				if (value == null) return;
				bool ok = false;
				float f = GetFloat(value, "PosY", out ok);
				if (ok) m_posY = f;
				f = GetFloat(value, "PosX", out ok);
				if (ok) m_posX = f;
				f = GetFloat(value, "Span", out ok);
				if (ok) m_span = f;
				f = GetFloat(value, "Root", out ok);
				if (ok) m_root = f;
				f = GetFloat(value, "Tip", out ok);
				if (ok) m_tip = f;
				f = GetFloat(value, "Swept", out ok);
				if (ok) m_swept = f;
				Calc();
			}
		}
		private float GetFloat(JsonObject obj, string key,out bool ok)
		{
			float ret = 0;
			ok = false;
			if (key == "") return ret;
			try
			{
				if (obj.ContainsKey(key))
				{
					ret = obj[key].GetValue<float>();
					ok=true;
				}
			}
			catch
			{
				ret = 0;
				ok = false;
			}
			return ret;
		}
	}
}
