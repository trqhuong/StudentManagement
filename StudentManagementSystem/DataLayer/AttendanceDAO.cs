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

            string query = "SELECT * FROM ĐIEMDANH";
            try
            {
                DataTable dt = MyExecuteReader(query, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                   
                    list.Add(new AttendanceDTO(
                         Convert.ToInt32(row["MaDiemDanh"]),
                         Convert.ToInt32(row["MaHS"]),
                         Convert.ToDateTime(row["NgayDiemDanh"]),
                         row["TrangThai"].ToString()
                        ));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
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
