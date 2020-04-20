using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


using Codeplex.Data;

namespace PaperPlanes
{
	public class DrawWings : Control
	{
		public float[] MainDef =new float[] {45,50,23.9f,7.9f,176.2f,15,15,20,10};
		public float[] HTailDef =new float[] {182.4f,30.3f,17,14.2f,104.9f,15,15,20,10};
		public float[] VTailDef =new float[] {158.8f,31.6f,15.8f,15.8f,55.4f,15,15,20,10};


		public enum EDITMODE
		{
			NORMAL =0,
			TWINTAIL,
			VTAIL
		}
		#region event
		public event EventHandler SetectWingIndexChanged;

		protected virtual void OnSetectWingIndexChanged(EventArgs e)
		{
			if (SetectWingIndexChanged != null)
			{
				SetectWingIndexChanged(this, e);
			}
		}
		#endregion

		#region mode
		private EDITMODE m_EditMode = EDITMODE.NORMAL;
		public EDITMODE EditMode
		{
			get { return m_EditMode; }
			set
			{
				if (m_EditMode!=(EDITMODE)value)
				{
					m_EditMode = (EDITMODE)value;
					switch(m_EditMode)
					{
						case EDITMODE.NORMAL:
							if (m_HTail != null) m_HTail.Wing_MODE = PPWing.MODE.POINT4;
							break;
						case EDITMODE.TWINTAIL:
							if (m_HTail != null) m_HTail.Wing_MODE = PPWing.MODE.POINT6;
							break;
						case EDITMODE.VTAIL:
							if (m_HTail != null) m_HTail.Wing_MODE = PPWing.MODE.POINT4;
							break;
					}
					if (m_ParamList != null)
					{
						m_ParamList.EditMode = m_EditMode;
					}
					this.Invalidate();
				}
			}
		}
		#endregion

		private int m_SelectWingIndex = -1;
		public int SelectWingIndex
		{
			get { return m_SelectWingIndex; }
		}

		#region dpi
		private float m_DPI = (float)82.0;
		public float DPI
		{
			get { return m_DPI; }
			set
			{
				m_DPI = value;
				if (m_Main != null) m_Main.SetDPI(m_DPI);
				if (m_HTail != null) m_HTail.SetDPI(m_DPI);
				if (m_VTail != null) m_VTail.SetDPI(m_DPI);
				this.Invalidate();
			}
		}
		#endregion

		private PointF m_DispLocation = new PointF(10, 120);
		public PointF DispLocation
		{
			get { return m_DispLocation; }
			set { m_DispLocation = value; }
		}

		#region color

		private Color m_GridColor = Color.FromArgb(230,230,230);
		public Color GridColor { get { return m_GridColor; } set { m_GridColor = value; this.Invalidate(); } }

		private Color m_BaseLine = Color.FromArgb(190,190,190);
		public Color BaseLine { get { return m_BaseLine; } set { m_BaseLine = value; this.Invalidate(); } }

		private Color m_OriLine = Color.FromArgb(170,170,170);
		public Color OriLine { get { return m_OriLine; } set { m_OriLine = value; this.Invalidate(); } }

		#endregion

		#region wings
		private PPWing m_Main = null;
		public PPWing MainWing
		{
			get { return m_Main; }
			set
			{
				m_Main = value;
				if(m_Main!=null)
				{
					m_Main.SetLocDPI(m_DPI, m_DispLocation);
					m_Main.Params = MainDef;
					this.Invalidate();
				}
			}
		}
		private PPWing m_HTail = null;
		public PPWing HTail
		{
			get { return m_HTail; }
			set
			{
				m_HTail = value;
				if(m_HTail!=null)
				{
					m_HTail.SetLocDPI(m_DPI, m_DispLocation);
					m_HTail.Params = HTailDef;
					this.Invalidate();
				}
			}
		}
		private PPWing m_VTail = null;
		public PPWing VTail
		{
			get { return m_VTail; }
			set
			{
				m_VTail = value;
				if(m_VTail!=null)
				{
					m_VTail.SetLocDPI(m_DPI, m_DispLocation);
					m_VTail.Params = VTailDef;
					this.Invalidate();
				}
			}
		}
		#endregion
		private PPParamsList m_ParamList = null;
		public PPParamsList ParamList
		{
			get { return m_ParamList; }
			set
			{
				m_ParamList = value;
				if (m_ParamList != null)
				{
					m_ParamList.EditMode = m_EditMode;
					m_SelectWingIndex = 0;
					ToParamsList();

					m_ParamList.EditModeChanged += M_ParamList_EditModeChanged;

					m_ParamList.TargetWing = m_SelectWingIndex;
					m_ParamList.TargetWingChanged += M_ParamList_TargetWingChanged;

					m_ParamList.ValueChanged += M_ParamList_ValueChanged;

				}
			}
		}

		private void M_ParamList_ValueChanged(object sender, EventArgs e)
		{
			FromParamsList();
			this.Invalidate();
		}

