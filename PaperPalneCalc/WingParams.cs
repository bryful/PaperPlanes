using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Codeplex.Data;

namespace PaperPalneCalc
{
    public enum STAT
    {
        BODY = 0,
        MAIN,
        H_TAIL,
        H_TAIL_VC,
        V_TAIL,
        V_TAIL_VC,
        COUNT
    }
    public class WingParams : Control
    {

        private bool m_twinVTailMode = false;

        private bool m_refFlag = false;

        private float m_BodyLength = 0;
        private float m_H_TailMomentArms;
        private float m_V_TailMomentArms;
        private float m_CG2;

        //private float m_wingCGPercent = 85;
        //private float m_MACCenterPercebt = 0.25f;
 
        private TabControl m_tc;
        private TabPage[] m_pages;
        private WingParamsPage[] m_paramPages;
        private RadioButton[] m_rb;

        private SpinBox[] m_sb = null;

        private SpinBoxCap m_ht = new SpinBoxCap();
        private SpinBoxCap m_vt = new SpinBoxCap();
        private SpinBoxCap m_cg = new SpinBoxCap();
        public event EventHandler valueChanged;
        //--------------------------------------------------------
        public WingParams()
        {
            createItems();
            setTwinVTailMode(false);
            updateData();


        }
        //----------------------------------------
        public void updateData()
        {
            for (int i = 0; i < 4; i++)
            {
                m_paramPages[i].updateData();

            }
            calcStatus();
        }
        //----------------------------------------
        private void createItems()
        {
            FlowLayoutPanel fp = new FlowLayoutPanel();
            fp.FlowDirection = FlowDirection.LeftToRight;
            fp.Dock = DockStyle.Fill;
            fp.Location = new Point(0, 0);
            fp.Size = new Size(420, 600);

            m_tc = new TabControl();
            m_tc.Size = new Size(410, 200);
            m_pages = new TabPage[4];
            m_paramPages = new WingParamsPage[4];
            for (int i = 0; i < 4; i++)
            {
                m_pages[i] = new TabPage();
                m_pages[i].Location = new Point(0, 0);
                m_pages[i].Size = new Size(400, 160);

                m_paramPages[i] = new WingParamsPage();
                m_paramPages[i].Location = new Point(5, 5);
                m_paramPages[i].setWingMode((W_MODE)i);
                m_paramPages[i].setDef((W_MODE)i);

                m_paramPages[i].valueChanged += WingParams_CheckedChanged;
                m_pages[i].Controls.Add(m_paramPages[i]);

                m_tc.Controls.Add(m_pages[i]);
            }
            m_pages[0].Text = "主翼";
            m_pages[1].Text = "水平尾翼";
            m_pages[2].Text = "垂直尾翼";
            m_pages[3].Text = "双垂直尾翼";


            fp.Controls.Add(m_tc);

            m_ht.MinMax(0.6f, 2.0f);
            m_ht.defaultValue = 1.2f;
            m_ht.Value = 1.2f;
            m_ht.Caption = "水平尾翼の容積比(仮値)";
            m_ht.valueChanged += WingParams_CheckedChanged;


            m_vt.MinMax(0.02f, 0.06f);
            m_vt.defaultValue = 0.05f;
            m_vt.Value = 0.05f;
            m_vt.Caption = "垂直尾翼の容積比(仮値)";
            m_vt.valueChanged += WingParams_CheckedChanged;


            m_cg.MinMax(40f, 110f);
            m_cg.defaultValue = 85f;
            m_cg.Value = 85f;
            m_cg.Increment = 1f;
            m_cg.Caption = "重心位置(%)";
            m_cg.valueChanged += WingParams_CheckedChanged;

            fp.Controls.Add(m_ht);
            fp.Controls.Add(m_vt);
            fp.Controls.Add(m_cg);


            GroupBox gb = new GroupBox();
            gb.Text = "垂直尾翼の形式";
            gb.Size = new Size(410, 40);

            m_rb = new RadioButton[2];
            m_rb[0] = new RadioButton();
            m_rb[0].Text = "通常垂直尾翼";
            m_rb[0].Location = new Point(30, 16);
            m_rb[0].Size = new Size(100, 16);
            m_rb[0].CheckedChanged += WingParams_CheckedChanged;

            m_rb[1] = new RadioButton();
            m_rb[1].Text = "双垂直尾翼";
            m_rb[1].Location = new Point(150, 16);
            m_rb[1].Size = new Size(150, 16);
            m_rb[1].CheckedChanged += WingParams_CheckedChanged;
            gb.Controls.Add(m_rb[0]);
            gb.Controls.Add(m_rb[1]);

            fp.Controls.Add(gb);

            GroupBox gb2 = new GroupBox();
            gb2.Text = "各所の数値(mm)";
            gb2.Size = new Size(410, 36 * (int)STAT.COUNT + 18);

            m_sb = new SpinBox[(int)STAT.COUNT];
            for (int i = 0; i < (int)STAT.COUNT; i++)
            {
                m_sb[i] = new SpinBox();
                m_sb[i].Location = new Point(10, i * 36 + 18);
                gb2.Controls.Add(m_sb[i]);

            }
            m_sb[(int)STAT.BODY].IsCmpMode = false;
            m_sb[(int)STAT.MAIN].IsCmpMode = false;
            m_sb[(int)STAT.H_TAIL_VC].IsCmpMode = false;
            m_sb[(int)STAT.V_TAIL_VC].IsCmpMode = false;

            m_sb[(int)STAT.BODY].Caption = "胴体の長さ";
            m_sb[(int)STAT.BODY].Caption2 = "cm";
            m_sb[(int)STAT.MAIN].Caption = "主翼の面積";
            m_sb[(int)STAT.MAIN].Caption2 = "cm2";
            m_sb[(int)STAT.H_TAIL].Caption = "水平尾翼の面積";
            m_sb[(int)STAT.H_TAIL].Caption2 = "cm2";
            m_sb[(int)STAT.H_TAIL_VC].Caption = "水平尾翼容積比";
            m_sb[(int)STAT.H_TAIL_VC].Caption2 = "";
            m_sb[(int)STAT.V_TAIL].Caption = "垂直尾翼の面積";
            m_sb[(int)STAT.V_TAIL].Caption2 = "cm2";
            m_sb[(int)STAT.V_TAIL_VC].Caption = "垂直尾翼容積比";
            m_sb[(int)STAT.V_TAIL_VC].Caption2 = "";
            fp.Controls.Add(gb2);

            this.Controls.Add(fp);
            
        }

