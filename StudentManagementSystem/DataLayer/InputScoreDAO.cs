using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace DataLayer
{
    public class InputScoreDAO: DataProvider
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
        public List<StudentsDTO> GetStudentInClass(int class_id)
        {
            List<StudentsDTO> students = new List<StudentsDTO>();
            string query = "SELECT MaHocSinh, TenHocSinh FROM HOCSINH WHERE MaHocSinh in (SELECT h.MaHocSinh FROM HOCSINH_LOP hl, HOCSINH h " +
                "where hl.MaHS = h.MaHocSinh and hl.MaLop = @class_id )";
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
        public List<ScoreDTO> GetScore(int class_id, int subject_id)
        {
            List<ScoreDTO> scores = new List<ScoreDTO>();
            string query = "SELECT * FROM DIEM WHERE MaLop = @class_id AND MaMH = @subject_id";
            List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@class_id", class_id),
                    new SqlParameter("@subject_id", subject_id)
                };

            using (SqlDataReader reader = MyExecuteReader(query, CommandType.Text, parameters))
            {
                while (reader.Read())
                {
                    scores.Add(new ScoreDTO(
                        Convert.ToInt32(reader["MaLop"]),
                        Convert.ToInt32(reader["MaHS"]),
                        Convert.ToInt32(reader["MaMH"]),
                        Convert.ToInt32(reader["HocKy"]),
                        Convert.ToSingle(reader["Diem15P"]),
                        Convert.ToSingle(reader["Diem1T"]),
                        Convert.ToSingle(reader["DiemThi"])
                    ));
                }
            }
            return scores;
        }

        public bool SaveScore(ScoreDTO score)
        {
            // B1: Lấy học kỳ hiện tại
            string q = "SELECT MaHK FROM HOCKY WHERE TrangThai = 1";
            int semester = Convert.ToInt32(MyExecuteScalar(q, CommandType.Text));
            // B2: Kiểm tra điểm đã tồn tại chưa
            string checkQuery = @"SELECT COUNT(*) FROM DIEM 
                          WHERE MaLop = @class_id AND MaHS = @student_id AND MaMH = @subject_id AND HocKy = @semester_id";
            List<SqlParameter> checkParams = new List<SqlParameter>
            {
                new SqlParameter("@class_id", score.MaLop),
                new SqlParameter("@student_id", score.MaHS),
                new SqlParameter("@subject_id", score.MaMH),
                new SqlParameter("@semester_id", semester)
            };
            // trả về số dòng
            int count = Convert.ToInt32(MyExecuteScalar(checkQuery, CommandType.Text, checkParams));
            // B3: Thực hiện INSERT hoặc UPDATE
            string query;
            List<SqlParameter> scoreParams = new List<SqlParameter>
            {
                new SqlParameter("@student_score15", score.Diem15P),
                new SqlParameter("@student_score1",  score.Diem1T),
                new SqlParameter("@student_score",  score.DiemThi),
                new SqlParameter("@class_id", score.MaLop),
                new SqlParameter("@student_id", score.MaHS),
                new SqlParameter("@subject_id", score.MaMH),
                new SqlParameter("@semester_id", semester)
            };

            if (count > 0)
            {
                // Cập nhật
                query = @"UPDATE DIEM SET 
                    Diem15P = @student_score15, 
                    Diem1T = @student_score1, 
                    DiemThi = @student_score
                  WHERE MaLop = @class_id AND MaHS = @student_id AND MaMH = @subject_id AND HocKy = @semester_id";
            }
            else
            {
                // Thêm mới
                query = @"INSERT INTO DIEM (MaLop, MaHS, MaMH, HocKy, Diem15P, Diem1T, DiemThi)
                  VALUES (@class_id, @student_id, @subject_id, @semester_id, @student_score15, @student_score1, @student_score)";
            }
            return MyExecuteNonQuery(query, CommandType.Text, scoreParams) > 0;
        }
    }
}
