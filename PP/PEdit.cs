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
		private Label Label = new Label();
		private NumericUpDown Edit = new NumericUpDown();
		private PTrackBar TrackBar = new PTrackBar();
		[Category ("paperPlane")]
		public new string Text
		{
			get { return Label.Text; }
			set 
			{ 
				Label.Text = value;
				base.Text = value;
			}
		}
		[Category("paperPlane")]
		public float Value
		{
			get { return (float)Edit.Value; }
			set 
			{
				decimal v = (decimal)value;
				if ( (v>=Edit.Minimum)&&(v<=Edit.Maximum))
				{
					Edit.Value = v;
				}
			}
		}
		public new Font Font
		{
			get { return Label.Font; }
			set
			{
				base.Font = value;
				Label.Font = value;
				Edit.Font = value;
				int h = Edit.Height;
				Label.Height = h;
				base.MinimumSize = new Size(0,0);
				base.MaximumSize = new Size(32000,32000);
				base.Size = new Size(base.Width, h);
				base.MinimumSize = new Size(50, h);
				base.MaximumSize = new Size(32000, h);
			}
		}
		[Category("paperPlane")]
		public int CaptionWidth
		{
			get { return Label.Width; }
			set 
			{ 
				Label.Width = value;
				Edit.Left = Label.Width;
				TrackBar.Left = Label.Width + Edit.Width;
				int b = this.Width - TrackBar.Left;
				if (b<0) b = 0;
				TrackBar.Width = b;
			}
		}
		[Category("paperPlane")]
		public int TextWidth
		{
			get { return Edit.Width; }
			set
			{
				Edit.Width = value;	
				Edit.Left = Label.Width;
				TrackBar.Left = Label.Width + Edit.Width;
				int b = this.Width - TrackBar.Left;
				if (b < 0) b = 0;
				TrackBar.Width = b;
			}
		}
		[Category("paperPlane")]
		public float Minimum
		{
			get { return (float)Edit.Minimum; }
			set 
			{ 
				Edit.Minimum = (decimal)value;
			}
		}
		[Category("paperPlane")]
		public float Maximum
		{
			get { return (float)Edit.Maximum; }
			set 
			{ 
				Edit.Maximum = (decimal)value;
			}
		}
		public PEdit()
		{
			base.DoubleBuffered = true;
			SuspendLayout();
			int h = Edit.Height;
			Label.AutoSize = false;
			Label.Location = new Point(0, 0);
			Label.Size = new Size(60, h);
			Label.TextAlign = ContentAlignment.MiddleRight;
			Edit.AutoSize = false;
			Edit.Location = new Point(60, 0);
			Edit.Size = new Size(60, h);
			Edit.DecimalPlaces = 3;
			Edit.Maximum = 5000;
			TrackBar.Location = new Point(120, 0);
			TrackBar.Size = new Size(120, h);
			TrackBar.NumericUpDown = Edit;
			this.Maximum = 200;


			this.Controls.Add(Label);
			this.Controls.Add(Edit);
			this.Controls.Add(TrackBar);
			base.Size = new Size(240, h);
			base.MinimumSize = new Size(50, h);
			base.MaximumSize = new Size(32000, h);
			this.Name = base.Name;

			Edit.ValueChanged += (sender, e) =>
			{
				OnValueFChanged(new ValueFChangedEventArgs((float)Edit.Value));
			};
			ResumeLayout();
		}

		protected override void OnResize(EventArgs e)
		{
			int a = Label.Width + Edit.Width;
			int b = this.Width - a;
			if (b < 0) b = 0;
			SuspendLayout();
			Label.Height = Edit.Height;
			TrackBar.Location = new Point(a,0);
			TrackBar.Size = new Size(b,Edit.Height);
			base.OnResize(e);
			ResumeLayout();
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
