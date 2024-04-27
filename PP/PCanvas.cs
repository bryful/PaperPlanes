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

namespace PP
{
	public class PCanvas : Control
	{
		private float m_Dpi = 83.0f;
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
				this.Invalidate(); 
			}
		}

		[Category ("PaperPlane")]
		public SizeF CanvasSize
		{
			get 
			{
				return new SizeF(
					P.Px2Mm(Width,m_Dpi), 
					P.Px2Mm(Height, m_Dpi)); 
			}
			set
			{
				SetCanvasSize(value);
			}
		}
		public void SetWidthMM(float w)
		{
			base.Width = (int)(P.Mm2Px(w,m_Dpi));
			this.Invalidate();
		}
		public void SetHeightMM(float h)
		{
			base.Height = (int)(P.Mm2Px(h, m_Dpi) + 0.5);
			this.Invalidate();
		}
		public void SetCanvasSize(SizeF sz)
		{
			base.Size = new Size(
				(int)(P.Mm2Px(sz.Width, m_Dpi)),
				(int)(P.Mm2Px(sz.Height, m_Dpi))
				);
			this.Invalidate();
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
		private PointF m_DispP = new Point(0, 0);
		private PointF m_DispF = new PointF(10.0f, 10.0f);
		/// <summary>
		/// 表示基点
		/// </summary>
		[Category("PaperPlane")]
		public PointF DispF
		{
			get { return m_DispF; }
			set 
			{ 
				m_DispF = value; ;
				if (m_DispF.X < 0) m_DispF.X = 0;
				if (m_DispF.Y < 0) m_DispF.Y = 0;

				m_DispP.X = P.Mm2Px(m_DispF.X, m_Dpi);
				m_DispP.Y = P.Mm2Px(m_DispF.Y, m_Dpi);
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
				m_Wing.TailMode = value;
				this.Invalidate();
			}
		}
		// ********************************************************************
		public PCanvas() 
		{
			base.DoubleBuffered = true;
			base.BackColor = Color.White;
			Dpi = 83.0f;
			DispF = new PointF(10, 10);
			m_Wing.SyncTwin();
			m_Wing.MainWing.WingChanged += (sender, e) => { this.Invalidate(); };
			m_Wing.HTail.WingChanged += (sender, e) => { this.Invalidate(); };
			m_Wing.VTail.WingChanged += (sender, e) => { this.Invalidate(); };
		}
		// ********************************************************************
		private void DrawWingSub(Graphics g, Pen p, SolidBrush sb,
				PointF[] m, PointF[] mac,int idx
			)
		{
			p.Color = m_LineColor2;
			g.DrawLines(p, mac);
			
			float y = (float)(mac[0].Y + (mac[1].Y - mac[0].Y) * 0.25);
			float x0 = m_DispP.X;
			float x1 = (float)(mac[0].X);
			g.DrawLine(p, x0, y, x1, y);

			p.Color = m_LineColor;
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
			p.Width = 2;
			// baseLine
			p.Color = m_BaseColor;
			g.DrawLine(p, m_DispP, new PointF(m_DispP.X, this.Height));

			//Main
			PointF[] lines = m_Wing.MainLines(m_DispF);
			PointF[] mac = m_Wing.MainMACLines(m_DispF);
			DrawWingSub(g,p,sb, lines, mac, m_Wing.SelectedIndex);
			lines = m_Wing.HTailLines(m_DispF);
			mac = m_Wing.HTailMACLines(m_DispF);
			DrawWingSub(g, p, sb, lines, mac, m_Wing.SelectedIndex - 4);
			lines = m_Wing.VTailLines(m_DispF);
			mac = m_Wing.VTailMACLines(m_DispF);
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
		private Point m_md = new Point(0,0);
		// **************************************************************
		protected override void OnMouseDown(MouseEventArgs e)
		{
			float x = e.X - m_DispP.X;
			float y = e.Y - m_DispP.Y;

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
			m_md = new Point(0, 0);
			base.OnMouseUp(e);
		}
		// **************************************************************
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
