using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Xml.Schema;
using System.Security;
using System.IO;

using netDxf;
using netDxf.Entities;

namespace PP
{
	public class PCanvas : Control
	{
		private float m_Dpi = 82.0f;
		/// <summary>
		/// 解像度
		/// </summary>
		[Category("PaperPlane")]
		public float Dpi
		{
			get { return m_Dpi; }
			set 
			{
				m_Dpi = value;
				m_Wing.Dpi = value;
				m_Disp.Dpi = value;

				this.Invalidate(); 
			}
		}
		private Color m_GridColor = Color.FromArgb(255,180,180,180);
		/// <summary>
		/// グリッド線の色
		/// </summary>
		[Category("PaperPlane Color")]
		public Color GridColor
		{
			get { return this.m_GridColor; }
			set
			{
				m_GridColor = value;
				this.Invalidate();
			}
		}
		private Color m_LineColor = Color.FromArgb(255, 0, 0, 0);
		/// <summary>
		/// グリッド線の色
		/// </summary>
		[Category("PaperPlane Color")]
		public Color LineColor
		{
			get { return this.m_LineColor; }
			set
			{
				m_LineColor = value;
				this.Invalidate();
			}
		}
		/// <summary>
		/// グリッド線の色
		/// </summary>
		private Color m_LineColor2 = Color.FromArgb(255, 128, 128, 128);
		/// <summary>
		/// グリッド線の色
		/// </summary>
		[Category("PaperPlane Color")]
		public Color LineColor2
		{
			get { return this.m_LineColor2; }
			set
			{
				m_LineColor2 = value;
				this.Invalidate();
			}
		}
		private Color m_BaseColor = Color.FromArgb(255, 120, 90, 90);
		/// <summary>
		/// グリッド線の色
		/// </summary>
		[Category("PaperPlane Color")]
		public Color BaseColor
		{
			get { return this.m_BaseColor; }
			set
			{
				m_BaseColor = value;
				this.Invalidate();
			}
		}
		//private System.Drawing.PointF m_DispP = new System.Drawing.PointF(0, 0);
		//private PointF m_DispF = new PointF(10.0f, 10.0f);
		private PPoint m_Disp = new PPoint(10,10,82);
		/// <summary>
		/// 表示基点
		/// </summary>
		[Category("PaperPlane")]
		public PointF Disp
		{
			get { return m_Disp.PointMM; }
			set 
			{ 
				m_Disp.PointMM = value;
				this.Invalidate();
			}
		}

