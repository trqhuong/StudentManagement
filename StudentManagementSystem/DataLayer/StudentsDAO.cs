using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class StudentsDAO
    {
        private string cnn = "Data Source=.;Initial Catalog=QLHocSinh;Integrated Security=True";
        public List<StudentsDTO> GetAllHocSinh()
        {
            List<StudentsDTO> students = new List<StudentsDTO>();

            try
            {
                using (SqlConnection conn = new SqlConnection(cnn))
                {
                    conn.Open();
                    string query = "SELECT hs.MaHocSinh, hs.TenHocSinh, hs.NgaySinh, hs.GioiTinh, hs.TinhTrang, hs.QRCodePath, l.TenLop " +
                                   "FROM HOCSINH hs, LOPHOC l, HOCSINH_LOP hs_l " +
                                   "WHERE hs.MaHocSinh=hs_l.MaHS AND hs_l.MaLop=l.MaLop";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                students.Add(new StudentsDTO(
                                    Convert.ToInt32(reader["MaHocSinh"]),
                                    reader["TenHocSinh"].ToString(),
                                    Convert.ToDateTime(reader["NgaySinh"]),
                                    reader["GioiTinh"].ToString(),
                                    reader["TinhTrang"].ToString(),
                                    reader["QRCodePath"] as string,
                                    reader["TenLop"].ToString()
                                ));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi chung
                Console.WriteLine("Error: " + ex.Message);
            }

            return students;
        }

        public int AddStudent(StudentsDTO hs, int idLop)
        {
            using (SqlConnection conn = new SqlConnection(cnn))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction(); //đảm bảo tính toàn vẹn dữ liệu và khôi phục sau lỗi
                try
                {
                    
                    string query1 = "INSERT INTO HOCSINH (TenHocSinh, NgaySinh, GioiTinh, TinhTrang, QRCodePath) " +
                "VALUES (@TenHocSinh, @NgaySinh, @GioiTinh, @TinhTrang, @QRCodePath); " +
                "SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd1 = new SqlCommand(query1, conn, transaction);
                    cmd1.Parameters.AddWithValue("@TenHocSinh", hs.TenHS);
                    cmd1.Parameters.AddWithValue("@NgaySinh", hs.NgaySinh);
                    cmd1.Parameters.AddWithValue("@GioiTinh", hs.GioiTinh);
                    cmd1.Parameters.AddWithValue("@TinhTrang", hs.TinhTrang);
                    cmd1.Parameters.AddWithValue("@QRCodePath", (object)hs.QRCodePath ?? DBNull.Value);



                    int maHS = Convert.ToInt32(cmd1.ExecuteScalar());

                    // 2. Thêm vào bảng trung gian HocSinh_Lop
                    string query2 = "INSERT INTO HocSinh_Lop (MaHS, MaLop) VALUES (@MaHS, @MaLop)";
                    SqlCommand cmd2 = new SqlCommand(query2, conn, transaction);
                    cmd2.Parameters.AddWithValue("@MaHS", maHS);
                    cmd2.Parameters.AddWithValue("@MaLop", idLop);
                    cmd2.ExecuteNonQuery();

                    transaction.Commit();
                    return maHS; // Trả về ID của học sinh mới thêm
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex.Message);
                    return -1; // Lỗi
                }
            }
        }

        public bool UpdateQRCode(int maHS, string filePath)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cnn))
                {
                    conn.Open();
                    string query = "UPDATE HOCSINH SET QRCodePath = @QRCodePath WHERE MaHocSinh = @MaHocSinh";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@QRCodePath", (object)filePath ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@MaHocSinh", maHS);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // Trả về true nếu cập nhật thành công
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật QRCodePath: " + ex.Message);
                return false; // Trả về false nếu có lỗi
            }
        }

        public bool UpdateStudent(StudentsDTO hs)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cnn))
                {
                    conn.Open();
                    string updateQuery = "UPDATE HOCSINH SET TenHocSinh = @TenHocSinh, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, TinhTrang = @TinhTrang, QRCodePath = @QRCodePath WHERE MaHocSinh = @MaHocSinh";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHocSinh", hs.MaHS);
                        cmd.Parameters.AddWithValue("@TenHocSinh", hs.TenHS);
                        cmd.Parameters.AddWithValue("@NgaySinh", hs.NgaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", hs.GioiTinh);
                        cmd.Parameters.AddWithValue("@TinhTrang", hs.TinhTrang);
                        cmd.Parameters.AddWithValue("@QRCodePath", (object)hs.QRCodePath ?? DBNull.Value);

                        int studentRowsAffected = cmd.ExecuteNonQuery();


                        //Update lớp học
                        string updateClassQuery = "UPDATE HOCSINH_LOP SET MaLop = (SELECT MaLop FROM LOPHOC WHERE TenLop = @TenLop) WHERE MaHS = @MaHocSinh";
                        using (SqlCommand classCmd = new SqlCommand(updateClassQuery, conn))
                        {
                            classCmd.Parameters.AddWithValue("@TenLop", hs.tenLop);
                            classCmd.Parameters.AddWithValue("@MaHocSinh", hs.MaHS);

                            int classRowsAffected = classCmd.ExecuteNonQuery();

                            return studentRowsAffected > 0 && classRowsAffected > 0;
                        }
                    }


                }
            }catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool DeleteStudent(int maHS)
        {
            using (SqlConnection conn = new SqlConnection(cnn))
            {
                conn.Open();

                string updateStatusQuery = "UPDATE HOCSINH SET TinhTrang = 'Nghỉ Học' WHERE MaHocSinh = @MaHocSinh";

                using (SqlCommand cmd = new SqlCommand(updateStatusQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHocSinh", maHS);

                    int rowsAffected = cmd.ExecuteNonQuery();


                    return rowsAffected > 0;
                }
            }
        }

        public string getTinhTrang(int maHS)
        {
            using (SqlConnection conn = new SqlConnection(cnn))
            {
                conn.Open();

                string query = "SELECT  TinhTrang FROM HOCSINH WHERE MaHocSinh = @maHS";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maHS", maHS);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        return result.ToString(); 
                    }
                    else
                    {
                        return null; 
                    }
                }
            }
        }
    }
}
