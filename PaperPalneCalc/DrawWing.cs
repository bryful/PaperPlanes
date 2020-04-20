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
    public class DrawWing : Control
    {
        private PointF m_dispP = new PointF(30, 10);
        private WingParams wp = null;
        //------------------------------------------------------------
        public DrawWing()
        {
            this.DoubleBuffered = true;
        }

        //------------------------------------------------------------
        private PointF DP(PointF p,float aX=0,float aY=0)
        {
            return new PointF(p.X + m_dispP.X + aX, p.Y + m_dispP.Y + aY);
        }
        //------------------------------------------------------------
        private PointF[] DP(PointF[] p, float aX = 0, float aY = 0)
        {
            int l = p.Length;
            PointF[] r = new PointF[l];
            if (l > 0)
            {
                for (int i=0; i<l;i++)
                {
                    r[i] = DP(p[i], aX, aY);
                }
            }
            return r;
        }
        //------------------------------------------------------------
        private void DrawWing_Load(object sender, EventArgs e)
        {

        }
        //------------------------------------------------------------
        public PointF DispPoint
        {
            get { return m_dispP; }
            set
            {
                m_dispP = value;
                this.Invalidate();
            }
        }
        //------------------------------------------------------------
        public WingParams WingParams
        {
            get { return wp; }
            set
            {
                wp = value;
                if (wp != null)
                {
                    wp.valueChanged += Wp_valueChanged;
                }
            }
        }

        //------------------------------------------------------------
        private void Wp_valueChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }
        //---------------------------------------------------------------------
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }
        //---------------------------------------------------------------------
        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            Pen p = new Pen(Color.Black);

            //白で塗りつぶし
            g.PageUnit = GraphicsUnit.Pixel;
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, this.Width, this.Height));

            g.PageUnit = GraphicsUnit.Millimeter;
            drawMomentArm(g, p);
            drawMain(g, p);
            drawVTail(g, p);
            drawHTail(g, p);
            drawBody(g, p);

            //枠線を描く
            g.PageUnit = GraphicsUnit.Pixel;
            p.Width = 1;
            g.DrawRectangle(p, new Rectangle(0, 0, this.Width - 1, this.Height - 1));

            p.Dispose();

        }
        //------------------------------------------------------------
        private void drawBody(Graphics g, Pen p)
        {
            if (wp == null) return;
            //胴体の描画
            p.Width = 0.4f;
            p.Color = Color.Black;
            g.DrawLine(p, m_dispP, new PointF(m_dispP.X, m_dispP.Y+ wp.bodyLength));
       }
        //------------------------------------------------------------
        private void drawMomentArm(Graphics g, Pen p)
        {
            if (wp == null) return;
            p.Width = 0.3f;
            p.Color = Color.LightGray;
            PointF s0 = new PointF(0, wp.mainPos + wp.mainMACCenter);
            PointF s1 = new PointF(0, wp.mainPos + wp.mainMACCenter + wp.H_TailMomentArms);

            float si1 = -15;
            float si2 = -20;

            g.DrawLine(p, DP(s0, si1), DP(s0, 0));
            g.DrawLine(p, DP(s0, si1),DP(s1, si1));
            g.DrawLine(p, DP(s1, si1), DP(s1, 0));

            s1 = new PointF(0, wp.mainPos + wp.mainMACCenter + wp.V_TailMomentArms);
            g.DrawLine(p, DP(s0, si2), DP(s0, 0));
            g.DrawLine(p, DP(s0, si2), DP(s1, si2));
            g.DrawLine(p, DP(s1, si2), DP(s1, 0));
        }
        //------------------------------------------------------------
        private void drawMain(Graphics g,Pen p)
        {
            if (wp == null) return;

            PointF [] mainLine = wp.mainLines;
            PointF[] macLine = wp.mainMAC;
            float pos = wp.mainPos;

 
            p.Width = 0.1f;
            p.Color = Color.Black;
            g.DrawPolygon(p, DP(wp.mainMACCenterLine,0,pos));


            p.Width = 0.4f;
            p.Color = Color.Black;
            float wingCG = wp.mainWingCG + wp.mainPos;
            g.DrawLine(p, DP(new PointF(0,wingCG),-5), DP(new PointF(10, wingCG), -5));

            p.Color = Color.LightGray;
            p.Width = 0.6f;
            wingCG = wp.CG2 + wp.mainPos;
            g.DrawLine(p, DP(new PointF(0, wingCG),-5), DP(new PointF(10, wingCG), -5));

            p.Width = 0.2f;
            p.Color = Color.Red;
            g.DrawPolygon(p, DP(macLine,0,pos));

            p.Width = 0.2f;
            p.Color = Color.Black;
            g.DrawPolygon(p, DP(mainLine, 0, pos));



        }
        //------------------------------------------------------------
        private void drawHTail(Graphics g, Pen p)
        {
            if (wp == null) return;

            PointF[] lines = wp.hTailLines;
            PointF[] macLine = wp.hTailMAC;
            float pos = wp.hTailPos + wp.mainPos;

 
            p.Width = 0.1f;
            p.Color = Color.Black;
            g.DrawPolygon(p, DP(wp.hTailMACCenter, 0, pos));


            p.Width = 0.2f;
            p.Color = Color.Red;
            g.DrawPolygon(p, DP(macLine, 0, pos));

            p.Width = 0.2f;
            p.Color = Color.Black;
            g.DrawPolygon(p, DP(lines, 0, pos));

        }
        //------------------------------------------------------------
        private void drawVTail(Graphics g, Pen p)
        {
            if (wp == null) return;
            if (wp.isTVTailMode)
            {
                drawTVTail(g, p);
            }
            else
            {
                drawNVTail(g, p);
            }

        }
        //------------------------------------------------------------
        private void drawNVTail(Graphics g, Pen p)
        {
            if (wp == null) return;

            PointF[] lines = wp.VTailLines;
            PointF[] macLine = wp.VTailMAC;
            float pos = wp.mainPos + wp.hTailPos - wp.VTailRoot + wp.VTailPos;

            float HPos = wp.hTailLines[1].X + 10;

 
            p.Width = 0.2f;
            p.Color = Color.DarkGray;
            g.DrawLine(p, DP(new PointF(0, pos)), DP(new PointF(HPos, pos)));
            g.DrawLine(p, DP(new PointF(0, pos+ lines[3].Y)), DP(new PointF(HPos, pos + lines[3].Y)));


            p.Width = 0.1f;
            p.Color = Color.Black;
            g.DrawPolygon(p, DP(wp.VTailMACCenter, HPos, pos));


            p.Width = 0.2f;
            p.Color = Color.Red;
            g.DrawPolygon(p, DP(macLine,  HPos, pos));

            p.Width = 0.2f;
            p.Color = Color.Black;
            g.DrawPolygon(p, DP(lines, HPos, pos));

        }
        //------------------------------------------------------------
        //------------------------------------------------------------
        private void drawTVTail(Graphics g, Pen p)
        {
            if (wp == null) return;

            PointF[] lines = wp.TVTailLines;
            PointF[] macLine = wp.TVTailMAC;
            float YPos = wp.mainPos+ wp.hTailPos + wp.hTailTipOffset+ wp.TVTailPos;

            float XPos = wp.hTailSpan/2;

            p.Width = 0.1f;
            p.Color = Color.Black;
            g.DrawPolygon(p, DP(wp.TVTailMACCenter, XPos, YPos));


            p.Width = 0.2f;
            p.Color = Color.Red;
            g.DrawPolygon(p, DP(macLine, XPos, YPos));

            p.Width = 0.2f;
            p.Color = Color.Black;
            g.DrawPolygon(p, DP(lines, XPos, YPos));


        }
        //------------------------------------------------------------
        public void saveImage(string path, bool rot=false)
        {
            int w = (int)(210.0 * 300.0 / 25.4 + 0.5);
            int h = (int)(297.0 * 300.0 / 25.4 + 0.5);

            Bitmap bmp = new Bitmap(w, h);
            bmp.SetResolution(300.0F, 300.0F);
            Graphics g = Graphics.FromImage(bmp);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            Pen p = new Pen(Color.Black);

            //白で塗りつぶし
            g.PageUnit = GraphicsUnit.Pixel;
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, bmp.Width, bmp.Height));

            g.PageUnit = GraphicsUnit.Millimeter;
            drawMain(g, p);
            drawVTail(g, p);
            drawHTail(g, p);
            drawBody(g, p);
            p.Dispose();
            g.Dispose();

            if (rot)
            {
                bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);

            }
            bmp.Save(path, System.Drawing.Imaging.ImageFormat.Png);




        }
    }
}
