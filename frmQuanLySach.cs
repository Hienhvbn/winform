using System;
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
            btnHuy.Enabled = false; btnHuy.Cursor = Cursors.Arrow;
            txtMaSach.Enabled = false;
            txtTenSach.Enabled = false;
            txtTacGia.Enabled = false;
            txtNXB.Enabled = false;
            txtSoLuong.Enabled = false;
            txtDonGiaNhap.Enabled = false;
            txtDonGiaBan.Enabled = false;
            txtAnh.Enabled = false;
            txtGhiChu.Enabled = false;
            LoadDataGridView(); //Hiển thị bảng tblSach
        }

        // Hàm reset giá trị đã nhập
        private void ResetValues()
        {
            txtMaSach.Text = "";
            txtTenSach.Text = "";
            txtTacGia.Text = "";
            txtNXB.Text = "";
            txtSoLuong.Text = "0";
            txtDonGiaNhap.Text = "0";
            txtDonGiaBan.Text = "0";
            txtAnh.Text = "";
            picAnh.Image = null;
            txtGhiChu.Text = "";

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

        // Hàm tải dữ liệu từ bảng vào DataGridView
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from tblSach";
            tblS = Functions.GetDataToTable(sql);
            dgvSach.DataSource = tblS;
            dgvSach.Columns[0].HeaderText = "Mã hàng";
            dgvSach.Columns[1].HeaderText = "Tên hàng";
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

        // -----------------------BUTTON THÊM--------------------------
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Bật, Tắt các nút
            dgvSach.Enabled = false;
            btnSua.Enabled = false; btnSua.Cursor = Cursors.Arrow;
            btnXoa.Enabled = false; btnXoa.Cursor = Cursors.Arrow;
            btnTimKiem.Enabled = false; btnTimKiem.Cursor = Cursors.Arrow;
            btnHuy.Enabled = true; btnHuy.Cursor = Cursors.Hand;

            // Bật các textbox để nhập
            if (txtMaSach.Enabled == false)
            {
                ResetValues();
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

            // Kiểm tra Nếu chưa nhập đủ dữ liệu thì thông báo nhập
            if (txtMaSach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Bạn phải chọn ảnh minh hoạ cho sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOpen.Focus();
                return;
            }

            // Viết câu lệnh SQL để thêm vào database
            sql = "SELECT MaSach FROM tblSach WHERE MaSach=N'" + txtMaSach.Text.Trim() + "'";
            // Gọi hàm kiểm tra Primary key
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã sách này đã tồn tại, bạn phải chọn mã sách khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSach.Focus();
                return;
            }

            sql = "INSERT INTO tblSach(MaSach,TenSach,TacGia,NXB,SoLuong,DonGiaNhap,DonGiaBan,Anh,Ghichu) VALUES(N'"
                + txtMaSach.Text.Trim() + "',N'" + txtTenSach.Text.Trim() +
                "',N'" + txtTacGia.Text.Trim() + "',N'" + txtNXB.Text.Trim() +
                "'," + txtSoLuong.Text.Trim() + "," + txtDonGiaNhap.Text +
                "," + txtDonGiaBan.Text + ",'" + txtAnh.Text + "',N'" + txtGhiChu.Text.Trim() + "')";

            try
            {
                Functions.RunSQL(sql); // Gọi hàm chạy câu lệnh SQL
                LoadDataGridView();
                MessageBox.Show("Thêm thành công");
                ResetValues();
                dgvSach.Enabled = true;
                btnXoa.Enabled = true; btnXoa.Cursor = Cursors.Hand;
                btnThem.Enabled = true; btnThem.Cursor = Cursors.Hand;
                btnSua.Enabled = true; btnSua.Cursor = Cursors.Hand;
                btnTimKiem.Enabled = true; btnTimKiem.Cursor = Cursors.Hand;
                btnHuy.Enabled = false; btnHuy.Cursor = Cursors.Arrow;
            }
            catch
            {
                MessageBox.Show("Thêm không thành công");
            }
        }

        // -----------------------BUTTON XÓA--------------------------
        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Bật, Tắt các nút
            btnThem.Enabled = false; btnThem.Cursor = Cursors.Arrow;
            btnSua.Enabled = false; btnSua.Cursor = Cursors.Arrow;
            btnTimKiem.Enabled = false; btnTimKiem.Cursor = Cursors.Arrow;
            btnHuy.Enabled = true; btnHuy.Cursor = Cursors.Hand;

            // Bật, Tắt các nút
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

            // Kiểm tra nếu chưa nhập đủ dữ liệu thì thông báo
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
                try
                {
                    Functions.RunSqlDel(sql);
                    LoadDataGridView();
                    MessageBox.Show("Xóa thành công");
                    ResetValues();
                    btnXoa.Enabled = true; btnXoa.Cursor = Cursors.Hand;
                    btnThem.Enabled = true; btnThem.Cursor = Cursors.Hand;
                    btnSua.Enabled = true; btnSua.Cursor = Cursors.Hand;
                    btnTimKiem.Enabled = true; btnTimKiem.Cursor = Cursors.Hand;
                    btnHuy.Enabled = false; btnHuy.Cursor = Cursors.Arrow;
                }
                catch
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }

            
        }

        // -----------------------BUTTON SỬA--------------------------
        private void btnSua_Click(object sender, EventArgs e)
        {
            // Bật, Tắt các nút
            btnThem.Enabled = false; btnThem.Cursor = Cursors.Arrow;
            btnXoa.Enabled = false; btnXoa.Cursor = Cursors.Arrow;
            btnTimKiem.Enabled = false; btnTimKiem.Cursor = Cursors.Arrow;
            btnHuy.Enabled = true; btnHuy.Cursor = Cursors.Hand;

            // Bật các textbox để sửa
            if (txtTenSach.Enabled == false)
            {
                txtMaSach.Enabled = false;
                txtTenSach.Enabled = true;
                txtTenSach.Focus();
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

            // Kiểm tra nếu chưa nhập đủ dữ liệu thì thông báo
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
                MessageBox.Show("Bạn phải chọn ảnh minh hoạ cho sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAnh.Focus();
                return;
            }

            // Viết câu lệnh SQL để sửa
            sql = "UPDATE tblSach SET TenSach=N'" + txtTenSach.Text.Trim().ToString() +
                "',TacGia=N'" + txtTacGia.Text.ToString() +
                "',NXB=N'" + txtNXB.Text.ToString() +
                "',SoLuong=" + txtSoLuong.Text +
                ",Anh='" + txtAnh.Text + "',Ghichu=N'" + txtGhiChu.Text + "' WHERE MaSach=N'" + txtMaSach.Text + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã sách này đã tồn tại, bạn phải nhập mã sách khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSach.Focus();
                return;
            }

            try
            {
                Functions.RunSQL(sql); //  Gọi hàm chạy câu lệnh SQL
                LoadDataGridView();
                MessageBox.Show("Sửa thành công");
                ResetValues();
                btnXoa.Enabled = true; btnXoa.Cursor = Cursors.Hand;
                btnThem.Enabled = true; btnThem.Cursor = Cursors.Hand;
                btnSua.Enabled = true; btnSua.Cursor = Cursors.Hand;
                btnTimKiem.Enabled = true; btnTimKiem.Cursor = Cursors.Hand;
                btnHuy.Enabled = false; btnHuy.Cursor = Cursors.Arrow;
            }
            catch
            {
                MessageBox.Show("Sửa không thành công");
            }
        }

        // -----------------------BUTTON TÌM KIẾM--------------------------
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Bật, Tắt các nút và textbox
            if (txtMaSach.Enabled == false)
            {
                btnXoa.Enabled = false; btnXoa.Cursor = Cursors.Arrow;
                btnThem.Enabled = false; btnThem.Cursor = Cursors.Arrow;
                btnSua.Enabled = false; btnSua.Cursor = Cursors.Arrow;
                btnHuy.Enabled = true; btnHuy.Cursor = Cursors.Hand;

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
            // Kiểm tra nếu chưa nhập đủ dữ liệu thì thông báo
            if ((txtMaSach.Text == "") && (txtTenSach.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Viết câu lệnh SQL để tìm kiếm
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
            tblS = Functions.GetDataToTable(sql); // Gọi hàm lấy dữ liệu từ bảng trong database
            if (tblS.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblS.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvSach.DataSource = tblS;
            //ResetValues();
        }
        // -----------------------BUTTON HIỂN THỊ DS--------------------------
        private void btnHienthiDS_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaSach,TenSach,TacGia,NXB,SoLuong,DonGiaNhap,DonGiaBan,Anh,Ghichu FROM tblSach";
            tblS = Functions.GetDataToTable(sql);
            dgvSach.DataSource = tblS;
        }

        // -----------------------BUTTON HỦY--------------------------
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgvSach.Enabled = true;
            btnThem.Enabled = true; btnThem.Cursor = Cursors.Hand;
            btnSua.Enabled = true; btnSua.Cursor = Cursors.Hand;
            btnXoa.Enabled = true; btnXoa.Cursor = Cursors.Hand;
            btnTimKiem.Enabled = true; btnTimKiem.Cursor = Cursors.Hand;
            btnHuy.Enabled = false; btnHuy.Cursor = Cursors.Arrow;

            LoadDataGridView();
        }

        // -----------------------BUTTON BROWSE--------------------------
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

        // Sự kiện khi Click vào DataGridView thì hiển thị thông tin lên các control tương ứng
        private void dgvSach_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblS.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaSach.Text = dgvSach.CurrentRow.Cells["MaSach"].Value.ToString();
            txtTenSach.Text = dgvSach.CurrentRow.Cells["TenSach"].Value.ToString();
            txtTacGia.Text = dgvSach.CurrentRow.Cells["TacGia"].Value.ToString();
            txtNXB.Text = dgvSach.CurrentRow.Cells["NXB"].Value.ToString();
            txtSoLuong.Text = dgvSach.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtDonGiaNhap.Text = dgvSach.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
            txtDonGiaBan.Text = dgvSach.CurrentRow.Cells["DonGiaBan"].Value.ToString();

            sql = "SELECT Anh FROM tblSach WHERE MaSach=N'" + txtMaSach.Text + "'";
            txtAnh.Text = Functions.GetFieldValues(sql);
            picAnh.Image = Image.FromFile(txtAnh.Text);
            sql = "SELECT GhiChu FROM tblSach WHERE MaSach = N'" + txtMaSach.Text + "'";
            txtGhiChu.Text = Functions.GetFieldValues(sql);
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
        
      
    }
}///////

