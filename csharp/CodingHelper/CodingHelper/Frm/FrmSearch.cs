using CodingHelper.Model;
using CodingHelper.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodingHelper.Frm
{
    public partial class FrmSearch : Form
    {
        public FrmSearch()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        List<KVVO> dataList = new List<KVVO>();
        private void FrmSearch_Load(object sender, EventArgs e)
        {
            this.LoadFile();
            WinUtil.SetForegroundWindow(this.Handle);

            this.txtSearch.Focus();
            this.ActiveControl = txtSearch;
        }

        private void LoadFile()
        {
            string fileName = @".\Data\WordList.txt"; // 파일의 경로입니다.

            using (StreamReader reader = new StreamReader(fileName, System.Text.Encoding.UTF8))
            {

                string line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line); // 읽어온 문자열을 뿌립니다.
                    if (line.IndexOf('=') < 0) continue;

                    var idx = line.IndexOf('=');
                    string key = line.Substring(0, idx).Trim();
                    string value = line.Substring(idx +1).Trim();
                    var kv = new KVVO();
                    kv.Key = key;
                    kv.Value = value;
                    this.dataList.Add(kv);
                }

                reader.Close();
            }
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
