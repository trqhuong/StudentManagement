using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace DataLayer
{
    public class ClassDAO
    {
        private string cnn = "Data Source=.;Initial Catalog=QLHocSinh;Integrated Security=True";

        // Lấy danh sách lớp học
        public List<ClassDTO> GetAllLopHoc()
        {
            List<ClassDTO> lopHoc = new List<ClassDTO>();//danh sách lớp để trả về

            using (SqlConnection conn = new SqlConnection(cnn))
            {
                conn.Open();
                string query = "SELECT * FROM LOPHOC";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();//đọc dữ liệu từ database

                while (reader.Read())//duyệt qua từng dòng dữ liệu
                {
                    // tạo đối tượng lớp học từ dữ liệu đọc được
                    lopHoc.Add(new ClassDTO(
                     Convert.ToInt32(reader["MaLop"]),
                     reader["TenLop"].ToString(),
                     reader["NamHoc"].ToString(),
                     reader["GVQuanLi"].ToString(),
                     Convert.ToInt32(reader["SiSo"])
                    ));
                }

            }
            return lopHoc;
        }

        public int AddClass(ClassDTO classDTO)
        {
            using (SqlConnection conn = new SqlConnection(cnn))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string query = @"INSERT INTO LOPHOC(TenLop, NamHoc, GVQuanLi, SiSo)
                                    VALUES (@TenLop, 
                                    (SELECT TOP 1 MaNH FROM NAMHOC WHERE TrangThai = 1), 
                                     @GVQuanLi, @SiSo);
                                    SELECT SCOPE_IDENTITY();";


                    SqlCommand cmd = new SqlCommand(query, conn, transaction);
                    cmd.Parameters.AddWithValue("@TenLop", classDTO.TenLop);
                    cmd.Parameters.AddWithValue("@GVQuanLi", classDTO.GVQuanLi);
                    cmd.Parameters.AddWithValue("@SiSo", classDTO.SiSo);

                    // Thực thi và lấy ID lớp mới
                    int newClassId = Convert.ToInt32(cmd.ExecuteScalar());

                    transaction.Commit();
                    return newClassId;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi thêm lớp học: " + ex.Message);
                    return -1;
                }
            }
        }

        public int UpdateClass(ClassDTO classDTO)
        {
            using (SqlConnection conn = new SqlConnection(cnn))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    string query = @"UPDATE LOPHOC 
                             SET TenLop = @TenLop, 
                                 NamHoc = (SELECT TOP 1 MaNH FROM NAMHOC WHERE TrangThai = 1), 
                                 GVQuanLi = @GVQuanLi, 
                                 SiSo = @SiSo
                             WHERE MaLop = @MaLop;";
                    SqlCommand cmd = new SqlCommand(query, conn, transaction);
                    cmd.Parameters.AddWithValue("@MaLop", classDTO.MaLop);
                    cmd.Parameters.AddWithValue("@TenLop", classDTO.TenLop);
                    cmd.Parameters.AddWithValue("@GVQuanLi", classDTO.GVQuanLi);
                    cmd.Parameters.AddWithValue("@SiSo", classDTO.SiSo);
                    
                    transaction.Commit();
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi cập nhật lớp học: " + ex.Message);
                    return -1;
                }
            }

        }

        public bool DeleteClass(int maLop)
        {
            using (SqlConnection conn = new SqlConnection(cnn))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    string query = "DELETE FROM LOPHOC WHERE MaLop = @MaLop";
                    SqlCommand cmd = new SqlCommand(query, conn, transaction);
                    cmd.Parameters.AddWithValue("@MaLop", maLop);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    transaction.Commit();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi xóa lớp học: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
