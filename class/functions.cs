using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace quan_li_ban_sach.Class
{
    public class Functions
    {
        public static SqlConnection Con;  //Khai báo đối tượng kết nối        

        public static void Connect()
        {
            /*string chuoiketnoi = "Server = DESKTOP-1COAG34\\SQLEXPRESS; Database = qlbs ;Integrated Security = True";
            SqlConnection con = new SqlConnection();
            
                try
                {
                    con = new SqlConnection(chuoiketnoi); // truyen vao chuoi ket noi
                    con.Open();// mo ket noi
                    //MessageBox.Show("Kết nối thành công");
                }
                catch
                {
                    MessageBox.Show("Kết nối không thành công");
                }*/
                Con = new SqlConnection();   //Khởi tạo đối tượng
                Con.ConnectionString = "Server = DESKTOP-1COAG34; Database = qlbs ;Integrated Security = True";
                Con.Open();                  //Mở kết nối
                //Kiểm tra kết nối
                if (Con.State == ConnectionState.Open)
                    MessageBox.Show("Kết nối thành công");
                else MessageBox.Show("Không thể kết nối với dữ liệu");

        }
        public static void Disconnect()
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();   	//Đóng kết nối
                Con.Dispose(); 	//Giải phóng tài nguyên
                Con = null;
            }
        }
    }
}