        //----------------------------------------
        private void M_ht_valueChanged(object sender, EventArgs e)
        {
        }

        //----------------------------------------
        private void calcStatus()
        {
            
            //胴体の長さ
            m_BodyLength = m_paramPages[(int)W_MODE.MAIN].pos
                 + m_paramPages[(int)W_MODE.H_TAIL].pos
                 + m_paramPages[(int)W_MODE.H_TAIL].wingRoot;

            //
            m_H_TailMomentArms = hTailPos + m_paramPages[(int)W_MODE.H_TAIL].MACCenter 
                - m_paramPages[(int)W_MODE.MAIN].MACCenter;

            if (m_twinVTailMode)
            {
                m_V_TailMomentArms =
                    hTailPos + hTailTipOffset + m_paramPages[(int)W_MODE.TV_TAIL].pos
                    + m_paramPages[(int)W_MODE.TV_TAIL].MACCenter
                    - m_paramPages[(int)W_MODE.MAIN].MACCenter;
            }
            else
            {
                m_V_TailMomentArms = 
                    hTailPos - m_paramPages[(int)W_MODE.V_TAIL].wingRoot + m_paramPages[(int)W_MODE.V_TAIL].pos
                    + m_paramPages[(int)W_MODE.V_TAIL].MACCenter
                    - m_paramPages[(int)W_MODE.MAIN].MACCenter;

            }

            //単位をcmへ
            float ma = m_paramPages[(int)W_MODE.MAIN].wingArea / 100;
            float ml = m_paramPages[(int)W_MODE.MAIN].MACLen / 10;
            //
            float hl = m_H_TailMomentArms / 10;

            float HTA = m_ht.Value * (ma * ml) / hl;

            float rhta = m_paramPages[(int)W_MODE.H_TAIL].wingArea / 100;
            float HVC = rhta * hl / (ma * ml);


            float ac = m_H_TailMomentArms * m_paramPages[(int)W_MODE.H_TAIL].wingArea 
                / (m_paramPages[(int)W_MODE.MAIN].wingArea + m_paramPages[(int)W_MODE.H_TAIL].wingArea);
            ac = m_paramPages[(int)W_MODE.MAIN].MACCenter + ac - (m_H_TailMomentArms * 0.1f);
            m_CG2 = ac;

            m_sb[(int)STAT.BODY].Value = m_BodyLength / 10;
            m_sb[(int)STAT.MAIN].Value = ma;
            m_sb[(int)STAT.H_TAIL].Value = m_paramPages[(int)W_MODE.H_TAIL].wingArea / 100;
            m_sb[(int)STAT.H_TAIL].Value2 = HTA;
            m_sb[(int)STAT.H_TAIL_VC].Value = HVC;

            if (m_twinVTailMode)
            {
                m_sb[(int)STAT.V_TAIL].Value = m_paramPages[(int)W_MODE.TV_TAIL].wingArea / 100;
            }else
            {
                m_sb[(int)STAT.V_TAIL].Value = m_paramPages[(int)W_MODE.V_TAIL].wingArea / 100;

            }
            float ms = m_paramPages[(int)W_MODE.MAIN].wingSpan / 10;
            float vl = m_V_TailMomentArms / 10;
            m_sb[(int)STAT.V_TAIL].Value2 = m_vt.Value * ma * ms / vl;

          
            m_sb[(int)STAT.V_TAIL_VC].Value = (m_sb[(int)STAT.V_TAIL].Value) * vl/ (ma * ms);

        }
        
