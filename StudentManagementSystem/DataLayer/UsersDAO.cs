using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TransferObject;



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

        public void ChangeStatus(string username)
        {
            string query = "UPDATE TAIKHOAN SET TrangThai = 1 WHERE TenTaiKhoan = @username";

        
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@username", username)
            };
         
            MyExecuteNonQuery(query, CommandType.Text, parameters);
        }


    }
}
