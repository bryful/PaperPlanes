using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP
{
	public class EasySVG
	{
		public enum UnitType
		{
			Point,
			Mm
		};
		private UnitType m_UnitType = UnitType.Mm;
		public UnitType Unit 
		{
			get { return m_UnitType; }
			set { m_UnitType = value; }
		}
		private float m_ViewX1 = -150;
		private float m_ViewY1 = -150;
		private float m_ViewX2 = 150;
		private float m_ViewY2 = 150;
		private string XmlHeader = "<?xml version = \"1.0\" encoding=\"UTF-8\"?>\r\n";
		private string SVGHeader = "<svg id = \"{0}\" xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\" viewBox=\"{1} {2} {3} {4}\">\r\n";
		private string SVGFooter = "</svg>\r\n";

		private string m_RootID = "pp";
		private string DefBLoack =
			"<defs>\r\n" +
			"<style>\r\n" +
			".base{\r\n" +
			"fill: none;\r\n" +
			"stroke-miterlimit: 10;\r\n" +
			"stroke-width: .6;\r\n" +
			"}\r\n" +
			"</style>\r\n" +
			"</defs>\r\n";

		private string m_LineBlock =
			"<line id=\"{0}\" class=\"base\" x1=\"{1}\" y1=\"{2}\" x2=\"{3}\" y2=\"{4}\" stroke=\"{5}\" />\r\n";

		private string m_PolylineBlock =
		  " <polyline id=\"{0}\" class=\"base\" points=\"{1}\" stroke=\"{2}\" />\r\n ";

		private List<string> m_objects = new List<string>();
		
		public string SVGString()
		{
			string ret = "";
			ret += XmlHeader;

			ret += string.Format(SVGHeader, m_RootID, FS(m_ViewX1), FS(m_ViewY1), FS(m_ViewX2), FS(m_ViewY2));
			ret += DefBLoack;
			if(m_objects.Count>0)
			{
				for(int i=0; i<m_objects.Count;i++)
				{
					ret += m_objects[i];
				}
			}

			ret += SVGFooter;
			return ret;
		}
		// ***************************************************************************
		public EasySVG(float x1= -150, float y1 =-150, float x2 = 150, float y2 = 150, UnitType u = UnitType.Mm)
		{
			m_UnitType = u;
			m_ViewX1 = UV(x1);
			m_ViewY1 = UV(y1);
			m_ViewX2 = UV(x2);
			m_ViewY2 = UV(y2);
		}
		// ***************************************************************************
		private float UV(float m)
		{
			if(m_UnitType== UnitType.Point)
			{
				return m;
			}
			else
			{
				return (float)(((double)m * 72 / 25.4));
			}
		}
		private string FS(float m)
		{
			int mi = (int)(m * 100+0.5);
			string ret = "";
			if (m < 0)
			{
				ret += "-";
				mi *= -1;
			}
			ret += (mi / 100).ToString();
			ret += "." + (mi % 100).ToString("D2");
			return ret;
		}
		public void DrawLine(string id,PointF [] pnts,Color c)
		{
			if(pnts.Length < 2) return;

			string sx1 = FS(UV(pnts[0].X));
			string sy1 = FS(UV(pnts[0].Y));
			string sx2 = FS(UV(pnts[1].X));
			string sy2 = FS(UV(pnts[1].Y));
			string sc = $"#{c.R:X2}{c.G:X2}{c.B:X2}";
			string s = string.Format(m_LineBlock,id,sx1,sy1,sx2,sy2,sc);
			m_objects.Add(s);
		}
		public void DrawLine(string id, PointF st,PointF ed, Color c)
		{
			string sx1 = FS(UV(st.X));
			string sy1 = FS(UV(st.Y));
			string sx2 = FS(UV(st.X));
			string sy2 = FS(UV(st.Y));
			string sc = $"#{c.R:X2}{c.G:X2}{c.B:X2}";
			string s = string.Format(m_LineBlock, id, sx1, sy1, sx2, sy2, sc);
			m_objects.Add(s);
		}
		public void DrawLine(string id,float x1,float y1,float x2,float y2, Color c)
		{
			string sx1 = FS(UV(x1));
			string sy1 = FS(UV(y1));
			string sx2 = FS(UV(x2));
			string sy2 = FS(UV(y2));
			string sc = $"#{c.R:X2}{c.G:X2}{c.B:X2}";
			string s = string.Format(m_LineBlock, id, sx1, sy1, sx2, sy2, sc);
			m_objects.Add(s);
		}
		public void DrawPolyline(string id, PointF[] pnts, Color c)
		{
			if (pnts.Length == 0) return;

			string sp = "";
			for(int i = 0; i < pnts.Length; i++)
			{
				if (sp !="") sp+= " ";
				sp += FS(UV(pnts[i].X));
				sp += " ";
				sp += FS(UV(pnts[i].Y));
			}
			string sc = $"#{c.R:X2}{c.G:X2}{c.B:X2}";
			string s = string.Format(m_PolylineBlock, id, sp, sc);
			m_objects.Add(s);
		}
	}
}