        //----------------------------------------
        private void WingParams_CheckedChanged(object sender, EventArgs e)
        {
            calcStatus();
            setTwinVTailMode(m_rb[1].Checked);
        }

        //----------------------------------------
        protected virtual void OnValueChanged(EventArgs e)
        {
            if (valueChanged != null)
                valueChanged(this, e);

        }
        //----------------------------------------
        public void setTwinVTailMode(bool b)
        {
            if (m_refFlag) return;
            bool bak = m_refFlag;
            m_refFlag = true;

            m_twinVTailMode = b;

            if (m_rb[1].Checked != b)
            {
                m_rb[1].Checked = b;
            }
            if (m_rb[0].Checked == b)
            {
                m_rb[0].Checked = !b;
            }
            m_paramPages[2].Enabled = !b;
            m_paramPages[3].Enabled = b;

            int si = m_tc.SelectedIndex;
            if ((si == 2) && (b == true))
            {
                m_tc.SelectedIndex = 3;
            }
            if ((si == 3) && (b == false))
            {
                m_tc.SelectedIndex = 2;
            }
            OnValueChanged(new EventArgs());
            m_refFlag = bak;
        }
        
        //----------------------------------------
        public float bodyLength
        {
            get{return m_BodyLength;}
        }
        //----------------------------------------
        public float CG2
        {
            get { return m_CG2; }
        }
        //----------------------------------------
        public float V_TailMomentArms
        {
            get { return m_V_TailMomentArms; }
        }
        //----------------------------------------
        public float H_TailMomentArms
        {
            get { return m_H_TailMomentArms; }
        }
        //----------------------------------------
        public float tipOffsetSub(W_MODE md)
        {
            return m_paramPages[(int)md].wingTipOffset;
        }
        //----------------------------------------
        public float spanSub(W_MODE md)
        {
            return m_paramPages[(int)md].wingSpan;
        }
        //----------------------------------------
        public float rootSub(W_MODE md)
        {
            return m_paramPages[(int)md].wingRoot;
        }
        //----------------------------------------
        public PointF[] linesSub(W_MODE md)
        {
            return m_paramPages[(int)md].lines;
        }
        //----------------------------------------
        public float posSub(W_MODE md)
        {
            return m_paramPages[(int)md].pos;
        }
        //----------------------------------------
        public PointF[] MACSub(W_MODE md)
        {
            return m_paramPages[(int)md].MAC;
        }
        //----------------------------------------
        public PointF[] MACCenterLineSub(W_MODE md)
        {
            return m_paramPages[(int)md].MACCenterLine;
        }
        //----------------------------------------
        public float MACCenterSub(W_MODE md)
        {
            return m_paramPages[(int)md].MACCenter;
        }
        //----------------------------------------
        public PointF MACPointSub(W_MODE md)
        {
            return m_paramPages[(int)md].MACPoint;
        }
 


        //=============================================
        public PointF[] mainLines
        {
            get { return linesSub(W_MODE.MAIN); }
        }
        //----------------------------------------
        public float mainPos
        {
            get { return posSub(W_MODE.MAIN); }
        }
        //----------------------------------------
        public PointF[] mainMAC
        {
            get { return MACSub(W_MODE.MAIN); }
        }
        //----------------------------------------
        public PointF[] mainMACCenterLine
        {
            get { return MACCenterLineSub(W_MODE.MAIN); }
        }
        //----------------------------------------
        public float mainMACCenter
        {
            get { return MACCenterSub(W_MODE.MAIN); }
        }
        //----------------------------------------
        public PointF mainMACPoint
        {
            get { return MACPointSub(W_MODE.MAIN); }
        }
        //----------------------------------------
        public float mainWingCG
        {
            get
            {
                PointF [] m = MACSub(W_MODE.MAIN);

                return m[0].Y + (m[1].Y - m[0].Y) * m_cg.Value / 100.0f;
            }
        }
 
