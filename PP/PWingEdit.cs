using System;
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
	public class PWingEdit : Control
	{
		public delegate void ValueChangedEventHandler(object sender, EventArgs e);

		//イベントデリゲートの宣言
		public event ValueChangedEventHandler ValueChanged;

		protected virtual void OnValueChanged(EventArgs e)
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, e);
			}
		}

		[Category("PaperPlane")]
		public bool TwinMode
		{
			get { return (m_edits[0].Enabled == false); }
			set
			{
				m_edits[0].Enabled = !value;
				m_edits[2].Enabled = !value;
				m_edits[0].SliderVisible = !value;
				m_edits[2].SliderVisible = !value;
			}
		}
	
		private PEdit[] m_edits = new PEdit[5];
		[Category("PaperPlane")]
		public PEdit[] Edits
		{
			get { return m_edits; }
		}
		[Category("PaperPlane")]
		public string[] Captions
		{
			get
			{
				string[] result = new string[m_edits.Length];
				for(int i=0; i<result.Length; i++)
				{
					result[i] = m_edits[i].Text;
				}
				return result;
			}
			set
			{
				if (value.Length<=0) return;
				for (int i = 0; i < value.Length; i++)
				{
					m_edits[i].Text = value[i];
				}
			}
		}
		[Category("PaperPlane")]
		public int CaptionWidth
		{
			get
			{
				if (m_edits[0] != null)
				{
					return m_edits[0].CaptionWidth;
				}
				else
				{
					return 70;
				}
			}
			set
			{
				if (value <= 0) return;
				for (int i = 0; i <m_edits.Length; i++)
				{
					m_edits[i].CaptionWidth =value;
				}
			}
		}
		[Category("PaperPlane")]
		public int EditWidth
		{
			get
			{
				return m_edits[0].EditWidth;
			}
			set
			{
				if (value <= 0) return;
				for (int i = 0; i < m_edits.Length; i++)
				{
					m_edits[i].EditWidth = value;
				}
			}
		}
		public new Font Font
		{
			get { return base.Font; }
			set 
			{
				base.Font = value;
				for(int i=0;i<m_edits.Length;i++)
				{
					if (m_edits[i] != null)
					{
						m_edits[i].Font = value;
					}
				}
				ChkSize(true);
			}
		}
		private int m_EditHeight = 20;
		[Category("PaperPlane")]
		public int EditHeight
		{
			get { return m_EditHeight; }
			set
			{
				m_EditHeight=value;
				for(int i=0; i<m_edits.Length;i++)
				{
					m_edits[i].Height = value;
				}
				ChkSize(true);
			}
		}
		// **************************************************
		public PWingEdit()
		{
			base.DoubleBuffered = true;
			SuspendLayout();

			for (int i = 0;i<m_edits.Length;i++)
			{
				m_edits[i] =new PEdit();
				m_edits[i].Tag = (int)i;
				m_edits[i].MatchMode = false;
				m_edits[i].EditWidth = 80;
				m_edits[i].Location = new Point(0,24*(i+1));
				m_edits[i].Size = new Size(this.Width, 22);
				
				m_edits[i].ValueFChanged += (sender, e) =>
				{
					if (refFlag == true) return;
					OnValueChanged(new EventArgs());
				};
				this.Controls.Add(m_edits[i]);
			}

			m_edits[0].Text = "Pos";
			m_edits[0].SetMinMax(0, 200);
			m_edits[0].IsArrowHor = false;
			m_edits[1].Text = "Span";
			m_edits[1].SetMinMax(5, 150);
			m_edits[2].Text = "Root";
			m_edits[2].SetMinMax(5, 150);
			m_edits[2].IsArrowHor = false;
			m_edits[3].Text = "Tip";
			m_edits[3].SetMinMax(5, 150);
			m_edits[3].IsArrowHor = false;
			m_edits[4].Text = "Swept";
			m_edits[4].IsArrowHor = false;
			m_edits[4].SetMinMax(-60, 60);
			ChkSize(false);
			ResumeLayout();
		}
		private void ChkSize(bool r)
		{
			if (r) this.SuspendLayout();

			for (int i = 0; i < m_edits.Length; i++)
			{
				m_edits[(int)i].Location = new Point(0,(m_EditHeight+2)*i);
				m_edits[(int)i].Size = new Size(this.Width, m_EditHeight);
			}
			if(r) this.ResumeLayout();
		}
		protected override void OnResize(EventArgs e)
		{
			ChkSize(true);
			base.OnResize(e);
		}
		private bool refFlag = false;
		// ******************************************************************
		public float[] Params
		{
			get
			{
				float[] ret = new float[]
				{
					m_edits[0].Value,
					m_edits[1].Value,
					m_edits[2].Value,
					m_edits[3].Value,
					m_edits[4].Value
				};
				return ret;
			}
			set
			{
				if(value.Length<5) return;
				if (refFlag) return;
				refFlag = true;
				bool b = false;
				if (m_edits[0].Value != value[0]) { m_edits[0].Value = value[0]; b = true; }
				if (m_edits[1].Value != value[1]) { m_edits[1].Value = value[1]; b = true; }
				if (m_edits[2].Value != value[2]) { m_edits[2].Value = value[2]; b = true; }
				if (m_edits[3].Value != value[3]) { m_edits[3].Value = value[3]; b = true; }
				if (m_edits[4].Value != value[4]) { m_edits[4].Value = value[4]; b = true; }
				if(b) OnValueChanged(new EventArgs());
				refFlag = false;
			}
		}
		// **************************************************************
		// **************************************************************
		[Browsable(false)]
		public new System.String AccessibleDefaultActionDescription
		{
			get { return base.AccessibleDefaultActionDescription; }
			set { base.AccessibleDefaultActionDescription = value; }
		}
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
		public new System.Int32 Height
		{
			get { return base.Height; }
			set { base.Height = value; }
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
			set { base.Width = value; }
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

	}
	public enum EditMode
	{
		Main,
		HTail,
		VTail
	}
}
