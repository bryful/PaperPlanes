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
    public  class SpinBoxCap : Control
    {
        private Label m_label = new Label();
        private float m_defV = 0.05f;
        private NumericUpDown m_sb = new NumericUpDown();
        private CheckBox m_cb = new CheckBox();
        private Button m_reset = new Button();

        public event EventHandler valueChanged;

        public SpinBoxCap()
        {
            this.Size = new Size(320, 32);
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            m_cb.Checked = false;
            m_cb.Location = new Point(0, 0);
            m_cb.Size = new Size(150, 32);
            m_cb.Text = "水平尾翼の容積比(仮値)";
            this.Controls.Add(m_cb);

            m_sb.Enabled = m_cb.Checked;
            m_sb.DecimalPlaces = 2;
            m_sb.Maximum = 2;
            m_sb.Minimum = 0;
            m_sb.Increment = (decimal)0.01f;
            m_sb.Location = new Point(150, 5);
            m_sb.Size = new Size(100, 32);

            this.Controls.Add(m_sb);

            m_reset.Enabled = m_cb.Checked;
            m_reset.Text = "reset";
            m_reset.Location = new Point(260, 0);
            m_reset.Size = new Size(48, 28);
            this.Controls.Add(m_reset);

            m_cb.CheckedChanged += M_cb_CheckedChanged;
            m_reset.Click += M_reset_Click;
            m_sb.ValueChanged += M_sb_ValueChanged;
        }

        //----------------------------------------
        private void M_sb_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged(new EventArgs());
        }
        //----------------------------------------
        protected virtual void OnValueChanged(EventArgs e)
        {
            if (valueChanged != null)
                valueChanged(this, e);

        }

        private void M_reset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void M_cb_CheckedChanged(object sender, EventArgs e)
        {
            m_sb.Enabled = m_cb.Checked;
            m_reset.Enabled = m_cb.Checked;
        }

        //------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        public string Caption
        {
            get { return m_cb.Text; }
            set { m_cb.Text = value; }
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
        public float Value
        {
            get { return (float)m_sb.Value; }
            set
            {
                if (m_sb.Value != (decimal)value)
                {
                    m_sb.Value = (decimal)value;
                }
            }
        }

        //------------------------------------------------------------------
        public bool IsChecked
        {
            get
            {
                return m_cb.Checked;
            }
            set
            {
                if (m_cb.Checked != value)
                {
                    m_cb.Checked = value;
                }
            }
        }
        public void reset()
        {
            m_sb.Value = (decimal)m_defV;

        }
        //------------------------------------------------------------------
        public float defaultValue
        {
            get { return m_defV; }
            set
            {
                if (m_defV!=value) { m_defV = value; }
            }
        }
        //------------------------------------------------------------------
        public void MinMax(float mi, float mx)
        {
            if (mi > mx)
            {
                float f = mi;
                mi = mx;
                mx = f;
            }
            m_sb.Minimum = (decimal)mi;
            m_sb.Maximum = (decimal)mx;

        }
        //------------------------------------------------------------------
        public float Increment
        {
            get { return (float)m_sb.Increment; }
            set { m_sb.Increment = (decimal)value; }
        }

    }
}
