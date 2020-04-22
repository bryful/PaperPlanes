using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace PaperPlanes
{
	public class PPParamsList : Control
	{
		public bool EventFlag = true;
		#region event
		public event EventHandler EditModeChanged;

		protected virtual void OnEditModeChanged(EventArgs e)
		{
			if (EditModeChanged != null)
			{
				EditModeChanged(this, e);
			}
		}
		public event EventHandler TargetWingChanged;

		protected virtual void OnTargetWingChanged(EventArgs e)
		{
			if (TargetWingChanged != null)
			{
				TargetWingChanged(this, e);
			}
		}
		public event EventHandler ValueChanged;

		protected virtual void OnValueChanged(EventArgs e)
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, e);
			}
		}
		#endregion

		#region params
		private CombEditMode m_CmbEditMode = new CombEditMode();
		private CombSelectWings m_CmbSelectWing = new CombSelectWings();
		private PPParams m_WingPos = new PPParams();
		private PPParams m_WingSpan = new PPParams();
		private PPParams m_WingRoot = new PPParams();
		private PPParams m_WingTip = new PPParams();
		private PPParams m_WingTipOffset = new PPParams();
		private PPParams m_WingDihedral = new PPParams();

		private PPParams m_WingTip2 = new PPParams();
		private PPParams m_WingTipOffset2 = new PPParams();
		private PPParams m_WingSpan2 = new PPParams();

		private FlowLayoutPanel FlowLayoutPanel1 = new FlowLayoutPanel();
		#endregion

		#region value
		public float WingPos
		{
			get { return m_WingPos.Value; }
			set{if (m_WingPos.Value != value){m_WingPos.Value = value;}}
		}
		public float WingSpan
		{
			get { return m_WingSpan.Value; }
			set{if (m_WingSpan.Value != value){m_WingSpan.Value = value;}}
		}
		public float WingRoot
		{
			get { return m_WingRoot.Value; }
			set{if (m_WingRoot.Value != value){m_WingRoot.Value = value;}}
		}
		public float WingTip
		{
			get { return m_WingTip.Value; }
			set{if (m_WingTip.Value != value){m_WingTip.Value = value;}}
		}
		public float WingTipOffset
		{
			get { return m_WingTipOffset.Value; }
			set{if (m_WingTipOffset.Value != value){m_WingTipOffset.Value = value;}}
		}
		public float WingDihedral
		{
			get { return m_WingDihedral.Value; }
			set{if (m_WingDihedral.Value != value){m_WingDihedral.Value = value;}}
		}
		public float WingTip2
		{
			get { return m_WingTip2.Value; }
			set{if (m_WingTip2.Value != value){m_WingTip2.Value = value;}}
		}
		public float WingTipOffset2
		{
			get { return m_WingTipOffset2.Value; }
			set{if (m_WingTipOffset2.Value != value){m_WingTipOffset2.Value = value;}}
		}
		public float WingSpan2
		{
			get { return m_WingSpan2.Value; }
			set{if (m_WingSpan2.Value != value){m_WingSpan2.Value = value;}}
		}
		#endregion

		#region mode
		public DrawWings.EDIT_MODE EditMode
		{
			get { return m_CmbEditMode.EditMode; }
			set
			{
				if (m_CmbEditMode.EditMode != value)
				{
					m_CmbEditMode.EditMode = value;
				}
				bool b = (m_CmbEditMode.EditMode == DrawWings.EDIT_MODE.TWINTAIL);
				m_WingTip2.Visible = b;
				m_WingTipOffset2.Visible = b;
				m_WingSpan2.Visible = b;
				if (m_CmbEditMode.EditMode != DrawWings.EDIT_MODE.NORMAL)
				{
					if (TargetWing >= 2)
					{
						TargetWing = 1;
					}
				}

			}
		}
		public int TargetWing
		{
			get { return m_CmbSelectWing.TargetWing; }
			set
			{
				int v = value;
				if (v >= 0)
				{
					if((v>=2)&&(EditMode != DrawWings.EDIT_MODE.NORMAL))
					{
						v = 0;
					}
					m_CmbSelectWing.TargetWing = v;
				}
			}
		}
		#endregion

		// *************************************
		public PPParamsList()
		{
			this.Size = new Size(180, 160);

			m_CmbEditMode.Size =new Size(140, 20);
			m_CmbSelectWing.Size =new Size(140, 20);

			EditMode = EditMode;

			m_WingPos.Size = new Size(180, 20);
			m_WingPos.Caption = "位置(mm)";
			m_WingSpan.Size = new Size(180, 20);
			m_WingSpan.Caption = "翼全長(mm)";
			m_WingRoot.Size = new Size(180, 20);
			m_WingRoot.Caption = "翼根長(mm)";
			m_WingTip.Size = new Size(180, 20);
			m_WingTip.Caption = "翼端長(mm)";
			m_WingTipOffset.Size = new Size(180, 20);
			m_WingTipOffset.Caption = "翼端後退";
			m_WingDihedral.Size = new Size(180, 20);
			m_WingDihedral.Caption = "上反角(°)";

			m_WingTip2.Size = new Size(180, 20);
			m_WingTip2.Caption = "尾翼端";
			m_WingTipOffset2.Size = new Size(180, 20);
			m_WingTipOffset2.Caption = "尾翼端後退";
			m_WingSpan2.Size = new Size(180, 20);
			m_WingSpan2.Caption = "尾翼長";

			m_WingTipOffset.Minimum = -300;
			m_WingTipOffset2.Minimum = -300;
				

			FlowLayoutPanel1.Location = new Point(0, 0);
			FlowLayoutPanel1.Size = this.Size;
			FlowLayoutPanel1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
			this.Controls.Add(FlowLayoutPanel1);

			FlowLayoutPanel1.Controls.Add(m_CmbEditMode);
			FlowLayoutPanel1.Controls.Add(m_CmbSelectWing);

			FlowLayoutPanel1.Controls.Add(m_WingPos);
			FlowLayoutPanel1.Controls.Add(m_WingSpan);
			FlowLayoutPanel1.Controls.Add(m_WingRoot);
			FlowLayoutPanel1.Controls.Add(m_WingTip);
			FlowLayoutPanel1.Controls.Add(m_WingTipOffset);
			FlowLayoutPanel1.Controls.Add(m_WingDihedral);
			FlowLayoutPanel1.Controls.Add(m_WingTip2);
			FlowLayoutPanel1.Controls.Add(m_WingTipOffset2);
			FlowLayoutPanel1.Controls.Add(m_WingSpan2);


			m_CmbEditMode.SelectedIndexChanged += M_CmbEditMode_SelectedIndexChanged;
			m_CmbSelectWing.SelectedIndexChanged += M_CmbSelectWing_SelectedIndexChanged;

			m_WingPos.ValueChanged += M_Wing_ValueChanged;
			m_WingSpan.ValueChanged += M_Wing_ValueChanged;
			m_WingRoot.ValueChanged += M_Wing_ValueChanged;
			m_WingTip.ValueChanged += M_Wing_ValueChanged;
			m_WingTipOffset.ValueChanged += M_Wing_ValueChanged;
			m_WingDihedral.ValueChanged += M_Wing_ValueChanged;
			m_WingTip2.ValueChanged += M_Wing_ValueChanged;
			m_WingTipOffset2.ValueChanged += M_Wing_ValueChanged;
			m_WingSpan2.ValueChanged += M_Wing_ValueChanged;

		}

		private void M_Wing_ValueChanged(object sender, EventArgs e)
		{
			if (EventFlag == true)
			{
				OnValueChanged(new EventArgs());
			}
		}

		private void M_CmbSelectWing_SelectedIndexChanged(object sender, EventArgs e)
		{
			if( (m_CmbSelectWing.SelectedIndex==2)&&(EditMode!= DrawWings.EDIT_MODE.NORMAL))
			{
				m_CmbSelectWing.SelectedIndex = 0;
				return;
			}
			OnTargetWingChanged(new EventArgs());
		}

		private void M_CmbEditMode_SelectedIndexChanged(object sender, EventArgs e)
		{

			OnEditModeChanged(new EventArgs());
		}

		protected override void InitLayout()
		{

		}
	}
}
