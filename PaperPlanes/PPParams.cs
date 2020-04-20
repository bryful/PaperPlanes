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
	public class PPParams : Control
	{
		public event EventHandler ValueChanged;

		protected virtual void OnValueChanged(EventArgs e)
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, e);
			}
		}

		Label Label1 = new Label();
		NumericUpDown NumericUpDown1 = new NumericUpDown();
		public PPParams()

		{
			this.Size = new Size(140, 20);
			this.MinimumSize = this.Size;
			this.MaximumSize = this.Size;
			// *
			Label1.Name = "Label1";
			Label1.AutoSize = false;
			Label1.Location = new Point(0, 0);
			Label1.Size = new Size(70, 20);
			Label1.TextAlign = ContentAlignment.MiddleRight;
			Label1.Text = this.Text;
			Label1.Font = this.Font;

			NumericUpDown1.Name = "NumericUpDown1";
			NumericUpDown1.Location = new Point(70, 0);
			NumericUpDown1.Size = new Size(70, 20);
			NumericUpDown1.DecimalPlaces = 1;
			NumericUpDown1.Font = this.Font;
			NumericUpDown1.TextAlign = HorizontalAlignment.Right;
			NumericUpDown1.Minimum = 0;
			NumericUpDown1.Maximum = 300;

			this.Controls.Add(Label1);
			this.Controls.Add(NumericUpDown1);

			NumericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;

		}

		private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			OnValueChanged(new EventArgs());
		}

		public int CaptionWidth
		{
			get { return Label1.Width; }
			set
			{
				Label1.Width = value;
				Size sz = new Size(Label1.Width + NumericUpDown1.Width, this.Height);
				SetSize(sz);
			}
		}
		public int EditWidth
		{
			get { return NumericUpDown1.Width; }
			set
			{
				NumericUpDown1.Width = value;
				Size sz = new Size(Label1.Width + NumericUpDown1.Width, this.Height);
				SetSize(sz);
			}
		}
		public void SetSize(Size sz)
		{
			this.MaximumSize = sz;
			this.MinimumSize = sz;
			this.Size = sz;

			Label1.Size = new Size(sz.Width - NumericUpDown1.Width, sz.Height); 

			Label1.Location = new Point(0, (this.Height - Label1.Height) / 2);
			NumericUpDown1.Location = new Point(Label1.Width, (this.Height - NumericUpDown1.Height) / 2);

		}
		protected override void OnResize(EventArgs e)
		{
			SetSize(this.Size);
		}
		public string Caption
		{
			get { return Label1.Text; }
			set { Label1.Text = value; }
		}
		public float Value
		{
			get { return (float)NumericUpDown1.Value; }
			set
			{
				decimal v = (decimal)value;
				if (NumericUpDown1.Value != v) {
					NumericUpDown1.Value = v;
				}
			}
		}
		public  override Font Font
		{
			get { return Label1.Font; }
			set
			{
				Label1.Font = value;
				NumericUpDown1.Font = value;
			}
		}
		public Size ASize
		{
			get { return base.Size; }
			set
			{
				SetSize(value);
			}
		}
		public decimal Minimum
		{
			get { return NumericUpDown1.Minimum; }
			set { NumericUpDown1.Minimum = value;}
		}
		public decimal Maximum
		{
			get { return NumericUpDown1.Maximum; }
			set { NumericUpDown1.Maximum = value;}
		}

	}
}
