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


namespace quan_li_ban_sach
{
    public partial class frmhoadonban : Form
    {
        string chuoiketnoi = "Server = VHIEN03\\MSSQLLocalDB; Database = Quanlibansach; Integrated Security = True";
        SqlConnection con = new SqlConnection();
        private void ketnoicsdl()
        {
            try
            {
                con = new SqlConnection(chuoiketnoi); // truyen vao chuoi ket noi
                con.Open();// mo ket noi
                MessageBox.Show("Kết nối thành công");
            }
            catch
            {
                MessageBox.Show("Kết nối không thành công");
            }
        }
        public frmhoadonban()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmhoadonban_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnInHoaDon.Enabled = false;
            txtMaHDBan.ReadOnly = true;
            txtTenNhanVien.ReadOnly = true;
            txtTenKhach.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtDienThoai.ReadOnly = true;
            txtTenHang.ReadOnly = true;
            txtDonGiaBan.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtGiamGia.Text = "0";
            txtTongTien.Text = "0";
        }
    }
}
