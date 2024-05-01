using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PP
{
    public partial class InputPanelcs : UserControl
    {
        public event EventHandler ValueChanged;

        private bool m_isDec;
        private bool m_refFlag = false;
        public InputPanelcs()
        {
            InitializeComponent();
            SetDecMode(false);

        }
        //---------------------------------------------------------------------------
        public void SetDecMode(bool b)
        {
            bool r = m_refFlag;
            m_refFlag = true;

            m_isDec = b;
            if (b == true)
            {
                numericUpDown1.DecimalPlaces = 1;
                numericUpDown1.Increment = (decimal)0.1;
            }
            else
            {
                numericUpDown1.DecimalPlaces = 0;
                numericUpDown1.Increment = 1;
            }

            m_refFlag = r;
        }
        //----------------------------------------------------
        public bool IsDecMode
        {
            get
            {
                return m_isDec;
            }
            set
            {
                SetDecMode(value);
            }
        }
        public decimal MaxValue
        {
            get
            {
                return numericUpDown1.Maximum;
            }
            set
            {
                numericUpDown1.Maximum = value;
            }

        }
        public decimal MinValue
        {
            get
            {
                return numericUpDown1.Minimum;
            }
            set
            {
                numericUpDown1.Minimum = value;
            }

        }
        public decimal Value
        {
            get
            {
                return numericUpDown1.Value;
            }
            set
            {
                numericUpDown1.Value = value;
            }
        }
        //-----------------------------------------------------------------------------
        public string Caption
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }
        //-----------------------------------------------------------------------------


    }
}
