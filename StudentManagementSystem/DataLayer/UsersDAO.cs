using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TransferObject;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;



namespace DataLayer
{
    public class UsersDAO:DataProvider
    {
        public List<UsersDTO> GetTaiKhoan(string username, string password)
        {
            List<UsersDTO> list = new List<UsersDTO>();
            string sql = "SELECT * FROM TAIKHOAN WHERE tendangnhap = @username AND matkhau = @password";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@username", SqlDbType.NVarChar) { Value = username },
                new SqlParameter("@password", SqlDbType.NVarChar) { Value = password }
            };

            try
            {
                Connect();
                using (SqlDataReader reader = MyExecuteReader(sql,CommandType.Text,parameters))
                {
                    while (reader.Read())
                    {
                        string tenDangNhap = reader["tendangnhap"].ToString();
                        string matKhau = reader["matkhau"].ToString();
                        string loaiTaiKhoan = reader["loaitaikhoan"].ToString();
                        UsersDTO user = new UsersDTO(tenDangNhap, matKhau, loaiTaiKhoan);
                        list.Add(user);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }

            return list;
        }


        public void Login(string username)
        {
            string query = "UPDATE TAIKHOAN SET TrangThai = 1 WHERE TenDangNhap = @username";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@username", username)
            };
         
            MyExecuteNonQuery(query, CommandType.Text, parameters);
        }
        public void Logout()
        {
            string query = "UPDATE TAIKHOAN " +
                    "SET TrangThai = 0 WHERE TrangThai = 1 ";
            MyExecuteNonQuery(query, CommandType.Text);
        }

        public bool KiemTraUsernameTonTai(string username)
        {
            string sql = "SELECT COUNT(*) FROM TAIKHOAN WHERE  tendangnhap = @username";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@username", username)
            };

            object result = MyExecuteScalar(sql, CommandType.Text, parameters);

            if (result != null && int.TryParse(result.ToString(), out int count))
            {
                return count > 0;
            }

            return false;
        }

        public string LayEmailTheoUsername(string username)
        {
            string sql = "SELECT Email FROM TAIKHOAN WHERE  tendangnhap=@username";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@username", username)
            };

            object result = MyExecuteScalar(sql, CommandType.Text, parameters);

            return result?.ToString(); // Trả về null nếu không có
        }

        public bool UpdateMatKhau(string username, string newPassword)
        {
            string sql = "UPDATE TAIKHOAN SET matkhau = @password WHERE tendangnhap = @username";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@password", newPassword),
                new SqlParameter("@username", username)
            };

            return MyExecuteNonQuery(sql, CommandType.Text, parameters) > 0;
        }


    }
}
