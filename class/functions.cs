using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace qlbansach
{
    public class functions
{
    public static SqlConnection Con;  //Khai báo đối tượng kết nối        
    public static void Connect()
    {
        Con = new SqlConnection();   //Khởi tạo đối tượng
        Con.ConnectionString = @"Data Source=.\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + @"\Quanlibansach.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            //Kiểm tra kết nối
        if (Con.State == ConnectionState.Open)
        {
            MessageBox.Show("Kết nối thành công");
            Con.Open();
        }
        else MessageBox.Show("Không thể kết nối với dữ liệu");
    }
        public static void Disconnect()
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();    //Đóng kết nối
                Con.Dispose();  //Giải phóng tài nguyên
                Con = null;
            }
        }    
}
}