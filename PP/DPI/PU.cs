using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP
{
    class PU
    {
        public const float DefDPI = 81.0f;
        //-----------------------------------------------------------------
        static public float pp2mm(float p, float dpi = 300)
        {
            return (float)(p * 25.4 / dpi);
        }
        static public float mm2pp(float m, float dpi = 300)
        {
            return (float)((m * dpi / 25.4));
        }
        //-----------------------------------------------------------------
        static public float ABS(float v)
        {
            float ret = v;
            if (ret < 0) ret += -1;
            return (float)ret;
        }
        //-----------------------------------------------------------------
        /// <summary>
        /// 斜辺から幅を求める
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        static public float LenWidth(float l,float r)
        {
            int r1 = (int)(r * 10000 + 0.5) % (10000 * 360);
            if (r1 < 0) r1 += 360*10000;
            double r2 = (double)r1 / 10000;

            return (float)((double)l * Math.Cos(r2 * Math.PI / 180));
        }
        //-----------------------------------------------------------------
        static public float LenHeight(float l, float r)
        {
            int r1 = (int)(r * 10000 + 0.5) % (10000 * 360);
            if (r1 < 0) r1 += 360 * 10000;
            double r2 = (double)r1 / 10000;

            return (float)((double)l * Math.Sin(r2 * Math.PI / 180));
        }
        //-----------------------------------------------------------------
        static public float Display_DPI(int w,int h, double sz)
        {
            double r = Math.Atan2(h, w);

            double sz2 = sz * Math.Cos(r);

            double d = w / sz2;
            return (float)d;
        }
    }
}
