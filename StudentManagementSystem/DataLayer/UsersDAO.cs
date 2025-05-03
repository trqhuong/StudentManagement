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

            // Tạo danh sách tham số
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@username", SqlDbType.NVarChar) { Value = username },
                new SqlParameter("@password", SqlDbType.NVarChar) { Value = password }
            };

            // Thực thi câu lệnh với tham số
            DataTable result = MyExecuteReader(sql, CommandType.Text, parameters);

            foreach (DataRow row in result.Rows)
            {
                string tenDangNhap = row["tendangnhap"].ToString();
                string matKhau = row["matkhau"].ToString();
                string loaiTaiKhoan = row["loaitaikhoan"].ToString();

                UsersDTO user = new UsersDTO(tenDangNhap, matKhau, loaiTaiKhoan);
                list.Add(user);
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
