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
        
        public frmDangNhap()
        {
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtAccount_Click(object sender, EventArgs e)
        {
            txtAccount.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel4.BackColor = SystemColors.Control;
            txtPassword.BackColor = SystemColors.Control;
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.White;
            panel4.BackColor = Color.White;
            panel3.BackColor = SystemColors.Control;
            txtAccount.BackColor = SystemColors.Control;
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string tk = txtAccount.Text;
            string mk = txtPassword.Text;
            if (txtAccount.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tài khoản");
                txtAccount.Focus();
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
                txtPassword.Focus();
                return;
            }
            SqlConnection con = new SqlConnection("Server = DESKTOP-1COAG34; Database = Account; Integrated Security = True");
            try
            {
                con.Open();
                string sql = "SELECT * FROM tblAccount WHERE TaiKhoan = '" + tk + "' and MatKhau = '" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dta = cmd.ExecuteReader();

                if (dta.Read() == true)
                {
                    //MessageBox.Show("Đăng nhập thành công");
                    this.Hide();
                    frmTrangChu f = new frmTrangChu();
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối");
            }
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = SystemColors.Control;
        }


    }
}