        //=============================================
        public PointF[] hTailLines
        {
            get { return linesSub(W_MODE.H_TAIL); }
        }
        //----------------------------------------
        public float hTailPos
        {
            get { return posSub(W_MODE.H_TAIL); }
        }
        //----------------------------------------
        public float hTailTipOffset
        {
            get { return tipOffsetSub(W_MODE.H_TAIL); }
        }
        //----------------------------------------
        public float hTailSpan
        {
            get { return spanSub(W_MODE.H_TAIL); }
        }
        //----------------------------------------
        public float hTailRoot
        {
            get { return rootSub(W_MODE.H_TAIL); }
        }
        //----------------------------------------
        public PointF[] hTailMAC
        {
            get { return MACSub(W_MODE.H_TAIL); }
        }
        //----------------------------------------
        public PointF[] hTailMACCenter
        {
            get { return MACCenterLineSub(W_MODE.H_TAIL); }
        }
        //----------------------------------------
        public PointF hTailMACPoint
        {
            get { return MACPointSub(W_MODE.H_TAIL); }
        }
        //=============================================
        public PointF[] VTailLines
        {
            get { return linesSub(W_MODE.V_TAIL); }
        }
        //----------------------------------------
        public float VTailPos
        {
            get { return posSub(W_MODE.V_TAIL); }
        }
        //----------------------------------------
        public float VTailRoot
        {
            get { return rootSub(W_MODE.V_TAIL); }
        }
        //----------------------------------------
        public PointF[] VTailMAC
        {
            get { return MACSub(W_MODE.V_TAIL); }
        }
        //----------------------------------------
        public PointF[] VTailMACCenter
        {
            get { return MACCenterLineSub(W_MODE.V_TAIL); }
        }
        //----------------------------------------
        public PointF VTailMACPoint
        {
            get { return MACPointSub(W_MODE.V_TAIL); }
        }
        //=============================================
        public PointF[] TVTailLines
        {
            get { return linesSub(W_MODE.TV_TAIL); }
        }
        //----------------------------------------
        public float TVTailPos
        {
            get { return posSub(W_MODE.TV_TAIL); }
        }
        //----------------------------------------
        public float TVTailRoot
        {
            get { return rootSub(W_MODE.TV_TAIL); }
        }
        //----------------------------------------
        public PointF[] TVTailMAC
        {
            get { return MACSub(W_MODE.TV_TAIL); }
        }
        //----------------------------------------
        public PointF[] TVTailMACCenter
        {
            get { return MACCenterLineSub(W_MODE.TV_TAIL); }
        }
        //----------------------------------------
        public PointF TVTailMACPoint
        {
            get { return MACPointSub(W_MODE.TV_TAIL); }
        }
        //----------------------------------------
        public bool isTVTailMode
        {
            get { return m_twinVTailMode; }
            set { setTwinVTailMode(value); }
        }
        //----------------------------------------
        public string toJson()
        {
            dynamic obj = new DynamicJson();
            obj.main = m_paramPages[(int)W_MODE.MAIN].Data;
            obj.htail = m_paramPages[(int)W_MODE.H_TAIL].Data;
            obj.vtail = m_paramPages[(int)W_MODE.V_TAIL].Data;
            obj.tvtail = m_paramPages[(int)W_MODE.TV_TAIL].Data;
            obj.isTwinTail = isTVTailMode;
            obj.htVC = m_ht.Value; //horizontal tail volume coefficient
            obj.vtVC = m_vt.Value; //horizontal tail volume coefficient
            obj.cg = m_cg.Value;
            return obj.ToString();
        }
        //----------------------------------------
        private float[] ArrayTo(object[] v)
        {
            float[] ret = new float[0];
            int l = v.Length;
            if (l > 0)
            {
                ret = new float[l];
                for (int i=0; i<l;i++)
                {
                    double b = (double)v[i];
                    ret[i] = (float)b;
                }
            }
            return ret;
        }
        //----------------------------------------
        //----------------------------------------
        public void fromJson(string s)
        {
            var js = DynamicJson.Parse(s);
           
            m_paramPages[(int)W_MODE.MAIN].Data = ArrayTo((object[])js.main);
            m_paramPages[(int)W_MODE.H_TAIL].Data = ArrayTo((object[])js.htail);

            m_paramPages[(int)W_MODE.V_TAIL].Data = ArrayTo((object[])js.vtail);
            m_paramPages[(int)W_MODE.TV_TAIL].Data = ArrayTo((object[])js.tvtail);
            isTVTailMode = js.isTwinTail;
            m_ht.Value = (float)js.htVC;
            m_vt.Value = (float)js.vtVC;
            m_cg.Value = (float)js.cg;
            calcStatus();
        }
        //----------------------------------------
        public void setDeAllf()
        {
            for (int i = 0; i < (int)W_MODE.COUNT; i++)
                m_paramPages[i].setDef((W_MODE)i);
        }
    }
}
