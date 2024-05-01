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
	public class PWingCalc : Control
	{
		public event EventHandler ValueChanged;

		protected virtual void OnValueChanged(EventArgs e)
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, e);
			}
		}

		//private PCanvas m_canvas = null;

		private PEdit m_HTailVRT = new PEdit();
		private PEdit m_VTailVRT = new PEdit();
		private PEdit m_CG = new PEdit();

		private PEdit2 m_FuselageLength = new PEdit2();
		private PEdit2 m_MainArea = new PEdit2();

		private PEdit2 m_DistanceHTail = new PEdit2();
		private PEdit2 m_HTailArea = new PEdit2();
		private PEdit2 m_HTailVR = new PEdit2();

		private PEdit2 m_DistanceVTail = new PEdit2();
		private PEdit2 m_VTailArea = new PEdit2();
		private PEdit2 m_VTailVR = new PEdit2();

		[Category("PaperPlane")]
		public string[] Captions
		{
			get
			{
				string[] result = new string[]
				{
					m_HTailVRT.Text,
					m_VTailVRT.Text,
					m_CG.Text,
					m_FuselageLength.Text,
					m_MainArea.Text,
					m_DistanceHTail.Text,
					m_HTailArea.Text,
					m_HTailVR.Text,
					m_DistanceVTail.Text,
					m_VTailArea.Text,
					m_VTailVR.Text,
				};
				return result;
			}
			set
			{
				if (value.Length < 11) return;
				m_HTailVRT.Text = value[0];
				m_VTailVRT.Text = value[1];
				m_CG.Text = value[2];
				m_FuselageLength.Text = value[3];
				m_MainArea.Text = value[4];
				m_DistanceHTail.Text = value[5];
				m_HTailArea.Text = value[6];
				m_HTailVR.Text = value[7];
				m_DistanceVTail.Text = value[8];
				m_VTailArea.Text = value[9];
				m_VTailVR.Text = value[10];
			}
		}
		[Category("PaperPlane")]
		public new Font Font
		{
			get { return base.Font; }
			set
			{
				base.Font = value;
				m_HTailVRT.Font = value;
				m_VTailVRT.Font = value;
				m_CG.Font = value;
				m_FuselageLength.Font = value;
				m_MainArea.Font = value;

				m_DistanceHTail.Font = value;
				m_HTailArea.Font = value;
				m_HTailVR.Font = value;

				m_DistanceVTail.Font = value;
				m_VTailArea.Font = value;
				m_VTailVR.Font = value;
				ChkSize();
			}
		}
		// ***************************************************************
		public float[] ParamsT
		{
			get 
			{
				float[] ret = new float[]
				{
					m_HTailVRT.Value,
					m_VTailVRT.Value,
					m_CG.Value
				};
				return ret;
			}
			set
			{
				bool b = false;
				if (value.Length!=3) return;
				if (m_HTailVRT.Value != value[0]) { m_HTailVRT.Value = value[0]; b = true; }
				if (m_VTailVRT.Value != value[1]) { m_VTailVRT.Value = value[1]; b = true; }
				if (m_CG.Value != value[2]) { m_CG.Value = value[2]; b = true; }
				if (b) OnValueChanged(new EventArgs());
			}
		}
		public void SetParamsC(float[] value)
		{
			if (value.Length<10) return;
			m_FuselageLength.Value = value[0];
			m_MainArea.Value = value[1];

			m_DistanceHTail.Value = value[2];
			m_HTailArea.SetValues(value[3], value[4]);
			m_HTailVR.Value = value[5];

			m_DistanceVTail.Value = value[6];
			m_VTailArea.SetValues(value[7], value[8]);
			m_VTailVR.Value = value[9];
		}

		// ***************************************************************
		public PWingCalc()
		{
			m_HTailVRT.SliderVisible = false;
			m_HTailVRT.MatchMode = false;
			m_HTailVRT.Readonly = false;
			m_HTailVRT.Text = "!HTail_VRate";
			m_HTailVRT.ValueFChanged += (sender, e) =>{OnValueChanged(new EventArgs());};
			m_VTailVRT.SliderVisible = false;
			m_VTailVRT.MatchMode = false;
			m_VTailVRT.Readonly = false;
			m_VTailVRT.ValueFChanged += (sender, e) => { OnValueChanged(new EventArgs()); };
			m_VTailVRT.Text = "!VTail_VR";
			
			m_CG.SliderVisible = false;
			m_CG.MatchMode = false;
			m_CG.Readonly = false;
			m_CG.Text = "CenterG";
			m_CG.ValueFChanged += (sender, e) => { OnValueChanged(new EventArgs()); };

			m_FuselageLength.Text = "Fuselage";
			m_FuselageLength.Text2 = "mm";
			m_FuselageLength.MatchMode = false;
			
			m_MainArea.Text = "MainArea";
			m_MainArea.MatchMode = false;
			m_MainArea.Text2 = "mm2";
			m_DistanceHTail.Text = "DistanceHTail";
			m_DistanceHTail.MatchMode = false;
			m_DistanceHTail.Text2 = "mm";

			m_HTailArea.Text = "HTailArea";
			m_HTailArea.Text2 = "mm2";

			m_HTailVR.Text = "HTailVR";
			m_HTailVR.MatchMode = false;
			m_HTailVR.Text2 = "";

			m_DistanceVTail.Text = "DistanceVTail";
			m_DistanceVTail.MatchMode = false;
			m_DistanceVTail.Text2 = "mm";

			m_VTailArea.Text = "VTailArea";
			m_VTailArea.Text2 = "mm2";


			m_VTailVR.Text = "VTailVR";
			m_VTailVR.MatchMode = false;
			m_VTailVR.Text2 = "";

			EditWidth = 80;
			this.Controls.Add(m_HTailVRT);
			this.Controls.Add(m_VTailVRT);
			this.Controls.Add(m_CG);

			this.Controls.Add(m_FuselageLength);
			this.Controls.Add(m_MainArea);
			this.Controls.Add(m_DistanceHTail);
			this.Controls.Add(m_HTailArea);
			this.Controls.Add(m_HTailVR);
			this.Controls.Add(m_DistanceVTail);
			this.Controls.Add(m_VTailArea);
			this.Controls.Add(m_VTailVR);
			ChkSize();
		}

		[Category("PaperPlane")]
		public int CaptionWidth
		{
			get { return m_HTailVRT.CaptionWidth; }
			set
			{
				m_HTailVRT.CaptionWidth = value;
				m_VTailVRT.CaptionWidth = value;
				m_CG.CaptionWidth = value;
				m_FuselageLength.CaptionWidth = value;
				m_MainArea.CaptionWidth = value;
				m_DistanceHTail.CaptionWidth = value;
				m_HTailArea.CaptionWidth = value;
				m_HTailVR.CaptionWidth = value;
				m_DistanceVTail.CaptionWidth = value;
				m_VTailArea.CaptionWidth = value;
				m_VTailVR.CaptionWidth = value;
				ChkSize();
			}

		}
		[Category("PaperPlane")]
		public int EditWidth
		{
			get { return m_FuselageLength.EditWidth; }
			set
			{
				m_HTailVRT.EditWidth = value;
				m_VTailVRT.EditWidth = value;
				m_CG.EditWidth = value;
				m_FuselageLength.EditWidth = value;
				m_MainArea.EditWidth = value;
				m_DistanceHTail.EditWidth = value;
				m_HTailArea.EditWidth = value;
				m_HTailVR.EditWidth = value;
				m_DistanceVTail.EditWidth= value;
				m_VTailArea.EditWidth = value;
				m_VTailVR.EditWidth = value;
				ChkSize();
			}

		}
		public int m_EditHeight = 22;
		[Category("PaperPlane")]
		public int EditHeight
		{
			get { return m_EditHeight; }
			set
			{
				m_EditHeight = value;
				ChkSize();
			}

		}

		public void ChkSize()
		{
			int w = this.Width;
			int y = 0;
			int h = m_EditHeight+3;
			int h2 = m_EditHeight;

			m_HTailVRT.Location = new Point(0, y);
			m_HTailVRT.Size = new Size(w, h2);
			y += h;
			m_VTailVRT.Location = new Point(0, y);
			m_VTailVRT.Size = new Size(w, h2);
			y += h;
			m_CG.Location = new Point(0, y);
			m_CG.Size = new Size(w, h2);
			y += h;
			y += 4;
			m_FuselageLength.Location = new Point(0, y);
			m_FuselageLength.Size = new Size(w, h2);
			y += h;
			y += 4;
			m_MainArea.Location = new Point(0, y);
			m_MainArea.Size = new Size(w, h2);
			y += h;
			y += 4;

			m_DistanceHTail.Location = new Point(0, y);
			m_DistanceHTail.Size = new Size(w, h2);
			y += h;
			m_HTailArea.Location = new Point(0, y);
			m_HTailArea.Size = new Size(w, h2);
			y += h;
			m_HTailVR.Location = new Point(0, y);
			m_HTailVR.Size = new Size(w, h2);
			y += h;
			y += 4;

			m_DistanceVTail.Location = new Point(0, y);
			m_DistanceVTail.Size = new Size(w, h2);
			y += h;
			m_VTailArea.Location = new Point(0, y);
			m_VTailArea.Size = new Size(w, h2);
			y += h;
			m_VTailVR.Location = new Point(0, y);
			m_VTailVR.Size = new Size(w, h2);
			y += h;

		}
		protected override void OnResize(EventArgs e)
		{

			ChkSize();
			base.OnResize(e);

		}

		/*
		public void GetParams()
		{
			if (m_canvas == null) return;
			m_HTailVRT.Value = m_canvas.Wing.HTailVR_tentative;
			m_VTailVRT.Value = m_canvas.Wing.VTailVR_tentative;
			m_CG.Value = m_canvas.Wing.CenterG;
			m_FuselageLength.Value = m_canvas.Wing.FuselageLength;
			m_MainArea.Value = m_canvas.Wing.MainArea;
			m_DistanceHTail.Value = m_canvas.Wing.DistanceHTail;
			m_HTailArea.Value = m_canvas.Wing.HTailArea;
			//m_HTailVR
			m_DistanceVTail.Value = m_canvas.Wing.DistanceVTail;
			m_VTailArea.Value = m_canvas.Wing.VTailArea;
			//m_VTailVR
		}
		*/
	}
}
