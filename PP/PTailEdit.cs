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
	public class PTailEdit :Control
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
					GetParams();
					SetTailMode(m_PCanvas.TailMode);
					m_PCanvas.Wing.TailChanged += (sender, e) => { GetParams(); };
				}
			}
		}
		private PEdit[] m_edits = new PEdit[10];
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

		public TailMode TailMode
		{
			get
			{
				if (m_PCanvas != null)
				{
					return m_PCanvas.TailMode;
				}
				else
				{
					return TailMode.Normal;
				}
			}
			set
			{
				if (m_PCanvas != null)
				{
					m_PCanvas.TailMode = value;
				}
				SetTailMode(value);
			}
		}
		private ComboBox m_cmbMode = new ComboBox();
		// **************************************************
		public PTailEdit()
		{
			this.Text = base.Text;
			m_label.AutoSize = false;
			m_label.TextAlign = ContentAlignment.MiddleRight;
			m_label.Location = new Point(0, 0);
			this.Controls.Add(m_label);
			m_cmbMode.Items.AddRange(new string[] { "Normal","Twin" });
			m_cmbMode.DropDownStyle = ComboBoxStyle.DropDownList;
			m_cmbMode.SelectedIndex = 0;
			m_cmbMode.SelectedIndexChanged += (sender, e) =>
			{
				if (m_cmbMode.SelectedIndex < 0) return;
				TailMode tm = (TailMode)m_cmbMode.SelectedIndex;
				SetTailMode(tm);
			};
			this.Controls.Add(m_cmbMode);

			for (int i = 0; i < m_edits.Length; i++)
			{
				m_edits[i] = new PEdit();
				m_edits[i].Tag = (int)i;
				m_edits[i].Location = new Point(0, 24 * (i + 1));
				m_edits[i].Size = new Size(this.Width, 24);
				m_edits[i].ValueChanged += (sender, e) =>
				{
					if (refFlag == true) return;
					if (m_PCanvas != null)
					{
						if (sender is PEdit)
						{
							refFlag = true;
							switch ((int)((PEdit)sender).Tag)
							{
								case 0:
									m_PCanvas.Wing.HTailPos = e.Value;
									break;
								case 1:
									m_PCanvas.Wing.HTailSpan = e.Value;
									break;
								case 2:
									m_PCanvas.Wing.HTailRoot= e.Value;
									break;
								case 3:
									m_PCanvas.Wing.HTailTip = e.Value;
									break;
								case 4:
									m_PCanvas.Wing.HTailSwept = e.Value;
									break;
								case 5:
									m_PCanvas.Wing.VTailPos = e.Value;
									break;
								case 6:
									m_PCanvas.Wing.VTailSpan = e.Value;
									break;
								case 7:
									m_PCanvas.Wing.VTailRoot = e.Value;
									break;
								case 8:
									m_PCanvas.Wing.VTailTip = e.Value;
									break;
								case 9:
									m_PCanvas.Wing.VTailSwept = e.Value;
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
			m_cmbMode.Location = new Point(m_edits[0].CaptionWidth, 0);
			m_cmbMode.Width = this.Width - m_edits[0].CaptionWidth;

			m_edits[0].Text = "H_Pos";
			m_edits[1].Text = "H_Span";
			m_edits[2].Text = "H_Root";
			m_edits[3].Text = "H_Tip";
			m_edits[4].Text = "H_Swept";
			m_edits[4].Minimum = -60;
			m_edits[4].Maximum = 60;

			m_edits[5].Text = "V_Pos";
			m_edits[6].Text = "V_Span";
			m_edits[7].Text = "V_Root";
			m_edits[8].Text = "V_Tip";
			m_edits[9].Text = "V_Swept";
			m_edits[9].Minimum = -60;
			m_edits[9].Maximum = 60;

		}
		protected override void OnResize(EventArgs e)
		{
			m_label.Width = m_edits[0].CaptionWidth;
			m_cmbMode.Location = new Point(m_edits[0].CaptionWidth,0);
			m_cmbMode.Width = this.Width - m_cmbMode.Left;
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
			if (refFlag) return;
			refFlag = true;
			PWing pw = m_PCanvas.Wing;
			SetTailMode(pw.TailMode);
			m_edits[0].Value = pw.HTailPos;
			m_edits[1].Value = pw.HTailSpan;
			m_edits[2].Value = pw.HTailRoot;
			m_edits[3].Value = pw.HTailTip;
			m_edits[4].Value = pw.HTailSwept;
			m_edits[5].Value = pw.VTailPos;
			m_edits[6].Value = pw.VTailSpan;
			m_edits[7].Value = pw.VTailRoot;
			m_edits[8].Value = pw.VTailTip;
			m_edits[9].Value = pw.VTailSwept;
			refFlag = false;
		}
		// **************************************************************
		public void SetTailMode(TailMode tm)
		{
			/*
			switch (tm)
			{
				case TailMode.Normal:
					for(int i = 0; i < m_edits.Length;i++)
					{
						m_edits[i].Top = m_edits[0].Top + i * 24;
						m_edits[i].Visible = true;
					}
					break;
				case TailMode.Twin:
					m_edits[5].Visible = false;
					m_edits[7].Visible = false;
					int y = m_edits[0].Top;
					for (int i = 0; i < m_edits.Length; i++)
					{
						if (m_edits[i].Visible)
						{
							m_edits[i].Top = y;
							y += 24;
						}
					}
					break;
			}
			*/
			int idx = (int)tm;
			if (m_cmbMode.SelectedIndex!=idx)
				m_cmbMode.SelectedIndex = idx;
			if(m_PCanvas!=null)
			{
				if (m_PCanvas.TailMode!=tm)
				{
					m_PCanvas.TailMode = tm;
				}
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
		// **************************************************************
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
		// **************************************************************
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
