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
	public class PMain
	{
		private PWing m_main = new PWing();
		public float Dpi
		{
			get { return (float)m_main.Dpi; }
			set
			{
				m_main.Dpi = value;
			}
		}
		public float Position
		{
			get { return m_main.PosY; }
			set{m_main.PosY = value;}
		}
		public float Span
		{
			get { return m_main.Span; }
			set { m_main.Span = value; }
		}
		public float Root
		{
			get { return m_main.Root; }
			set { m_main.Root = value; }
		}
		public float Tip
		{
			get { return m_main.Tip; }
			set { m_main.Tip = value; }
		}
		public float Swept
		{
			get { return m_main.Swept; }
			set { m_main.Swept = value; }
		}
		public float SweptLength
		{
			get { return m_main.SweptLength; }
			set { m_main.SweptLength = value; }
		}
		public PointF[] Lines(PointF d)
		{
			return m_main.lines(d);
		}
		public PMain() 
		{
			m_main.SetIndex(0);
		}
		public int IsIn(float x, float y)
		{
			int ret = -1;
			for(int i=0; i<4;i++)
			{
				if (m_main.IsInPoint(i,x,y))
				{
					ret = i;
					break;
				}
			}
			return ret;
		}

	}
}
