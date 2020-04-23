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
		public event EventHandler SelectWingChanged;

		protected virtual void OnSelectWingChanged(EventArgs e)
		{
			if (SelectWingChanged != null)
			{
				SelectWingChanged(this, e);
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


		private PPInfoBox m_Body = new PPInfoBox();
		private PPInfoBox m_MainArea = new PPInfoBox();
		private PPInfoBox m_TailHorArea = new PPInfoBox();
		private PPInfoBox m_TailHorVolum = new PPInfoBox();

		private PPInfoBox m_TailVerArea = new PPInfoBox();
		private PPInfoBox m_TailVerVolum = new PPInfoBox();


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
				if (m_CmbEditMode.EditMode != DrawWings.EDIT_MODE.NORMAL)
				{
					if (SelectWing >= 2)
					{
						SelectWing = 1;
					}
				}
				chkItems();

			}
		}
		public int SelectWing
		{
			get { return m_CmbSelectWing.SelectWing; }
			set
			{
				int v = value;
				if (v >= 0)
				{
					if((v>=2)&&(EditMode != DrawWings.EDIT_MODE.NORMAL))
					{
						v = 0;
					}
					m_CmbSelectWing.SelectWing = v;
					chkItems();

				}
			}
		}
		public float Body
		{
			get { return m_Body.Value1; }
			set { m_Body.Value1 = value; }
		}
		public float MainArea
		{
			get { return m_MainArea.Value1; }
			set { m_MainArea.Value1 = value; }
		}
		public float TailHorArea
		{
			get { return m_TailHorArea.Value1; }
			set { m_TailHorArea.Value1 = value; }
		}
		public float TailHorAreaIdeal
		{
			get { return m_TailHorArea.Value2; }
			set { m_TailHorArea.Value2 = value; }
		}
		public float TailHorVolum
		{
			get { return m_TailHorVolum.Value1; }
			set { m_TailHorVolum.Value1 = value; }
		}
		public float TailVerArea
		{
			get { return m_TailVerArea.Value1; }
			set { m_TailVerArea.Value1 = value; }
		}
		public float TailVerAreaIdeal
		{
			get { return m_TailVerArea.Value2; }
			set { m_TailVerArea.Value2 = value; }
		}
		public float TailVerVolum
		{
			get { return m_TailVerVolum.Value1; }
			set { m_TailVerVolum.Value1 = value; }
		}
		#endregion

		// *************************************
		public PPParamsList()
		{
			this.Size = new Size(210, 410);

			m_CmbEditMode.Size =new Size(200, 20);
			m_CmbSelectWing.Size =new Size(200, 20);

			EditMode = EditMode;


			m_WingPos.Size = new Size(200, 20);
			m_WingPos.Caption = "位置(mm)";
			m_WingPos.CaptionWidth = 130;
			m_WingSpan.Size = new Size(200, 20);
			m_WingSpan.Caption = "翼全長(mm)";
			m_WingRoot.Size = new Size(200, 20);
			m_WingRoot.Caption = "翼根長(mm)";
			m_WingTip.Size = new Size(200, 20);
			m_WingTip.Caption = "翼端長(mm)";
			m_WingTipOffset.Size = new Size(200, 20);
			m_WingTipOffset.Caption = "翼端後退";
			m_WingDihedral.Size = new Size(200, 20);
			m_WingDihedral.Caption = "上反角(°)";

			m_WingTip2.Size = new Size(200, 20);
			m_WingTip2.Caption = "尾翼端";
			m_WingTipOffset2.Size = new Size(200, 20);
			m_WingTipOffset2.Caption = "尾翼端後退";
			m_WingSpan2.Size = new Size(200, 20);
			m_WingSpan2.Caption = "尾翼長";

			m_WingTipOffset.Minimum = -300;
			m_WingTipOffset2.Minimum = -300;
				

			m_Body.Size = new Size(200, 20);
			m_Body.Caption = "胴体の長さ(cm)";
			m_Body.Is2Mode = false;
			m_MainArea.Size = new Size(200, 20);
			m_MainArea.Caption = "主翼の面積(cm)";
			m_MainArea.Is2Mode = false;

			m_TailHorArea.Size = new Size(200, 40);
			m_TailHorArea.Caption = "水平尾翼の面積(cm)";
			m_TailHorArea.Is2Mode = true;
			m_TailHorArea.CaptionWidth = 130; 

			m_TailHorVolum.Size = new Size(200, 20);
			m_TailHorVolum.Caption = "水平尾翼容積比(cm)";
			m_TailHorVolum.Is2Mode = false;

			m_TailVerArea.Size = new Size(200, 20);
			m_TailVerArea.Caption = "垂直尾翼の面積(cm)";
			m_TailVerArea.Is2Mode = true;

			m_TailVerVolum.Size = new Size(200, 20);
			m_TailVerVolum.Caption = "垂直尾翼容積比(cm)";
			m_TailVerVolum.Is2Mode = false;

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
			FlowLayoutPanel1.Controls.Add(new EmptyBox());
			FlowLayoutPanel1.Controls.Add(m_Body);
			FlowLayoutPanel1.Controls.Add(m_MainArea);
			FlowLayoutPanel1.Controls.Add(m_TailHorArea);
			FlowLayoutPanel1.Controls.Add(m_TailHorVolum);
			FlowLayoutPanel1.Controls.Add(m_TailVerArea);
			FlowLayoutPanel1.Controls.Add(m_TailVerVolum);



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
			chkItems();
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
				//return;
			}
			chkItems();

			OnSelectWingChanged(new EventArgs());
		}

		private void M_CmbEditMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			chkItems();
			OnEditModeChanged(new EventArgs());
		}

		protected override void InitLayout()
		{

		}
		private void chkItems()
		{
			int tw = m_CmbSelectWing.SelectWing;
			switch( m_CmbEditMode.EditMode)
			{
				case DrawWings.EDIT_MODE.NORMAL:
					m_WingSpan2.Enabled = false;
					m_WingTipOffset2.Enabled = false;
					m_WingTip2.Enabled = false;
					if (tw == 0)
					{
						m_WingDihedral.Enabled = true;
					}else if (tw == 1)
					{
						m_WingDihedral.Enabled = false;

					}else if (tw == 2)
					{
						m_WingDihedral.Enabled = false;
					}
					break;
				case DrawWings.EDIT_MODE.TWINTAIL:
					if (tw>= 2)
					{
						m_CmbSelectWing.SelectWing = 0;
						tw = 0;
					}

					if (tw == 0)
					{
						m_WingDihedral.Enabled = true;
						m_WingSpan2.Enabled = false;
						m_WingTipOffset2.Enabled = false;
						m_WingTip2.Enabled = false;
					}else if (tw == 1)
					{
						m_WingDihedral.Enabled = false;
						m_WingSpan2.Enabled = true;
						m_WingTipOffset2.Enabled = true;
						m_WingTip2.Enabled = true;

					}
					break;
			}
		}
	}
}
