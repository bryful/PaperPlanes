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
	public class PPPos : Control
	{
		public event EventHandler ValueChanged;

		protected virtual void OnValueChanged(EventArgs e)
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, e);
			}
		}
		public event EventHandler ButttonClick;

		protected virtual void OnButttonClicked(EventArgs e)
		{
			if (ButttonClick != null)
			{
				ButttonClick(this, e);
			}
		}
		private Button m_Button = new Button();
		private NumericUpDown m_numX = new NumericUpDown();
		private NumericUpDown m_numY = new NumericUpDown();
		private FlowLayoutPanel fl = new FlowLayoutPanel();
		// **********************************************************
		public PPPos()
		{
			this.Size = new Size(150, 0);

			fl.FlowDirection = FlowDirection.LeftToRight;
			fl.Location = new Point(0, 0);
			fl.Size = this.Size;
			fl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
			this.Controls.Add(fl);


			m_Button.Size = new Size(40, 20);
			m_Button.Text = "Back";

			m_numX.Size = new Size(50, 20);
			m_numX.DecimalPlaces = 2;
			m_numX.Increment = (decimal)0.5;
			m_numX.Minimum = -30;
			m_numX.Maximum = 30;

			m_numY.Size = new Size(50, 20);
			m_numY.DecimalPlaces = 2;
			m_numY.Increment = (decimal)0.5;
			m_numY.Minimum = -30;
			m_numY.Maximum = 30;

			fl.Controls.Add(m_Button);
			fl.Controls.Add(m_numX);
			fl.Controls.Add(m_numY);


			m_numX.ValueChanged += M_num_ValueChanged;
			m_numY.ValueChanged += M_num_ValueChanged;

			m_Button.Click += M_Button_Click;

		}

		private void M_Button_Click(object sender, EventArgs e)
		{
			OnButttonClicked(new EventArgs());
		}

		private void M_num_ValueChanged(object sender, EventArgs e)
		{
			OnValueChanged(new EventArgs());
		}
		public PointF XYPosF
		{
			get { return new PointF((float)m_numX.Value,(float)m_numY.Value); }
			set
			{
				m_numX.Value = (decimal)value.X;
				m_numY.Value = (decimal)value.Y;
			}
		}
		public PointF XYPosP(float dpi)
		{
			return new PointF(PP.MM2P((float)m_numX.Value), PP.MM2P((float)m_numY.Value));
		}
	}
}
