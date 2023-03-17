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
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
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
            frmHoaDonBanHang frmhoadonban = new frmHoaDonBanHang();
            frmhoadonban.MdiParent = this;
            frmhoadonban.Show();
        }
        private void mnusach_Click(object sender, EventArgs e)
        {
            frmQuanLySach frmQuanLySach = new frmQuanLySach();
            //frmQuanLySach.MdiParent = this;
            frmQuanLySach.Show();
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            
            frmQuanLySach frmQuanLySach = new frmQuanLySach();
            frmQuanLySach.MdiParent = this;
            frmQuanLySach.Show();
            frmQuanLySach.Dock = DockStyle.Fill;
            panel2.Controls.Add(frmQuanLySach);
            btnSach.Enabled = false;
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            //
            btnSach.Enabled = true;
            frmHoaDonBanHang frmHoaDonBanHang = new frmHoaDonBanHang();
            frmHoaDonBanHang.MdiParent = this;
            frmHoaDonBanHang.Show();
            frmHoaDonBanHang.Dock = DockStyle.Fill;
            panel2.Controls.Add(frmHoaDonBanHang);
            btnHoaDon.Enabled = false;
        }
    }
}
