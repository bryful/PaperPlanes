using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Imaging;

using System.Windows.Forms;


using Codeplex.Data;

namespace PaperPalneCalc
{
    class wingCalc
    {

        private float m_wingArea;

        private float m_wingSpan;
        private float m_wingRoot;
        private float m_wingTip;
        private float m_tipOffset;
        private float m_pos;

        //private float m_cg;

        private float m_MACCenterPercebt = 0.25f;

        private PointF m_MACpoint;
        private PointF[] m_MAC = new PointF[2];
        private float m_MACLength = 0;


        private PointF[] m_lines = new PointF[4];
        //===============================================
        public wingCalc()
        {
            m_wingArea = 0;
            m_pos = 0;

            m_wingSpan = 90;
            m_wingRoot = 50;
            m_wingTip = 30;
            m_tipOffset = 10;


            m_MACpoint = new PointF(0, 0);
            m_MAC[0] = new PointF(0, 0);
            m_MAC[1] = new PointF(0, 0);

            updateData();

        }
        //===============================================
        private bool crossPoint(PointF A, PointF B, PointF C, PointF D, ref PointF R)
        {
            R = new PointF(0, 0);

            double dBunbo = (B.X - A.X)
                  * (D.Y - C.Y)
                  - (B.Y - A.Y)
                  * (D.X - C.X);
            if (0 == dBunbo)
            {   // 平行
                return false;
            }

            PointF AC = new PointF(C.X - A.X, C.Y - A.Y);

            double dr = ((D.Y - C.Y) * AC.X
                         - (D.X - C.X) * AC.Y) / dBunbo;
            double ds = ((B.Y - A.Y) * AC.X
                         - (B.X - A.X) * AC.Y) / dBunbo;

            double x = A.X + dr * (B.X - A.X);
            double y = A.Y + ds * (B.Y - A.Y);
            R = new PointF((float)x, (float)y);

            return true;
        }
        //===============================================
        /// <summary>
        /// MAC交点
        /// </summary>
        public PointF MACPoint
        {
            get { return new PointF( m_MACpoint.X, m_MACpoint.Y); }
        }
        //===============================================
        /// <summary>
        /// MAC線を配列で返す
        /// </summary>
        public PointF[] MACLine
        {
            get
            {
                PointF[] r = new PointF[2];
                r[0] = m_MAC[0];
                r[1] = m_MAC[1];
                return r;
            }
        }
        //===============================================
        public float MACCenter
        {
            get
            {
                return m_MACLength * m_MACCenterPercebt + m_MAC[0].Y;
            }
        }

        //===============================================
        public PointF[] MACCenterLine
        {
            get
            {
                float l = MACCenter;
                PointF[] r = new PointF[2];
                r[0] = new PointF(0,l);
                r[1] = new PointF(m_MACpoint.X, l);
                return r;
            }
        }
        //===============================================
        /// <summary>
        /// MACの長さを返す
        /// </summary>
        public float MACLenｇｔｈ
        {
            get { return m_MACLength; }
        }
        //===============================================
        /// <summary>
        /// 翼の横幅
        /// </summary>
        public float wingSpan
        {
            get { return m_wingSpan; }

            set
            {
                float v = value;
                if (v < 10) v = 10;
                if (m_wingSpan != v)
                {
                    m_wingSpan = v;
                    updateData();
                }
            }
        }
        //===============================================
        public float wingRoot
        {
            get { return m_wingRoot; }

            set
            {
                float v = value;
                if (v < 10) v = 10;
                if (v < m_wingTip) v = m_wingTip;

                if (m_wingRoot != v)
                {
                    m_wingRoot = v;
                    updateData();
                }
            }
        }
        //===============================================
        public float wingTip
        {
            get { return m_wingTip; }

            set
            {
                float v = value;
                if (v < 10) v = 10;
                if (v > m_wingRoot) v = m_wingRoot;

                if (m_wingTip != v)
                {
                    m_wingTip = v;
                    updateData();
                }
            }
        }
        //===============================================
        public float wingTipOffset
        {
            get { return m_tipOffset; }

            set
            {
                float v = value;
                if (v < -m_wingTip) v = -m_wingTip;
                else if (v > m_wingRoot) v = m_wingRoot;
                if (m_tipOffset != v)
                {
                    m_tipOffset = v;
                    updateData();
                }
            }
        }
        //===============================================
        public void setSize(float s, float r, float t, float to)
        {
            if (s < 10) s = 10;


            if (t > r) t = r;
            if (to < -t) to = -t;
            if (to > r) to = r;

            if (to < -t) t = -t;
            if (to > r) to = r;

            if (r < t) r = t;
            if (t > r) t = r;




            bool b = false;
            if (m_wingSpan != s)
            {
                m_wingSpan = s;
                b = true;
            }
            if (m_wingRoot != r) {
                m_wingRoot = r;
                b = true;
            }
            if (m_wingTip != t) {
                m_wingTip = t;
                b = true;
            }
            if (m_tipOffset != to)
            {
                m_tipOffset = to;
                b = true;
            }
            if (b)
            {
                updateData();
            }

        }
        //===============================================
        public PointF[] lines
        {
            get
            {
                PointF[] r = new PointF[4];
                r[0] = m_lines[0];
                r[1] = m_lines[1];
                r[2] = m_lines[2];
                r[3] = m_lines[3];
                return r;
            }
        }
       
