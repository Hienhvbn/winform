using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using quan_li_ban_sach.Class;

namespace quan_li_ban_sach
{
    public partial class frmKhachHang : Form
    {
        DataTable tblKH; //Bảng khách hàng
        public frmKhachHang()
        {
            InitializeComponent();
        }


        private void frmKhachHang_Load(object sender, EventArgs e)
        {
           
            txtMaKhach.Enabled = false; 
            txtTenKhach.Enabled = false;
            txtDiaChi.Enabled = false;
            mtbDienThoai.Enabled = false;
            btnHuy.Enabled = false; btnHuy.Cursor = Cursors.Arrow;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from tblKhachHang";
            tblKH = Functions.GetDataToTable(sql); //Lấy dữ liệu từ bảng
            dgvKhachHang.DataSource = tblKH; //Hiển thị vào dataGridView
            dgvKhachHang.Columns[0].HeaderText = "Mã khách";
            dgvKhachHang.Columns[1].HeaderText = "Tên khách";
            dgvKhachHang.Columns[2].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns[3].HeaderText = "Điện thoại";
            dgvKhachHang.Columns[0].Width = 100;
            dgvKhachHang.Columns[1].Width = 150;
            dgvKhachHang.Columns[2].Width = 150;
            dgvKhachHang.Columns[3].Width = 150;
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtMaKhach.Text = "";
            txtTenKhach.Text = "";
            txtDiaChi.Text = "";
            mtbDienThoai.Text = "";

            txtMaKhach.Enabled = false;
            txtTenKhach.Enabled = false;
            txtDiaChi.Enabled = false;
            mtbDienThoai.Enabled = false;
        }

        
        // ---------------------------------BUTTON THÊM---------------------------------
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Bật, Tắt các nút
            dgvKhachHang.Enabled = false;
            btnSua.Enabled = false; btnSua.Cursor = Cursors.Arrow;
            btnXoa.Enabled = false; btnXoa.Cursor = Cursors.Arrow;
            btnHuy.Enabled = true; btnHuy.Cursor = Cursors.Hand;

            // Bật các textbox để nhập
            if (txtMaKhach.Enabled == false)
            {
                ResetValues();
                txtMaKhach.Enabled = true;
                txtMaKhach.Focus();
                txtTenKhach.Enabled = true;
                txtDiaChi.Enabled = true;
                mtbDienThoai.Enabled = true;
                return;
            }

            string sql;
            if (txtMaKhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKhach.Focus();
                return;
            }
            if (txtTenKhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKhach.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            if (mtbDienThoai.Text == "(  )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtbDienThoai.Focus();
                return;
            }
            //Kiểm tra đã tồn tại mã khách chưa
            sql = "SELECT MaKhach FROM tblKhachHang WHERE MaKhach=N'" + txtMaKhach.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã khách này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKhach.Focus();
                return;
            }
            //Chèn thêm
            sql = "INSERT INTO tblKhachHang VALUES (N'" + txtMaKhach.Text.Trim() +
                "',N'" + txtTenKhach.Text.Trim() + "',N'" + txtDiaChi.Text.Trim() + "','" + mtbDienThoai.Text + "')";

            try
            {
                Functions.RunSQL(sql); // Gọi hàm chạy câu lệnh SQL
                LoadDataGridView();
                ResetValues();
                MessageBox.Show("Thêm thành công");
                dgvKhachHang.Enabled = true;
                btnXoa.Enabled = true; btnXoa.Cursor = Cursors.Hand;
                btnThem.Enabled = true; btnThem.Cursor = Cursors.Hand;
                btnSua.Enabled = true; btnSua.Cursor = Cursors.Hand;
                btnHuy.Enabled = false; btnHuy.Cursor = Cursors.Arrow;
            }
            catch
            {
                MessageBox.Show("Thêm không thành công");
            }

            
        }
        // ---------------------------------BUTTON XÓA---------------------------------
        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Bật, Tắt các nút
            dgvKhachHang.Enabled = true;
            btnThem.Enabled = false; btnThem.Cursor = Cursors.Arrow;
            btnSua.Enabled = false; btnSua.Cursor = Cursors.Arrow;
            btnHuy.Enabled = true; btnHuy.Cursor = Cursors.Hand;

