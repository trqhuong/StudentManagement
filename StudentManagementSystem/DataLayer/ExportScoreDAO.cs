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
    public class ExportScoreDAO
    {
        private string cnn = "Data Source=.;Initial Catalog=QLHocSinh;Integrated Security=True";
        public List<SubjectDTO> GetAssignmentSubject(int teacher_id)
        {
            List<SubjectDTO> subjects = new List<SubjectDTO>();
            using (SqlConnection conn = new SqlConnection(cnn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_GetAssignmentSubject", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaGV", teacher_id);
                SqlDataReader reader = cmd.ExecuteReader();
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
        public List<ClassDTO> GetAssignmentClass(int teacher_id, int subject_id, int year_id)
        {
            List<ClassDTO> classes = new List<ClassDTO>();
            using (SqlConnection conn = new SqlConnection(cnn))
            {
                conn.Open();
                string query = "SELECT * FROM LOPHOC WHERE MaLop IN ( SELECT p.MaLop FROM PHANCONG p, LOPHOC l " +
                    "where p.MaLop = l.MaLop and p.MaMH = @subject_id and p.MaGV = @teacher_id and l.NamHoc = @year_id)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@teacher_id", teacher_id);
                cmd.Parameters.AddWithValue("@subject_id", subject_id);
                cmd.Parameters.AddWithValue("@year_id", year_id);
                SqlDataReader reader = cmd.ExecuteReader();
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
            using (SqlConnection conn = new SqlConnection(cnn))
            {
                conn.Open();
                string query = "SELECT * FROM NAMHOC";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
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
            using (SqlConnection conn = new SqlConnection(cnn))
            {
                conn.Open();
                string query = "SELECT MaHocSinh, TenHocSinh FROM HOCSINH WHERE MaHocSinh in (SELECT h.MaHocSinh FROM HOCSINH_LOP hl, HOCSINH h " +
                    "where hl.MaHS = h.MaHocSinh and hl.MaLop = @class_id )";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@class_id", class_id);
                SqlDataReader reader = cmd.ExecuteReader();
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
        public List<AverageScoreDTO> ExportScore(int subject_id,int class_id, int year_id)
        {
            List<AverageScoreDTO> averagescores = new List<AverageScoreDTO>();
            using (SqlConnection conn = new SqlConnection(cnn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ExportScore", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaLop", class_id);
                cmd.Parameters.AddWithValue("@MaMH", subject_id);
                cmd.Parameters.AddWithValue("@MaNH", year_id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    float diemHK1 = reader["DiemTBHK1"] != DBNull.Value ? Convert.ToSingle(reader["DiemTBHK1"]) : 0;
                    float diemHK2 = reader["DiemTBHK2"] != DBNull.Value ? Convert.ToSingle(reader["DiemTBHK2"]) : 0;
                    float diemCaNam = (float)Math.Round((diemHK1 + diemHK2 * 2) / 3, 1);
                    averagescores.Add(new AverageScoreDTO(
                        Convert.ToInt32(reader["MaHocSinh"].ToString()),
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