		private SizeF m_GridSize = new SizeF(5.0f,5.0f);
		[Category("PaperPlane")]
		public SizeF GridSize
		{
			get { return this.m_GridSize; }
			set
			{
				m_GridSize = value;
				this.Invalidate();
			}
		}
		private PWing m_Wing = new PWing();
		[Category("PaperPlane Wing")]
		public PWing Wing
		{
			get { return m_Wing; }
			set{ m_Wing = value;}
		}
		[Category("PaperPlane")]
		public TailMode TailMode
		{
			get { return m_Wing.TailMode; }
			set
			{
				bool b = (m_Wing.TailMode != value);
				m_Wing.TailMode = value;
				this.Invalidate();
				if (m_TailModeBtns != null)
				{
						m_TailModeBtns.TailMode = m_Wing.TailMode;
				}
				if(m_VTailEdit != null)
				{
					m_VTailEdit.TwinMode = (m_Wing.TailMode == TailMode.Twin);

				}
				this.Invalidate();
			}
		}
		// ********************************************************************
		public PCanvas() 
		{
			base.DoubleBuffered = true;
			base.BackColor = Color.White;
			Dpi = 82.0f;
			m_Disp.PointMM = new PointF(10,10);
			m_Wing.Calc();
			m_Wing.WingChanged -= (sender, e) => { this.Invalidate(); };
			m_Wing.WingChanged += (sender, e) => { this.Invalidate(); };
		}
		// ********************************************************************
		private void DrawWingSub(Graphics g, Pen p, SolidBrush sb,
				PointF[] m, PointF[] mac,int idx
			)
		{
			p.Width = 1;
			p.Color = m_LineColor2;
			g.DrawLines(p, mac);
			
			float y = (float)(mac[0].Y + (mac[1].Y - mac[0].Y) * 0.25);
			float x0 = m_Disp.PointPX.X;
			float x1 = (float)(mac[0].X);
			g.DrawLine(p, x0, y, x1, y);

			p.Color = m_LineColor;
			p.Width = 2;
			g.DrawLines(p, m);

			if ((idx >= 0) && (idx < 4))
			{
				sb.Color = m_LineColor;
				P.FillDot(g, sb, m[idx], 6);
			}


		}
		// ********************************************************************
		private void DrawWing(Graphics g,Pen p,SolidBrush sb)
		{
			// baseLine
			p.Width = 2;
			p.Color = m_BaseColor;
			g.DrawLine(p, m_Disp.PointPX, new PointF(m_Disp.Xp, m_Disp.Yp + P.Mm2Px(m_Wing.FuselageLength,m_Dpi)));

			//Main
			PointF[] lines = m_Wing.MainLines(m_Disp.PointMM);
			PointF[] mac = m_Wing.MainMACLines(m_Disp.PointMM);
			DrawWingSub(g,p,sb, lines, mac, m_Wing.SelectedIndex);

			p.Color = m_LineColor;
			p.Width = 1;
			float cg = P.Mm2Px(m_Wing.CenterGP, m_Dpi) + m_Disp.Yp;
			g.DrawLine(p, m_Disp.Xp, cg, m_Disp.Xp - 10, cg);

			p.Color = Color.Red;
			p.Width = 1;
			float cg2 = P.Mm2Px(m_Wing.CenterGReal, m_Dpi) + m_Disp.Yp;
			g.DrawLine(p, m_Disp.Xp, cg2, m_Disp.Xp + 20, cg2);


			lines = m_Wing.HTailLines(m_Disp.PointMM);
			mac = m_Wing.HTailMACLines(m_Disp.PointMM);
			DrawWingSub(g, p, sb, lines, mac, m_Wing.SelectedIndex - 4);
			lines = m_Wing.VTailLines(m_Disp.PointMM);
			mac = m_Wing.VTailMACLines(m_Disp.PointMM);
			DrawWingSub(g, p, sb, lines, mac, m_Wing.SelectedIndex - 8);

		}
		// ********************************************************************
		protected override void OnPaint(PaintEventArgs e)
		{
			using (SolidBrush sb = new SolidBrush(BackColor))
			using (Pen p = new Pen(ForeColor))
			{
				Rectangle rct;
				Graphics g = e.Graphics;
				g.Clear(BackColor);
				p.Width = 1;

				// hor
				p.Color = m_GridColor;
				float h = 0.0f;
				float hh = P.Mm2Px(this.Height, m_Dpi);
				while(h<hh)
				{
					float h2 = P.Mm2Px(h, m_Dpi);
					g.DrawLine(p, 0, h2, this.Width, h2);
					h += m_GridSize.Height;
				}
				// Vur
				float w = 0.0f;
				float ww = P.Mm2Px(this.Width, m_Dpi);
				while (w < ww)
				{
					float w2 = P.Mm2Px(w, m_Dpi);
					g.DrawLine(p, w2, 0, w2, this.Height);
					w += m_GridSize.Width;
				}
				p.Color = ForeColor;
				p.Width = 1;
				DrawWing(g, p,sb);

				p.Width = 1;
				p.Color = ForeColor;
				rct = new Rectangle(0,0,this.Width-1,this.Height-1);
				g.DrawRectangle(p, rct);

			}
			base.OnPaint(e);
		}
		// ********************************************************************
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.Invalidate();
		}
		private bool m_IsMd = false;
		private System.Drawing.Point m_md = new System.Drawing.Point(0,0);
		// **************************************************************
		protected override void OnMouseDown(MouseEventArgs e)
		{
			float x = e.X - m_Disp.Xp;
			float y = e.Y - m_Disp.Yp;

			int idx = m_Wing.IsIn(x, y);
			if(idx>=0)
			{
				m_IsMd=true;
				m_Wing.PushPrm();
				m_md.X = e.X;
				m_md.Y = e.Y;
			}
			else
			{
				m_IsMd = false;
				m_md.X = 0;
				m_md.Y = 0;
			}
			base.OnMouseDown(e);
			this.Invalidate();

		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if(m_IsMd)
			{
				float x = e.X - m_md.X;
				float y = e.Y - m_md.Y;
				m_Wing.Move(P.Px2Mm(x,Dpi), P.Px2Mm(y,Dpi));
				this.Invalidate();
			}
			base.OnMouseMove(e);
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			m_IsMd = false;
			m_md = new System.Drawing.Point(0, 0);
			base.OnMouseUp(e);
		}
		// **************************************************************
		private TailModeBtns m_TailModeBtns = null;
		[Category("PaperPlaneControl")]
		public TailModeBtns TailModeBtns
		{
			get { return m_TailModeBtns; }
			set
			{
				m_TailModeBtns = value;
				if (m_TailModeBtns != null)
				{
					m_TailModeBtns.TailMode = m_Wing.TailMode;
					m_TailModeBtns.TailModeChanged += (sender, e) =>
					{
						if (TailMode != e.Mode)
						{
							TailMode = e.Mode;
						}
					};
				}
			}
		}
		private PWingEdit m_MainEdit = null;
		[Category("PaperPlaneControl")]
		public PWingEdit MainEdit
		{
			get { return m_MainEdit; }
			set
			{
				m_MainEdit = value;

				if (m_MainEdit != null)
				{
					m_MainEdit.TwinMode = false;
					m_MainEdit.Params = Wing.MainParams;
					Wing.WingChanged += (sender, e) =>
					{
						m_MainEdit.Params = Wing.MainParams;
					};
					m_MainEdit.ValueChanged += (sender, e) =>
					{
						Debug.WriteLine("PCANVAS:m_MainEdit");
						Wing.MainParams = m_MainEdit.Params;
						this.Invalidate();
					};
				}
			}
		}
		private PWingEdit m_HTailEdit = null;
		[Category("PaperPlaneControl")]
		public PWingEdit HTailEdit
		{
			get { return m_HTailEdit; }
			set
			{
				m_HTailEdit = value;

				if (m_HTailEdit != null)
				{
					m_HTailEdit.TwinMode = false;
					m_HTailEdit.Params = Wing.HTailParams;
					Wing.WingChanged += (sender, e) =>
					{
						m_HTailEdit.Params = Wing.HTailParams;
					};
					m_HTailEdit.ValueChanged += (sender, e) =>
					{
						Wing.HTailParams = m_HTailEdit.Params;
					};
				}
			}
		}
		private PWingEdit m_VTailEdit = null;
		[Category("PaperPlaneControl")]
		public PWingEdit VTailEdit
		{
			get { return m_VTailEdit; }
			set
			{
				m_VTailEdit = value;

				if (m_VTailEdit != null)
				{
					if (Wing.TailMode == TailMode.Twin)
					{
						m_VTailEdit.TwinMode = true;
					}
					else
					{
						m_VTailEdit.TwinMode = false;
					}
					m_VTailEdit.Params = Wing.VTailParams;
					Wing.WingChanged += (sender, e) =>
					{
						m_VTailEdit.Params = Wing.VTailParams;
					};
					m_VTailEdit.ValueChanged += (sender, e) =>
					{
						Wing.VTailParams = m_VTailEdit.Params;
					};
				}
			}
		}

