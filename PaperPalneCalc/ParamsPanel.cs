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
    public  class ParamsPanel : Control
    {
        private Label m_label = new Label();
        private NumericUpDown m_sb = new NumericUpDown();
        private TrackBar m_tb = new TrackBar();

        public event EventHandler valueChanged;

        private bool refFlag = false;
        public ParamsPanel()
        {
            Font f = new Font(this.Font.Name,12);
            m_label.AutoSize = false;
            m_label.TextAlign = ContentAlignment.MiddleRight;
            m_label.Location = new Point(0, 4);
            m_label.Size = new Size(100, 24);
            this.Controls.Add(m_label);

            m_sb.DecimalPlaces = 2;
            m_sb.Location = new Point(100, 4);
            m_sb.Size = new Size(80, 24);
            m_sb.Font = f;
            m_sb.Increment = (decimal)0.5f;
            this.Controls.Add(m_sb);

            m_tb.Location = new Point(180, 0);
            m_tb.Size = new Size(220, 32);
            this.Controls.Add(m_tb);


            this.MaxValue = 100.0f;
            this.MinValue = 0;


            this.Size = new Size(300, 16);
            this.MaximumSize = new Size(400, 32);
            this.MinimumSize = new Size(400, 32);


            m_sb.ValueChanged += M_sb_ValueChanged;
            m_tb.ValueChanged += M_tb_ValueChanged;



        }

 



        //------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        public string caption
        {
            get { return m_label.Text; }
            set { m_label.Text = value; }
        }
        //------------------------------------------------------------------
        //----------------------------------------
        protected virtual void OnValueChanged(EventArgs e)
        {
            if (valueChanged != null)
                valueChanged(this, e);
        }
        //------------------------------------------------------------------
        public float Value
        {
            get { return (float)m_sb.Value; }
            set
            {
                decimal v = (decimal)value;
                if (m_sb.Value != v)
                {
                    m_sb.Value = v;
                    int v2 = (int)(v * 10);
                    if (m_tb.Value != v2)
                    {
                        bool b = refFlag;
                        refFlag = true;
                        m_tb.Value = v2;
                        refFlag = b;
                    }
                }
            }
        }
        //------------------------------------------------------------------
        private void M_sb_ValueChanged(object sender, EventArgs e)
        {
            if (refFlag) return;
            bool b = refFlag;
            refFlag = true;
            m_tb.Value = (int)m_sb.Value * 10;
            OnValueChanged(new EventArgs());
            refFlag = b;
        }
        //------------------------------------------------------------------
        private void M_tb_ValueChanged(object sender, EventArgs e)
        {
            if (refFlag) return;
            bool b = refFlag;
            refFlag = true;
            m_sb.Value = (decimal)m_tb.Value / 10;
            OnValueChanged(new EventArgs());
            refFlag = b;
        }
        //------------------------------------------------------------------
        public float MaxValue
        {
            get { return (float)m_sb.Maximum; }
            set
            {
                m_sb.Maximum = (decimal)value;
                m_tb.Maximum = (int)(value * 10);
            }
        }
        //------------------------------------------------------------------
        public float MinValue
        {
            get { return (float)m_sb.Minimum; }
            set
            {
                m_sb.Minimum = (decimal)value;
                m_tb.Minimum = (int)(value * 10);
            }
        }

        //------------------------------------------------------------------
        public void setMinMax(float lo, float hi)
        {
            if (hi<lo)
            {
                float v = hi;
                hi = lo;
                lo = v;
            }
            MinValue = lo;
            MaxValue = hi;

        }
        //------------------------------------------------------------------
    }
}
