﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient; //Sử dụng thư viện để làm việc SQL server
using quan_li_ban_sach.Class; //Sử dụng class Functions.cs

namespace quan_li_ban_sach
{
    public partial class frmQuanLySach : Form
    {
        DataTable tblS; //Chứa dữ liệu bảng Chất liệu    
        public frmQuanLySach()
        {
            InitializeComponent();
        }

        private void frmQuanLySach_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect();
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            txtMaSach.Enabled = false;
            txtTenSach.Enabled = false;
            txtTacGia.Enabled = false;
            txtNXB.Enabled = false;
            txtSoLuong.Enabled = false;
            txtDonGiaNhap.Enabled = false;
            txtDonGiaBan.Enabled = false;
            txtAnh.Enabled = false;
            txtGhiChu.Enabled = false;
            LoadDataGridView();
            btnLuu.Hide();
        }
        private void ResetValues()
        {
            txtMaSach.Text = "";
            txtTenSach.Text = "";
            txtTacGia.Text = "";
            txtNXB.Text = "";
            txtSoLuong.Text = "0";
            txtDonGiaNhap.Text = "0";
            txtDonGiaBan.Text = "0";
            //txtSoLuong.Enabled = true;
            //txtDonGiaNhap.Enabled = false;
            //txtDonGiaBan.Enabled = false;
            txtAnh.Text = "";
            picAnh.Image = null;
            txtGhiChu.Text = "";
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from tblSach";
            tblS = Functions.GetDataToTable(sql);
            dgvSach.DataSource = tblS;
            dgvSach.Columns[0].HeaderText = "Mã Sách";
            dgvSach.Columns[1].HeaderText = "Tên Sách";
            dgvSach.Columns[2].HeaderText = "Tác giả";
            dgvSach.Columns[3].HeaderText = "NXB";
            dgvSach.Columns[4].HeaderText = "Số lượng";
            dgvSach.Columns[5].HeaderText = "Đơn giá nhập";
            dgvSach.Columns[6].HeaderText = "Đơn giá bán";
            dgvSach.Columns[7].HeaderText = "Ảnh";
            dgvSach.Columns[8].HeaderText = "Ghi chú";
            dgvSach.Columns[0].Width = 80;
            dgvSach.Columns[1].Width = 140;
            dgvSach.Columns[2].Width = 80;
            dgvSach.Columns[3].Width = 80;
            dgvSach.Columns[4].Width = 80;
            dgvSach.Columns[5].Width = 100;
            dgvSach.Columns[6].Width = 100;
            dgvSach.Columns[7].Width = 200;
            dgvSach.Columns[8].Width = 300;
            dgvSach.AllowUserToAddRows = false;
            dgvSach.EditMode = DataGridViewEditMode.EditProgrammatically;
        }





        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnTimKiem.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
 
            txtMaSach.Enabled = true;
            txtMaSach.Focus();
            txtTenSach.Enabled = true;
            txtTacGia.Enabled = true;
            txtNXB.Enabled = true;
            txtSoLuong.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            txtDonGiaBan.Enabled = true;
            txtAnh.Enabled = true;
            txtGhiChu.Enabled = true;
            btnThem.Hide();
            btnLuu.Show();
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnTimKiem.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;

            if (txtMaSach.Enabled == false)
            {
                txtMaSach.Enabled = true;
                txtMaSach.Focus();
                txtTenSach.Enabled = true;
                txtTacGia.Enabled = true;
                txtNXB.Enabled = true;
                txtSoLuong.Enabled = true;
                txtDonGiaNhap.Enabled = true;
                txtDonGiaBan.Enabled = true;
                txtAnh.Enabled = true;
                txtGhiChu.Enabled = true;
                return;
            }
            
