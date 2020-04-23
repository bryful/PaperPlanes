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

using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;


namespace PaperPlanes
{
	public class DrawWings : Control
	{

		public float HorVolumeRate = 1.2f;
		public float VerVolumeRate = 0.05f;
		

		public float[] MainDef =new float[]		{ 49.8f,48.3f,21.6f,4.9f ,152f ,15f   ,15f  ,20f ,10f};
		public float[] HTailDef =new float[]	{182.4f,30.3f,17f  ,13.9f,100f ,15f   ,0    ,20f ,10f};
		public float[] VTailDef =new float[]	{158.8f,31.6f,12.6f,24.8f,54.1f,15f   ,15f  ,20f ,10f};
		public float[] TwinTailDef =new float[] {156.3f,31.6f,18.9f,14.9f,58.5f,15.2f ,16.7f,9.8f,10.5f};
		public float[] V_TailDef =new float[]	{158.8f,31.6f,15.8f,10.5f,67.2f,15,25f,20f  ,10f};

		/*
		"Main":[49.8,48.3,21.6,4.9,152,15,15,20,10],
"TailH":[182.4,30.3,17,13.9,100,15,0,20,10],
"TailV":[158.8,31.6,12.6,24.8,54.1,15,15,20,10],
"TwinTail":[156.3,31.6,18.9,14.9,58.5,15.2,16.7,9.8,10.5],
"V_Tail":[158.8,31.6,15.8,10.5,67.2,15,25,20,10]}
		*/
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
		public enum EDIT_MODE
		{
			NORMAL =0,
			TWINTAIL
			//VTAIL
		}
		private EDIT_MODE m_EditMode = EDIT_MODE.NORMAL;
		public EDIT_MODE EditMode
		{
			get { return m_EditMode; }
			set
			{
				if (m_Main != null) m_Main.SetWingMode(PPWing.WING_MODE.MAIN);
				if (m_TailV != null) m_TailV.SetWingMode(PPWing.WING_MODE.VER_TAIL);
				if (m_TailH != null) m_TailH.SetWingMode(PPWing.WING_MODE.HOR_TAIL);
				if (m_TwinTail != null) m_TwinTail.SetWingMode(PPWing.WING_MODE.TWIN_TAIL);
				if (m_EditMode != (EDIT_MODE)value)
				{
					m_EditMode = (EDIT_MODE)value;
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
				if (m_TailH != null) m_TailH.SetDPI(m_DPI);
				if (m_TailV != null) m_TailV.SetDPI(m_DPI);
				if (m_TwinTail != null) m_TwinTail.SetDPI(m_DPI);
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

		private float m_CG = 0;
		private float m_CG1 = 0;
		public float CG
		{ get { return m_CG; } }


		private Color m_GridColor = Color.FromArgb(230,230,230);
		public Color GridColor { get { return m_GridColor; } set { m_GridColor = value; this.Invalidate(); } }
		private Color m_GridColor2 = Color.FromArgb(210,210,210);
		public Color GridColor2 { get { return m_GridColor2; } set { m_GridColor2 = value; this.Invalidate(); } }

		private Color m_BaseLine = Color.FromArgb(150,150,150);
		public Color BaseLine { get { return m_BaseLine; } set { m_BaseLine = value; this.Invalidate(); } }


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
					m_Main.SetWingMode(PPWing.WING_MODE.MAIN);
					m_Main.SetLocDPI(m_DPI, m_DispLocation);
					m_Main.Params = MainDef;
					this.Invalidate();
				}
			}
		}
		private PPWing m_TailH = null;
		public PPWing TailH
		{
			get { return m_TailH; }
			set
			{
				m_TailH = value;
				if(m_TailH!=null)
				{
					m_TailH.SetWingMode(PPWing.WING_MODE.HOR_TAIL);
					m_TailH.SetLocDPI(m_DPI, m_DispLocation);
					m_TailH.Params = HTailDef;
					m_TailH.WingDihedral = 0;
					this.Invalidate();
				}
			}
		}
		private PPWing m_TailV = null;
		public PPWing TailV
		{
			get { return m_TailV; }
			set
			{
				m_TailV = value;
				if(m_TailV!=null)
				{
					m_TailV.SetWingMode(PPWing.WING_MODE.VER_TAIL);
					m_TailV.SetLocDPI(m_DPI, m_DispLocation);
					m_TailV.Params = VTailDef;
					m_TailV.WingDihedral = 0;
					this.Invalidate();
				}
			}
		}
		private PPWing m_TwinTail = null;
		public PPWing TwinTail
		{
			get { return m_TwinTail; }
			set
			{
				m_TwinTail = value;
				if(m_TwinTail!=null)
				{
					m_TwinTail.SetWingMode(PPWing.WING_MODE.TWIN_TAIL);
					m_TwinTail.SetLocDPI(m_DPI, m_DispLocation);
					m_TwinTail.Params = TwinTailDef;
					m_TwinTail.WingDihedral = 0;
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
					m_ParamList.SelectWing = m_SelectWingIndex;
					m_ParamList.SelectWingChanged += M_ParamList_TargetWingChanged;
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
			if(m_SelectWingIndex!= m_ParamList.SelectWing)
			{
				m_SelectWingIndex = m_ParamList.SelectWing;
			}
			ToParamsList();
			this.Invalidate();
		}

		public void Init()
		{
			if (m_Main != null) m_Main.Params = MainDef;
			if (m_TailH != null) m_TailH.Params = HTailDef;
			if (m_TailV != null) m_TailV.Params = VTailDef;
			if (m_TwinTail != null) m_TwinTail.Params = TwinTailDef;
		}
		// *****************************************************************************
		private void M_ParamList_EditModeChanged(object sender, EventArgs e)
		{
			if (m_ParamList == null) return;
			if (EditMode != m_ParamList.EditMode)
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
		public float BodyLength()
		{
			float ret = 0;
			switch (m_EditMode)
			{
				case DrawWings.EDIT_MODE.NORMAL:
					if ((m_TailH != null) && (m_TailV != null))
					{
						ret = m_TailH.WingPos + m_TailH.WingRoot;
						float x2 = m_TailV.WingPos + m_TailV.WingRoot;
						if (ret < x2) ret = x2;
					}
					break;
				case DrawWings.EDIT_MODE.TWINTAIL:
					if (m_TwinTail != null)
					{
						ret = m_TwinTail.WingPos + m_TwinTail.WingRoot;
					}
					break;

			}
			return ret;
		}
		// *****************************************************************************
		/// <summary>
		/// 機体の全長を求める
		/// </summary>
		/// <returns></returns>
		public PointF BodyLengthPos()
		{
			PointF ret = new PointF(0, 0);
			float x = BodyLength();
			
			ret = new PointF(PP.MM2P(m_DispLocation.X + x, m_DPI), PP.MM2P(m_DispLocation.Y, m_DPI));
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

				#region hor
				//水平線
				float y = (float)PP.MM2P(m_DispLocation.Y, m_DPI);
				int cnt = 0;
				do
				{
					if((cnt % 5) == 0)
					{
						p.Color = m_GridColor2;
					}
					else
					{
						p.Color = m_GridColor;
					}
					cnt++;
					g.DrawLine(p, 0, y, w, y);
					y += cm1;
				} while (y < h);
				cnt = 1;
				y = (float)PP.MM2P(m_DispLocation.Y, m_DPI) -cm1;
				do
				{
					if((cnt % 5) == 0)
					{
						p.Color = m_GridColor2;
					}
					else
					{
						p.Color = m_GridColor;
					}
					cnt++;
					g.DrawLine(p, 0, y, w, y);
					y -= cm1;
				} while (y >= 0);
				#endregion

				#region Vur
				float x = (float)PP.MM2P(m_DispLocation.X, m_DPI);
				cnt = 0;
				do
				{
					if((cnt % 5) == 0)
					{
						p.Color = m_GridColor2;
					}
					else
					{
						p.Color = m_GridColor;
					}
					cnt++;
					g.DrawLine(p, x, 0, x, h);
					x += cm1;
				} while (x < w);
				cnt = 1;
				x = (float)PP.MM2P(m_DispLocation.X, m_DPI) -cm1;
				do
				{
					if((cnt % 5) == 0)
					{
						p.Color = m_GridColor2;
					}
					else
					{
						p.Color = m_GridColor;
					}
					cnt++;
					g.DrawLine(p, x, 0, x, h);
					x -= cm1;
				} while (x >= 0);
				#endregion

				//ベースライン
				p.Width = 2;
				p.Color = m_BaseLine;
				float hh = (float)PP.MM2P(m_DispLocation.Y, m_DPI);
				float ww = (float)PP.MM2P(m_DispLocation.X, m_DPI);

				g.DrawLine(p, 0, hh, w, hh);
				g.DrawLine(p, ww, 0, ww, h);

				//全長
				p.Width = 2.5f;
				p.Color = Color.Black;
				g.DrawLine(p, new PointF(PP.MM2P(m_DispLocation.X, m_DPI), PP.MM2P(m_DispLocation.Y, m_DPI)), BodyLengthPos());


				p.Color = Color.Black;
				sb.Color = Color.Black;
				p.Width = 2;
				if (m_Main != null)
				{
					m_Main.Draw(g, sb, p);
					//cg

				}
				switch (m_EditMode)
				{
					case EDIT_MODE.NORMAL:
						if (m_TailH != null) m_TailH.Draw(g, sb, p);
						if (m_TailV != null) m_TailV.Draw(g, sb, p);
						break;
					case EDIT_MODE.TWINTAIL:
						if (m_TwinTail != null) m_TwinTail.Draw(g, sb, p);
						break;
				}

				PointF[] cgl = new PointF[3];
				x = PP.MM2P( m_CG, m_DPI);
				y = PP.MM2P(m_DispLocation.Y + 10, m_DPI);
				cgl[0] = new PointF(x, y);
				y = PP.MM2P(m_DispLocation.Y,m_DPI);
				cgl[1] = new PointF(x, y);
				x += PP.MM2P(3, m_DPI);
				y += PP.MM2P(5, m_DPI);
				cgl[2] = new PointF(x, y);
				//cgl[3] = new PointF(0100, 100);
				p.Color = Color.Black;
				p.Width = 1;
				g.DrawLines(p, cgl);
				

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
			if ((m_Main != null) && (IsMouseDown == false))
			{
				if (m_Main.InMouseDow(e.X, e.Y))
				{
					IsMouseDown = true;
					MouseDownPoint.X = e.X;
					MouseDownPoint.Y = e.Y;
					m_SelectWingIndex = 0;
				}
			}
			PPWing wing0 = null;
			PPWing wing1 = null;

			switch (m_EditMode)
			{
				case EDIT_MODE.NORMAL:
					wing0 = m_TailH;
					wing1 = m_TailV;

					break;
				case EDIT_MODE.TWINTAIL:
					wing0 = m_TwinTail;
					break;
			}
			if (wing0 != null)
			{
				if (wing0.InMouseDow(e.X, e.Y))
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
						if (wing0 != null) wing0.SelectIndex = -1;
					}
				}
			}
			if (wing1 != null)
			{
				if (wing1.InMouseDow(e.X, e.Y))
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
						if (wing1 != null) wing1.SelectIndex = -1;
					}

				}
			}
			if (bsw != m_SelectWingIndex)
			{
				if (m_ParamList != null)
				{
					m_ParamList.SelectWing = m_SelectWingIndex;
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
						if (m_Main != null) m_Main.SetPointPixel(e.X, e.Y);
						break;
					case 1:
						switch (m_EditMode)
						{
							case EDIT_MODE.NORMAL:
								if (m_TailH != null) m_TailH.SetPointPixel(e.X, e.Y);
								break;
							case EDIT_MODE.TWINTAIL:
								if (m_TwinTail != null) m_TwinTail.SetPointPixel(e.X, e.Y);
								break;
						}
						break;
					case 2:
						if (m_TailV != null) m_TailV.SetPointPixel(e.X, e.Y);
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
			float tv = 1;
			switch (m_SelectWingIndex)
			{
				case 1:
					if (m_EditMode == EDIT_MODE.NORMAL)
					{
						wing = m_TailH;
					}
					else
					{
						wing = m_TwinTail;
					}
					break;
				case 2:
					wing = m_TailV;
					tv = 0.5f;
					break;
				case 0:
				default:
					wing = m_Main;
					break;
			}
			m_ParamList.EventFlag = false;
			m_ParamList.WingPos = wing.WingPos;
			m_ParamList.WingRoot = wing.WingRoot;
			m_ParamList.WingTip = wing.WingTip;
			m_ParamList.WingTipOffset = wing.WingTipOffset;
			m_ParamList.WingSpan = wing.WingSpan * tv;
			m_ParamList.WingDihedral = wing.WingDihedral;
			m_ParamList.WingTip2 = wing.WingTip2;
			m_ParamList.WingTipOffset2 = wing.WingTipOffset2;
			m_ParamList.WingSpan2 = wing.WingSpan2;
	
			m_ParamList.EventFlag = true;

			ShowInfo();


		}
		// *****************************************************************************
		public void ShowInfo()
		{
			if (m_ParamList == null) return;
			if (m_Main == null) return;
			float sh = 0;
			float sv = 0;
			float kh = 0;
			float kv = 0;
			float LO = 0;
			float L1 = 0;

			switch(m_EditMode)
			{
				case EDIT_MODE.NORMAL:
					if ((m_TailH == null) || (m_TailV == null)) return;
					//理想的な水平尾翼の大きさを求める
					sh = HorVolumeRate *m_Main.HorArea * m_Main.HorMacLength  / (m_TailH.AerodynamicCenterPosH - m_Main.AerodynamicCenterPosH);
					//理想的な垂直尾翼
					sv = VerVolumeRate * m_Main.HorArea * m_Main.WingSpan / (m_TailV.AerodynamicCenterPosH - m_Main.AerodynamicCenterPosH);
					kh = m_TailH.HorArea * (m_TailH.AerodynamicCenterPosH - m_Main.AerodynamicCenterPosH) / (m_Main.HorArea * m_Main.HorMacLength);
					kv = (m_TailV.VerArea/2) * (m_TailV.AerodynamicCenterPosV - m_Main.AerodynamicCenterPosH) / (m_Main.HorArea * m_Main.WingSpan);

					LO = (m_TailH.AerodynamicCenterPosH - m_Main.AerodynamicCenterPosH);
					L1 =  LO * m_TailH.HorArea / (m_Main.HorArea + m_TailH.HorArea);

					m_CG1 = m_Main.AerodynamicCenterPosH + L1;
					m_CG = m_Main.AerodynamicCenterPosH + L1 - (LO * 0.103f);

					break;
				case EDIT_MODE.TWINTAIL:
					if (m_TwinTail == null) return;
					sh = m_Main.HorArea * m_Main.HorMacLength * HorVolumeRate / (m_TwinTail.AerodynamicCenterPosH - m_Main.AerodynamicCenterPosH);
					sv = VerVolumeRate * m_Main.HorArea * m_Main.WingSpan / (m_TwinTail.AerodynamicCenterPosV - m_Main.AerodynamicCenterPosH);
					kh = m_TwinTail.HorArea * (m_TwinTail.AerodynamicCenterPosH - m_Main.AerodynamicCenterPosH) / (m_Main.HorArea * m_Main.HorMacLength);
					kv = m_TwinTail.VerArea * (m_TwinTail.AerodynamicCenterPosV - m_Main.AerodynamicCenterPosH) / (m_Main.HorArea * m_Main.WingSpan);

					LO = (m_TwinTail.AerodynamicCenterPosH - m_Main.AerodynamicCenterPosH);
					L1 =  LO * m_TwinTail.HorArea / (m_Main.HorArea + m_TwinTail.HorArea);

					m_CG1 = m_Main.AerodynamicCenterPosH + L1;
					m_CG = m_Main.AerodynamicCenterPosH + L1 - LO * 0.103f;

					break;
			}

			
			m_ParamList.Body = BodyLength()/10;// mm->cm

			m_ParamList.MainArea = m_Main.HorArea/100;
			m_ParamList.TailHorArea = TailHorArea()/100;
			m_ParamList.TailHorAreaIdeal = sh/100;
			m_ParamList.TailHorVolum = kh;

			m_ParamList.TailVerArea = TailVerArea() / 100;
			m_ParamList.TailVerAreaIdeal = sv / 100;
			m_ParamList.TailVerVolum = kv;
		}
		// *****************************************************************************
		public float TailHorArea()
		{
			float ret = 0;
			switch(m_EditMode)
			{
				case EDIT_MODE.NORMAL:
					if (m_TailH != null) ret = m_TailH.HorArea;
					break;
				case EDIT_MODE.TWINTAIL:
					if (m_TwinTail != null) ret = m_TwinTail.HorArea;
					break;
			}
			return ret;
		}
		// *****************************************************************************
		public float TailVerArea()
		{
			float ret = 0;
			switch(m_EditMode)
			{
				case EDIT_MODE.NORMAL:
					if (m_TailV != null) ret = m_TailV.HorArea/2;
					break;
				case EDIT_MODE.TWINTAIL:
					if (m_TwinTail != null) ret = m_TwinTail.VerArea;
					break;
			}
			return ret;
		}
		// *****************************************************************************
		public void FromParamsList()
		{
			if (m_ParamList == null) return;
			PPWing wing = null;
			float tv = 1;
			switch (m_ParamList.SelectWing)
			{
				case 1:
					if (m_EditMode == EDIT_MODE.NORMAL)
					{
						wing = m_TailH;
						
					}
					else if (m_EditMode == EDIT_MODE.TWINTAIL)
					{
						wing = m_TwinTail;
					}
					break;
				case 2:
					wing = m_TailV;
					tv = 2;
					break;
				default:
				case 0:
					wing = m_Main;
					break;
			}
			wing.WingPos = m_ParamList.WingPos;
			wing.WingRoot = m_ParamList.WingRoot;
			wing.WingTip = m_ParamList.WingTip;
			wing.WingTipOffset = m_ParamList.WingTipOffset;
			wing.WingSpan = m_ParamList.WingSpan * tv;

			wing.WingDihedral = m_ParamList.WingDihedral;
			wing.WingSpan2 = m_ParamList.WingSpan2;
			wing.WingTip2 = m_ParamList.WingTip2;
			wing.WingTipOffset2 = m_ParamList.WingTipOffset2;
			this.Invalidate();

			ShowInfo();

		}
		// *****************************************************************************
		public bool Save(string path)
		{
			bool ret = false;

			dynamic obj = new DynamicJson();
			obj.EditMode = (double)EditMode;
			if (m_Main != null)
			{
				obj.Main = m_Main.Params;
			}
			if (m_TailH != null)
			{
				obj.TailH = m_TailH.Params;
			}
			if (m_TailV != null)
			{
				obj.TailV = m_TailV.Params;
			}
			if (m_TwinTail != null)
			{
				obj.TwinTail = m_TwinTail.Params;
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
				EditMode = (DrawWings.EDIT_MODE)v;
			}
			if (((DynamicJson)obj).IsDefined("Main"))
			{
				float[] sa = (float[])obj.Main;
				if (m_Main != null) m_Main.Params = sa;

			}
			if (((DynamicJson)obj).IsDefined("TailH"))
			{
				float[] sa = (float[])obj.TailH;
				if (m_TailH != null) m_TailH.Params = sa;

			}
			if (((DynamicJson)obj).IsDefined("TailV"))
			{
				float[] sa = (float[])obj.TailV;
				if (m_TailV != null) m_TailV.Params = sa;
			}
			if (((DynamicJson)obj).IsDefined("TwinTail"))
			{
				float[] sa = (float[])obj.TwinTail;
				if (m_TwinTail != null) m_TwinTail.Params = sa;
			}
			return ret;

		}
		// ******************************************
		public bool exportPDF(string path)
		{
			bool ret = false;

			PdfDocument document = new PdfDocument();
			PdfPage page = document.AddPage();
			page.Size = PageSize.A4;
			page.Orientation = PageOrientation.Portrait;
			XGraphics xg = XGraphics.FromPdfPage(page,XGraphicsUnit.Millimeter);
			XPen xp = new XPen(XColor.FromArgb(16, 16, 16));
			xp.Width = 0.1f;
			XPoint[] ps = new XPoint[0];

			double x = 0;
			double y = 0;
			try
			{
				switch (m_EditMode)
				{
					case EDIT_MODE.NORMAL:
						if (m_Main != null) m_Main.PdfDraw(xg, xp);
						if (m_TailH != null) m_TailH.PdfDraw(xg, xp);
						if (m_TailV != null) m_TailV.PdfDraw(xg, xp,(m_TailH.WingSpan/2+10)*-1);
						break;
					case EDIT_MODE.TWINTAIL:
						if (m_Main != null) m_Main.PdfDraw(xg, xp);
						if (m_TwinTail != null) m_TwinTail.PdfDraw(xg, xp);
						break;
				}
				//body
				ps = new XPoint[2];
				ps[0] = new XPoint(m_DispLocation.X, m_DispLocation.Y);
				ps[1] = new XPoint(m_DispLocation.X + BodyLength(), m_DispLocation.Y);
				xp.Color = XColor.FromArgb(0, 0, 0);
				xg.DrawLines(xp, ps);


				ps = new XPoint[3];
				x = m_CG;
				y = m_DispLocation.Y + 10;
				ps[0] = new XPoint(x, y);
				y = m_DispLocation.Y;
				ps[1] = new XPoint(x, y);
				x += 3;
				y += 5;
				ps[2] = new XPoint(x, y);
				xp.Color = XColor.FromArgb(180, 180, 180);
				xg.DrawLines(xp, ps);


				document.Save(path);
				ret = true;
			}
			finally
			{
				document.Dispose();

			}

			return ret;
		}
	}
}
