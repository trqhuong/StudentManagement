using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class StudentsDAO:DataProvider
    {
   
        public List<StudentsDTO> GetAllHocSinh()
        {
            List<StudentsDTO> students = new List<StudentsDTO>();
            string query = "SELECT hs.MaHocSinh, hs.TenHocSinh, hs.NgaySinh, hs.GioiTinh, hs.TinhTrang, hs.QRCodePath, l.TenLop " +
                           "FROM HOCSINH hs, LOPHOC l, HOCSINH_LOP hs_l " +
                           "WHERE hs.MaHocSinh=hs_l.MaHS AND hs_l.MaLop=l.MaLop";

            try
            {
                // Sử dụng DataProvider để thực thi câu lệnh SQL
                DataTable dt = MyExecuteReader(query, CommandType.Text);

                // Duyệt qua DataTable và chuyển các hàng thành danh sách StudentsDTO
                foreach (DataRow row in dt.Rows)
                {
                    students.Add(new StudentsDTO(
                        Convert.ToInt32(row["MaHocSinh"]),
                        row["TenHocSinh"].ToString(),
                        Convert.ToDateTime(row["NgaySinh"]),
                        row["GioiTinh"].ToString(),
                        row["TinhTrang"].ToString(),
                        row["QRCodePath"] as string,
                        row["TenLop"].ToString()
                    ));
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
            string query1 = "INSERT INTO HOCSINH (TenHocSinh, NgaySinh, GioiTinh, TinhTrang, QRCodePath) " +
                            "VALUES (@TenHocSinh, @NgaySinh, @GioiTinh, @TinhTrang, @QRCodePath); " +
                            "SELECT SCOPE_IDENTITY();";

            var parameters1 = new List<SqlParameter>
            {
                new SqlParameter("@TenHocSinh", hs.TenHS),
                new SqlParameter("@NgaySinh", hs.NgaySinh),
                new SqlParameter("@GioiTinh", hs.GioiTinh),
                new SqlParameter("@TinhTrang", hs.TinhTrang),
                new SqlParameter("@QRCodePath", (object)hs.QRCodePath ?? DBNull.Value)
            };

            try
            {
                int maHS = Convert.ToInt32(MyExecuteScalar(query1, CommandType.Text, parameters1));

                // Thêm học sinh vào bảng HocSinh_Lop
                string query2 = "INSERT INTO HocSinh_Lop (MaHS, MaLop) VALUES (@MaHS, @MaLop)";
                        var parameters2 = new List<SqlParameter>
                {
                    new SqlParameter("@MaHS", maHS),
                    new SqlParameter("@MaLop", idLop)
                };
                MyExecuteNonQuery(query2, CommandType.Text, parameters2);

                // Cập nhật sĩ số lớp
                string query3 = "UPDATE LOPHOC SET SiSo = SiSo + 1 WHERE MaLop = @MaLop";
                var parameters3 = new List<SqlParameter>
                {
                    new SqlParameter("@MaLop", idLop)
                };
                MyExecuteNonQuery(query3, CommandType.Text, parameters3);

                return maHS;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return -1;
            }
        }



        public bool UpdateQRCode(int maHS, string filePath)
        {
            string query = "UPDATE HOCSINH SET QRCodePath = @QRCodePath WHERE MaHocSinh = @MaHocSinh";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@QRCodePath", (object)filePath ?? DBNull.Value),
                new SqlParameter("@MaHocSinh", maHS)
            };

            try
            {
                // Sử dụng phương thức MyExecuteNonQuery kế thừa từ DataProvider
                int rowsAffected = MyExecuteNonQuery(query, CommandType.Text, parameters);

                return rowsAffected > 0; // Trả về true nếu cập nhật thành công
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật QRCodePath: " + ex.Message);
                return false; // Trả về false nếu có lỗi
            }
        }


        public bool UpdateStudent(StudentsDTO hs)
        {
            // Cập nhật thông tin học sinh
            string updateQuery = "UPDATE HOCSINH SET TenHocSinh = @TenHocSinh, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, TinhTrang = @TinhTrang, QRCodePath = @QRCodePath WHERE MaHocSinh = @MaHocSinh";
            var parameters1 = new List<SqlParameter>
            {
                new SqlParameter("@MaHocSinh", hs.MaHS),
                new SqlParameter("@TenHocSinh", hs.TenHS),
                new SqlParameter("@NgaySinh", hs.NgaySinh),
                new SqlParameter("@GioiTinh", hs.GioiTinh),
                new SqlParameter("@TinhTrang", hs.TinhTrang),
                new SqlParameter("@QRCodePath", (object)hs.QRCodePath ?? DBNull.Value)
            };

            // Cập nhật lớp học của học sinh
            string updateClassQuery = "UPDATE HOCSINH_LOP SET MaLop = (SELECT MaLop FROM LOPHOC WHERE TenLop = @TenLop) WHERE MaHS = @MaHocSinh";
            var parameters2 = new List<SqlParameter>
            {
                new SqlParameter("@TenLop", hs.tenLop),
                new SqlParameter("@MaHocSinh", hs.MaHS)
            };

            try
            {
                // Cập nhật học sinh
                int studentRowsAffected = MyExecuteNonQuery(updateQuery, CommandType.Text, parameters1);

                // Cập nhật lớp học
                int classRowsAffected = MyExecuteNonQuery(updateClassQuery, CommandType.Text, parameters2);

                // Nếu cả hai câu lệnh đều thành công, trả về true
                return studentRowsAffected > 0 && classRowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false; // Trả về false nếu có lỗi
            }
        }


        public bool DeleteStudent(int maHS)
        {
            string updateStatusQuery = "UPDATE HOCSINH SET TinhTrang = N'Nghỉ Học' WHERE MaHocSinh = @MaHocSinh";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@MaHocSinh", maHS)
            };

            try
            {
                // Sử dụng phương thức MyExecuteNonQuery để thực hiện câu lệnh UPDATE
                int rowsAffected = MyExecuteNonQuery(updateStatusQuery, CommandType.Text, parameters);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false; // Trả về false nếu có lỗi
            }
        }


        public string getTinhTrang(int maHS)
        {
            string query = "SELECT TinhTrang FROM HOCSINH WHERE MaHocSinh = @maHS";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@maHS", maHS)
            };

            try
            {
                // Sử dụng phương thức MyExecuteScalar để lấy giá trị trả về
                object result = MyExecuteScalar(query, CommandType.Text, parameters);

                if (result != null)
                {
                    return result.ToString(); // Trả về giá trị trạng thái
                }
                else
                {
                    return null; // Trả về null nếu không tìm thấy
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null; // Trả về null nếu có lỗi
            }
        }

        public StudentsDTO GetHocSinhById(int maHS)
        {
            StudentsDTO student = null;
            string query = "sp_GetHocSinhById";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@MaHocSinh", maHS)
            };

            try
            {
                // Sử dụng MyExecuteReader để lấy dữ liệu
                DataTable dt = MyExecuteReader(query, CommandType.StoredProcedure, parameters);

                if (dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    student = new StudentsDTO(
                        Convert.ToInt32(row["MaHocSinh"]),
                        row["TenHocSinh"].ToString(),
                        Convert.ToDateTime(row["NgaySinh"]),
                        row["GioiTinh"].ToString(),
                        row["TinhTrang"].ToString(),
                        row["QRCodePath"] as string,
                        row["TenLop"].ToString()
                    );
                }
            }
            catch (Exception ex)
            {
         
                Console.WriteLine("Error: " + ex.Message);
            }

            return student;
        }
     

    }
}
