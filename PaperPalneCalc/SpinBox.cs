using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaperPalneCalc
{
    public  class SpinBox : Control
    {
        private float m_value1 = 0;
        private float m_value2 = 0;
        private Label m_label1 = new Label();
        private Label m_label2 = new Label();
        private TextBox m_tb1 = new TextBox();
        private TextBox m_tb2 = new TextBox();


        public SpinBox()
        {
            FlowLayoutPanel fp = new FlowLayoutPanel();
            fp.FlowDirection = FlowDirection.LeftToRight;
            fp.Dock = DockStyle.Fill;
            fp.Location = new Point(150, 0);
            fp.Size = new Size(400, 32);

            Font f = new Font(this.Font.Name,10);
            m_label1.AutoSize = false;
            m_label1.TextAlign = ContentAlignment.MiddleRight;
            m_label1.Location = new Point(0, 4);
            m_label1.Size = new Size(130, 32);
            m_label1.Font = f;
            m_label1.Text = "AAAAA";
            fp.Controls.Add(m_label1);


            m_tb1.Size = new Size(70, 32);
            f = new Font(this.Font.Name, 16);
            m_tb1.Font = f;
            m_tb1.ReadOnly = true;
            m_tb1.TextAlign = HorizontalAlignment.Right;
            m_tb1.Text = "000.00";
            m_tb1.BackColor = Color.White;
            fp.Controls.Add(m_tb1);

            m_tb2.Size = new Size(70, 32);
            f = new Font(this.Font.Name, 16);
            m_tb2.Font = f;
            m_tb2.ReadOnly = true;
            m_tb2.TextAlign = HorizontalAlignment.Right;
            m_tb2.Text = "000.00";
           // m_tb2.Visible = false;
            m_tb2.BackColor = Color.White;
            fp.Controls.Add(m_tb2);

            f = new Font(this.Font.Name, 16);
            m_label2.AutoSize = false;
            m_label2.TextAlign = ContentAlignment.MiddleLeft;
            m_label2.Size = new Size(60, 32);
            m_label2.Font = f;
            m_label2.Text = "BB";
            fp.Controls.Add(m_label2);


            this.Controls.Add(fp);




            this.Size = new Size(400, 16);
            this.MaximumSize = new Size(400, 32);
            this.MinimumSize = new Size(400, 32);

        }

 



        //------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        public string Caption
        {
            get { return m_label1.Text; }
            set { m_label1.Text = value; }
        }
        //------------------------------------------------------------------
        public string Caption2
        {
            get { return m_label2.Text; }
            set { m_label2.Text = value; }
        }
        //------------------------------------------------------------------
        private string float2str(float f)
        {
            long v = (int)(f * 100 + 0.5f);
            long v1 = v / 100;
            long v2 = v % 100;
            string s = "";
            if (v2 < 10) s = "0";

            return string.Format("{0}.{1}{2}", v1,s,v2);
        }
        //------------------------------------------------------------------
        private void calcValue()
        {
            if (m_tb2.Visible == false) return;
            float m = m_value1 - m_value2;
            if (m < 0) m *= -1;

            float minV = 0.2f;
            float maxV = 20;
            int v0 = 255;
            int v1 = 160;

            Color b;
            int r = 0;
            if (m<minV)
            {
                m_tb1.BackColor = Color.Yellow;
                return;
            }else if (m>=maxV)
            {
                r = v1;

            }else
            {
                r = (int)(128 + ((float)v0 - (float)v1) * (1 - (m - minV) / (maxV - minV)));
            }

            b=  Color.FromArgb(255, r, r, r);
            m_tb1.BackColor = b;

        }
        //------------------------------------------------------------------
        public float Value
        {
            get { return (float)m_value1; }
            set
            {
                if (m_value1 != value)
                {
                    m_value1 = value;
                    m_tb1.Text = float2str(m_value1);
                    calcValue();
                }
            }
        }
        //------------------------------------------------------------------
        public float Value2
        {
            get { return (float)m_value2; }
            set
            {
                if (m_value2 != value)
                {
                    m_value2 = value;
                    m_tb2.Text = float2str(m_value2);
                    calcValue();
                }
            }
        }

        //------------------------------------------------------------------
        public bool IsCmpMode
        {
            get
            {
                return m_tb2.Visible;
            }
            set
            {
                m_tb2.Visible = value;
            }
        }
    }
}
