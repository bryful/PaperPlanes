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


using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

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
		public XPoint ToXPoint(double dpi)
		{
			return new XPoint(PP.MM2P(m_X, (float)dpi), PP.MM2P(m_Y, (float)dpi));
		}

	}
}
