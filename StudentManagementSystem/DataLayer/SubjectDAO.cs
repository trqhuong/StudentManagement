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
    public class SubjectDAO
    {
        private string cnn = "Data Source=.;Initial Catalog=QLHocSinh;Integrated Security=True";

        public List<SubjectDTO> GetAllSubject()
        {
            List<SubjectDTO> subjects = new List<SubjectDTO>();

            try
            {
                using (SqlConnection conn = new SqlConnection(cnn))
                {
                    conn.Open();
                    string sql = "SELECT * FROM MonHoc";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int maMH = reader.GetInt32(0);
                        string tenMH = reader.GetString(1);
                        SubjectDTO subject = new SubjectDTO(maMH, tenMH);
                        subjects.Add(subject);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return subjects;

        }

        public int AddSubject(SubjectDTO subject)
        {
            using (SqlConnection conn = new SqlConnection(cnn))
            {
                conn.Open();
                try
                {
                    string query = "INSERT INTO MONHOC (TenMonHoc) VALUES (@TenMonHoc); SELECT SCOPE_IDENTITY();";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenMonHoc", subject.TenMH);
                        object result = cmd.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
                        {
                            throw new Exception("Không thể lấy ID môn học sau khi thêm.");
                        }

                        return Convert.ToInt32(result);
                    }
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
        }
        public int UpdateSubject(SubjectDTO subject)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(cnn))
                {
                    conn.Open();
                    string query = "UPDATE MONHOC SET TenMonHoc=@TenMonHoc WHERE MaMonHoc=@MaMonHoc";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenMonHoc", subject.TenMH);
                        cmd.Parameters.AddWithValue("@MaMonHoc", subject.MaMH);
                        return cmd.ExecuteNonQuery();
                    }
                }
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
            using (SqlConnection conn = new SqlConnection(cnn))
            {
                conn.Open();
                try
                {
                    string query = "DELETE FROM MONHOC WHERE MaMonHoc=@MaMonHoc";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaMonHoc", maMH);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
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
        }

    }
}
