using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quan_li_ban_sach
{
    public partial class frmDangNhap : Form
    {
        SqlConnection con = new SqlConnection("Server = DESKTOP-1COAG34; Database = Account; Integrated Security = True");
        public frmDangNhap()
        {
            InitializeComponent();
        }


        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tk = txtTaiKhoan.Text;
            string mk = txtMatKhau.Text;
            if (txtTaiKhoan.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tài khoản");
                txtTaiKhoan.Focus();
                return;
            }
            if (txtMatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
                txtMatKhau.Focus();
                return;
            }
            string sql = "SELECT * FROM tblAccount WHERE TaiKhoan = '" + tk + "' and MatKhau = '" + mk + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dta = cmd.ExecuteReader();
            if (dta.Read() == true)
            {
                MessageBox.Show("Đăng nhập thành công");
                this.Hide();
                frmTrangChu f = new frmTrangChu();
                f.Show();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
                return;
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            
            try
            {
                con.Open();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối");
            }
        }
    }
}
