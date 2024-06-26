﻿using System;
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
            Class.Functions.Connect(); //Mở kết nối
            btnDong.Hide();
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
            btnDong.Show();

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
            btnDong.Show();

            btnHoaDon.BackColor = Color.FromArgb(0, 102, 102);
            btnSach.BackColor = Color.FromArgb(51, 51, 76);
            btnNhanVien.BackColor = Color.FromArgb(51, 51, 76);
            btnKhachHang.BackColor = Color.FromArgb(51, 51, 76);

            panelTop.BackColor = Color.FromArgb(0, 102, 102);
            panelLogo.BackColor = Color.FromArgb(0, 51, 51);

        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhanVien());
            lblTitle.Text = btnNhanVien.Text;
            btnDong.Show();

            btnNhanVien.BackColor = Color.FromArgb(153, 0, 0);
            btnHoaDon.BackColor = Color.FromArgb(51, 51, 76);
            btnSach.BackColor = Color.FromArgb(51, 51, 76);
            btnKhachHang.BackColor = Color.FromArgb(51, 51, 76);

            panelTop.BackColor = Color.FromArgb(153, 0, 0);
            panelLogo.BackColor = Color.FromArgb(102, 0, 0);

        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhachHang());
            lblTitle.Text = btnKhachHang.Text;
            btnDong.Show();

            btnKhachHang.BackColor = Color.FromArgb(153, 76, 0);
            btnHoaDon.BackColor = Color.FromArgb(51, 51, 76);
            btnNhanVien.BackColor = Color.FromArgb(51, 51, 76);
            btnSach.BackColor = Color.FromArgb(51, 51, 76);

            panelTop.BackColor = Color.FromArgb(153, 76, 0);
            panelLogo.BackColor = Color.FromArgb(102, 51, 0);

        }

        private void frmTrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                btnSach.BackColor = Color.FromArgb(51, 51, 76);
                btnHoaDon.BackColor = Color.FromArgb(51, 51, 76);
                btnNhanVien.BackColor = Color.FromArgb(51, 51, 76);
                btnKhachHang.BackColor = Color.FromArgb(51, 51, 76);
                panelTop.BackColor = Color.FromArgb(51, 51, 76);
                panelLogo.BackColor = Color.FromArgb(39, 39, 58);
                lblTitle.Text = "HOME";

                currentFormChild.Close();
                btnDong.Hide();
            }
        }
    }
}
