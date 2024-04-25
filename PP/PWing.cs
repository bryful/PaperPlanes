using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PP
{
	public class PWing
	{
		public event EventHandler MainChanged;
		public event EventHandler TailChanged;

		protected virtual void OnMainChanged(EventArgs e)
		{
			if (MainChanged != null)
			{
				MainChanged(this, e);
			}
		}
		protected virtual void OnTailChanged(EventArgs e)
		{
			if (TailChanged != null)
			{
				TailChanged(this, e);
			}
		}
		private PWingBase m_Main = new PWingBase();
		private PWingBase m_Hor = new PWingBase();
		private PWingBase m_Vur = new PWingBase();

		public void SyncTwin()
		{
			if (m_TailMode == TailMode.Twin)
			{
				m_Vur.SetPosXYRoot(m_Hor.Span, m_Hor.PosY + m_Hor.TipOffset, m_Hor.Tip);
			}
			else
			{
				m_Vur.PosX = 0;
			}
		}
		private TailMode m_TailMode = TailMode.Normal;
		public TailMode TailMode
		{
			get { return m_TailMode; }
			set
			{
				bool b = (m_TailMode != value);
				m_TailMode = value;
				SyncTwin();
				if (b)
					OnTailChanged(new EventArgs());
			}
		}
		public float Dpi
		{
			get { return m_Main.Dpi; }
			set
			{
				m_Main.Dpi = value;
				m_Hor.Dpi = value;
				m_Vur.Dpi = value;
			}
		}
		public float MainPos
		{
			get { return m_Main.PosY; }
			set{m_Main.PosY = value;}
		}
		public float MainSpan
		{
			get { return m_Main.Span; }
			set { m_Main.Span = value; }
		}
		public float MainRoot
		{
			get { return m_Main.Root; }
			set { m_Main.Root = value; }
		}
		public float MainTip
		{
			get { return m_Main.Tip; }
			set { m_Main.Tip = value; }
		}
		public float MainSwept
		{
			get { return m_Main.Swept; }
			set { m_Main.Swept = value; }
		}
		public float MainTipOffset
		{
			get { return m_Main.TipOffset; }
		}
		public PointF[] MainLines(PointF d)
		{
			return m_Main.Lines(d);
		}
		public PointF[] MainMACLines(PointF d)
		{
			return m_Main.MACLines(d);
		}
		public PointF[] HTailLines(PointF d)
		{
			return m_Hor.Lines(d);
		}
		public PointF[] VTailLines(PointF d)
		{
			return m_Vur.Lines(d);
		}

		public float HTailPos
		{
			get { return m_Hor.PosY; }
			set { m_Hor.PosY = value; SyncTwin(); }
		}
		public float HTailSpan
		{
			get { return m_Hor.Span; }
			set { m_Hor.Span = value; SyncTwin(); }
		}
		public float HTailRoot
		{
			get { return m_Hor.Root; }
			set { m_Hor.Root = value; SyncTwin(); }
		}
		public float HTailTip
		{
			get { return m_Hor.Tip; }
			set
			{
				m_Hor.Tip = value;
				SyncTwin();
			}
		}
		public float HTailSwept
		{
			get { return m_Hor.Swept; }
			set { m_Hor.Swept = value; SyncTwin(); }
		}
		public float HTailTipOffset
		{
			get { return m_Hor.TipOffset; }
		}
		// ********************************
		public float VTailPos
		{
			get
			{
				SyncTwin();
				return m_Vur.PosY;
			}
			set
			{
				if (m_TailMode == TailMode.Twin)
				{
					float f = m_Hor.PosY + m_Hor.TipOffset;
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
		public float VTailSpan
		{
			get { return m_Vur.Span; }
			set { m_Vur.Span = value; SyncTwin(); }
		}
		public float VTailRoot
		{
			get
			{
				if (m_TailMode == TailMode.Twin)
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
		public float VTailTip
		{
			get { return m_Vur.Tip; }
			set { m_Vur.Tip = value; }
		}
		public float VTailSwept
		{
			get { return m_Vur.Swept; }
			set { m_Vur.Swept = value; }
		}
		public float VTailTipOffset
		{
			get { return m_Vur.TipOffset; }
		}
		public PWing() 
		{
			m_Main.CreateIndex(0);
			m_Hor.CreateIndex(4);
			m_Vur.CreateIndex(8);
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


			SyncTwin();
			m_Main.WingChanged += (sender, e) => { OnMainChanged(new EventArgs()); };
			m_Hor.WingChanged += (sender, e) => { OnTailChanged(new EventArgs()); };
			m_Vur.WingChanged += (sender, e) => { OnTailChanged(new EventArgs()); };
		}
		private int m_SelectedIndex = -1;
		public int SelectedIndex { get { return m_SelectedIndex; } }

		public int IsIn(float x, float y)
		{
			int ret = -1;
			m_SelectedIndex = -1;
			for (int i = 0; i < 4; i++)
			{
				if (m_Main.IsInPoint(i, x, y))
				{
					ret = i;
					break;
				}
			}
			if (ret < 0)
			{
				for (int i = 0; i < 4; i++)
				{
					if (m_Hor.IsInPoint(i, x, y))
					{
						ret = i + 4;
						break;
					}
				}
			}
			if (ret < 0)
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

			m_SelectedIndex = ret;
			return ret;
		}
		public void PushPrm()
		{
			m_Main.PushPrm();
			m_Hor.PushPrm();
			m_Vur.PushPrm();
		}
		public void Move(float x,float y)
		{
			if (m_SelectedIndex<0) return;
			switch(m_SelectedIndex)
			{
				case 0:
					m_Main.AddPosY(y);
					break;
				case 1:
					m_Main.AddWingEdge(x,y);
					break;
				case 2:
					m_Main.AddTip(y);
					break;
				case 3:
					m_Main.AddRoot(y);
					break;
				case 4:
					m_Hor.AddPosY(y);
					SyncTwin();
					break;
				case 5:
					m_Hor.AddWingEdge(x,y);
					SyncTwin();
					break;
				case 6:
					m_Hor.AddTip(y);
					SyncTwin();
					break;
				case 7:
					m_Hor.AddRoot(y);
					SyncTwin();
					break;
				case 8:
					m_Vur.AddPosY(y);
					break;
				case 9:
					m_Vur.AddWingEdge(x,y);
					break;
				case 10:
					m_Vur.AddTip(y);
					break;
				case 11:
					m_Vur.AddRoot(y);
					break;
			}
		}

	}
	public enum TailMode
	{
		Normal = 0,
		Twin
	}
}
