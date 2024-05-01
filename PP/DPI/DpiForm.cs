using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PP
{
    public partial class DpiForm : Form
    {
		private float m_dpiOld = 82;
		private float m_dpi = 82;
        public float DPI
        {
            get { return m_dpi; } 
            set 
            { 
                m_dpi = value;
				m_dpiOld = value;
				lbDpiNow.Text = $"{value}DPI";
            }
        }
        public DpiForm()
        {
            InitializeComponent();
            Calc();
        }

        public void Calc()
        {
            m_dpi = (int)(PU.Display_DPI((int)inputPanelcs1.Value, (int)inputPanelcs2.Value, (double)inputPanelcs3.Value) + 0.5);

            lbDpi.Text = $"{m_dpi}DPI";
		}

        private void inputPanelcs1_ValueChanged(object sender, EventArgs e)
        {
            Calc();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