		private void M_ParamList_TargetWingChanged(object sender, EventArgs e)
		{
			if (m_ParamList == null) return;
			if(m_SelectWingIndex!= m_ParamList.TargetWing)
			{
				m_SelectWingIndex = m_ParamList.TargetWing;
				ToParamsList();
				this.Invalidate();
			}
		}

		public void Init()
		{
			if (m_Main != null) m_Main.Params = MainDef;
			if (m_HTail != null) m_HTail.Params = HTailDef;
			if (m_VTail != null) m_VTail.Params = VTailDef;
		}
		// *****************************************************************************
		private void M_ParamList_EditModeChanged(object sender, EventArgs e)
		{
			if (m_ParamList == null) return;
			if(EditMode!= m_ParamList.EditMode)
			{
				EditMode = m_ParamList.EditMode;
			}
		}

		// *****************************************************************************
		public DrawWings()
		{
			this.SetStyle(
		   ControlStyles.DoubleBuffer |
		   ControlStyles.UserPaint |
		   ControlStyles.AllPaintingInWmPaint,
		   true);

	
			ToParamsList();

		}
		// *****************************************************************************
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.Invalidate();
		}
		// *****************************************************************************
		public PointF LengthPos()
		{
			PointF ret = new PointF(0, 0);
			if ((m_VTail == null) || (m_HTail == null)) return ret;
			float x = 0;
			switch(m_EditMode)
			{
				case EDITMODE.NORMAL:
					x = m_HTail.WingPos + m_HTail.WingRoot;
					float x1 = m_VTail.WingPos + m_VTail.WingRoot;
					if (x < x1) x = x1;
					break;
				case EDITMODE.TWINTAIL:
				case EDITMODE.VTAIL:
					x = m_HTail.WingPos + m_HTail.WingRoot;
					break;
					
			}
			ret = new PointF(PP.MM2P(m_DispLocation.X + x,m_DPI), PP.MM2P(m_DispLocation.Y,m_DPI));
			return ret;
		}
		// *****************************************************************************
		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			g.SmoothingMode = SmoothingMode.HighQuality;
			//base.OnPaint(e);
			SolidBrush sb = new SolidBrush(this.BackColor);
			Pen p = new Pen(m_GridColor);
			try
			{
				//塗りつぶし
				g.FillRectangle(sb, this.ClientRectangle);

				//グリッド
				p.Width = 1;
				p.Color = m_GridColor;
				int w = this.ClientRectangle.Width;
				int h = this.ClientRectangle.Height;
				float cm1 = (float)PP.MM2P(10, m_DPI);
				int cw = (int)(w / cm1 + 0.5); 
				int ch = (int)(h / cm1 + 0.5);
				for (int i=0; i<=ch; i++)
				{
					g.DrawLine(p, 0, cm1 * i, w, cm1 * i);
				}
				for (int i=0; i<=cw; i++)
				{
					g.DrawLine(p, cm1*i, 0, cm1 * i, h);
				}
				//ベースライン
				p.Width = 2;
				p.Color = m_BaseLine;
				float hh = (float)PP.MM2P(m_DispLocation.Y, m_DPI);
				float ww = (float)PP.MM2P(m_DispLocation.X, m_DPI);

				g.DrawLine(p, 0, hh, w, hh);
				g.DrawLine(p, ww, 0, ww, h);

				//全長
				p.Width = 2;
				p.Color = Color.Black;
				g.DrawLine(p, new PointF(PP.MM2P(m_DispLocation.X,m_DPI), PP.MM2P(m_DispLocation.Y,m_DPI)), LengthPos());


				p.Color = Color.Black;
				sb.Color = Color.Black;
				p.Width = 2;
				if (m_Main!=null)
				{
					m_Main.Draw(g, sb,p);
				}
				if(m_HTail!=null)
				{

					m_HTail.Draw(g, sb,p);
				}
				if (m_EditMode == EDITMODE.NORMAL) {
					if (m_VTail != null)
					{
						m_VTail.Draw(g, sb, p);
					}
				}

			}
			finally
			{
				sb.Dispose();
				p.Dispose();
			}

		}
		private bool IsMouseDown = false;
		private PointF MouseDownPoint = new PointF(0, 0);
		// *****************************************************************************
		protected override void OnMouseDown(MouseEventArgs e)
		{
			//base.OnMouseDown(e);
			int bsw = m_SelectWingIndex;
			m_SelectWingIndex = -1;
			if ((m_Main != null)&&(IsMouseDown==false))
			{
				if (m_Main.InMouseDow(e.X, e.Y))
				{
					IsMouseDown = true;
					MouseDownPoint.X = e.X;
					MouseDownPoint.Y = e.Y;
					m_SelectWingIndex = 0;
				}
			}
			if (m_HTail != null)
			{
				if (m_HTail.InMouseDow(e.X, e.Y))
				{
					if (m_SelectWingIndex < 0)
					{
						IsMouseDown = true;
						MouseDownPoint.X = e.X;
						MouseDownPoint.Y = e.Y;
						m_SelectWingIndex = 1;
					}
					else
					{
						if (m_HTail != null) m_HTail.SelectIndex = -1;
					}
				}
			}
			if (m_VTail != null)
			{
				if (m_EditMode == EDITMODE.NORMAL)
				{
					if (m_VTail.InMouseDow(e.X, e.Y))
					{
						if (m_SelectWingIndex < 0)
						{
							IsMouseDown = true;
							MouseDownPoint.X = e.X;
							MouseDownPoint.Y = e.Y;
							m_SelectWingIndex = 2;
						}
						else
						{
							if (m_VTail != null) m_VTail.SelectIndex = -1;
						}
						
					}
				}
			}
			if(bsw != m_SelectWingIndex)
			{
				if (m_ParamList != null)
				{
					m_ParamList.TargetWing = m_SelectWingIndex;
				}
			}
			if (IsMouseDown)
			{
				this.Invalidate();
			}
		}
		// *****************************************************************************
		protected override void OnMouseMove(MouseEventArgs e)
		{
			//base.OnMouseMove(e);
			if (IsMouseDown == true)
			{
				switch (m_SelectWingIndex)
				{
					case 0:
						if (m_Main != null)m_Main.SetPointPixel(e.X, e.Y);
						break;
					case 1:
						if (m_HTail != null)m_HTail.SetPointPixel(e.X, e.Y);
						break;
					case 2:
						if (m_VTail != null)m_VTail.SetPointPixel(e.X, e.Y);
						break;

				}
				ToParamsList();
				this.Invalidate();
			}
		}
		// *****************************************************************************
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (IsMouseDown)
			{
				IsMouseDown = false;
				ToParamsList();
			}
		}
		// *****************************************************************************
		public void ToParamsList()
		{
			if (m_ParamList == null) return;
			PPWing wing = null;
			switch (m_SelectWingIndex)
			{
				case 0:
					wing = m_Main;
					break;
				case 1:
					wing = m_HTail;
					break;
				case 2:
					wing = m_VTail;
					break;
				default:
					return;
			}
			m_ParamList.EventFlag = false;
			m_ParamList.WingPos = wing.WingPos;
			m_ParamList.WingRoot = wing.WingRoot;
			m_ParamList.WingTip = wing.WingTip;
			m_ParamList.WingTipOffset = wing.WingTipOffset;
			m_ParamList.WingSpan = wing.WingSpan;
			m_ParamList.WingSpan2= wing.WingSpan2;
			m_ParamList.WingDihedral= wing.WingDihedral;
			m_ParamList.WingTip2= wing.WingTip2;
			m_ParamList.WingTipOffset2= wing.WingTipOffset2;
			m_ParamList.EventFlag = true;


		}
		// *****************************************************************************
		public void FromParamsList()
		{
			if (m_ParamList == null) return;
			PPWing wing = null;
			
			switch (m_ParamList.TargetWing)
			{
				case 0:
					wing = m_Main;
					break;
				case 1:
					wing = m_HTail;
					break;
				case 2:
					wing = m_VTail;
					break;
				default:
					return;
			}
			wing.WingPos = m_ParamList.WingPos;
			wing.WingRoot = m_ParamList.WingRoot;
			wing.WingTip = m_ParamList.WingTip;
			wing.WingTipOffset = m_ParamList.WingTipOffset;
			wing.WingSpan = m_ParamList.WingSpan;
			wing.WingSpan2 = m_ParamList.WingSpan2;
			wing.WingDihedral = m_ParamList.WingDihedral;
			wing.WingTip2 = m_ParamList.WingTip2;
			wing.WingTipOffset2 = m_ParamList.WingTipOffset2;
			this.Invalidate();
		}
		// *****************************************************************************
		public bool Save(string path)
		{
			bool ret = false;

			dynamic obj = new DynamicJson();
			obj.EditMode = (double)EditMode;
			if(m_Main  != null)
			{
				obj.Main = m_Main.Params;
			}
			if(m_HTail != null)
			{
				obj.HTail = m_HTail.Params;
			}
			if(m_VTail != null)
			{
				obj.VTail = m_VTail.Params;
			}

			string js = obj.ToString();

			try
			{
				File.WriteAllText(path, js);
				ret = true;
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		public bool Load(string path)
		{
			bool ret = false;

			if (File.Exists(path) == false) return ret;

			string js = File.ReadAllText(path);

			dynamic obj = DynamicJson.Parse(js);

			if (((DynamicJson)obj).IsDefined("EditMode"))
			{
				int v = (int)obj.EditMode;
				EditMode = (EDITMODE)v;
			}
			if (((DynamicJson)obj).IsDefined("Main"))
			{
				float[] sa = (float[])obj.Main;
				if (m_Main != null) m_Main.Params = sa;

			}
			if (((DynamicJson)obj).IsDefined("HTail"))
			{
				float[] sa = (float[])obj.HTail;
				if (m_HTail != null) m_HTail.Params = sa;

			}
			if (((DynamicJson)obj).IsDefined("VTail"))
			{
				float[] sa = (float[])obj.VTail;
				if (m_VTail != null) m_VTail.Params = sa;
			}
			return ret;

		}
	}
}
