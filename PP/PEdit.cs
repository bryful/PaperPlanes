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
	public class PEdit :Control
	{
		//デリゲートの宣言
		//TimeEventArgs型のオブジェクトを返すようにする
		public delegate void ValueFChangedEventHandler(object sender, ValueFChangedEventArgs e);

		//イベントデリゲートの宣言
		public event ValueFChangedEventHandler ValueFChanged;

		protected virtual void OnValueFChanged(ValueFChangedEventArgs e)
		{
			if (ValueFChanged != null)
			{
				ValueFChanged(this, e);
			}
		}
		//private Label Label = new Label();
		//private NumericUpDown Edit = new NumericUpDown();
		private PNumEdit Edit = new PNumEdit();
		private PTrackBar TrackBar = new PTrackBar();
		[Category("paperPlane")]
		public bool IsArrowHor
		{
			get { return Edit.IsArrowHor; }
			set
			{
				Edit.IsArrowHor = value;
			}
		}
		[Category ("paperPlane")]
		public new string Text
		{
			get { return Edit.Text; }
			set 
			{
				Edit.Text = value;
				base.Text = value;
			}
		}
		[Category("PaperPlane")]
		public float Value
		{
			get { return Edit.Value; }
			set 
			{
				float v = value;
				if ( (v>=Edit.Minimum)&&(v<=Edit.Maximum))
				{
					Edit.Value = v;
				}
			}
		}
		[Category("PaperPlane")]
		public bool MatchMode
		{
			get { return Edit.MatchMode; }
			set
			{
				Edit.MatchMode = value;
			}
		}
		public new Font Font
		{
			get { return Edit.Font; }
			set
			{
				base.Font = value;
				Edit.Font = value;
			}
		}
		[Category("paperPlane")]
		public int CaptionWidth
		{
			get { return Edit.CaptionWidth; }
			set 
			{
				int v = value - Edit.CaptionWidth;
				if (v != 0)
				{
					Edit.CaptionWidth = value;
					Edit.Width += v; 
					TrackBar.Left = Edit.Width;
					int b = this.Width - TrackBar.Left;
					if (b < 0) b = 0;
					TrackBar.Width = b;
				}
			}
		}

		private int m_EditWidth = 80;
		[Category("PaperPlane")]
		public int EditWidth
		{
			get { return m_EditWidth; }
			set
			{
				if (m_EditWidth != value)
				{
					m_EditWidth = value;
					int w = Edit.CaptionWidth + m_EditWidth;
					if (Edit.IsShowArrow) w += Edit.Height;
					Edit.Width = w;
					int v = this.Width - w;
					if (v < 0) v = 0;
					TrackBar.Left = Edit.Width;
					TrackBar.Width = v;
				}
			}
		}
		[Category("PaperPlane")]
		public float Minimum
		{
			get { return Edit.Minimum; }
			set 
			{ 
				Edit.Minimum = value;
			}
		}
		[Category("PaperPlane")]
		public float Maximum
		{
			get { return Edit.Maximum; }
			set 
			{ 
				Edit.Maximum = value;
			}
		}
		public void SetMinMax(float min, float max) { Edit.SetMinMax(min, max); }
		[Category("PaperPlane")]
		public bool Readonly
		{
			get { return Edit.ReadOnly; }
			set
			{
				Edit.ReadOnly = value;
			}
		}
		[Category("PaperPlane")]
		public bool SliderVisible
		{
			get { return TrackBar.Visible; }
			set
			{
				TrackBar.Visible = value;
			}
		}

		public Color EditColor
		{
			get { return Edit.EditColor; }
			set
			{
				Edit.EditColor = value;
			}
		}
		public PEdit()
		{
			base.DoubleBuffered = true;
			SuspendLayout();
			int h = 20;
			Edit.Location = new Point(0, 0);
			Edit.Size = new Size(150, h);
			Edit.Maximum = 5000;
			TrackBar.Location = new Point(150, 0);
			TrackBar.Size = new Size(120, h);
			TrackBar.NumEdit = Edit;
			this.Maximum = 200;


			this.Controls.Add(Edit);
			this.Controls.Add(TrackBar);
			base.Size = new Size(240, h);
			this.Name = base.Name;

			Edit.ValueFChanged += (sender, e) =>
			{
				OnValueFChanged(new ValueFChangedEventArgs(Edit.Value));
			};
			ChkSize();
			ResumeLayout();
		}
		public void ChkSize()
		{
			Edit.Size = new Size(Edit.Width, this.Height);
			TrackBar.Location = new Point(Edit.Width, 0);
			int b = this.Width - Edit.Width -2;
			if (b < 0) b = 0;
			TrackBar.Size = new Size(b, this.Height);
		}

		protected override void OnResize(EventArgs e)
		{
			ChkSize();
			base.OnResize(e);
		}
		// *******************************************************************
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
		public new System.Boolean IsAccessible
		{
			get { return base.IsAccessible; }
			set { base.IsAccessible = value; }
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
		public new System.Boolean UseWaitCursor
		{
			get { return base.UseWaitCursor; }
			set { base.UseWaitCursor = value; }
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
	// **************************************************************
	public class ValueFChangedEventArgs : EventArgs
	{
		public float Value;
		public ValueFChangedEventArgs(float v)
		{
			Value = v;
		}
	}

}
