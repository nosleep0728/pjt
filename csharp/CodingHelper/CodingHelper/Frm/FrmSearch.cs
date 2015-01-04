using CodingHelper.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void FrmSearch_Load(object sender, EventArgs e)
        {
            this.LoadFile();
            WinUtil.SetForegroundWindow(this.Handle);

            this.txtSearch.Focus();
            this.ActiveControl = txtSearch;
        }

        private void LoadFile()
        {

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
