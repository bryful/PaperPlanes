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
		public static string GetProps(Type ct)
		{
			// DateTimeのプロパティ一覧を取得する
			PropertyInfo[] p = ct.GetProperties();

			// 取得した一覧をコンソールに出力する
			string s = "";
			foreach (var a in p)
			{
				if (a.CanWrite == true)
				{
					s += "// **************************************************************\r\n";
					s += $"[Browsable(false)]\r\n";
					s += $"public new {a.PropertyType.ToString()} {a.Name}\r\n";
					s += $"{{\r\n";
					s += $"	get {{ return base.{a.Name}; }}\r\n";
					s += $"	set {{ base.{a.Name} = value; }}\r\n";
					s += "}\r\n";
				}
			}
			return s;
		}
		private float m_Dpi = 83.0f;
		[Category("PaperPlane")]
		public float Dpi
		{
			get { return m_Dpi; }
			set 
			{
				m_Dpi = value;
				m_Main.Dpi = value;
				m_Tail.Dpi = value;	
				this.Invalidate(); 
			}
		}

		[Category ("PaperPlane")]
		public SizeF SizeMM
		{
			get 
			{
				return new SizeF(
					PPoint.Px2Mm(Width,m_Dpi), 
					PPoint.Px2Mm(Height, m_Dpi)); 
			}
			set
			{
				SetSizeMM(value);
			}
		}
		public void SetWidthMM(float w)
		{
			base.Width = (int)(PPoint.Mm2Px(w,m_Dpi));
			this.Invalidate();
		}
		public void SetHeightMM(float h)
		{
			base.Height = (int)(PPoint.Mm2Px(h, m_Dpi) + 0.5);
			this.Invalidate();
		}
		public void SetSizeMM(SizeF sz)
		{
			base.Size = new Size(
				(int)(PPoint.Mm2Px(sz.Width, m_Dpi)),
				(int)(PPoint.Mm2Px(sz.Height, m_Dpi))
				);
			this.Invalidate();
		}

		private Color m_GridColor = Color.FromArgb(255,180,180,180);
		[Category("PaperPlane")]
		public Color GridColor
		{
			get { return this.m_GridColor; }
			set
			{
				m_GridColor = value;
				this.Invalidate();
			}
		}
		private PointF m_DispP = new Point(0, 0);
		private PointF m_DispPF = new PointF(10.0f, 10.0f);
		[Category("PaperPlane")]
		public PointF DispPF
		{
			get { return m_DispPF; }
			set 
			{ 
				m_DispPF = value; ;
				if (m_DispPF.X < 0) m_DispPF.X = 0;
				if (m_DispPF.Y < 0) m_DispPF.Y = 0;

				m_DispP.X = PPoint.Mm2Px(m_DispPF.X, m_Dpi);
				m_DispP.Y = PPoint.Mm2Px(m_DispPF.Y, m_Dpi);
			}
		}

		private PointF m_GridSize = new PointF(10.0f,10.0f);
		[Category("PaperPlane")]
		public PointF GridSize
		{
			get { return this.m_GridSize; }
			set
			{
				m_GridSize = value;
				this.Invalidate();
			}
		}
		private PMain m_Main = new PMain();
		[Category("PaperPlane")]
		public PMain Main
		{
			get { return m_Main; }
			set{ m_Main = value;}
		}
		private PTail m_Tail = new PTail();
		[Category("PaperPlane")]
		public PTail Tail
		{
			get { return m_Tail; }
			set { m_Tail = value; }
		}
		[Category("PaperPlane")]
		public TailMode TailMode
		{
			get { return m_Tail.TailMode; }
			set
			{
				m_Tail.TailMode = value;
				this.Invalidate();
			}
		}
		// ********************************************************************
		public PCanvas() 
		{
			base.DoubleBuffered = true;
			base.BackColor = Color.White;
			Dpi = 83.0f;
			DispPF = new PointF(10, 10);
		}
		// ********************************************************************
		private void DrawMain(Graphics g,Pen p)
		{

			PointF[] pnts = m_Main.Lines(m_GridSize);
			g.DrawLines(p, pnts);

			pnts = m_Tail.HorLines(m_GridSize);
			g.DrawLines(p, pnts);
			switch(m_Tail.TailMode)
			{
				case TailMode.Normal:
					pnts = m_Tail.VurLines(m_GridSize);
					break;
				case TailMode.Twin:
					pnts = m_Tail.VurLines(m_GridSize);
					break;
			}
			g.DrawLines(p, pnts);
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
				float hh = PPoint.Mm2Px(this.Height, m_Dpi);
				while(h<hh)
				{
					float h2 = PPoint.Mm2Px(h, m_Dpi);
					g.DrawLine(p, 0, h2, this.Width, h2);
					h += m_GridSize.Y;
				}
				// Vur
				float w = 0.0f;
				float ww = PPoint.Mm2Px(this.Width, m_Dpi);
				while (w < ww)
				{
					float w2 = PPoint.Mm2Px(w, m_Dpi);
					g.DrawLine(p, w2, 0, w2, this.Height);
					w += m_GridSize.X;
				}
				p.Color = ForeColor;
				p.Width = 2;
				DrawMain(g, p);

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
			int idx = -1;

			float x = e.X - m_DispP.X;
			float y = e.Y - m_DispP.Y;

			idx = m_Main.IsIn(x, y);
			if (idx<0) idx = m_Tail.IsIn(x, y);
			Debug.WriteLine($"idx:{idx}");
			if(idx>=0)
			{
				m_IsMd=true;
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

		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if(m_IsMd)
			{

			}
			base.OnMouseMove(e);
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
		[Category ("PapePlane_Main")]
		public float MainPosition
		{
			get { return m_Main.Position; }
			set 
			{
				m_Main.Position = value;
				this.Invalidate ();
			}
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
