using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;

namespace ThanksGoogle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] list = new string[19];
            for (int i = 0; i <= 18; i++) list[i] = i.ToString();

            comboBox1.Items.AddRange(list);
            comboBox1.SelectedIndex = 10;

            comboBox2.Items.AddRange(new string[] { "衛星", "向量", "衛星+向量" });
            comboBox2.SelectedIndex = 0;

            TBX_ExportPath.Text = Application.StartupPath;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_ThreadList != null)
            {
                for (int i = 0; i < ThreadSize; i++)
                {
                    if (m_ThreadList[i] != null) m_ThreadList[i].Abort();
                }
            }
        }


        private void BTN_ExportPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                TBX_ExportPath.Text = dlg.SelectedPath;
            }
        }

        private void BTN_Start_Click(object sender, EventArgs e)
        {
            z = comboBox1.SelectedIndex;
            if (z < 0)
            {
                MessageBox.Show("請選擇精細度", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBox2.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇影像類型", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double west, north, east, south;
            if (!double.TryParse(TBX_West.Text, out west))
            {
                MessageBox.Show("西邊範圍輸入錯誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(TBX_North.Text, out north))
            {
                MessageBox.Show("北邊範圍輸入錯誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(TBX_East.Text, out east))
            {
                MessageBox.Show("東邊範圍輸入錯誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(TBX_South.Text, out south))
            {
                MessageBox.Show("南邊範圍輸入錯誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(TBX_ExportPath.Text))
            {
                try
                {
                    Directory.CreateDirectory(TBX_ExportPath.Text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (!Directory.Exists(TBX_ExportPath.Text))
                {
                    MessageBox.Show("輸出目錄創建失敗", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            ExportPath = TBX_ExportPath.Text;

            try
            {
                string url = TBX_ServerUrl.Text + "/docmd?cmd=EPSG_Transfer&FromEPSG=4326&ToEPSG=3857&Points=";
                url += TBX_West.Text + "," + TBX_North.Text;
                url += "," + TBX_East.Text + "," + TBX_North.Text;
                url += "," + TBX_East.Text + "," + TBX_South.Text;
                url += "," + TBX_West.Text + "," + TBX_North.Text;

                HttpWebRequest req = (HttpWebRequest)(WebRequest.Create(url));
                req.Method = "GET";
                req.UserAgent = "MyBrowser";
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                Stream stream = res.GetResponseStream();
                MemoryStream ms = new MemoryStream();
                int len = 1024 * 1024;
                byte[] bytes = new byte[len];
                int readlen = 0;
                do
                {
                    readlen = stream.Read(bytes, 0, len);
                    ms.Write(bytes, 0, readlen);
                }
                while (readlen > 0);

                string s = Encoding.UTF8.GetString(ms.ToArray());
                int startindex = 0;
                int a = -1, b = -1;
                List<string> strs = new List<string>();
                while (true)
                {
                    a = s.IndexOf("\"coordinates\": [", startindex);
                    if (a >= 0) a += 16;
                    else break;

                    startindex = a;
                    b = s.IndexOf("]}", startindex);
                    startindex = b;

                    if (a >= 0 && b >= 0)
                    {
                        string _s = s.Substring(a, b - a);
                        strs.Add(_s);
                    }
                    else break;
                }

                for (int i = 0; i < strs.Count; i++)
                {
                    string[] ss = strs[i].Split(',');
                    double x = Convert.ToDouble(ss[0]);
                    double y = Convert.ToDouble(ss[1]);
                    if (i == 0)
                    {
                        west = east = x;
                        south = north = y;
                    }
                    else
                    {
                        if (x < west) west = x;
                        else if (x > east) east = x;

                        if (y < south) south = y;
                        else if (y > north) north = y;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("轉換座標失敗" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //開始打格子
            width = 20037508.34278925 * 2 / Math.Pow(2, z);
            minx = Convert.ToInt32(Math.Floor((west - left) / width));
            miny = Convert.ToInt32(Math.Floor((top - north) / width));
            maxx = Convert.ToInt32(Math.Ceiling((east - left) / width));
            maxy = Convert.ToInt32(Math.Ceiling((top - south) / width));

            if (minx <= 0) minx = 0;
            if (maxx <= 0) maxx = 0;
            if (miny <= 0) miny = 0;
            if (maxy <= 0) maxy = 0;
            if (minx >= Math.Pow(2, z)) minx = Convert.ToInt32(Math.Pow(2, z)) - 1;
            if (maxx >= Math.Pow(2, z)) maxx = Convert.ToInt32(Math.Pow(2, z)) - 1;
            if (miny >= Math.Pow(2, z)) miny = Convert.ToInt32(Math.Pow(2, z)) - 1;
            if (maxy >= Math.Pow(2, z)) maxy = Convert.ToInt32(Math.Pow(2, z)) - 1;

            imagetype = comboBox2.SelectedIndex;
            ErrorCount = 0;

            Console.WriteLine(minx.ToString() + " " + maxx.ToString() + " " + miny.ToString() + " " + maxy.ToString());

            m_TotalCount = ((maxx - minx + 1) * (maxy - miny + 1));
            LBL_TolalPages.Text = "預估總張數:" + m_TotalCount.ToString("N0");

            Thread thd = new Thread(MainThreadWork);
            LBL_Process.Text = "剩餘張數:" + "計算中...";
            BTN_Start.Enabled = false;
            thd.Start();
        }

        int ThreadSize = 12;
        int LiveThread = 0;

        double z = 0;
        int imagetype = 0;
        double left = -20037508.34278925;
        double top = 20037508.34278925;
        double width = 20037508.34278925 * 2;
        int minx = 0, miny = 0, maxx = 0, maxy = 0;
        int m_TotalCount = 0;
        string ExportPath = "";
        List<int> m_xList = new List<int>();
        List<int> m_yList = new List<int>();
        Thread[] m_ThreadList = null;
        int ErrorCount = 0;
        Random m_Rnd = new Random();

        public void MainThreadWork()
        {
            m_xList.Clear();
            m_xList.Capacity = m_TotalCount;
            m_yList.Clear();
            m_yList.Capacity = m_TotalCount;
            for (int y = miny; y <= maxy; y++)
            {
                for (int x = minx; x <= maxx; x++)
                {
                    m_xList.Add(x);
                    m_yList.Add(y);
                }
            }

            m_ThreadList = new Thread[ThreadSize];
            for (int i = 0; i < ThreadSize; i++)
            {
                m_ThreadList[i] = new Thread(SubThreadWork);
                LiveThread++;
                m_ThreadList[i].Start();
            }
        }

        public void SubThreadWork()
        {
            while (true)
            {
                int x = -1, y = -1;
                lock (m_xList)
                {
                    lock (m_yList)
                    {
                        if (m_xList.Count > 0 && m_yList.Count > 0)
                        {
                            x = m_xList[m_xList.Count - 1];
                            y = m_yList[m_yList.Count - 1];
                            m_xList.RemoveAt(m_xList.Count - 1);
                            m_yList.RemoveAt(m_yList.Count - 1);
                        }
                        else break;
                    }
                }
                if (x >= 0 && y >= 0)
                {
                    bool bOK = false;
                    if (MakeImageFile(x, y))
                    {
                        if (MakeCoordinateFile(x, y))
                        {
                            bOK = true;
                            UIText("剩餘張數:" + m_xList.Count.ToString(), LBL_Process);
                        }
                    }
                    if (!bOK) ErrorCount++;
                }
            }
            if (m_ThreadList != null)
            {
                for (int i = 0; i < ThreadSize; i++)
                {
                    if (m_ThreadList[i] == Thread.CurrentThread)
                    {
                        m_ThreadList[i] = null;
                        break;
                    }
                }
            }
            LiveThread--;
            if (LiveThread == 0)
            {
                MessageBox.Show("完成" + ((ErrorCount > 0) ? "，" + ErrorCount.ToString() + " 失敗。" : ""), "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UIEnabled(true, BTN_Start);
            }
        }

        public bool MakeImageFile(int x, int y)
        {
            bool Ret = false;

            string s = "";
            if (imagetype == 0) s = string.Format("http://mt{0}.google.com/vt/lyrs=s&hl=zh-TW&x={1}&y={2}&z={3}", m_Rnd.Next(6), x, y, z);
            else if (imagetype == 1) s = string.Format("http://mt{0}.google.com/vt/lyrs=m&hl=zh-TW&x={1}&y={2}&z={3}", m_Rnd.Next(6), x, y, z);
            else if (imagetype == 2) s = string.Format("http://mt{0}.google.com/vt/lyrs=y&hl=zh-TW&x={1}&y={2}&z={3}", m_Rnd.Next(6), x, y, z);

            try
            {
                string dir = ExportPath + "\\" + z.ToString() + "\\" + y.ToString();
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                string filename = dir + "\\" + x.ToString() + ".jpg";
                HttpWebRequest req = (HttpWebRequest)(WebRequest.Create(s));
                req.Method = "GET";
                req.UserAgent = "MyBrowser";
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                Stream stream = res.GetResponseStream();
                Image img = Image.FromStream(stream);
                img.Save(filename);
                Ret = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Ret;
        }

        public bool MakeCoordinateFile(int x, int y)
        {
            bool Ret = false;

            try
            {
                string dir = ExportPath + "\\" + z.ToString() + "\\" + y.ToString();
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                string filename = dir + "\\" + x.ToString() + ".jgw";
                StreamWriter sw = new StreamWriter(filename, false, Encoding.ASCII);
                sw.WriteLine((width / 256.0).ToString("0.000000"));
                sw.WriteLine("0.000000");
                sw.WriteLine("0.000000");
                sw.WriteLine((width / 256.0 * -1.0).ToString("0.000000"));
                sw.WriteLine((left + (x * width)).ToString("0.000000"));
                sw.WriteLine((top - (y * width)).ToString("0.000000"));
                sw.Close();
                Ret = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Ret;
        }    

        private delegate void UICallBackText(string myStr, Control ctl);
        private delegate void UICallBackEnabled(bool myBool, Control ctl);
        private void UIText(string myStr, Control ctl)
        {
            if (this.InvokeRequired)
            {
                UICallBackText myUpdate = new UICallBackText(UIText);
                this.Invoke(myUpdate, myStr, ctl);
            }
            else
            {
                ctl.Text = myStr;
            }
        }

        private void UIEnabled(bool myBool, Control ctl)
        {
            if (this.InvokeRequired)
            {
                UICallBackEnabled myUpdate = new UICallBackEnabled(UIEnabled);
                this.Invoke(myUpdate, myBool, ctl);
            }
            else
            {
                ctl.Enabled = myBool;
            }
        }


    }
}
