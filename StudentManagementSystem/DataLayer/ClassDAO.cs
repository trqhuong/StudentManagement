using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransferObject;

namespace DataLayer
{
    public class ClassDAO : DataProvider
    {

        public List<ClassDTO> GetAllClass()
        {
            List<ClassDTO> lopHoc = new List<ClassDTO>();
            string query = "SELECT * FROM LOPHOC l, NAMHOC n Where l.NamHoc = n.MaNH and n.TrangThai = 1";
            try
            {
                Connect();
                using (SqlDataReader reader = MyExecuteReader(query, CommandType.Text))
                {
                    while (reader.Read())
                    {
                        lopHoc.Add(new ClassDTO(
                            Convert.ToInt32(reader["MaLop"]),
                            reader["TenLop"].ToString(),
                            Convert.ToInt32(reader["Khoi"]),
                            reader["NamHoc"].ToString(),
                            reader["GVQuanLi"].ToString(),
                            Convert.ToInt32(reader["SiSo"])
                        ));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách lớp: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
            return lopHoc;
        }


        public int AddClass(ClassDTO classDTO)
        {
            string query = @"INSERT INTO LOPHOC (TenLop, Khoi, NamHoc, GVQuanLi, SiSo)
                             VALUES (@TenLop, (SELECT TOP 1 MaNH FROM NAMHOC WHERE TrangThai = 1), @GVQuanLi, @SiSo);
                             SELECT SCOPE_IDENTITY();";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@TenLop", classDTO.TenLop),
                new SqlParameter("@Khoi", classDTO.Khoi),
                new SqlParameter("@GVQuanLi", classDTO.GVQuanLi),
                new SqlParameter("@SiSo", classDTO.SiSo)
            };

            try
            {
                object result = MyExecuteScalar(query, CommandType.Text, parameters);
                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm lớp học: " + ex.Message);
                return -1;
            }
        }

        public int UpdateClass(ClassDTO classDTO)
        {
            string query = @"UPDATE LOPHOC 
                             SET TenLop = @TenLop, 
                                 Khoi = @Khoi,
                                 GVQuanLi = @GVQuanLi, 
                                 SiSo = @SiSo
                             WHERE MaLop = @MaLop;";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@MaLop", classDTO.MaLop),
                new SqlParameter("@TenLop", classDTO.TenLop),
                new SqlParameter("@Khoi", classDTO.Khoi),
                new SqlParameter("@GVQuanLi", classDTO.GVQuanLi),
                new SqlParameter("@SiSo", classDTO.SiSo)
            };

            try
            {
                return MyExecuteNonQuery(query, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật lớp học: " + ex.Message);
                return -1;
            }
        }
        public bool DeleteClass(int maLop)
        {
            string query = "DELETE FROM LOPHOC WHERE MaLop = @MaLop";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@MaLop", maLop)
            };

            try
            {
                int rowsAffected = MyExecuteNonQuery(query, CommandType.Text, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa lớp học: " + ex.Message);
                return false;
            }
        }
        public List<ClassDTO> GetClassTeacher()
        {
            List<ClassDTO> lopHoc = new List<ClassDTO>();
            // Lấy mã giáo viên
            int teacher_id = Convert.ToInt32(MyExecuteScalar("sp_GetTeacherActive", CommandType.StoredProcedure));
            //lấy lớp
            string query = @"SELECT l.* FROM LOPHOC l
                     INNER JOIN PHANCONG p ON p.MaLop = l.MaLop
                     INNER JOIN NAMHOC m ON l.NamHoc = m.MaNH
                     WHERE p.MaGV = @teacherID AND m.TrangThai = 1";
            List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@teacherID", teacher_id)
                };
            Connect();
            using (SqlDataReader reader = MyExecuteReader(query, CommandType.Text, parameters))
            {
                while (reader.Read())
                {
                    lopHoc.Add(new ClassDTO(
                        Convert.ToInt32(reader["MaLop"]),
                        reader["TenLop"].ToString(),
                        Convert.ToInt32(reader["Khoi"]),
                        reader["NamHoc"].ToString(),
                        reader["GVQuanLi"].ToString(),
                        Convert.ToInt32(reader["SiSo"])
                    ));
                }
            }
            DisConnect();
            return lopHoc;
        }
        
        //lấy các lớp giáo viên dạy môn học này trong năm học hiện tại
        public List<ClassDTO> GetAssignmentClass(int subject_id)
        {
            List<ClassDTO> classes = new List<ClassDTO>();
            // Lấy mã giáo viên
            int teacher_id = Convert.ToInt32(MyExecuteScalar("sp_GetTeacherActive", CommandType.StoredProcedure));
            //lấy môn học
            List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@MaGV", teacher_id),
                    new SqlParameter("@MaMH", subject_id)
                };
            using (SqlDataReader reader = MyExecuteReader("sp_GetAssignmentClass", CommandType.StoredProcedure, parameters))
            {
                while (reader.Read())
                {
                    classes.Add(new ClassDTO(
                        Convert.ToInt32(reader["MaLop"]),
                        reader["TenLop"].ToString()
                    ));
                }
            }
            return classes;
        }


        public List<ClassDTO> GetAssignmentClass(int subject_id, int year_id)
        {
            List<ClassDTO> classes = new List<ClassDTO>();
            // B1: Lấy mã giáo viên đang hoạt động
            int teacher_id = Convert.ToInt32(MyExecuteScalar("sp_GetTeacherActive", CommandType.StoredProcedure));
            // B2: Lấy danh sách lớp được phân công
            string query = @"SELECT * FROM LOPHOC WHERE MaLop IN (
                        SELECT p.MaLop FROM PHANCONG p, LOPHOC l
                        WHERE p.MaLop = l.MaLop 
                          AND p.MaMH = @subject_id 
                          AND p.MaGV = @teacher_id 
                          AND l.NamHoc = @year_id
                     )";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@subject_id", subject_id),
                new SqlParameter("@teacher_id", teacher_id),
                new SqlParameter("@year_id", year_id)
            };
            Connect();
            using (SqlDataReader reader = MyExecuteReader(query, CommandType.Text, parameters))
            {
                while (reader.Read())
                {
                    classes.Add(new ClassDTO(
                        Convert.ToInt32(reader["MaLop"]),
                        reader["TenLop"].ToString()
                    ));
                }
            }
            DisConnect();
            return classes;
        }
        public ClassDTO GetClassById(int class_id)
        {
            ClassDTO classes = new ClassDTO();
            string query = "SELECT * FROM LOPHOC WHERE MaLop = @class_id";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@class_id", class_id)
            };
            Connect();
            using (SqlDataReader reader = MyExecuteReader(query, CommandType.Text, parameters))
            {
                if (reader.Read())
                {
                    classes = new ClassDTO(
                        Convert.ToInt32(reader["MaLop"]),
                        reader["TenLop"].ToString()
                    );
                }
            }
            DisConnect();
            return classes;
        }
    }
}