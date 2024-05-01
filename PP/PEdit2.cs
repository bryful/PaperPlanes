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
	public class PEdit2 :Control
	{

		[Category("PaperPlane")]
		public bool MatchMode
		{
			get { return Edit2.Visible; }
			set
			{
				Edit2.Visible = value;
				Edit.MatchMode = Edit2.Visible;
				ChkSize();
			}
		}

		private PNumEdit Edit = new PNumEdit();
		private PNumEdit Edit2 = new PNumEdit();
		private Label Label2 = new Label();
		[Category ("PaperPlane")]
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
		public string Text2
		{
			get { return Label2.Text; }
			set
			{
				Label2.Text = value;
			}
		}
		[Category("PaperPlane")]
		public float Value
		{
			get { return Edit.Value; }
			set 
			{
				Edit.Value = value;
			}
		}
		public void SetValues(float value,float mvalue)
		{
			if(MatchMode)
			{
				Edit.SetValues(value,mvalue);
				Edit2.Value = mvalue;
			}
			else
			{
				Edit.Value=value;	
			}
		}
		public new Font Font
		{
			get { return Edit.Font; }
			set
			{
				base.Font = value;
				Edit.Font = value;
				Label2.Font = value;
				Edit2.Font = value;
			}
		}
		[Category("PaperPlane")]
		public int CaptionWidth
		{
			get { return Edit.CaptionWidth; }
			set 
			{
				Edit.CaptionWidth = value;
				ChkSize();
			}
		}
		[Category("PaperPlane")]
		public int EditWidth
		{
			get { return Edit.EditWidth; }
			set
			{

				Edit.Width = Edit.CaptionWidth + value;
				Edit2.Width = value;
				ChkSize();
			}
		}
		[Category("PaperPlane")]
		public bool Readonly
		{
			get { return Edit.ReadOnly; }
			set
			{
				Edit.ReadOnly = value;
			}
		}
		
		public PEdit2()
		{
			base.DoubleBuffered = true;
			SuspendLayout();
			int x = 0;
			Edit.Location = new Point(x, 0);
			Edit.Size = new Size(140, 24);
			Edit.ReadOnly = true;
			Edit.IsShowArrow = false;
			Edit.SetMinMax(0, 320000);
			x += Edit.Width;

			if (Edit2.Visible)
			{
				x += 2;
				Edit2.Location = new Point(x, 0);
				Edit2.ReadOnly = true;
				Edit2.IsShowArrow = false;
				Edit2.IsShowCaption = false;
				Edit2.Size = new Size(70, 24);
				Edit2.MatchMode = false; ;
				Edit2.SetMinMax(0, 320000);
				x += Edit2.Width;
			}
			Label2.AutoSize = false;
			Label2.Location = new Point(x, 0);
			Label2.Size = new Size(70, 24);
			Label2.TextAlign = ContentAlignment.MiddleLeft;
			x += Label2.Width;
			base.Width = x;

			this.Controls.Add(Edit);
			this.Controls.Add(Edit2);
			this.Controls.Add(Label2);
			base.Size = new Size(x, 24);
			this.Name = base.Name;

			ResumeLayout();
			ChkSize();
		}
		public void ChkSize()
		{
			SuspendLayout();
			int x = 0;
			Edit.Location = new Point(x, 0);
			Edit.Size = new Size(Edit.Width, this.Height);
			x += Edit.Width;
			if (Edit2.Visible)
			{
				x += 2;
				Edit2.Location = new Point(x, 0);
				Edit2.Size = new Size(Edit2.Width, this.Height);
				x += Edit2.Width;
			}
			Label2.Location = new Point(x, 0);

			Label2.Size = new Size(this.Width-x, this.Height);
			ResumeLayout();
		}
		protected override void OnResize(EventArgs e)
		{

			ChkSize();
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


}