        //===============================================
        public float WingArea
        {

            get
            {
                return m_wingArea;
            }
        }
        //===============================================
        public float Pos
        {

            get
            {
                return m_pos;
            }
            set
            {
                m_pos = value;
            }
        }
        //===============================================
        public void updateData()
        {
            calcMACPoint();
            calArea();
            calcLines();
        }
        //===============================================
        /// <summary>
        /// 重心を計算
        /// </summary>
        private void calcGC()
        {
            //画像を作成
            //大きさを決める 1mmを1pxとする
            int w, h, hOffset;
            w = (int)(m_wingSpan + 1.0f);
            h = 0;
            hOffset = 0;
            if (m_tipOffset < 0)
            {
                hOffset = (int)(m_tipOffset * -1 + 1);
                h += hOffset;
            }
            float he = m_tipOffset + m_wingTip;
            if (he < m_wingRoot) he = m_wingRoot;
            h += (int)(he + 1);

            Bitmap bmp = new Bitmap(w, h, PixelFormat.Format24bppRgb);

            //翼を描く
            PointF[] ply = new PointF[4];
            ply[0] = new PointF(0, (float)hOffset);
            ply[1] = new PointF(m_wingSpan, (float)hOffset + m_tipOffset);
            ply[2] = new PointF(m_wingSpan, (float)hOffset + m_tipOffset + m_wingTip);
            ply[3] = new PointF(0, (float)hOffset + m_wingRoot);

            //画像を作成
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            SolidBrush b = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
            //黒で塗りつぶし
            g.FillRectangle(b,new Rectangle(0, 0, w, h));
            //白で翼を描く
            b = new SolidBrush(Color.FromArgb(255, 255, 255, 255));
            g.FillPolygon(b, ply);
            g.Dispose();
            b.Dispose();

            BitmapData _img = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
               System.Drawing.Imaging.ImageLockMode.ReadWrite,
               System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            IntPtr adr = _img.Scan0;

            double[] tbl = new double[h];

            for (int y=0; y<h; y++)
            {
                int pos = _img.Stride * y;
                double m = 0;
                for (int x =0; x<w; x++)
                {
                    int pos2 = x * 3 + pos;
                    byte v = System.Runtime.InteropServices.Marshal.ReadByte(adr, pos2);
                    if (v <= 0)
                    {
                    }
                    else if (v >= 255)
                    {
                        m += 1.0f;
                    }
                    else
                    {
                        m += (double)v / 255.0;
                    }
                }
                tbl[y] = m;
            }
            bmp.UnlockBits(_img);
            _img = null;
            bmp.Dispose();
            double gu, gd;
            gu = 0;
            gd = 0;
            for (int y = 0; y < h; y++)
            {
                gu += tbl[y] * (double)y;
                gd += tbl[y];
            }

            float c = (float)(gu / gd) - (float)hOffset;
            //m_cg = c;
           
        }
        //===============================================
        /// <summary>
        /// 翼の描画用のLine配列を作成
        /// </summary>
        private void calcLines()
        {
            m_lines[0] = new PointF(0, 0);
            m_lines[1] = new PointF(m_wingSpan, m_tipOffset);
            m_lines[2] = new PointF(m_wingSpan, m_tipOffset + m_wingTip);
            m_lines[3] = new PointF(0, m_wingRoot);

        }
        //===============================================
        public float[] Data
        {
            get
            {
                float[] ret = new float[5];
                ret[0] = m_wingSpan;
                ret[1] = m_wingRoot;
                ret[2] = m_wingTip;
                ret[3] = m_tipOffset;
                ret[4] = m_pos;
                return ret;

            }
            set
            {
                int r = value.Length;
                if (r>=5)
                {
                    m_wingSpan = value[0];
                    m_wingRoot = value[1];
                    m_wingTip = value[2];
                    m_tipOffset = value[3];
                    m_pos = value[4];
                    updateData();
                }
            }
        }
        public dynamic jsonData
        {
            get
            {
                dynamic ret = new DynamicJson();

                ret.Add((double)m_wingSpan);
                ret.Add((double)m_wingRoot);
                ret.Add((double)m_wingTip);
                ret.Add((double)m_tipOffset);
                ret.Add((double)m_pos);
                return ret;
            }
            set
            {
                if (value.IsArray)
                {
                    int c = value.Count;
                    if (c >= 5)
                    {
                        m_wingSpan = (float)value[0];
                        m_wingRoot = (float)value[1];
                        m_wingTip = (float)value[2];
                        m_tipOffset = (float)value[3];
                        m_pos = (float)value[4];
                        updateData();
                    }
                }
            }
        }
        //===============================================
        /// <summary>
        /// 面積を計算する
        /// </summary>
        private void calArea()
        {
            double area = 0;
            if (m_tipOffset < 0)
            {
                area = (-m_tipOffset * m_wingSpan) / 2;
                area += (m_wingTip + m_tipOffset) * m_wingSpan;
            }else if (m_tipOffset + m_wingTip> m_wingRoot)
            {
                area = (m_tipOffset + m_wingTip - m_wingRoot) * m_wingSpan / 2;
                area += ( (m_wingRoot - m_tipOffset) + m_wingRoot)* m_wingSpan / 2;
            }else
            {
                area += (m_wingRoot + m_wingRoot) * m_wingSpan / 2;

            }
            m_wingArea = (float)area;
        }
        //===============================================
        //===============================================
        /// <summary>
        /// MACの交点を求める
        /// </summary>
        private void calcMACPoint()
        {
            m_MACpoint = new PointF(0, -1);
            m_MAC[0] = new PointF(0, 0);
            m_MAC[1] = new PointF(0, 0);

            PointF cp = new PointF(0, 0);
            PointF mac0 = new PointF(0, 0);
            PointF mac1 = new PointF(0, 0);

            //まず翼の中心線
            PointF la0 = new PointF(0, m_wingRoot / 2);
            PointF la1 = new PointF(m_wingSpan, m_tipOffset + (m_wingTip / 2));

            PointF lb0 = new PointF(0, m_wingRoot + m_wingTip);
            PointF lb1 = new PointF(m_wingSpan, m_tipOffset - m_wingRoot);

            PointF r = new PointF(0, 0);
            if (crossPoint(la0, la1, lb0, lb1, ref r))
            {
                m_MACpoint = r;
            }
            else
            {
                return;
            }
            //
            la0 = new PointF(0, 0);
            la1 = new PointF(m_wingSpan, m_tipOffset);
            lb0 = new PointF(0, m_wingRoot);
            lb1 = new PointF(m_wingSpan, m_tipOffset + m_wingTip);

            PointF m0 = new PointF(m_MACpoint.X, -(m_wingRoot + m_wingTip));
            PointF m1 = new PointF(m_MACpoint.X, (m_tipOffset + m_wingTip));

            if (crossPoint(la0, la1, m0, m1, ref r))
            {
                m_MAC[0] = r;
            }
            if (crossPoint(lb0, lb1, m0, m1, ref r))
            {
                m_MAC[1] = r;
            }
            m_MACLength = m_MAC[1].Y - m_MAC[0].Y;
            //m_wingCG = m_MAC[0].Y + (m_MACLength * m_wingCGPercent);

        }

    }
}
