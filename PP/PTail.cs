using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PP
{
	public class PTail
	{
		private TailMode m_TailMode = TailMode.Normal;
		public TailMode TailMode
		{
			get { return m_TailMode; }
			set
			{
				m_TailMode = value;
				switch(m_TailMode)
				{
					case TailMode.Twin:
						m_Vur.SetPosXYRoot(
							m_Hor.Span,
							m_Hor.PosY + m_Hor.SweptLength,
							m_Hor.Tip);
						break;
					case TailMode.Normal:
						m_Vur.PosX = 0;
						break;

				}
			}
		}
		private PWing m_Hor = new PWing();
		private PWing m_Vur = new PWing();
		public float Dpi
		{
			get { return (float)m_Hor.Dpi; }
			set
			{
				m_Hor.Dpi = value;
				m_Vur.Dpi = value;
			}
		}
		public float PosY
		{
			get { return m_Hor.PosY; }
			set { m_Hor.PosY = value; }
		}
		public float Span
		{
			get { return m_Hor.Span; }
			set 
			{ 
				m_Hor.Span = value;
				switch(m_TailMode)
				{
					case TailMode.Normal :
						m_Vur.PosX = 0;
						break;
					case TailMode.Twin:
						m_Vur.PosX = m_Hor.Span;
						break;
				}
			}
		}
		public float Root
		{
			get { return m_Hor.Root; }
			set 
			{ 
				m_Hor.Root = value;
			}
		}
		public float Tip
		{
			get { return m_Hor.Tip; }
			set 
			{ 
				m_Hor.Tip = value; 
				switch(m_TailMode)
				{
					case TailMode.Twin :
						m_Vur.Root = m_Hor.Tip;
						break;

				}
			}
		}
		public float Swept
		{
			get { return m_Hor.Swept; }
			set { m_Hor.Swept = value; }
		}
		public float SweptLength
		{
			get { return m_Hor.SweptLength; }
		}
		public float VPosY
		{
			get 
			{
				if (m_TailMode== TailMode.Twin)
				{
					float f = m_Hor.PosY + m_Vur.SweptLength;
					if ((m_Vur.PosY != f) || (m_Vur.PosX != m_Hor.Span))
					{
						m_Vur.SetPosXYRoot(m_Hor.Span, f, m_Hor.Tip);
					} 
				}
				return m_Vur.PosY;
			}
			set 
			{
				if (m_TailMode == TailMode.Twin)
				{
					float f = m_Hor.PosY + m_Vur.SweptLength;
					if ((m_Vur.PosY != f) || (m_Vur.PosX != m_Hor.Span))
					{
						m_Vur.SetPosXYRoot(m_Hor.Span, f, m_Hor.Tip);
					}
				}
				else
				{
					m_Vur.PosY = value;
				}
			}
		}
		public float VSpan
		{
			get { return m_Vur.Span; }
			set { m_Vur.Span = value; }
		}
		public float VRoot
		{
			get 
			{
				if(m_TailMode == TailMode.Twin)
				{
					if (m_Vur.Root != m_Hor.Tip)
					{
						m_Vur.Root = m_Hor.Tip;
					}
				}
				return m_Vur.Root;
			}
			set 
			{
				if (m_TailMode == TailMode.Twin)
				{
					if (m_Vur.Root != m_Hor.Tip)
					{
						m_Vur.Root = m_Hor.Tip;
					}
				}
				else
				{
					m_Vur.Root = value;
				}
			}
		}
		public float VTip
		{
			get { return m_Vur.Tip; }
			set { m_Vur.Tip = value; }
		}
		public float VSwept
		{
			get { return m_Vur.Swept; }
			set { m_Vur.Swept = value; }
		}
		public float VSweptLength
		{
			get { return m_Vur.SweptLength; }
		}
		public PointF[] HorLines(PointF d)
		{
			return m_Hor.lines(d);
		}
		public PointF[] VurLines(PointF d)
		{
			return m_Vur.lines(d);
		}
		public PTail() 
		{
			m_Hor.PosY = 100;
			m_Hor.Span = 40;
			m_Hor.Root = 20;
			m_Hor.Tip = 10;
			m_Hor.Swept = 5;

			m_Vur.PosY = 80;
			m_Vur.Span = 30;
			m_Vur.Root = 20;
			m_Vur.Tip = 10;
			m_Vur.Swept = 10;
			m_Hor.SetIndex(4);
			m_Vur.SetIndex(8);
		}
		public int IsIn(float x, float y)
		{
			int ret = -1;
			for (int i = 0; i < 4; i++)
			{
				if (m_Hor.IsInPoint(i, x, y))
				{
					ret = i + 4;
					break;
				}

			}
			if (ret == -1)
			{
				if (m_TailMode == TailMode.Twin)
				{
					if (m_Vur.IsInPoint(1, x, y))
					{
						ret = 9;
					}
					else if (m_Vur.IsInPoint(1, x, y))
					{
						ret = 10;
					}
				}
				else
				{
					for (int i = 0; i < 4; i++)
					{
						if (m_Vur.IsInPoint(i, x, y))
						{
							ret = i + 8;
							break;
						}

					}
				}
			}
			return ret;
		}
	}
	public enum TailMode
	{
		Normal=0,
		Twin
	}
}
