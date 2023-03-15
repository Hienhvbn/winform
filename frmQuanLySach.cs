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
namespace quan_li_ban_sach
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
            if (lblMaSach.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã sách");
                lblMaSach.Focus();
                return;
            }
            if (lblTenSach.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên sách");
                lblTenSach.Focus();
                return;
            }
            if (lblTacGia.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tác giả");
                lblTacGia.Focus();
                return;
            }
            if (lblNXB.Text == "")
            {
                MessageBox.Show("Vui lòng nhập NXB");
                lblNXB.Focus();
                return;
            }
            if (lblSoLuong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số lượng");
                lblSoLuong.Focus();
                return;
            }
            if (lblGiaTien.Text == "")
            {
                MessageBox.Show("Vui lòng nhập giá tiền");
                lblGiaTien.Focus();
                return;
            }
            string sqlthem = "INSERT INTO Books VALUES ( '" + lblMaSach.Text.Trim() + "','" + lblTenSach.Text.Trim() + "','" + lblTacGia.Text.Trim() + "','" + lblNXB.Text.Trim() + "','" + lblSoLuong.Text.Trim() + "','" + lblGiaTien.Text.Trim() + "')";
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lblMaSach.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã sách muốn xóa");
                lblMaSach.Focus();
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa không?", "Chú ý", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sqlxoa = "DELETE Books WHERE MaSach = '" + lblMaSach.Text.Trim() + "'";
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lblMaSach.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã sách muốn sửa");
                lblMaSach.Focus();
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn sửa không?", "Chú ý", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sqlsua = "UPDATE Books SET TenSach = '" + lblTenSach.Text.Trim() + "'," + "TacGia = '" + lblTacGia.Text.Trim() + "'," + "NXB = '" + lblNXB.Text.Trim() + "'," + "SoLuong = " + lblSoLuong.Text.Trim() + "," + "GiaTien = " + lblGiaTien.Text.Trim() + " WHERE MaSach = '" + lblMaSach.Text.Trim() + "'";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView1.Rows[e.RowIndex];
            lblMaSach.Text = Convert.ToString(row.Cells["MaSach"].Value);
            lblTenSach.Text = Convert.ToString(row.Cells["TenSach"].Value);
            lblTacGia.Text = Convert.ToString(row.Cells["TacGia"].Value);
            lblNXB.Text = Convert.ToString(row.Cells["NXB"].Value);
            lblSoLuong.Text = Convert.ToString(row.Cells["SoLuong"].Value);
            lblGiaTien.Text = Convert.ToString(row.Cells["GiaTien"].Value);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Chú ý", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtMaSach_TextChanged(object sender, EventArgs e)
        {

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
}////

