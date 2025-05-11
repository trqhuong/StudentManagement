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
    public class ExportScoreDAO: DataProvider
    {
        public List<SubjectDTO> GetAssignmentSubject()
        {
            List<SubjectDTO> subjects = new List<SubjectDTO>();
            // Lấy mã giáo viên
            int teacher_id = Convert.ToInt32(MyExecuteScalar("sp_GetTeacherActive", CommandType.StoredProcedure));
            //lấy môn học
            List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@MaGV", teacher_id)
                };
            using (SqlDataReader reader = MyExecuteReader("sp_GetAssignmentSubject", CommandType.StoredProcedure, parameters))
            {
                while (reader.Read())
                {
                    subjects.Add(new SubjectDTO(
                        Convert.ToInt32(reader["MaMonHoc"]),
                        reader["TenMonHoc"].ToString()
                    ));
                }
            }
            return subjects;
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
            return classes;
        }

        public List<SchoolYearDTO> GetSchoolYear()
        {
            List<SchoolYearDTO> schoolyears = new List<SchoolYearDTO>();
            string query = "SELECT * FROM NAMHOC";
            using (SqlDataReader reader = MyExecuteReader(query, CommandType.Text))
            {
                while (reader.Read())
                {
                    schoolyears.Add(new SchoolYearDTO(
                        Convert.ToInt32(reader["MaNH"]),
                        Convert.ToInt32(reader["NamBatDau"]),
                        Convert.ToInt32(reader["NamKetThuc"])
                    ));
                }
            }
            return schoolyears;
        }

        public List<StudentsDTO> GetStudentInClass(int class_id)
        {
            List<StudentsDTO> students = new List<StudentsDTO>();
            string query = "SELECT MaHocSinh, TenHocSinh FROM HOCSINH WHERE MaHocSinh IN " +
                           "(SELECT h.MaHocSinh FROM HOCSINH_LOP hl, HOCSINH h " +
                           "WHERE hl.MaHS = h.MaHocSinh AND hl.MaLop = @class_id)";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@class_id", class_id)
            };

            using (SqlDataReader reader = MyExecuteReader(query, CommandType.Text, parameters))
            {
                while (reader.Read())
                {
                    students.Add(new StudentsDTO(
                        Convert.ToInt32(reader["MaHocSinh"]),
                        reader["TenHocSinh"].ToString()
                    ));
                }
            }
            return students;
        }

        public List<AverageScoreDTO> ExportScore(int subject_id, int class_id, int year_id)
        {
            List<AverageScoreDTO> averagescores = new List<AverageScoreDTO>();
            string procedureName = "sp_ExportScore";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@MaLop", class_id),
                new SqlParameter("@MaMH", subject_id),
                new SqlParameter("@MaNH", year_id)
            };

            using (SqlDataReader reader = MyExecuteReader(procedureName, CommandType.StoredProcedure, parameters))
            {
                while (reader.Read())
                {
                    float diemHK1 = reader["DiemTBHK1"] != DBNull.Value ? Convert.ToSingle(reader["DiemTBHK1"]) : 0;
                    float diemHK2 = reader["DiemTBHK2"] != DBNull.Value ? Convert.ToSingle(reader["DiemTBHK2"]) : 0;
                    float diemCaNam = (float)Math.Round((diemHK1 + diemHK2 * 2) / 3, 1);
                    averagescores.Add(new AverageScoreDTO(
                        Convert.ToInt32(reader["MaHocSinh"]),
                        diemHK1,
                        diemHK2,
                        diemCaNam
                    ));
                }
            }
            return averagescores;
        }

    }
}
