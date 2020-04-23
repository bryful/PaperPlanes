using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperPlanes
{
	public class PP
	{
		/// <summary>
		/// 空力中心を求めるパーセント値
		/// </summary>
		static public readonly float AerodynamicCenterPar = 0.25f;
		/// <summary>
		/// MACから求める重心位置のパーセント値
		/// </summary>
		static public readonly float CengerOfGravityPar = 0.85f;



		 static public float P2MM(float p, float dpi = 300)
        {
            return (float)((double)p * 25.4 / (double)dpi);
        }
        static public float MM2P(float m, float dpi = 300)
        {
            return (float)(((double)m * (double)dpi / 25.4));
        }
		static public float Display_DPI(int w,int h, float sz)
        {
            double r = Math.Atan2(h, w);

            double sz2 = sz * Math.Cos(r);

            double d = w / sz2;
            return (float)d;
        }
		
		
	}
}
