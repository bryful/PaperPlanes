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
	public class PPInfoBox : Control
	{
		private Label Label1 = new Label();
		private TextBox TextBox1 = new TextBox();
		private TextBox TextBox2 = new TextBox();
		private float m_Value1 = 0;
		private float m_Value2 = 0;
		private float m_CompareV = 5;
		public float CompareV
		{
			get { return m_CompareV; }
			set { m_CompareV = value; ValueCompare(); }
		}
		private float m_BorderV = 0.1f;
		public float BorderV
		{
			get { return m_BorderV; }
			set { m_BorderV = value; ValueCompare(); }
		}
		private Color m_MatchColor = Color.Yellow;
		public Color MatchColor
		{
			get { return m_MatchColor; }
			set { m_MatchColor = value; ValueCompare(); }
		}

		private Color m_OutColor = Color.FromArgb(100,100,100);
		public Color OutColor
		{
			get { return m_OutColor; }
			set { m_OutColor = value; ValueCompare(); }
		}
		private Color m_InColor = Color.FromArgb(245,245,245);
		public Color InColor
		{
			get { return m_InColor; }
			set { m_InColor = value; ValueCompare(); }
		}
		public PPInfoBox()
		{
			this.Size = new Size(200, 40);
			//this.MinimumSize = this.Size;
			//this.MaximumSize = this.Size;


			int x = 0;
			Label1.Name = "Label1";
			Label1.AutoSize = false;
			Label1.Size = new Size(130, 20);
			Label1.Location = new Point(x, 00);
			Label1.TextAlign = ContentAlignment.MiddleRight;
			Label1.Font = this.Font;

			x += Label1.Width;

			TextBox1.Name = "TextBox1";
			TextBox1.Size = new Size(70, 20);
			TextBox1.Location = new Point(x, 0);
			TextBox1.Font = this.Font;
			TextBox1.TextAlign = HorizontalAlignment.Right;
			TextBox1.ReadOnly = true;

			TextBox2.Name = "TextBox2";
			TextBox2.Size = new Size(70, 20);
			TextBox2.Location = new Point(x, 20);
			TextBox2.Font = this.Font;
			TextBox2.TextAlign = HorizontalAlignment.Right;
			TextBox2.ReadOnly = true;



			this.Controls.Add(Label1);
			this.Controls.Add(TextBox1);
			this.Controls.Add(TextBox2);

			Value1 = 0;
			Value2 = 0;
			SetSize();
		}
		public float Value1
		{
			get { return m_Value1; }
			set
			{
				m_Value1 = value;
				TextBox1.Text = m_Value1.ToString("0.00");
				ValueCompare();
			}

		}
		public float Value2
		{
			get { return m_Value2; }
			set
			{
				m_Value2 = value;
				TextBox2.Text = m_Value2.ToString("0.00");
				ValueCompare();
			}

		}
		private void SetSize()
		{
			Size sz = new Size();
			if (Is2Mode) {
				sz = new Size(Label1.Width + TextBox1.Width, 40);
			}
			else
			{
				sz = new Size(Label1.Width + TextBox1.Width, 20);
			}
			//this.MaximumSize = sz;
			//this.MinimumSize = sz;
			this.Size = sz;
			TextBox1.Location = new Point(Label1.Width, 0);
			TextBox2.Location = new Point(Label1.Width, 20);

		}
		public int CaptionWidth
		{
			get { return Label1.Width; }
			set
			{
				Label1.Width = value;
				SetSize();
			}
		}
		public int EditWidth
		{
			get { return TextBox1.Width; }
			set
			{
				TextBox1.Width = value;
				TextBox2.Width = value;
				SetSize();
			}
		}
		public string Caption
		{
			get { return Label1.Text; }
			set { Label1.Text = value; }
		}
		public  override Font Font
		{
			get { return Label1.Font; }
			set
			{
				Label1.Font = value;
				TextBox1.Font = value;
				TextBox2.Font = value;

			}
		}
		public Color ColorFrom(Color c)
		{
			return Color.FromArgb(c.R, c.G, c.B);
		}
		public void Set2Mode(bool b)
		{
			TextBox2.Visible = b;
			if( b==true)
			{
				ValueCompare();
				this.Height = 40;
			}
			else
			{
				TextBox1.BackColor = ColorFrom(TextBox2.BackColor);
				this.Height = 20;
			}
		}
		public bool Is2Mode
		{
			get { return TextBox2.Visible; }
			set { Set2Mode(value); }
		}
		private void ValueCompare()
		{
			if (TextBox2.Visible == false) return;
			float v = Math.Abs(m_Value2 - m_Value1);

			if (v >= m_CompareV)
			{
				TextBox1.BackColor = ColorFrom( m_OutColor);
			}
			else if (v<m_BorderV)
			{
				TextBox1.BackColor =  ColorFrom( m_MatchColor);
			}
			else
			{

				double p = ((double)v-(double)m_BorderV)/((double)m_CompareV-(double)m_BorderV);
				if (p > 1) p = 1; else if (p < 0) p = 0;
				double r = (double)m_OutColor.R * p + (double)m_InColor.R * (1-p);  
				double g = (double)m_OutColor.G * p + (double)m_InColor.G * (1-p);  
				double b = (double)m_OutColor.B * p + (double)m_InColor.B * (1-p);
				r += 0.5; g += 0.5; b += 0.5;
				if (r < 0) r = 0; else if (r > 255) r = 255;
				if (g < 0) g = 0; else if (g > 255) g = 255;
				if (b < 0) b = 0; else if (b > 255) b = 255;
				TextBox1.BackColor = Color.FromArgb((int)(r), (int)(g), (int)(b));
			}

		}
	}
}
