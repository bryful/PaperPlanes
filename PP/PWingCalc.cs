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
		private PEdit m_HTailVRT = new PEdit();
		private PEdit m_VTailVRT = new PEdit();
		private PEdit m_CG = new PEdit();

		private PValueBox m_FuselageLength = new PValueBox();
		private PValueBox m_MainArea = new PValueBox();

		private PValueBox m_DistanceHTail = new PValueBox();
		private PValueBox m_HTailArea = new PValueBox();
		private PValueBox m_HTailVR = new PValueBox();

		private PValueBox m_DistanceVTail = new PValueBox();
		private PValueBox m_VTailArea = new PValueBox();
		private PValueBox m_VTailVR = new PValueBox();

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

		public PWingCalc()
		{
			m_HTailVRT.SliderVisible = false;
			m_HTailVRT.Readonly = true;
			m_HTailVRT.Text = "!HTail_VRate";
			m_VTailVRT.SliderVisible = false;
			m_VTailVRT.Readonly = true;
			m_VTailVRT.Text = "!VTail_VR";
			m_CG.SliderVisible = false;
			m_CG.Readonly = true;
			m_CG.Text = "CenterG";

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
			m_HTailVR.Text2 = "mm2";

			m_DistanceVTail.Text = "DistanceVTail";
			m_DistanceVTail.MatchMode = false;
			m_DistanceVTail.Text2 = "mm";

			m_VTailArea.Text = "VTailArea";
			m_VTailArea.Text2 = "mm2";


			m_VTailVR.Text = "VTailVR";
			m_VTailVR.MatchMode = false;
			m_VTailVR.Text2 = "mm2";

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
			get { return m_HTailVRT.EditWidth; }
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

		public void ChkSize()
		{
			int w = this.Width;
			int y = 0;
			int h = m_HTailVRT.Height + 2;
			
			m_HTailVRT.Location = new Point(0, y);
			m_HTailVRT.Size = new Size(w, h);
			y += m_HTailVRT.Height;
			m_VTailVRT.Location = new Point(0, y);
			m_VTailVRT.Size = new Size(w, h);
			y += m_VTailVRT.Height;
			m_CG.Location = new Point(0, y);
			m_CG.Size = new Size(w, h);
			y += m_CG.Height;
			y += 5;
			m_FuselageLength.Location = new Point(0, y);
			m_FuselageLength.Size = new Size(w, h);
			y += m_FuselageLength.Height;
			y += 5;
			m_MainArea.Location = new Point(0, y);
			m_MainArea.Size = new Size(w, h);
			y += m_MainArea.Height;
			y += 5;

			m_DistanceHTail.Location = new Point(0, y);
			m_DistanceHTail.Size = new Size(w, h);
			y += m_DistanceHTail.Height;
			m_HTailArea.Location = new Point(0, y);
			m_HTailArea.Size = new Size(w, h);
			y += m_HTailArea.Height;
			m_HTailVR.Location = new Point(0, y);
			m_HTailVR.Size = new Size(w, h);
			y += m_HTailVR.Height;
			y += 5;

			m_DistanceVTail.Location = new Point(0, y);
			m_DistanceVTail.Size = new Size(w, h);
			y += m_DistanceVTail.Height;

			m_VTailArea.Location = new Point(0, y);
			m_VTailArea.Size = new Size(w, h);
			y += m_VTailArea.Height;
			m_VTailVR.Location = new Point(0, y);
			m_VTailVR.Size = new Size(w, h);
			y += m_VTailVR.Height;

		}
		protected override void OnResize(EventArgs e)
		{

			ChkSize();
			base.OnResize(e);

		}
	}
}
