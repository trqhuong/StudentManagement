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
                           "FROM HOCSINH hs " +
                           "JOIN HOCSINH_LOP hs_l ON hs.MaHocSinh = hs_l.MaHS " +
                           "JOIN LOPHOC l ON hs_l.MaLop = l.MaLop";
            try
            {
                
                SqlDataReader reader = MyExecuteReader(query, CommandType.Text);
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
                reader.Close();  
            }
            catch (Exception ex)
            {
               
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                DisConnect();
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
           
                int rowsAffected = MyExecuteNonQuery(query, CommandType.Text, parameters);

                return rowsAffected > 0; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật QRCodePath: " + ex.Message);
                return false; 
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
            string updateClassQuery = @"
                                       UPDATE HOCSINH_LOP
                                                        SET MaLop = (
                                                            SELECT TOP 1 L.MaLop
                                                            FROM LOPHOC L
                                                            JOIN NAMHOC NH ON L.NamHoc = NH.MaNH
                                                            WHERE L.TenLop = @TenLop AND NH.TrangThai = 1 ) WHERE MaHS = @MaHocSinh";

            var parameters2 = new List<SqlParameter>
            {
                new SqlParameter("@TenLop", hs.TenLop),
                new SqlParameter("@MaHocSinh", hs.MaHS)
            };
            try
            {
                int studentRowsAffected = MyExecuteNonQuery(updateQuery, CommandType.Text, parameters1);
                int classRowsAffected = MyExecuteNonQuery(updateClassQuery, CommandType.Text, parameters2);
               
                return studentRowsAffected > 0 && classRowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false; 
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
            
                object result = MyExecuteScalar(query, CommandType.Text, parameters);

                if (result != null)
                {
                    return result.ToString(); 
                }
                else
                {
                    return null; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null; 
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
                
                SqlDataReader reader = MyExecuteReader(query, CommandType.StoredProcedure, parameters);

                if (reader.HasRows)
                {
                    reader.Read();  
                    student = new StudentsDTO(
                        Convert.ToInt32(reader["MaHocSinh"]),
                        reader["TenHocSinh"].ToString(),
                        Convert.ToDateTime(reader["NgaySinh"]),
                        reader["GioiTinh"].ToString(),
                        reader["TinhTrang"].ToString(),
                        reader["QRCodePath"] as string,
                        reader["TenLop"].ToString()
                    );
                }
                reader.Close();  
            }
            catch (Exception ex)
            {
               
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
            return student;
        }

        public List<StudentsDTO> GetStudentByClass(int classID)
        {
            List<StudentsDTO> students = new List<StudentsDTO>();
            string query = "SELECT * FROM HOCSINH WHERE MaHocSinh in (SELECT h.MaHocSinh FROM HOCSINH_LOP hl, HOCSINH h " +
                    "where hl.MaHS = h.MaHocSinh and hl.MaLop = @classID )";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@classID", classID)
            };
            Connect();
            using (SqlDataReader reader = MyExecuteReader(query, CommandType.Text, parameters))
            {
                while (reader.Read())
                {
                    students.Add(new StudentsDTO(
                        Convert.ToInt32(reader["MaHocSinh"]),
                        reader["TenHocSinh"].ToString(),
                        Convert.ToDateTime(reader["NgaySinh"]),
                        reader["GioiTinh"].ToString(),
                        reader["TinhTrang"].ToString(),
                        reader["QRCodePath"].ToString()
                    ));
                }
            }
            DisConnect();
            return students;
        }
        public List<StudentsDTO> GetStudentNoClass(int class_id)
        {
            List<StudentsDTO> students = new List<StudentsDTO>();
            string query = "SELECT Khoi From LOPHOC WHERE MaLop = @classID";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@classID", class_id)
            };
            int khoi = Convert.ToInt32(MyExecuteScalar(query, CommandType.Text, parameters));
            string pro = "sp_GetMaxKhoi";
            Connect();
            using (SqlDataReader reader = MyExecuteReader(pro, CommandType.StoredProcedure))
            {
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["KhoiLonNhat"]) == khoi)
                    {
                        students.Add(new StudentsDTO(
                        Convert.ToInt32(reader["MaHocSinh"]),
                        reader["TenHocSinh"].ToString(),
                        Convert.ToDateTime(reader["NgaySinh"]),
                        reader["GioiTinh"].ToString()
                        ));
                    }
                }
            }
            DisConnect();
            return students;
        }
        public bool AddStudentInClass(int class_id, int student_id)
        {
            string query = @"INSERT INTO HOCSINH_LOP (MaHS, MaLop) VALUES ( @student_id, @class_id )
                            UPDATE LOPHOC SET SiSo = SiSo + 1 WHERE MaLop = @class_id ";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@class_id", class_id),
                new SqlParameter("@student_id", student_id)
            };
            return MyExecuteNonQuery(query, CommandType.Text, parameters) > 0;
        }


    }
}
