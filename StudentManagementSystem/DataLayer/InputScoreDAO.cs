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
    public class InputScoreDAO
    {
        private string cnn = "Data Source=.;Initial Catalog=QLHocSinh;Integrated Security=True";
        public List<SubjectDTO> GetAssignmentSubject (int teacher_id)
        {
            List<SubjectDTO> subjects = new List<SubjectDTO>();
            using (SqlConnection conn = new SqlConnection(cnn))
            {
                conn.Open();
                string query = "SELECT * FROM MONHOC where MaMonHoc in ( SELECT MaMH FROM PHANCONG " +
                    "where MaGV = @teacher_id)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@teacher_id", teacher_id);
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
        public List<ClassDTO> GetAssignmentClass(int teacher_id, int subject_id )
        {
            List<ClassDTO> classes = new List<ClassDTO>();
            using (SqlConnection conn = new SqlConnection(cnn))
            {
                conn.Open();
                string query = "SELECT * FROM LOPHOC WHERE MaLop in (SELECT p.MaLop FROM PHANCONG p, LOPHOC l, NAMHOC m " +
                    "where p.MaLop = l.MaLop and l.NamHoc = m.MaNH and p.MaGV = @teacher_id and p.MaMH = @subject_id and m.TrangThai = 1)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@subject_id", subject_id);
                cmd.Parameters.AddWithValue("@teacher_id", teacher_id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    classes.Add(new ClassDTO (
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
        public List<ScoreDTO> GetScore(int class_id, int subject_id)
        {
            List<ScoreDTO> scores = new List<ScoreDTO>();
            using (SqlConnection conn = new SqlConnection(cnn))
            {
                conn.Open();
                string query = "SELECT * FROM DIEM where Malop = @class_id and MaMh = @subject_id ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@class_id", class_id);
                cmd.Parameters.AddWithValue("@subject_id", subject_id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    scores.Add(new ScoreDTO(
                        Convert.ToInt32(reader["MaLop"]),
                        Convert.ToInt32(reader["MaHS"]),
                        Convert.ToInt32(reader["MaMH"]),
                        Convert.ToInt32(reader["HocKy"]),
                        Convert.ToInt32(reader["Diem15P"]),
                        Convert.ToInt32(reader["Diem1T"]),
                        Convert.ToInt32(reader["DiemThi"])
                        ));
                }
            }
            return scores;
        }
        public bool SaveScore(int class_id, int student_id, int subject_id, float student_score15, float student_score1, float student_score)
        {
            using (SqlConnection conn = new SqlConnection(cnn))
            {
                conn.Open();
                // B1: Lấy học kỳ hiện tại
                int semester = 0;
                string query1 = "SELECT MaHK FROM HOCKY WHERE TrangThai = 1";
                SqlCommand cmd1 = new SqlCommand(query1, conn);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    semester = Convert.ToInt32(reader1["MaHK"]);
                }
                reader1.Close();
                // B2: Kiểm tra tồn tại
                string checkQuery = "SELECT COUNT(*) FROM DIEM " +
                    "WHERE MaLop = @class_id AND MaHS = @student_id AND MaMH = @subject_id AND HocKy = @semester_id";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@class_id", class_id);
                checkCmd.Parameters.AddWithValue("@student_id", student_id);
                checkCmd.Parameters.AddWithValue("@subject_id", subject_id);
                checkCmd.Parameters.AddWithValue("@semester_id", semester);
                int count = (int)checkCmd.ExecuteScalar(); // trả về số dòng
                if (count > 0)
                {
                    // B3.1: Đã có → UPDATE
                    string updateQuery = @"UPDATE DIEM SET 
                            Diem15P = @student_score15, 
                            Diem1T = @student_score1, 
                            DiemThi = @student_score
                         WHERE MaLop = @class_id AND MaHS = @student_id AND MaMH = @subject_id AND HocKy = @semester_id";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@student_score15", student_score15);
                    updateCmd.Parameters.AddWithValue("@student_score1", student_score1);
                    updateCmd.Parameters.AddWithValue("@student_score", student_score);
                    updateCmd.Parameters.AddWithValue("@class_id", class_id);
                    updateCmd.Parameters.AddWithValue("@student_id", student_id);
                    updateCmd.Parameters.AddWithValue("@subject_id", subject_id);
                    updateCmd.Parameters.AddWithValue("@semester_id", semester);
                    updateCmd.ExecuteNonQuery();
                    MessageBox.Show("Đã cập nhật điểm.");
                }
                else
                {
                    // B3.2: Chưa có → INSERT
                    string insertQuery = @" INSERT INTO DIEM (MaLop, MaHS, MaMH, HocKy, Diem15P, Diem1T, DiemThi)
                        VALUES (@class_id, @student_id, @subject_id, @semester_id, @student_score15, @student_score1, @student_score)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@class_id", class_id);
                    insertCmd.Parameters.AddWithValue("@student_id", student_id);
                    insertCmd.Parameters.AddWithValue("@subject_id", subject_id);
                    insertCmd.Parameters.AddWithValue("@semester_id", semester);
                    insertCmd.Parameters.AddWithValue("@student_score15", student_score15);
                    insertCmd.Parameters.AddWithValue("@student_score1", student_score1);
                    insertCmd.Parameters.AddWithValue("@student_score", student_score);
                    insertCmd.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm điểm mới.");
                }
            }
            return true;
        }
    }
}
