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

using Codeplex.Data;

namespace PaperPalneCalc
{

    public partial class Form1 : Form
    {
        const string defFileName = "PaperPlaneCalc_def.json";
        const string bakFileName = "PaperPlaneCalc_bak.json";
        const string prefFileName = "PaperPlaneCalc.json";
        private string m_filename = "";
        /// <summary>
        /// 
        /// </summary>
         public Form1()
        {
            InitializeComponent();
        }
        //-----------------------------------------
        public bool save(string p)
        {
            bool ret = false;
            try
            {
                string js = wingParams.toJson();
                System.IO.File.WriteAllText(p, js, Encoding.GetEncoding("UTF-8"));
                ret = true;
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
        //-----------------------------------------
        public bool load(string p)
        {
            bool ret = false;
            if (System.IO.File.Exists(p))
            {
                if (Path.GetExtension(p).ToLower() != ".json")
                {
                    return ret;
                }
                try
                {
                    string s = System.IO.File.ReadAllText(p, Encoding.GetEncoding("UTF-8"));
                    wingParams.fromJson(s);
                    ret = true;
                }
                catch
                {
                    ret = false;
                }
            }
            return ret;
        }
        //-----------------------------------------
        public string bakFilePath()
        {
            string p = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            p = System.IO.Path.Combine(p, bakFileName);
            return p;
        }
        //-----------------------------------------
        public string defFilePath()
        {
            string p = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            p = System.IO.Path.Combine(p, defFileName);
            return p;
        }
        //-----------------------------------------
        public string Pref_FileName()
        {
            string p = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            p = System.IO.Path.Combine(p, prefFileName);
            return p;
        }
        //-----------------------------------------
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            PrefSave();
        }
        //-----------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            PrefLoad();
            string[] files = System.Environment.GetCommandLineArgs();
            if (files.Length>=1)
            {
                foreach(string n in files)
                {
                    if (load(n) == true) break;
                }
            }
        }
        //-----------------------------------------
        public void PrefSave()
        {
            save(bakFilePath());
            StatusSave(Pref_FileName());
        }
        //-----------------------------------------
        public void PrefLoad()
        {
            if (File.Exists(defFilePath())==false)
            {
                saveDef();
            }
            if (load(bakFilePath()) == false)
            {
                load(defFilePath());

            }
            StatusLoad(Pref_FileName());

        }
        //-----------------------------------------
        public bool loadDef()
        {
            return load(defFilePath());
        }
        //-----------------------------------------
        public void saveDef()
        {
            save(defFilePath());
        }
        //-----------------------------------------
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LoadDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (m_filename == "")
            {
                ofd.FileName = "PaperPlane.json";
            }else
            {
                ofd.FileName = Path.GetFileName(m_filename);
                ofd.InitialDirectory =Path.GetDirectoryName(m_filename);
            }
            ofd.Filter = "jsonファイル(*.json)|*.json|すべてのファイル(*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.Title = "Open PerperPlaneCalc json";
            ofd.RestoreDirectory = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (load(ofd.FileName))
                {
                    m_filename = ofd.FileName;
                }
            }
        }
        public void SaveDialog()
        {
            SaveFileDialog sfd = new SaveFileDialog();

            if (m_filename == "")
            {
                sfd.FileName = "PaperPlane.json";
            }
            else
            {
                sfd.FileName = Path.GetFileName(m_filename);
                sfd.InitialDirectory = Path.GetDirectoryName(m_filename);
            }
            sfd.Filter = "jsonファイル(*.json)|*.json|すべてのファイル(*.*)|*.*";
            sfd.FilterIndex = 1;
            //タイトルを設定する
            sfd.Title = "Save PerperPlaneCalc json";
            sfd.RestoreDirectory = true;
            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (save(sfd.FileName))
                {
                    m_filename = sfd.FileName;
                }
            }
        }
        public void save()
        {
            if (m_filename != "")
            {
                save(m_filename);
            }else
            {
                SaveDialog();
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDialog();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save();
        }
        public void exportPNG(bool rot=false)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            if (m_filename == "")
            {
                sfd.FileName = "PaperPlane.png";
            }
            else
            {
                sfd.FileName = Path.ChangeExtension( Path.GetFileName(m_filename),".png");
                sfd.InitialDirectory = Path.GetDirectoryName(m_filename);
            }
            sfd.Filter = "pngファイル(*.png)|*.png|すべてのファイル(*.*)|*.*";
            sfd.FilterIndex = 1;
            //タイトルを設定する
            sfd.Title = "Exporte PerperPlaneCalc png";
            sfd.RestoreDirectory = true;
            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                drawWing1.saveImage(sfd.FileName,rot);

            }

        }
        private void exportPngM2_Click(object sender, EventArgs e)
        {
            exportPNG(true);
        }

        private void exportPngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportPNG(false);
        }
        public bool StatusSave(string p)
        {
            dynamic pref = new DynamicJson();
            pref.LocationX = this.Location.X;
            pref.LocationY = this.Location.Y;
            pref.SizeX = this.Size.Width;
            pref.SizeY = this.Size.Height;
            bool ret = false;
            try
            {
                string js = pref.ToString();
                System.IO.File.WriteAllText(p, js, Encoding.GetEncoding("UTF-8"));
                ret = true;
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
        public bool StatusLoad(string p)
        {

            bool ret = false;
            if (System.IO.File.Exists(p))
            {
                try
                {
                    string s = System.IO.File.ReadAllText(p, Encoding.GetEncoding("UTF-8"));
                    var js = DynamicJson.Parse(s);
                    if (js.IsDefined("LocationX") && js.IsDefined("LocationY"))
                    {
                        int x = (int)js["LocationX"];
                        int y = (int)js["LocationY"];
                        this.Location = new Point(x, y);
                    }
                    if (js.IsDefined("SizeX") && js.IsDefined("SizeY"))
                    {
                        int w = (int)js["SizeX"];
                        int h = (int)js["SizeY"];
                        this.Size = new Size(w, h);
                    }
                    ret = true;
                }
                catch
                {
                    ret = false;
                }
            }
            return ret;

        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileName =
                (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (fileName.Length>0)
            {
                foreach(string fn in fileName)
                {
                    if (File.Exists(fn))
                    {
                        if (load(fn))
                        {
                            break;
                        }
                    }
                }
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("現在の値をリセットしますか？",
                "Set Default",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                if (loadDef()==false)
                {
                    wingParams.setDeAllf();
                    saveDef();
                }
            }
        }

    }
}
