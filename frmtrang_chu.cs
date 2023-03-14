using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quan_li_ban_sach
{
    public partial class frmtrang_chu : Form
    {
        public frmtrang_chu()
        {
            InitializeComponent();
        }

        private void frmtrang_chu_Load(object sender, EventArgs e)
        {

        }

        private void mnuthoat_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Thoát
        }

        private void mnuhoadonban_Click(object sender, EventArgs e)
        {
            frmhoadonban frmhoadonban = new frmhoadonban();
            frmhoadonban.ShowDialog();
        }
    }
}
