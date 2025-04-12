using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class AttendanceDAO
    {
        private string cnn= "Data Source=.;Initial Catalog=QLHocSinh;Integrated Security=True";
        public bool InsertDiemDanh(AttendanceDTO dto)
        {
            using (SqlConnection conn = new SqlConnection(cnn))
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

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHS", dto.MaHS);
                cmd.Parameters.AddWithValue("@TrangThai", dto.TrangThai);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
