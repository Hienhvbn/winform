using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using quan_li_ban_sach;

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
            Class.Functions.Connect();
            //Mở kết nối

        }

        private void mnuthoat_Click(object sender, EventArgs e)
        {
            Class.Functions.Disconnect(); //Đóng kết nối
            Application.Exit(); //Thoát
        }

        private void mnuhoadonban_Click(object sender, EventArgs e)
        {
            frmhoadonban frmhoadonban = new frmhoadonban();
            frmhoadonban.MdiParent = this;
            frmhoadonban.Show();
        }
        private void mnusach_Click(object sender, EventArgs e)
        {
            frmQuanLySach frmQuanLySach = new frmQuanLySach();
            frmQuanLySach.MdiParent = this;
            frmQuanLySach.Show();
        }
    }
}
