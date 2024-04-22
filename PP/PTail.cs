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
		private bool m_IsTwin=false;
		public bool IsTwin
		{
			get { return m_IsTwin; }
			set
			{
				m_IsTwin = value;
				if (m_IsTwin)
				{
					m_Vur.Position = m_Hor.Position + m_Hor.SweptLength;
					m_Vur.Root = m_Hor.Tip;
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
		public float Position
		{
			get { return m_Hor.Position; }
			set { m_Hor.Position = value; }
		}
		public float Span
		{
			get { return m_Hor.Span; }
			set { m_Hor.Span = value; }
		}
		public float Root
		{
			get { return m_Hor.Root; }
			set { m_Hor.Root = value; }
		}
		public float Tip
		{
			get { return m_Hor.Tip; }
			set { m_Hor.Tip = value; }
		}
		public float Swept
		{
			get { return m_Hor.Swept; }
			set { m_Hor.Swept = value; }
		}
		public float SweptLength
		{
			get { return m_Hor.SweptLength; }
			set { m_Hor.SweptLength = value; }
		}
		public float VPosition
		{
			get 
			{
				if (m_IsTwin)
				{
					float f = m_Hor.Position + m_Vur.SweptLength;
					if (f != m_Vur.Position) m_Vur.Position = f;
				}
				return m_Vur.Position;
			}
			set 
			{
				if (m_IsTwin)
				{
					float f = m_Hor.Position + m_Vur.SweptLength;
					if (m_Vur.Position != f) m_Vur.Position = f;
				}
				else
				{
					m_Vur.Position = value;
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
				if(m_IsTwin)
				{
					if (m_Vur.Root != m_Hor.Tip)
					{
						m_Vur.Root = m_Hor.Tip;
					}
					return m_Vur.Root;
				}
				else
				{
					return m_Vur.Root;
				}
			}
			set { m_Hor.Root = value; }
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
			set { m_Vur.SweptLength = value; }
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
			m_Hor.Position = 100;
			m_Hor.Span = 40;
			m_Hor.Root = 20;
			m_Hor.Tip = 10;
			m_Hor.Swept = 5;

			m_Vur.Position = 80;
			m_Vur.Span = 30;
			m_Vur.Root = 20;
			m_Vur.Tip = 10;
			m_Vur.Swept = 10;
		}
	}
}
