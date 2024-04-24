using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PP
{
	public class PMainEdit : Control
	{
		private PCanvas m_PCanvas = null;
		[Category("paperPlane")]
		public PCanvas PCanvas
		{
			get { return m_PCanvas; }
			set 
			{
				m_PCanvas = value;
				if (m_PCanvas != null)
				{
					m_PCanvas.MainChanged += (sender, e) => { GetParams(); };
					GetParams();
				}
			}
		}

		private PEdit[] m_edits = new PEdit[5];
		[Category("paperPlane")]
		public PEdit[] Edits
		{
			get { return m_edits; }
		}
		private Label m_label = new Label();
		[Category("paperPlane")]
		public new string Text
		{
			get { return m_label.Text; }
			set 
			{
				base.Text = value;
				m_label.Text = value;
			}
		}
		[Category("paperPlane")]
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
		// **************************************************
		public PMainEdit()
		{
			this.Text = base.Text;
			m_label.AutoSize = false;
			m_label.TextAlign= ContentAlignment.MiddleRight;
			m_label.Location = new Point(0, 0);
			this.Controls.Add(m_label);
			for (int i = 0;i<m_edits.Length;i++)
			{
				m_edits[i] =new PEdit();
				m_edits[i].Tag = (int)i;
				m_edits[i].Location = new Point(0,24*(i+1));
				m_edits[i].Size = new Size(this.Width, 24);
				m_edits[i].ValueChanged += (sender, e) =>
				{
					if (refFlag == true) return;
					if ((m_PCanvas != null) && (m_PCanvas.Wing != null))
					{
						if (sender is PEdit)
						{
							refFlag = true;
							switch ((int)((PEdit)sender).Tag)
							{
								case 0:
									m_PCanvas.Wing.MainPos = e.Value;
									break;
								case 1:
									m_PCanvas.Wing.MainSpan = e.Value;
									break;
								case 2:
									m_PCanvas.Wing.MainRoot = e.Value;
									break;
								case 3:
									m_PCanvas.Wing.MainTip = e.Value;
									break;
								case 4:
									m_PCanvas.Wing.MainSwept = e.Value;
									break;

							}
							m_PCanvas.Invalidate();
							refFlag = false;
						}
					}
				};
				this.Controls.Add(m_edits[i]);
			}
			m_label.Size = new Size(m_edits[0].CaptionWidth, 24);

			m_edits[0].Text = "Pos";
			m_edits[1].Text = "Span";
			m_edits[2].Text = "Root";
			m_edits[3].Text = "Tip";
			m_edits[4].Text = "Swept";
			m_edits[4].Minimum = -60;
			m_edits[4].Maximum = 60;
		}
		protected override void OnResize(EventArgs e)
		{
			m_label.Width=m_edits[0].CaptionWidth;
			for (int i = 0; i < m_edits.Length; i++)
			{
				m_edits[(int)i].Width = this.Width;
			}
				base.OnResize(e);
		}
		private bool refFlag = false;
		private void GetParams()
		{
			if (m_PCanvas == null) return;
			PWing pMain = m_PCanvas.Wing;
			if (pMain == null) return;
			if (refFlag) return;
			refFlag = true;

			m_edits[0].Value = pMain.MainPos;
			m_edits[1].Value = pMain.MainSpan;
			m_edits[2].Value = pMain.MainRoot;
			m_edits[3].Value = pMain.MainTip;
			m_edits[4].Value = pMain.MainSwept;
			refFlag = false;
		}
		// ******************************************************************
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
		[Browsable(false)]
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
}
