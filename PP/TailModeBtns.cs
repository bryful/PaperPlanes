using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PP
{
	public class TailModeBtns :Control
	{
		private PCanvas m_canvas = null;
		[Category("PaperPlane")]
		public PCanvas Canvas
		{
			get { return m_canvas; }
			set 
			{ 
				m_canvas = value;
				if (m_canvas != value) 
				{
					this.TailMode = m_canvas.TailMode;
					m_canvas.Wing.TailModeChanged += (sender, e) =>{ this.TailMode = e.Mode;};
					this.TailModeChanged += (sender, e) =>
					{
						m_canvas.TailMode = this.TailMode;
					};
				}
			}
		}

		//デリゲートの宣言
		//TimeEventArgs型のオブジェクトを返すようにする
		public delegate void TailModeChangedEventHandler(object sender, TailModeChangedEventArgs e);

		//イベントデリゲートの宣言
		public event TailModeChangedEventHandler TailModeChanged;

		protected virtual void OnTailModeChanged(TailModeChangedEventArgs e)
		{
			Debug.WriteLine("aaaa");
			if (TailModeChanged != null)
			{
				Debug.WriteLine("BBBBB");
				TailModeChanged(this, e);
			}
		}
		private RadioButton m_rbNormal = new RadioButton();
		private RadioButton m_rbTwin = new RadioButton();
		[Category("PaperPlane")]
		public string [] Caption
		{
			get 
			{
				string[] r = new string[2];
				r[0] = m_rbNormal.Text;
				r[1] = m_rbTwin.Text;
				return r; 
			}
			set 
			{
				if (value.Length>=2)
				{
					m_rbNormal.Text = value[0];
					m_rbTwin.Text = value[1];
				}
			}
		}
		[Category("PaperPlane")]
		public TailMode TailMode
		{
			get 
			{
				TailMode tm = TailMode.Normal;
				if (m_rbTwin.Checked)
				{
					tm = TailMode.Twin;
				}
				return tm; 
			}
			set 
			{
				TailMode tm = TailMode;

				bool b = (tm != value);
				switch(value)
				{
					case TailMode.Twin:
						m_rbTwin.Checked = true;
						break;
					case TailMode.Normal:
					default:
						m_rbNormal.Checked = true;
						break;
				}
				if (b) OnTailModeChanged(new TailModeChangedEventArgs(tm));
			}
		}

		public new Font Font
		{
			get { return base.Font; }
			set 
			{ 
				base.Font = value;
				m_rbNormal.Font = value;
				m_rbTwin.Font = value;
				ChkSize();
			}
		}
		public TailModeBtns()
		{
			m_rbNormal.Tag = 0;
			m_rbNormal.AutoSize = false;
			m_rbNormal.Text = "Normal";
			m_rbTwin.Tag = 1;
			m_rbTwin.AutoSize = false;
			m_rbTwin.Text = "Twin";
			m_rbNormal.Click+= (sender, e) =>
			{
				if(m_canvas != null)
				{
					m_canvas.TailMode = this.TailMode;
				}
			};
			m_rbTwin.Click += (sender, e) =>
			{
				if (m_canvas != null)
				{
					m_canvas.TailMode = this.TailMode;
				}
			};


			this.Controls.Add(m_rbNormal);
			this.Controls.Add(m_rbTwin);
			ChkSize() ;
		}
		private void ChkSize()
		{
			int w = (this.Width-20)/2;
			int h = (this.Height - 20);

			m_rbNormal.Location = new Point(10, 13);
			m_rbNormal.Size = new Size(w, h);
			m_rbTwin.Location = new Point(w+10, 13);
			m_rbTwin.Size = new Size(w, h);
		}
		protected override void OnResize(EventArgs e)
		{
			ChkSize();
			base.OnResize(e);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			using(Pen p = new Pen(ForeColor, 1))
			{
				Graphics g = e.Graphics;
				g.DrawRectangle(p,new Rectangle(0,0,this.Width-1,this.Height-1));
			}
		}
	}
	// **************************************************************
	public class TailModeChangedEventArgs : EventArgs
	{
		public TailMode Mode;
		public TailModeChangedEventArgs(TailMode v)
		{
			Mode = v;
		}
	}
}
