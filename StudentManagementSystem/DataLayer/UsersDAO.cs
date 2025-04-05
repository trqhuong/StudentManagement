using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;



namespace DataLayer
{
    public class UsersDAO
    {
        private string cnn = "Data Source=.;Initial Catalog=QLHocSinh;Integrated Security=True";

        public UsersDTO GetTaiKhoan(string username, string password)
        {
            string sql = "SELECT * FROM TAIKHOAN WHERE tendangnhap = @username AND matkhau = @password";

            using (SqlConnection cn = new SqlConnection(cnn))
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader(); // đọc dữ liệu từ sql

                if (reader.Read()) // Nếu có dữ liệu trả về
                {
                    // Lấy thông tin từ DB
                    string tenDangNhap = reader["tendangnhap"].ToString();
                    string matKhau = reader["matkhau"].ToString();
                    string loaiTaiKhoan = reader["loaitaikhoan"].ToString();

                    cn.Close();
                    return new UsersDTO(tenDangNhap, matKhau, loaiTaiKhoan);
                }
                else
                {
                    cn.Close();
                    return null; // Không tìm thấy tài khoản
                }
            }
        }
        
    }
}