		private PWingCalc m_CalcEdit = null;
		[Category("PaperPlaneControl")]
		public PWingCalc CalcEdit
		{
			get { return m_CalcEdit; }
			set
			{
				m_CalcEdit = value;

				if (m_CalcEdit != null)
				{
					m_CalcEdit.ParamsT = Wing.ParamsT;
					m_CalcEdit.SetParamsC(Wing.ParamsC);
					Wing.WingChanged += (sender, e) =>
					{
						m_CalcEdit.ParamsT = Wing.ParamsT;
						m_CalcEdit.SetParamsC(Wing.ParamsC);
					};
					m_CalcEdit.ValueChanged += (sender, e) =>
					{
						Wing.ParamsT = m_CalcEdit.ParamsT;
					};
				}
			}
		}
		// ***********************************************************
		private NavBtn m_NavBtn = null;
		[Category("PaperPlaneControl")]
		public NavBtn NavBtn
		{
			get { return m_NavBtn; }
			set
			{
				m_NavBtn = value;

				if (m_NavBtn != null)
				{
					m_NavBtn.UpTailChanged += (sender, e) => { Wing.MoveTail(-1); };
					m_NavBtn.DownTailChanged += (sender, e) => { Wing.MoveTail(1); };
					m_NavBtn.UpAllChanged += (sender, e) => { Wing.MoveMainTail(-1); };
					m_NavBtn.DownAllChanged += (sender, e) => { Wing.MoveMainTail(1); };
				}
			}
		}

