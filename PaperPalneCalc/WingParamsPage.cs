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
    public enum W_MODE
    {
        MAIN=0,
        H_TAIL,
        V_TAIL,
        TV_TAIL,
        COUNT
    };
    public enum W_PRM
    {
        SPAN=0,
        ROOT,
        TIP,
        TIP_OFFSET,
        POS
    }

    public class WingParamsPage : Control
    {
        private wingCalc m_wc = new wingCalc();
        private ParamsPanel[] m_params = null;

        private bool m_refFlag = false;

        private W_MODE m_mode;
        public event EventHandler valueChanged;
        //----------------------------------------
        protected virtual void OnValueChanged(EventArgs e)
        {
            if (valueChanged != null)
                valueChanged(this, e);

        }
        //--------------------------------------------------------
        public WingParamsPage()
        {
            m_refFlag = false;
            createItems();
            this.MinimumSize = new Size(400, 32 * 5);
            this.MaximumSize = new Size(400, 32 * 5);
            setWingMode(W_MODE.MAIN);
            setDef(W_MODE.MAIN);
            
        }
        //----------------------------------------
        private void createItems()
        {
            m_params = new ParamsPanel[5];
            for (int i= 0;i<5;i++)
            {
                m_params[i] = new ParamsPanel();
                m_params[i].Location = new Point(0, i * 32);
                m_params[i].valueChanged += WingParamsPage_valueChanged;
                this.Controls.Add(m_params[i]);
            }
            m_params[(int)W_PRM.SPAN].caption = "翼長(mm)";
            m_params[(int)W_PRM.ROOT].caption = "翼根(mm)";
            m_params[(int)W_PRM.TIP].caption = "翼端(mm)";
            m_params[(int)W_PRM.TIP_OFFSET].caption = "翼端後退(mm)";
            m_params[(int)W_PRM.POS].caption = "位置(mm)";
        }
        //----------------------------------------
        private void WingParamsPage_valueChanged(object sender, EventArgs e)
        {
            FromUI();
        }
        //----------------------------------------
        private void FromUI()
        {
            if (m_refFlag) return;
            bool bak = m_refFlag;
            m_refFlag = true;

            float s, r, t, to, p;
            if ((m_mode== W_MODE.MAIN)|| (m_mode == W_MODE.H_TAIL))
            {
                s = m_params[(int)W_PRM.SPAN].Value/2;
            }else
            {
                s = m_params[(int)W_PRM.SPAN].Value;
            }
            r = m_params[(int)W_PRM.ROOT].Value;
            t = m_params[(int)W_PRM.TIP].Value;
            to = m_params[(int)W_PRM.TIP_OFFSET].Value;
            p = m_params[(int)W_PRM.POS].Value;

            m_wc.setSize(s, r, t, to);
            m_wc.Pos = p;
            m_wc.updateData();

            m_refFlag = bak;
            OnValueChanged(new EventArgs());
        }
        //----------------------------------------
        private void ToUI()
        {
            if (m_refFlag) return;
            bool bak = m_refFlag;
            m_refFlag = true;
            if ((m_mode == W_MODE.MAIN) || (m_mode == W_MODE.H_TAIL))
            {
                m_params[(int)W_PRM.SPAN].Value = m_wc.wingSpan * 2;
            }
            else
            {
                m_params[(int)W_PRM.SPAN].Value = m_wc.wingSpan;
            }
            m_params[(int)W_PRM.ROOT].Value = m_wc.wingRoot;
            m_params[(int)W_PRM.TIP].Value = m_wc.wingTip;
            m_params[(int)W_PRM.TIP_OFFSET].Value = m_wc.wingTipOffset;
            m_params[(int)W_PRM.POS].Value = m_wc.Pos;

            m_refFlag = bak;
            OnValueChanged(new EventArgs());
        }

        //----------------------------------------
        public void setWingMode(W_MODE md)
        {
            m_mode = md;
            switch (md)
            {
                case W_MODE.MAIN:
                    m_params[(int)W_PRM.POS].caption = "位置(mm)";
                    break;
                case W_MODE.H_TAIL:
                case W_MODE.V_TAIL:
                    m_params[(int)W_PRM.POS].caption = "主翼からの位置";
                    break;
                case W_MODE.TV_TAIL:
                    m_params[(int)W_PRM.POS].caption = "翼端からの位置";
                    break;
            }

        }
        
        //----------------------------------------
        public void setDef(W_MODE md)
        {

            m_mode = md;
            switch (md)
            {
                case W_MODE.MAIN:
                    m_params[(int)W_PRM.SPAN].setMinMax(50,250);
                    m_params[(int)W_PRM.SPAN].Value = 180;
                    m_params[(int)W_PRM.ROOT].setMinMax(10, 60);
                    m_params[(int)W_PRM.ROOT].Value = 40;
                    m_params[(int)W_PRM.TIP].setMinMax(5, 60);
                    m_params[(int)W_PRM.TIP].Value = 20;
                    m_params[(int)W_PRM.TIP_OFFSET].setMinMax(-50, 50);
                    m_params[(int)W_PRM.TIP_OFFSET].Value = 0;
                    m_params[(int)W_PRM.POS].setMinMax(20, 100);
                    m_params[(int)W_PRM.POS].Value = 40;
                    break;
                case W_MODE.H_TAIL:
                    m_params[(int)W_PRM.SPAN].setMinMax(20, 200);
                    m_params[(int)W_PRM.SPAN].Value = 87;
                    m_params[(int)W_PRM.ROOT].setMinMax(10, 60);
                    m_params[(int)W_PRM.ROOT].Value = 30;
                    m_params[(int)W_PRM.TIP].setMinMax(0, 50);
                    m_params[(int)W_PRM.TIP].Value = 20;
                    m_params[(int)W_PRM.TIP_OFFSET].setMinMax(-30, 30);
                    m_params[(int)W_PRM.TIP_OFFSET].Value = 10;
                    m_params[(int)W_PRM.POS].setMinMax(0, 200);
                    m_params[(int)W_PRM.POS].Value = 100;
                    break;
                case W_MODE.V_TAIL:
                    m_params[(int)W_PRM.SPAN].setMinMax(10, 110);
                    m_params[(int)W_PRM.SPAN].Value = 28.6f;
                    m_params[(int)W_PRM.ROOT].setMinMax(10, 110);
                    m_params[(int)W_PRM.ROOT].Value = 35;
                    m_params[(int)W_PRM.TIP].setMinMax(0, 50);
                    m_params[(int)W_PRM.TIP].Value = 18;
                    m_params[(int)W_PRM.TIP_OFFSET].setMinMax(-50, 50);
                    m_params[(int)W_PRM.TIP_OFFSET].Value = 20;
                    m_params[(int)W_PRM.POS].setMinMax(-50, 50);
                    m_params[(int)W_PRM.POS].Value = 11.7f;
                    break;
                case W_MODE.TV_TAIL:
                    m_params[(int)W_PRM.SPAN].setMinMax(10, 110);
                    m_params[(int)W_PRM.SPAN].Value = 16.7f;
                    m_params[(int)W_PRM.ROOT].setMinMax(0, 100);
                    m_params[(int)W_PRM.ROOT].Value = 20;
                    m_params[(int)W_PRM.TIP].setMinMax(0, 100);
                    m_params[(int)W_PRM.TIP].Value =15.5f;
                    m_params[(int)W_PRM.TIP_OFFSET].setMinMax(-50, 50);
                    m_params[(int)W_PRM.TIP_OFFSET].Value = 5.5f;
                    m_params[(int)W_PRM.POS].setMinMax(-20, 30);
                    m_params[(int)W_PRM.POS].Value = 0;
                    break;
            }
            
        }
        //----------------------------------------
        public PointF[] lines
        {
            get { return m_wc.lines; }
        }
        //----------------------------------------
        public PointF[] MACCenterLine
        {
            get { return m_wc.MACCenterLine; }
        }
        //----------------------------------------
        public float MACCenter
        {
            get { return m_wc.MACCenter; }
        }
        //----------------------------------------
        public PointF[] MAC
        {
            get { return m_wc.MACLine; }
        }
        //----------------------------------------
        public PointF MACPoint
        {
            get { return m_wc.MACPoint; }
        }
        //----------------------------------------
        public float MACLen
        {
            get { return m_wc.MACLenｇｔｈ; }
        }
        //----------------------------------------
        public float pos
        {
            get { return m_wc.Pos; }
        }
        //----------------------------------------
        public float wingSpan
        {
            get
            {
                if ((m_mode == W_MODE.MAIN) || (m_mode == W_MODE.H_TAIL))
                {
                    return m_wc.wingSpan * 2;
                }
                else
                {
                    return m_wc.wingSpan;
                }
            }
        }
        //----------------------------------------
        public float wingRoot
        {
            get { return m_wc.wingRoot; }
        }
        //----------------------------------------
        public float wingTip
        {
            get { return m_wc.wingTip; }
        }
        //----------------------------------------
        public float wingTipOffset
        {
            get { return m_wc.wingTipOffset; }
        }
        //----------------------------------------
        public float wingArea
        {
            get {
                if ((m_mode == W_MODE.MAIN) || (m_mode == W_MODE.H_TAIL) || (m_mode == W_MODE.TV_TAIL))
                {
                    return m_wc.WingArea*2;
                }
                else
                {
                    return m_wc.WingArea;
                }
            }
        }
        //----------------------------------------
        public float [] Data
        {
            get
            {
                return m_wc.Data;
            }
            set
            {
                m_wc.Data = value;
                ToUI();
            }
        }
        //----------------------------------------
        public dynamic jsonData
        {
            get
            {
                return m_wc.jsonData;
            }
            set
            {
                m_wc.jsonData = value;
                ToUI();
            }
        }
        //----------------------------------------
        public void updateData()
        {
            m_wc.updateData();
        }
    }
}