            // Bật, Tắt các nút
            if (txtMaKhach.Enabled == false)
            {
                txtMaKhach.Enabled = true;
                txtMaKhach.Focus();
                txtTenKhach.Enabled = false;
                txtDiaChi.Enabled = false;
                mtbDienThoai.Enabled = false;
                return;
            }
            string sql;
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKhach.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblKhachHang WHERE MaKhach=N'" + txtMaKhach.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
                btnXoa.Enabled = true; btnXoa.Cursor = Cursors.Hand;
                btnThem.Enabled = true; btnThem.Cursor = Cursors.Hand;
                btnSua.Enabled = true; btnSua.Cursor = Cursors.Hand;
                btnHuy.Enabled = false; btnHuy.Cursor = Cursors.Arrow;
            }
        }
        // ---------------------------------BUTTON SỬA---------------------------------
        private void btnSua_Click(object sender, EventArgs e)
        {
            // Bật, Tắt các nút
            dgvKhachHang.Enabled = true;
            btnThem.Enabled = false; btnThem.Cursor = Cursors.Arrow;
            btnXoa.Enabled = false; btnXoa.Cursor = Cursors.Arrow;
            btnHuy.Enabled = true; btnHuy.Cursor = Cursors.Hand;

            // Bật các textbox để sửa
            if (txtTenKhach.Enabled == false)
            {
                txtMaKhach.Enabled = false;
                txtTenKhach.Enabled = true;
                txtTenKhach.Focus();
                txtDiaChi.Enabled = true;
                mtbDienThoai.Enabled = true;
                return;
            }
            string sql;
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKhach.Text == "")
            {
                MessageBox.Show("Bạn phải chọn bản ghi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenKhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKhach.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            if (mtbDienThoai.Text == "(  )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtbDienThoai.Focus();
                return;
            }
            sql = "UPDATE tblKhachHang SET TenKhach=N'" + txtTenKhach.Text.Trim().ToString() + "',DiaChi=N'" +
                txtDiaChi.Text.Trim().ToString() + "',DienThoai='" + mtbDienThoai.Text.ToString() +
                "' WHERE MaKhach=N'" + txtMaKhach.Text + "'";
            

            try
            {
                Functions.RunSQL(sql); //  Gọi hàm chạy câu lệnh SQL
                LoadDataGridView();
                MessageBox.Show("Sửa thành công");
                ResetValues();
                btnXoa.Enabled = true; btnXoa.Cursor = Cursors.Hand;
                btnThem.Enabled = true; btnThem.Cursor = Cursors.Hand;
                btnSua.Enabled = true; btnSua.Cursor = Cursors.Hand;
                btnHuy.Enabled = false; btnHuy.Cursor = Cursors.Arrow;
            }
            catch
            {
                MessageBox.Show("Sửa không thành công");
            }
        }
        // ---------------------------------BUTTON HỦY---------------------------------
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgvKhachHang.Enabled = true;
            btnThem.Enabled = true; btnThem.Cursor = Cursors.Hand;
            btnSua.Enabled = true; btnSua.Cursor = Cursors.Hand;
            btnXoa.Enabled = true; btnXoa.Cursor = Cursors.Hand;
            btnHuy.Enabled = false; btnHuy.Cursor = Cursors.Arrow;

            LoadDataGridView();
        }
        // ---------------------------------BUTTON ĐÓNG---------------------------------
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Sự kiện khi Click vào DataGridView thì sẽ hiển thị lên các control tương ứng 
        private void dgvKhachHang_Click(object sender, EventArgs e)
        {

            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaKhach.Text = dgvKhachHang.CurrentRow.Cells["MaKhach"].Value.ToString();
            txtTenKhach.Text = dgvKhachHang.CurrentRow.Cells["TenKhach"].Value.ToString();
            txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells["DiaChi"].Value.ToString();
            mtbDienThoai.Text = dgvKhachHang.CurrentRow.Cells["DienThoai"].Value.ToString();
        }

        private void txtMaKhach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                txtTenKhach.Focus();
            }
        }

        private void txtTenKhach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDiaChi.Focus();
            }
        }

        private void txtDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtbDienThoai.Focus();
            }
        }
    }
}