            string sql;
            if (tblS.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaSach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSach.Focus();
                return;
            }
            if (txtTenSach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSach.Focus();
                return;
            }
            if (txtTacGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên tác giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTacGia.Focus();
                return;
            }
            if (txtNXB.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên NXB", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNXB.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải tải ảnh minh hoạ cho sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAnh.Focus();
                return;
            }
            sql = "UPDATE tblSach SET TenSach=N'" + txtTenSach.Text.Trim().ToString() +
                "',TacGia=N'" + txtTacGia.Text.ToString() +
                "',NXB=N'" + txtNXB.Text.ToString() +
                "',SoLuong=" + txtSoLuong.Text +
                ",Anh='" + txtAnh.Text + "',Ghichu=N'" + txtGhiChu.Text + "' WHERE MaSach=N'" + txtMaSach.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnHuy.Enabled = false;
            
        }
        private void dataGridView1_CellContentClick123(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvSach.Rows[e.RowIndex];
            txtMaSach.Text = Convert.ToString(row.Cells["MaSach"].Value);
            txtTenSach.Text = Convert.ToString(row.Cells["TenSach"].Value);
            txtTacGia.Text = Convert.ToString(row.Cells["TacGia"].Value);
            txtNXB.Text = Convert.ToString(row.Cells["NXB"].Value);
            txtSoLuong.Text = Convert.ToString(row.Cells["SoLuong"].Value);
            txtGiaTien.Text = Convert.ToString(row.Cells["GiaTien"].Value);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Chú ý", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtMaSach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtTenSach.Focus();
            }
        }

        private void txtTenSach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtTacGia.Focus();
            }
        }

        private void txtTacGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtNXB.Focus();
            }
        }

        private void txtNXB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSoLuong.Focus();
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDonGiaNhap.Focus();
            }
        }

        private void txtDonGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDonGiaBan.Focus();
            }
        }
        private void txtDonGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnOpen.Focus();
            }
        }

        private void btnOpen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtGhiChu.Focus();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            string sql;
            if (txtMaSach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSach.Focus();
                return;
            }
            if (txtTenSach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSach.Focus();
                return;
            }
            if (txtTacGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên tác giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTacGia.Focus();
                return;
            }
            if (txtNXB.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên NXB", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNXB.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOpen.Focus();
                return;
            }
            sql = "SELECT MaSach FROM tblSach WHERE MaSach=N'" + txtMaSach.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã tồn tại, bạn phải chọn mã hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSach.Focus();
                return;
            }
            sql = "INSERT INTO tblSach(MaSach,TenSach,TacGia,NXB,SoLuong,DonGiaNhap,DonGiaBan,Anh,Ghichu) VALUES(N'"
                + txtMaSach.Text.Trim() + "',N'" + txtTenSach.Text.Trim() +
                "',N'" + txtTacGia.Text.Trim() + "',N'" + txtNXB.Text.Trim() +
                "'," + txtSoLuong.Text.Trim() + "," + txtDonGiaNhap.Text +
                "," + txtDonGiaBan.Text + ",'" + txtAnh.Text + "',N'" + txtGhiChu.Text.Trim() + "')";

            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnLuu.Hide();
            btnThem.Show();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnTimKiem.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtMaSach.Enabled = false;
            txtTenSach.Enabled = false;
            txtTacGia.Enabled = false;
            txtNXB.Enabled = false;
            txtSoLuong.Enabled = false;
            txtDonGiaNhap.Enabled = false;
            txtDonGiaBan.Enabled = false;
            txtAnh.Enabled = false;
            txtGhiChu.Enabled = false;
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnTimKiem.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = false;
            if (txtMaSach.Enabled == false)
            {
                txtMaSach.Enabled = true;
                txtMaSach.Focus();
                txtTenSach.Enabled = false;
                txtTacGia.Enabled = false;
                txtNXB.Enabled = false;
                txtSoLuong.Enabled = false;
                txtDonGiaNhap.Enabled = false;
                txtDonGiaBan.Enabled = false;
                txtAnh.Enabled = false;
                txtGhiChu.Enabled = false;
                return;
            }
            
            string sql;
            if (tblS.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaSach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblSach WHERE MaSach=N'" + txtMaSach.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtAnh.Text = dlgOpen.FileName;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(txtMaSach.Enabled == false)
            {
                btnXoa.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnHuy.Enabled = true;
                btnLuu.Enabled = false;
                txtMaSach.Enabled = true;
                txtTenSach.Enabled = true;
                txtTacGia.Enabled = true;
                txtNXB.Enabled = true;
                txtSoLuong.Enabled = false;
                txtDonGiaNhap.Enabled = false;
                txtDonGiaBan.Enabled = false;
                txtAnh.Enabled = false;
                txtGhiChu.Enabled = false;
                return;
            }
            
            string sql;
            if ((txtMaSach.Text == "") && (txtTenSach.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from tblSach WHERE 1=1";
            if (txtMaSach.Text != "")
                sql += " AND MaSach LIKE N'%" + txtMaSach.Text + "%'";
            if (txtTenSach.Text != "")
                sql += " AND TenSach LIKE N'%" + txtTenSach.Text + "%'";
            if (txtTacGia.Text != "")
                sql += " AND TacGia LIKE N'%" + txtTacGia.Text + "%'";
            if (txtNXB.Text != "")
                sql += " AND NXB LIKE N'%" + txtNXB.Text + "%'";
            /*if (cboMaChatLieu.Text != "")
                sql += " AND MaChatLieu LIKE N'%" + cboMaChatLieu.SelectedValue + "%'";
            */
            tblS = Functions.GetDataToTable(sql);
            if (tblS.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblS.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvSach.DataSource = tblS;
            //ResetValues();
        }

        private void btnHienthiDS_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaSach,TenSach,TacGia,NXB,SoLuong,DonGiaNhap,DonGiaBan,Anh,Ghichu FROM tblSach";
            tblS = Functions.GetDataToTable(sql);
            dgvSach.DataSource = tblS;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnThem.Show();
            btnLuu.Hide();
            ResetValues();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnTimKiem.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtMaSach.Enabled = false;
            txtTenSach.Enabled = false;
            txtTacGia.Enabled = false;
            txtNXB.Enabled = false;
            txtSoLuong.Enabled = false;
            txtDonGiaNhap.Enabled = false;
            txtDonGiaBan.Enabled = false;
            txtAnh.Enabled = false;
            txtGhiChu.Enabled = false;
            LoadDataGridView();
        }

        private void lblNXB_Click(object sender, EventArgs e)
        {

        }

        private void lblTacGia_Click(object sender, EventArgs e)
        {

        }

        private void lblTenSach_Click(object sender, EventArgs e)
        {

        }

        private void lblMaSach_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void lblSoLuong_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void picAnh_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtDonGiaNhap_TextChanged(object sender, EventArgs e)
        {
            
        }
        
        private void dgvSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvSach_Click(object sender, EventArgs e)
        {
            string sql;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSach.Focus();
                return;
            }
            if (tblS.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaSach.Text = dgvSach.CurrentRow.Cells["MaSach"].Value.ToString();
            txtTenSach.Text = dgvSach.CurrentRow.Cells["TenSach"].Value.ToString();
            txtTacGia.Text = dgvSach.CurrentRow.Cells["TacGia"].Value.ToString();
            txtNXB.Text = dgvSach.CurrentRow.Cells["NXB"].Value.ToString();
            //MaChatLieu = dgvSach.CurrentRow.Cells["MaChatLieu"].Value.ToString();
            //sql = "SELECT TenChatLieu FROM tblChatLieu WHERE MaChatLieu=N'" + MaChatLieu + "'";
            //cboMaChatLieu.Text = Functions.GetFieldValues(sql);
            txtSoLuong.Text = dgvSach.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtDonGiaNhap.Text = dgvSach.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
            txtDonGiaBan.Text = dgvSach.CurrentRow.Cells["DonGiaBan"].Value.ToString();
            sql = "SELECT Anh FROM tblSach WHERE MaSach=N'" + txtMaSach.Text + "'";
            txtAnh.Text = Functions.GetFieldValues(sql);
            picAnh.Image = Image.FromFile(txtAnh.Text);
            sql = "SELECT GhiChu FROM tblSach WHERE MaSach = N'" + txtMaSach.Text + "'";
            txtGhiChu.Text = Functions.GetFieldValues(sql);
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
        }
        /*
private void dgvSach_Click(object sender, EventArgs e)
{
   string sql;
   if (btnThem.Enabled == false)
   {
       MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
       txtMaSach.Focus();
       return;
   }
   if (tblS.Rows.Count == 0)
   {
       MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
       return;
   }
   txtMaSach.Text = dgvSach.CurrentRow.Cells["MaSach"].Value.ToString();
   txtTenSach.Text = dgvSach.CurrentRow.Cells["TenSach"].Value.ToString();
   txtTacGia.Text = dgvSach.CurrentRow.Cells["TacGia"].Value.ToString();
   txtNXB.Text = dgvSach.CurrentRow.Cells["NXB"].Value.ToString();
   //MaChatLieu = dgvSach.CurrentRow.Cells["MaChatLieu"].Value.ToString();
   //sql = "SELECT TenChatLieu FROM tblChatLieu WHERE MaChatLieu=N'" + MaChatLieu + "'";
   //cboMaChatLieu.Text = Functions.GetFieldValues(sql);
   txtSoLuong.Text = dgvSach.CurrentRow.Cells["SoLuong"].Value.ToString();
   txtDonGiaNhap.Text = dgvSach.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
   txtDonGiaBan.Text = dgvSach.CurrentRow.Cells["DonGiaBan"].Value.ToString();
   sql = "SELECT Anh FROM tblSach WHERE MaSach=N'" + txtMaSach.Text + "'";
   txtAnh.Text = Functions.GetFieldValues(sql);
   picAnh.Image = Image.FromFile(txtAnh.Text);
   sql = "SELECT GhiChu FROM tblSach WHERE MaSach = N'" + txtMaSach.Text + "'";
   txtGhiChu.Text = Functions.GetFieldValues(sql);
   btnSua.Enabled = true;
   btnXoa.Enabled = true;
   btnHuy.Enabled = true;
}*/
    }
}///////

