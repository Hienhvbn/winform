using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
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

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect();
            //Mở kết nối
        }

        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if(currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelBody.Controls.Add(childForm);
            panelBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLySach());
            lblTitle.Text = btnSach.Text;
            //
            btnSach.BackColor = Color.FromArgb(0, 102, 51);
            btnHoaDon.BackColor = Color.FromArgb(51, 51, 76);
            btnNhanVien.BackColor = Color.FromArgb(51, 51, 76);
            btnKhachHang.BackColor = Color.FromArgb(51, 51, 76);

            panelTop.BackColor = Color.FromArgb(0, 102, 51);
            panelLogo.BackColor = Color.FromArgb(0, 51, 25);
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmHoaDonBanHang());
            lblTitle.Text = btnHoaDon.Text;

            btnHoaDon.BackColor = Color.FromArgb(0, 102, 102);
            btnSach.BackColor = Color.FromArgb(51, 51, 76);
            btnNhanVien.BackColor = Color.FromArgb(51, 51, 76);
            btnKhachHang.BackColor = Color.FromArgb(51, 51, 76);

            panelTop.BackColor = Color.FromArgb(0, 102, 102);
            panelLogo.BackColor = Color.FromArgb(0, 51, 51);

            //btnHoaDon.ForeColor = Color.FromArgb(41, 128, 185);
            //btnSach.ForeColor = SystemColors.Control;
            //btnNhanVien.ForeColor = SystemColors.Control;
            //btnKhachHang.ForeColor = SystemColors.Control;

            //btnHoaDon.BackColor = SystemColors.Control;
            //btnSach.BackColor = Color.FromArgb(41, 128, 185);
            //btnNhanVien.BackColor = Color.FromArgb(41, 128, 185);
            //btnKhachHang.BackColor = Color.FromArgb(41, 128, 185);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form7());
            lblTitle.Text = btnNhanVien.Text;

            btnNhanVien.BackColor = Color.FromArgb(153, 0, 0);
            btnHoaDon.BackColor = Color.FromArgb(51, 51, 76);
            btnSach.BackColor = Color.FromArgb(51, 51, 76);
            btnKhachHang.BackColor = Color.FromArgb(51, 51, 76);

            panelTop.BackColor = Color.FromArgb(153, 0, 0);
            panelLogo.BackColor = Color.FromArgb(102, 0, 0);

            //btnNhanVien.ForeColor = Color.FromArgb(41, 128, 185);
            //btnSach.ForeColor = SystemColors.Control;
            //btnHoaDon.ForeColor = SystemColors.Control;
            //btnKhachHang.ForeColor = SystemColors.Control;

            //btnNhanVien.BackColor = SystemColors.Control;
            //btnSach.BackColor = Color.FromArgb(24, 128, 185);
            //btnHoaDon.BackColor = Color.FromArgb(24, 128, 185);
            //btnKhachHang.BackColor = Color.FromArgb(24, 128, 185);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhanVien());
            lblTitle.Text = btnKhachHang.Text;

            btnKhachHang.BackColor = Color.FromArgb(153, 76, 0);
            btnHoaDon.BackColor = Color.FromArgb(51, 51, 76);
            btnNhanVien.BackColor = Color.FromArgb(51, 51, 76);
            btnSach.BackColor = Color.FromArgb(51, 51, 76);

            panelTop.BackColor = Color.FromArgb(153, 76, 0);
            panelLogo.BackColor = Color.FromArgb(102, 51, 0);

            //btnKhachHang.ForeColor = Color.FromArgb(41, 128, 185);
            //btnSach.ForeColor = SystemColors.Control;
            //btnNhanVien.ForeColor = SystemColors.Control;
            //btnHoaDon.ForeColor = SystemColors.Control;

            //btnKhachHang.BackColor = SystemColors.Control;
            //btnSach.BackColor = Color.FromArgb(24, 128, 185);
            //btnNhanVien.BackColor = Color.FromArgb(24, 128, 185);
            //btnHoaDon.BackColor = Color.FromArgb(24, 128, 185);
        }

        private void frmTrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
