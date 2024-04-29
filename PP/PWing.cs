using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PP
{
	public class PWing : Component
	{
		bool refFlag = false;
		public event EventHandler WingChanged;

		protected virtual void OnWingChanged(EventArgs e)
		{
			if (refFlag) return;
			WingChanged?.Invoke(this, e);
		}
		//デリゲートの宣言
		//TimeEventArgs型のオブジェクトを返すようにする
		public delegate void TailModeChangedEventHandler(object sender, TailModeChangedEventArgs e);

		//イベントデリゲートの宣言
		public event TailModeChangedEventHandler TailModeChanged;

		protected virtual void OnTailModeChanged(TailModeChangedEventArgs e)
		{
			if (refFlag) return;
			if (TailModeChanged != null)
			{
				TailModeChanged(this, e);
			}
		}
		private PWingBase m_Main = new PWingBase();
		private PWingBase m_Hor = new PWingBase();
		private PWingBase m_Ver = new PWingBase();


		private TailMode m_TailMode = TailMode.Normal;
		public TailMode TailMode
		{
			get { return m_TailMode; }
			set
			{
				if (refFlag) return;
				refFlag = true;
				bool b = (m_TailMode != value);
				m_TailMode = value;
				Calc();
				refFlag = false;
				if (b)
				{
					OnWingChanged(new EventArgs());
					OnTailModeChanged(new TailModeChangedEventArgs(m_TailMode));
				}
			}
		}
		public float Dpi
		{
			get { return m_Main.Dpi; }
			set
			{
				m_Main.Dpi = value;
				m_Hor.Dpi = value;
				m_Ver.Dpi = value;
				Calc();
			}
		}
		public float MainPos
		{
			get { return m_Main.PosY; }
			set
			{
				m_Main.PosY = value;
			}
		}
		public float MainSpan
		{
			get { return m_Main.Span; }
			set
			{
				m_Main.Span = value;
			}
		}
		public float MainRoot
		{
			get { return m_Main.Root; }
			set
			{
				m_Main.Root = value;
			}
		}
		public float MainTip
		{
			get { return m_Main.Tip; }
			set
			{
				m_Main.Tip = value;
			}
		}
		public float MainSwept
		{
			get { return m_Main.Swept; }
			set
			{
				m_Main.Swept = value;
			}
		}
		public float MainTipOffset
		{
			get { return m_Main.TipOffset; }
		}
		public float MainArea
		{
			get { return m_Main.Area; }
		}

		public float[] MainParams
		{
			get { return m_Main.Params; }
			set
			{
				m_Main.Params = value;
				Calc();
			}
		}
		public PointF[] MainLines(PointF d)
		{
			return m_Main.GetLines(d);
		}
		public PointF[] MainMACLines(PointF d)
		{
			return m_Main.GetMACLines(d);
		}
		public PointF[] HTailLines(PointF d)
		{
			return m_Hor.GetLines(d);
		}
		public PointF[] VTailLines(PointF d)
		{
			return m_Ver.GetLines(d);
		}
		public PointF[] HTailMACLines(PointF d)
		{
			return m_Hor.GetMACLines(d);
		}
		public PointF[] VTailMACLines(PointF d)
		{
			return m_Ver.GetMACLines(d);
		}

		public float HTailPos
		{
			get { return m_Hor.PosY; }
			set
			{
				m_Hor.PosY = value;
			}
		}
		public float HTailSpan
		{
			get { return m_Hor.Span; }
			set
			{
				m_Hor.Span = value;
			}
		}
		public float HTailRoot
		{
			get { return m_Hor.Root; }
			set { m_Hor.Root = value; }
		}
		public float HTailTip
		{
			get { return m_Hor.Tip; }
			set
			{
				m_Hor.Tip = value;
			}
		}
		public float HTailSwept
		{
			get { return m_Hor.Swept; }
			set { m_Hor.Swept = value; }
		}
		public float HTailTipOffset
		{
			get { return m_Hor.TipOffset; }
		}
		public float HTailArea
		{
			get { return m_Hor.Area; }
		}
		public float[] HTailParams
		{
			get { return m_Hor.Params; }
			set
			{
				m_Hor.Params = value;
				Calc();
			}
		}
		// ********************************
		public float VTailPos
		{
			get
			{
				return m_Ver.PosY;
			}
			set
			{
				if (m_TailMode == TailMode.Twin)
				{
					float f = m_Hor.PosY + m_Hor.TipOffset;
					if ((m_Ver.PosY != f) || (m_Ver.PosX != m_Hor.Span))
					{
						m_Ver.SetPosXYRoot(m_Hor.Span, f, m_Hor.Tip);
					}
				}
				else
				{
					m_Ver.PosY = value;
				}
			}
		}
		public float VTailSpan
		{
			get { return m_Ver.Span; }
			set { m_Ver.Span = value; }
		}
		public float VTailRoot
		{
			get
			{
				if (m_TailMode == TailMode.Twin)
				{
					if (m_Ver.Root != m_Hor.Tip)
					{
						m_Ver.Root = m_Hor.Tip;
					}
				}
				return m_Ver.Root;
			}
			set
			{
				if (m_TailMode == TailMode.Twin)
				{
					if (m_Ver.Root != m_Hor.Tip)
					{
						m_Ver.Root = m_Hor.Tip;
					}
				}
				else
				{
					m_Ver.Root = value;
				}
			}
		}
		public float VTailTip
		{
			get { return m_Ver.Tip; }
			set { m_Ver.Tip = value; }
		}
		public float VTailSwept
		{
			get { return m_Ver.Swept; }
			set
			{
				m_Ver.Swept = value;
			}
		}
		public float VTailTipOffset
		{
			get { return m_Ver.TipOffset; }
		}
		public float VTailArea
		{
			get { return m_Ver.Area; }
		}
		public float[] VTailParams
		{
			get { return m_Ver.Params; }
			set
			{
				m_Ver.Params = value;
				Calc();
			}
		}
		// ********************************
		private float m_FuselageLength = 17.0f;
		private float m_DistanceHTail = 0;
		private float m_DistanceVTail = 0;

		private float m_HTailVR_tentative = 1.2f;
		private float m_VTailVR_tentative = 0.05f;
		private float m_CenterG = 85;

		private float m_HTailAreaT = 0;
		private float m_HTailVR = 0;

		private float m_VTailAreaT = 0;
		private float m_VTailVR = 0;

		private float m_CenterGP = 0;
		private float m_CenterGReal = 0;
		// ********************************
		public float DistanceHTail
		{
			get

			{
				return m_DistanceHTail;
			}
		}
		public float DistanceVTail
		{
			get
			{
				return m_DistanceVTail;
			}
		}
		public float FuselageLength
		{
			get
			{
				return m_FuselageLength;
			}
		}
		public float HTailVR_tentative
		{
			get { return (m_HTailVR_tentative); }
			set
			{
				m_HTailVR_tentative = value;
				Calc();
				OnWingChanged(new EventArgs());
			}
		}
		public float VTailVR_tentative
		{
			get { return (m_VTailVR_tentative); }
			set
			{
				m_VTailVR_tentative = value;
				Calc();
				OnWingChanged(new EventArgs());
			}
		}
		public float CenterG
		{
			get { return (m_CenterG); }
			set
			{
				m_CenterG = value;
				Calc();
				OnWingChanged(new EventArgs());
			}
		}
		public float CenterGP
		{
			get { return m_CenterGP; }
		}
		public float CenterGReal
		{
			get { return m_CenterGReal; }
		}
		// ********************************
		public float[] ParamsT
		{
			get
			{
				float[] ret = new float[]
				{
					m_HTailVR_tentative,
					m_VTailVR_tentative,
					m_CenterG
				};
				return ret;
			}
			set
			{
				bool b = false;
				if (value.Length >= 3)
				{
					if (m_HTailVR_tentative != value[0]) { m_HTailVR_tentative = value[0]; b = true; }
					if (m_VTailVR_tentative != value[1]) { m_VTailVR_tentative = value[1]; b = true; }
					if (m_CenterG != value[2]) { m_CenterG = value[2]; b = true; }
				}
				if (b) OnWingChanged(new EventArgs());
			}
		}

		public float[] ParamsC
		{
			get
			{
				float va = m_Ver.Area;
				if (m_TailMode== TailMode.Twin) va *= 2;
				float[] ret = new float[]
				{
					m_FuselageLength,
					m_Main.Area*2,

					m_DistanceHTail,
					m_Hor.Area*2,
					m_HTailAreaT,
					m_HTailVR,

					m_DistanceVTail,
					va,
					m_VTailAreaT,
					m_VTailVR,
				};
				return ret;
			}
		}
		// ********************************

		public void Calc()
		{
			// Twin
			if (m_TailMode == TailMode.Twin)
			{
				m_Ver.SetPosXYRoot(m_Hor.Span, m_Hor.PosY + m_Hor.TipOffset, m_Hor.Tip);
			}
			else
			{
				m_Ver.PosX = 0;
			}
			m_DistanceHTail = m_Hor.AC.Ymm - m_Main.AC.Ymm;
			m_DistanceVTail = m_Ver.AC.Ymm - m_Main.AC.Ymm;

			float a = m_Hor.Root + m_Hor.PosY;
			if (m_TailMode == TailMode.Normal)
			{
				float b = m_Ver.Root + m_Hor.PosY;
				if (a < b) a = b;

			}
			m_FuselageLength = a;

			float MArea = m_Main.Area * 2;
			float HArea = m_Hor.Area * 2;
			float VArea = m_Ver.Area;
			float MSpan = m_Main.Span * 2;

			m_HTailAreaT = m_HTailVR_tentative * MArea * m_Main.MACLineLength / m_DistanceHTail;
			m_HTailVR = HArea * m_DistanceHTail / (MArea * m_Main.MACLineLength);

			if (m_TailMode == TailMode.Twin)
			{
				VArea *= 2;
			}
			m_VTailAreaT = m_VTailVR_tentative * MArea * MSpan / m_DistanceVTail;
			m_VTailVR = VArea * m_DistanceVTail / (MArea * MSpan);


			m_CenterGP = m_Main.MACLine[0].Ymm + m_Main.MACLineLength * m_CenterG / 100;

			float y1 = m_Main.MACLine[0].Ymm + m_Main.MACLineLength / 2;
			float y2 = m_Hor.MACLine[0].Ymm + m_Hor.MACLineLength / 2;
			float y3 = m_Ver.MACLine[0].Ymm + m_Ver.MACLineLength / 2;

			float m1 = m_Main.Area*2;
			float m2 = m_Hor.Area*2;
			float m3 = m_Ver.Area;
			if (m_TailMode == TailMode.Twin) m3 *= 2;
			m_CenterGReal = (m1 * y1 + m2 * y2 + m3 * y3) / (m1 + m2 + m3);

		}
		// ********************************
		// ********************************
		public PWing()
		{
			m_Main.CreateIndex(0);
			m_Hor.CreateIndex(4);
			m_Ver.CreateIndex(8);
			m_Hor.PosY = 100;
			m_Hor.Span = 40;
			m_Hor.Root = 20;
			m_Hor.Tip = 10;
			m_Hor.Swept = 5;

			m_Ver.PosY = 80;
			m_Ver.Span = 30;
			m_Ver.Root = 20;
			m_Ver.Tip = 10;
			m_Ver.Swept = 10;


			Calc();
			m_Main.WingChanged += (sender, e) => { Calc(); OnWingChanged(new EventArgs()); };
			m_Hor.WingChanged += (sender, e) => { Calc(); OnWingChanged(new EventArgs()); };
			m_Ver.WingChanged += (sender, e) => { Calc(); OnWingChanged(new EventArgs()); };
		}
		private int m_SelectedIndex = -1;
		public int SelectedIndex { get { return m_SelectedIndex; } }

		public int IsIn(float x, float y)
		{
			int ret = -1;
			m_SelectedIndex = -1;
			for (int i = 0; i < 4; i++)
			{
				if (m_Main.IsInPoint(i, x, y))
				{
					ret = i;
					break;
				}
			}
			if (ret < 0)
			{
				for (int i = 0; i < 4; i++)
				{
					if (m_Hor.IsInPoint(i, x, y))
					{
						ret = i + 4;
						break;
					}
				}
			}
			if (ret < 0)
			{
				for (int i = 0; i < 4; i++)
				{
					if (m_Ver.IsInPoint(i, x, y))
					{
						ret = i + 8;
						break;
					}
				}
			}

			m_SelectedIndex = ret;
			return ret;
		}
		public void PushPrm()
		{
			m_Main.PushPrm();
			m_Hor.PushPrm();
			m_Ver.PushPrm();
		}
		public void Move(float x, float y)
		{
			if (m_SelectedIndex < 0) return;
			switch (m_SelectedIndex)
			{
				case 0:
					m_Main.AddPosY(y);
					break;
				case 1:
					m_Main.AddWingEdge(x, y);
					break;
				case 2:
					m_Main.AddTip(y);
					break;
				case 3:
					m_Main.AddRoot(y);
					break;
				case 4:
					m_Hor.AddPosY(y);
					Calc();
					break;
				case 5:
					m_Hor.AddWingEdge(x, y);
					Calc();
					break;
				case 6:
					m_Hor.AddTip(y);
					Calc();
					break;
				case 7:
					m_Hor.AddRoot(y);
					Calc();
					break;
				case 8:
					m_Ver.AddPosY(y);
					break;
				case 9:
					m_Ver.AddWingEdge(x, y);
					break;
				case 10:
					m_Ver.AddTip(y);
					break;
				case 11:
					m_Ver.AddRoot(y);
					break;
			}
		}
		public string ToJson()
		{
			JsonObject obj = new JsonObject();
			obj.Add("Main", m_Main.JObj);
			obj.Add("HTail", m_Hor.JObj);
			obj.Add("VTail", m_Ver.JObj);
			obj.Add("TailMode", (int)m_TailMode);


			return obj.ToJsonString();
		}
		public void FromJson(string code)
		{
			try
			{
				if (code == "") return;
				var doc = JsonNode.Parse(code);
				if (doc != null)
				{
					JsonObject json = (JsonObject)doc;
					int v = GetInt(json, "TailMode");
					if ((v >= 0) && (v < 2))
					{
						this.TailMode = (TailMode)v;
					}
					JsonObject a = GetObj(json, "Main");
					if(a != null)
					{
						m_Main.JObj = a;
					}
					a = GetObj(json, "HTail");
					if (a != null)
					{
						m_Hor.JObj = a;
					}
					a = GetObj(json, "VTail");
					if (a != null)
					{
						m_Ver.JObj = a;
					}
					Calc();
				}
			}
			catch
			{
			}
			return;
		}
		public bool Load(string p)
		{
			bool ret = false;

			try
			{
				if (File.Exists(p) == true)
				{
					string str = File.ReadAllText(p);
					if (str != "")
					{
						FromJson(str);
						ret = true;
					}
				}
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		public bool Save(string p)
		{
			bool ret = false;
			try
			{
				string js = ToJson();
				File.WriteAllText(p, js);
				ret = true;
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		private JsonObject GetObj(JsonObject obj, string key)
		{
			JsonObject ret = null;
			if (key == "") return ret;
			try
			{
				if (obj.ContainsKey(key))
				{
					ret = obj[key].AsObject();
				}
			}
			catch
			{
				ret = null;
			}
			return ret;
		}
		public int GetInt(JsonObject obj, string key)
		{
			int ret = -1;
			if (key == "") return ret;
			try
			{
				if (obj.ContainsKey(key))
				{
					ret = obj[key].GetValue<int>();
				}
			}
			catch
			{
				ret = -1;
			}
			return ret;
		}
	}
	public enum TailMode
	{
		Normal = 0,
		Twin
	}
	public class TailModeChangedEventArgs : EventArgs
	{
		public TailMode Mode;
		public TailModeChangedEventArgs(TailMode v)
		{
			Mode = v;
		}
	}
}