		// ***********************************************************
		public bool Load(string p)
		{
			bool b = Wing.Load(p);
			if(b)
			{
				if (m_TailModeBtns!=null)
				{
					m_TailModeBtns.TailMode = this.TailMode;
				}
			}
			if(m_CalcEdit!=null)
			{
				m_CalcEdit.ParamsT= Wing.ParamsT;
				m_CalcEdit.SetParamsC(Wing.ParamsC);
			}
			this.Invalidate();
			return b;
		}
		public bool Save(string p)
		{
			return Wing.Save(p);
		}
		public PointF[] ShiftLines(PointF[] pnts, float x, float y)
		{
			if (pnts.Length > 0)
			{
				for (int i = 0; i < pnts.Length; i++)
				{
					pnts[i].X += x;
					pnts[i].Y += y;
				}
			}
			return pnts;
		}
		private string m_filename = "";
		private PointF[] Rotate(PointF[] pt, float r)
		{
			if (pt.Length<=0) return pt;
			PointF[] ret = new PointF[pt.Length];

			for (int i=0; i<pt.Length; i++)
			{
				float x = pt[i].X;
				float y = pt[i].Y;
				double r2 = r * Math.PI / 180;
				float x2 = (float)(x * Math.Cos(r2) - y * Math.Sin(r2));
				float y2 = (float)(x * Math.Sin(r2) + y * Math.Cos(r2));
				ret[i] = new PointF(x2, y2);
			}
			return ret;
		}
		private PointF[] MirrorH(PointF[] pt)
		{
			if (pt.Length <= 0) return pt;

			for (int i = 0; i < pt.Length; i++)
			{
				pt[i].Y *= -1; 
			}
			return pt;
		}
		public bool ExportSVG(string p)
		{
			bool ret = false;
			float w = Wing.CSize.Width/2;
			float h = Wing.CSize.Height/2;

			EasySVG svg = new EasySVG(-w,-h,w*2,h*2);
			svg.Unit = EasySVG.UnitType.Mm;
			float sX = 0;
			float sY =  -m_Wing.CenterGP;

			PointF[] cg = new PointF[] {
				new PointF(sX-10,sY+m_Wing.CenterGP),
				new PointF(sX,sY+m_Wing.CenterGP),
			};
			cg = Rotate(cg,-90);
			svg.DrawLine("cg",cg,Color.FromArgb(255,128,128));
			PointF[] cg_ex = new PointF[] {
				new PointF(sX-5,sY+m_Wing.CenterGReal),
				new PointF(sX,sY+m_Wing.CenterGReal),
			};
			cg_ex = Rotate(cg_ex, -90);
			svg.DrawLine("cg-ex", cg_ex, Color.FromArgb(255, 200, 200));
			PointF[] LineBody = new PointF[] {
				new PointF(sX,sY),
				new PointF(sX,sY + Wing.FuselageLength),
			};
			LineBody = Rotate(LineBody, -90);
			svg.DrawLine("body", LineBody, Color.FromArgb(0, 0, 0));

			PointF dp = new PointF(sX, sY);
			PointF[] lineM = Wing.MainMMLines(dp);
			PointF[] lineHT = Wing.HTailMMLines(dp);
			PointF[] lineVT = Wing.VTailMMLines(dp);

			lineM = Rotate(lineM, -90);
			svg.DrawPolyline("Main", lineM, Color.FromArgb(0, 0, 0));

			if (TailMode == TailMode.Twin)
			{
				PointF[] TT1 = new PointF[]
				{
					lineHT[1],
					lineHT[2]
				};
				TT1 = Rotate(TT1, -90);
				svg.DrawLine("Tail-ori", TT1, Color.FromArgb(160, 160, 160));

				PointF[] TT = new PointF[]
				{
					lineHT[0],
					lineHT[1],
					lineVT[1],
					lineVT[2],
					lineHT[2],
					lineHT[3],
				};
				TT = Rotate(TT, -90);
				svg.DrawPolyline("tail", TT, Color.FromArgb(0, 0, 0));
			}
			else
			{
				lineHT = Rotate(lineHT, -90);
				svg.DrawPolyline("HTail", lineHT, Color.FromArgb(0, 0, 0));
				lineVT = Rotate(lineVT, -90);
				svg.DrawPolyline("VTail", lineVT, Color.FromArgb(0, 0, 0));

			}

			try
			{
				StreamWriter sw = new StreamWriter(p);
				sw.Write(svg.SVGString());
				sw.Close();
				ret = true;
			}catch{
				ret = false;
			}
			return ret;
		}
		public bool ExportSVG()
		{
			bool ret = false;
			using (SaveFileDialog dlg = new SaveFileDialog())
			{
				dlg.DefaultExt = ".svg";
				dlg.Filter = "*.svg|*.svg|*.*|*.*";
				if (m_filename != "")
				{
					dlg.InitialDirectory = Path.GetDirectoryName(m_filename);
					string pp = Path.GetFileName(m_filename);
					pp = Path.ChangeExtension(pp, ".svg");
					dlg.FileName = pp;
				}

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ret = ExportSVG(dlg.FileName);
					if(ret)
						m_filename = dlg.FileName;

				}
			}

