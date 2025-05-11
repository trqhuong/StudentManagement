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
    public class ScoreDAO: DataProvider
    {

        public List<ScoreDTO> GetScore(int class_id, int subject_id)
        {
            List<ScoreDTO> scores = new List<ScoreDTO>();
            string query = "SELECT * FROM DIEM WHERE MaLop = @class_id AND MaMH = @subject_id";
            List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@class_id", class_id),
                    new SqlParameter("@subject_id", subject_id)
                };
            Connect();
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
            DisConnect();
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

        public List<AverageScoreDTO> ExportScore(int subject_id, int class_id)
        {
            List<AverageScoreDTO> averagescores = new List<AverageScoreDTO>();
            string procedureName = "sp_ExportScore";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@MaLop", class_id),
                new SqlParameter("@MaMH", subject_id)
            };
            Connect();
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
            DisConnect();
            return averagescores;
        }
    }
}
