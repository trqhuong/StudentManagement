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
    public class AttendanceDAO : DataProvider
    {
        public List<AttendanceDTO> GetAllAttendance()
        {
            List<AttendanceDTO> list = new List<AttendanceDTO>();
            string query = "SELECT * FROM DIEMDANH";
            try
            {
                Connect();
                using (SqlDataReader reader = MyExecuteReader(query,CommandType.Text))
                {
                    while (reader.Read())
                    {
                        list.Add(new AttendanceDTO(
                            Convert.ToInt32(reader["MaDiemDanh"]),
                            Convert.ToInt32(reader["MaHS"]),
                            Convert.ToDateTime(reader["NgayDiemDanh"]),
                            reader["TrangThai"].ToString()
                        ));
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

            return list;
        }
        public bool InsertDiemDanh(AttendanceDTO dto)
        {
            string query = @"
                            IF NOT EXISTS (
                                SELECT 1 FROM ĐIEMDANH
                                WHERE MaHS = @MaHS AND NgayDiemDanh = CAST(GETDATE() AS DATE)
                            )
                            BEGIN
                                INSERT INTO ĐIEMDANH (MaHS, TrangThai)
                                VALUES (@MaHS, @TrangThai)
                            END";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@MaHS", dto.MaHS),
                new SqlParameter("@TrangThai", dto.TrangThai)
            };

            int rowsAffected = MyExecuteNonQuery(query, CommandType.Text, parameters);
            return rowsAffected > 0;
        }

    }
}
