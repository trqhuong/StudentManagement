using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TransferObject;

namespace DataLayer
{
    public class SubjectDAO : DataProvider
    {
        public List<SubjectDTO> GetAllSubject()
        {
            List<SubjectDTO> subjects = new List<SubjectDTO>();
            string query = "SELECT * FROM MONHOC";

            try
            {
                Connect();
                using (SqlDataReader reader = MyExecuteReader(query, CommandType.Text))
                {
                    while (reader.Read())
                    {
                        int maMH = Convert.ToInt32(reader["MaMonHoc"]);
                        string tenMH = reader["TenMonHoc"].ToString();
                        SubjectDTO subject = new SubjectDTO(maMH, tenMH);
                        subjects.Add(subject);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }

            return subjects;
        }


        public int AddSubject(SubjectDTO subject)
        {
            string query = "INSERT INTO MONHOC (TenMonHoc) VALUES (@TenMonHoc); SELECT SCOPE_IDENTITY();";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@TenMonHoc", subject.TenMH)
            };

            try
            {
                object result = MyExecuteScalar(query, CommandType.Text, parameters);

                if (result == null || result == DBNull.Value)
                {
                    throw new Exception("Không thể lấy ID môn học sau khi thêm.");
                }

                return Convert.ToInt32(result);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khác: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public int UpdateSubject(SubjectDTO subject)
        {
            string query = "UPDATE MONHOC SET TenMonHoc=@TenMonHoc WHERE MaMonHoc=@MaMonHoc";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@TenMonHoc", subject.TenMH),
                new SqlParameter("@MaMonHoc", subject.MaMH)
            };

            try
            {
                return MyExecuteNonQuery(query, CommandType.Text, parameters);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khác: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public bool DeleteSubject(int maMH)
        {
            string query = "DELETE FROM MONHOC WHERE MaMonHoc=@MaMonHoc";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@MaMonHoc", maMH)
            };

            try
            {
                int rowsAffected = MyExecuteNonQuery(query, CommandType.Text, parameters);
                return rowsAffected > 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khác: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //chỉ lấy môn học giáo viên dạy
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
        
        //lấy môn học chưa được phân công
        public List<SubjectDTO> GetSubjectNoSchedule(int class_id)
        {
            List<SubjectDTO> subjects = new List<SubjectDTO>();
            string query = @"SELECT * FROM MONHOC 
                         WHERE MaMonHoc NOT IN (
                             SELECT MaMH FROM PHANCONG WHERE MaLop = @class_id
                         )";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@class_id", class_id)
            };
            Connect();
            using (SqlDataReader reader = MyExecuteReader(query, CommandType.Text, parameters))
            {
                while (reader.Read())
                {
                    subjects.Add(new SubjectDTO(
                        Convert.ToInt32(reader["MaMonHoc"]),
                        reader["TenMonHoc"].ToString()
                    ));
                }
            }
            DisConnect();
            return subjects;
        }
    }
}