			return ret;
		}

		public bool ExportDXF(string p)
		{
			bool ret = false;

			SizeF sz = m_Wing.CSize;

			DxfDocument dxf = new DxfDocument();
			float sX = 0;
			float sY = -m_Wing.CenterGP;
			Vector2[] Edge1 = new Vector2[]
			{
				new Vector2(-sz.Width/2,-sz.Height/2+10),
				new Vector2(-sz.Width/2,-sz.Height/2),
				new Vector2(-sz.Width/2+10,-sz.Height/2)
			};
			Polyline2D e1 = new Polyline2D(Edge1);
			dxf.Entities.Add(e1);
			
			Vector2[] Edge2 = new Vector2[]
			{
				new Vector2(sz.Width/2,sz.Height/2-10),
				new Vector2(sz.Width/2,sz.Height/2),
				new Vector2(sz.Width/2-10,sz.Height/2)
			};
			Polyline2D e2 = new Polyline2D(Edge2);
			dxf.Entities.Add(e2);

			PointF[] cg1_ = new PointF[] {
				new PointF(sX-10,sY+m_Wing.CenterGP),
				new PointF(sX,sY+m_Wing.CenterGP),
			};
			cg1_ = MirrorH(Rotate(cg1_, -90));

			Line cg1 = new Line (
				new Vector2(cg1_[0].X, cg1_[0].Y),
				new Vector2(cg1_[1].X, cg1_[1].Y)
			);
			dxf.Entities.Add(cg1);

			PointF[] cg2_ = new PointF[] {
				new PointF(sX-5,sY+m_Wing.CenterGReal),
				new PointF(sX,sY+m_Wing.CenterGReal)
			};
			cg2_ = MirrorH(Rotate(cg2_, -90));

			Line cg2 = new Line (
				new Vector2(cg2_[0].X, cg2_[0].Y),
				new Vector2(cg2_[1].X, cg2_[1].Y)
			);
			dxf.Entities.Add(cg2);


			PointF[] LineBody_ = new PointF[] {
				new PointF(sX, sY),
				new PointF(sX, sY + Wing.FuselageLength),
			};
			LineBody_ = MirrorH(Rotate(LineBody_, -90));

			Line LineBody = new Line(
				new Vector2(LineBody_[0].X, LineBody_[0].Y),
				new Vector2(LineBody_[1].X, LineBody_[1].Y)
			);
			dxf.Entities.Add(LineBody);


			PointF dp = new PointF(sX, sY);
			PointF[] m = Wing.MainMMLines(dp);
			m = MirrorH(Rotate(m, -90));

			Vector2[] lineM = new Vector2[]
			{
				new Vector2(m[0].X,m[0].Y),
				new Vector2(m[1].X,m[1].Y),
				new Vector2(m[2].X,m[2].Y),
				new Vector2(m[3].X,m[3].Y)
			};
			PointF[]  HT = Wing.HTailMMLines(dp);
			HT = MirrorH(Rotate(HT, -90));
			Vector2[] lineHT = new Vector2[]
			{
				new Vector2(HT[0].X,HT[0].Y),
				new Vector2(HT[1].X,HT[1].Y),
				new Vector2(HT[2].X,HT[2].Y),
				new Vector2(HT[3].X,HT[3].Y)
			};
			PointF[] VT = Wing.VTailMMLines(dp);
			VT = MirrorH(Rotate(VT, -90));
			Vector2[] lineVT = new Vector2[]
			{
				new Vector2(VT[0].X,VT[0].Y),
				new Vector2(VT[1].X,VT[1].Y),
				new Vector2(VT[2].X,VT[2].Y),
				new Vector2(VT[3].X,VT[3].Y)
			};

			Polyline2D Ml = new Polyline2D(lineM);
			dxf.Entities.Add(Ml);

			if (TailMode == TailMode.Twin)
			{
				Line TT1 = new Line(
				lineHT[1],
				lineHT[2]
				);
				dxf.Entities.Add(TT1);

				Vector2[] TT = new Vector2[] {
					lineHT[0],
					lineHT[1],
					lineVT[1],
					lineVT[2],
					lineHT[2],
					lineHT[3]
				};
				Polyline2D TTL = new Polyline2D(TT);
				dxf.Entities.Add(TTL);
			}
			else
			{
				Polyline2D HTa = new Polyline2D(lineHT);
				Polyline2D VTa = new Polyline2D(lineVT);
				dxf.Entities.Add(HTa);
				dxf.Entities.Add(VTa);

			}
			try
			{
				ret = dxf.Save(p);
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		public bool ExportDXF()
		{
			bool ret = false;
			using (SaveFileDialog dlg = new SaveFileDialog())
			{
				dlg.DefaultExt = ".dxf";
				dlg.Filter = "*.dxf|*.dxf|*.*|*.*";
				if (m_filename != "")
				{
					dlg.InitialDirectory = Path.GetDirectoryName(m_filename);
					string pp = Path.GetFileName(m_filename);
					pp = Path.ChangeExtension(pp, ".dxf");
					dlg.FileName = pp;
				}

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ret = ExportDXF(dlg.FileName);
					if(ret)
						m_filename = dlg.FileName;
				}
			}

			return ret;
		}

		public void ShowDpiDialog()
		{
			using(DpiForm dlg = new DpiForm())
			{
				dlg.DPI = Dpi;

				if (dlg.ShowDialog()==DialogResult.OK)
				{
					Dpi = dlg.DPI;
				}
			}
		}

		#region Porp
		[Browsable(false)]
		public new System.String AccessibleDefaultActionDescription
		{
			get { return base.AccessibleDefaultActionDescription; }
			set { base.AccessibleDefaultActionDescription = value; }
		}
		// **************************************************************
		// **************************************************************
		// **************************************************************
		// **************************************************************
		// **************************************************************
		[Browsable(false)]
		public new System.String AccessibleDescription
		{
			get { return base.AccessibleDescription; }
			set { base.AccessibleDescription = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.String AccessibleName
		{
			get { return base.AccessibleName; }
			set { base.AccessibleName = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.AccessibleRole AccessibleRole
		{
			get { return base.AccessibleRole; }
			set { base.AccessibleRole = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean AllowDrop
		{
			get { return base.AllowDrop; }
			set { base.AllowDrop = value; }
		}
		// **************************************************************
		[Browsable(true)]
		public new System.Windows.Forms.AnchorStyles Anchor
		{
			get { return base.Anchor; }
			set { base.Anchor = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean AutoSize
		{
			get { return base.AutoSize; }
			set { base.AutoSize = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Point AutoScrollOffset
		{
			get { return base.AutoScrollOffset; }
			set { base.AutoScrollOffset = value; }
		}
		// **************************************************************
		[Category("PaperPlane")]
		public new System.Drawing.Color BackColor
		{
			get { return base.BackColor; }
			set { base.BackColor = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Image BackgroundImage
		{
			get { return base.BackgroundImage; }
			set { base.BackgroundImage = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.ImageLayout BackgroundImageLayout
		{
			get { return base.BackgroundImageLayout; }
			set { base.BackgroundImageLayout = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.BindingContext BindingContext
		{
			get { return base.BindingContext; }
			set { base.BindingContext = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Rectangle Bounds
		{
			get { return base.Bounds; }
			set { base.Bounds = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean Capture
		{
			get { return base.Capture; }
			set { base.Capture = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean CausesValidation
		{
			get { return base.CausesValidation; }
			set { base.CausesValidation = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Size ClientSize
		{
			get { return base.ClientSize; }
			set { base.ClientSize = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.ContextMenu ContextMenu
		{
			get { return base.ContextMenu; }
			set { base.ContextMenu = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.ContextMenuStrip ContextMenuStrip
		{
			get { return base.ContextMenuStrip; }
			set { base.ContextMenuStrip = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.Cursor Cursor
		{
			get { return base.Cursor; }
			set { base.Cursor = value; }
		}
		// **************************************************************
		[Browsable(true)]
		public new System.Windows.Forms.DockStyle Dock
		{
			get { return base.Dock; }
			set { base.Dock = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean Enabled
		{
			get { return base.Enabled; }
			set { base.Enabled = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Font Font
		{
			get { return base.Font; }
			set { base.Font = value; }
		}
		// **************************************************************
		[Category("PaperPlane")]
		public new System.Drawing.Color ForeColor
		{
			get { return base.ForeColor; }
			set { base.ForeColor = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Int32 Height
		{
			get { return base.Height; }
			set 
			{ 
				base.Height = value;
			}
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean IsAccessible
		{
			get { return base.IsAccessible; }
			set { base.IsAccessible = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Int32 Left
		{
			get { return base.Left; }
			set { base.Left = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Point Location
		{
			get { return base.Location; }
			set { base.Location = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.Padding Margin
		{
			get { return base.Margin; }
			set { base.Margin = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Size MaximumSize
		{
			get { return base.MaximumSize; }
			set { base.MaximumSize = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Size MinimumSize
		{
			get { return base.MinimumSize; }
			set { base.MinimumSize = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.String Name
		{
			get { return base.Name; }
			set { base.Name = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.Control Parent
		{
			get { return base.Parent; }
			set { base.Parent = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Region Region
		{
			get { return base.Region; }
			set { base.Region = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.RightToLeft RightToLeft
		{
			get { return base.RightToLeft; }
			set { base.RightToLeft = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.ComponentModel.ISite Site
		{
			get { return base.Site; }
			set { base.Site = value; }
		}
		// **************************************************************
		[Browsable(true)]
		public new System.Drawing.Size Size
		{
			get { return base.Size; }
			set 
			{
				base.Size = value;
			}
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Int32 TabIndex
		{
			get { return base.TabIndex; }
			set { base.TabIndex = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean TabStop
		{
			get { return base.TabStop; }
			set { base.TabStop = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Object Tag
		{
			get { return base.Tag; }
			set { base.Tag = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.String Text
		{
			get { return base.Text; }
			set { base.Text = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Int32 Top
		{
			get { return base.Top; }
			set { base.Top = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean UseWaitCursor
		{
			get { return base.UseWaitCursor; }
			set { base.UseWaitCursor = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean Visible
		{
			get { return base.Visible; }
			set { base.Visible = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Int32 Width
		{
			get { return base.Width; }
			set 
			{
				base.Width = value;
			}
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.IWindowTarget WindowTarget
		{
			get { return base.WindowTarget; }
			set { base.WindowTarget = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.Padding Padding
		{
			get { return base.Padding; }
			set { base.Padding = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.ImeMode ImeMode
		{
			get { return base.ImeMode; }
			set { base.ImeMode = value; }
		}
		#endregion
	}
}
