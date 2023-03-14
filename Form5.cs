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
using System.Data.SqlClient;
namespace qlsach
{
    public partial class frmQuanLySach : Form
    {
        string chuoiketnoi = "Server = DESKTOP-1COAG34\\SQLEXPRESS; Database = quanlybansach; Integrated Security = True";
        SqlConnection con = new SqlConnection();
        private void ketnoicsdl()
        {
            try
            {
                con = new SqlConnection(chuoiketnoi); // truyen vao chuoi ket noi
                con.Open();// mo ket noi
                //MessageBox.Show("Kết nối thành công");
            }
            catch
            {
                MessageBox.Show("Kết nối không thành công");
            }
        }
        private void loaddulieulen()
        {
            string sql = "SELECT * FROM Books";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public frmQuanLySach()
        {
            InitializeComponent();
        }

        private void frmQuanLySach_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
            loaddulieulen();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã sách");
                txtMaSach.Focus();
                return;
            }
            if (txtTenSach.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên sách");
                txtTenSach.Focus();
                return;
            }
            if (txtTacGia.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tác giả");
                txtTacGia.Focus();
                return;
            }
            if (txtNXB.Text == "")
            {
                MessageBox.Show("Vui lòng nhập NXB");
                txtNXB.Focus();
                return;
            }
            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số lượng");
                txtSoLuong.Focus();
                return;
            }
            if (txtGiaTien.Text == "")
            {
                MessageBox.Show("Vui lòng nhập giá tiền");
                txtGiaTien.Focus();
                return;
            }
            string sqlthem = "INSERT INTO Books VALUES ( '" + txtMaSach.Text.Trim() + "','" + txtTenSach.Text.Trim() + "','" + txtTacGia.Text.Trim() + "','" + txtNXB.Text.Trim() + "','" + txtSoLuong.Text.Trim() + "','" + txtGiaTien.Text.Trim() + "')";
            try
            {
                SqlCommand command = new SqlCommand(sqlthem, con);
                command.ExecuteNonQuery();
                loaddulieulen();
                MessageBox.Show("Thêm thành công");
            }
            catch
            {
                MessageBox.Show("Thêm không thành công");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã sách muốn sửa");
                txtMaSach.Focus();
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn sửa không?", "Chú ý", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sqlsua = "UPDATE Books SET TenSach = '" + txtTenSach.Text.Trim() + "'," + "TacGia = '" + txtTacGia.Text.Trim() + "'," + "NXB = '" + txtNXB.Text.Trim() + "'," + "SoLuong = " + txtSoLuong.Text.Trim() + "," + "GiaTien = " + txtGiaTien.Text.Trim() + " WHERE MaSach = '" + txtMaSach.Text.Trim() + "'";
                    try
                    {
                        SqlCommand command = new SqlCommand(sqlsua, con);
                        command.ExecuteNonQuery();
                        loaddulieulen();
                        MessageBox.Show("Sửa thành công");
                    }
                    catch
                    {
                        MessageBox.Show("Sửa không thành công");
                    }
                }

            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã sách muốn xóa");
                txtMaSach.Focus();
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa không?", "Chú ý", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sqlxoa = "DELETE Books WHERE MaSach = '" + txtMaSach.Text.Trim() + "'";
                    try
                    {
                        SqlCommand command = new SqlCommand(sqlxoa, con);
                        command.ExecuteNonQuery();
                        loaddulieulen();
                        MessageBox.Show("Xóa thành công");
                    }
                    catch
                    {
                        MessageBox.Show("Xóa không thành công");
                    }
                }

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView1.Rows[e.RowIndex];
            txtMaSach.Text = Convert.ToString(row.Cells["MaSach"].Value);
            txtTenSach.Text = Convert.ToString(row.Cells["TenSach"].Value);
            txtTacGia.Text = Convert.ToString(row.Cells["TacGia"].Value);
            txtNXB.Text = Convert.ToString(row.Cells["NXB"].Value);
            txtSoLuong.Text = Convert.ToString(row.Cells["SoLuong"].Value);
            txtGiaTien.Text = Convert.ToString(row.Cells["GiaTien"].Value);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSach.Text = "";
            txtTenSach.Text = "";
            txtTacGia.Text = "";
            txtNXB.Text = "";
            txtSoLuong.Text = "";
            txtGiaTien.Text = "";
            txtMaSach.Focus();
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
                txtGiaTien.Focus();
            }
        }
    }
}