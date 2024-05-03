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
	public class P
	{
		static public float Px2Mm(float p, float dpi)
		{
			return (float)((double)p * 25.4 / (double)dpi);
		}
		static public float Mm2Px(float m, float dpi)
		{
			return (float)(((double)m * (double)dpi / 25.4));
		}
		static public void FillDot(Graphics g,SolidBrush sb,  PointF pt,float sz)
		{
			RectangleF rct = new RectangleF(pt.X - sz/2, pt.Y - sz/2, sz, sz);
			g.FillEllipse(sb, rct);
		}
		static public float CF(float f)
		{
			int ff = (int)(f * 100);
			return (float)ff /100;
		}
		static public string F2S(float f)
		{
			int f2 = (int)(f * 100 + 0.5);
			bool b = (f2 < 0);
			if(b ) { f2*=-1; }
			string ret = "";
			if(b ) { ret += "-"; }
			ret += (f2/100).ToString();
			ret += "." + (f2 % 100).ToString("D2");
			return ret;
		}
	}
}
