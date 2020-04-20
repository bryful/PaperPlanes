using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace PaperPlanes
{
	public class MAC
	{
		private float m_Area = 0;
		private PointF[] m_MACLine = new PointF[2];


		private float m_Span = 90;
		private float m_Root = 50;
		private float m_Tip = 30;
		private float m_TipOffset = 10;

		public float Area { get { return m_Area; } }
		public PointF [] MacLine { get { return m_MACLine; } }

		public float Span
		{
			get { return m_Span; }
			set { m_Span = value;Update(); }
		}
		public float Root
		{
			get { return m_Root; }
			set { m_Root = value;Update(); }
		}
		public float Tip
		{
			get { return m_Tip; }
			set { m_Tip = value;Update(); }
		}
		public float TipOffset
		{
			get { return m_TipOffset; }
			set { m_TipOffset = value;Update(); }
		}


		public MAC(float span, float root, float tip, float tipOffset)
		{
			m_Span = span;
			m_Root = root;
			m_Tip = tip;
			m_TipOffset = tipOffset;


			m_MACLine[0] = new PointF(0, 0);
			m_MACLine[1] = new PointF(0, 0);
			Update();

		}
		//===============================================
		/// <summary>
		/// 交点を求める
		/// </summary>
		/// <param name="A"></param>
		/// <param name="B"></param>
		/// <param name="C"></param>
		/// <param name="D"></param>
		/// <param name="R"></param>
		/// <returns></returns>
		private bool CrossPoint(PointF A, PointF B, PointF C, PointF D, ref PointF R)
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
		private void CalcArea()
		{
			m_Area = (m_Root + m_Tip) * (m_Span / 2);// *2/2
		}
		private void CalcMac()
		{
			m_MACLine[0] = new PointF(0, 0);
			m_MACLine[1] = new PointF(0, 0);
			//まず翼の中央線を求める（先端と根本の半分を結ぶ線）
			PointF[] Line0 = new PointF[2];
			Line0[0] = new PointF(m_Root / 2, 0);
			Line0[1] = new PointF(m_TipOffset +m_Tip/2, m_Span/2);

			PointF[] Line1 = new PointF[2];
			Line1[0] = new PointF(m_Root+m_Tip, 0);
			Line1[1] = new PointF(m_TipOffset - m_Root,  m_Span/2);

			//交点を求める
			PointF mc = new PointF(0, 0);
			if (CrossPoint(Line0[0],Line0[1],Line1[0],Line1[1],ref mc)==false)
			{
				return;
			}
			//交点の水平線と翼の交点を求めてMACを得る
			Line0[0] = new PointF(-m_Root, mc.Y);
			Line0[1] = new PointF(m_Root*2,mc.Y);

			Line1[0] = new PointF(0, 0);
			Line1[1] = new PointF(m_TipOffset,  m_Span/2);
			PointF mc0 = new PointF(0, 0);
			if (CrossPoint(Line0[0],Line0[1],Line1[0],Line1[1],ref mc0)==false)
			{
				return;
			}
			Line1[0] = new PointF(m_Root, 0);
			Line1[1] = new PointF(m_TipOffset+m_Tip,  m_Span/2);
			PointF mc1 = new PointF(0, 0);
			if (CrossPoint(Line0[0],Line0[1],Line1[0],Line1[1],ref mc1)==false)
			{
				return;
			}
			m_MACLine[0] = mc0;
			m_MACLine[1] = mc1;

		}

		private void Update()
		{
			CalcArea();
			CalcMac();
		}
	}
}
