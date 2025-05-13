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
               
                SqlDataReader reader = MyExecuteReader(query, CommandType.Text);

                while (reader.Read())
                {
                    list.Add(new AttendanceDTO(
                        Convert.ToInt32(reader["MaDiemDanh"]),
                        Convert.ToInt32(reader["MaHS"]),
                        Convert.ToDateTime(reader["NgayDiemDanh"]),
                        reader["TrangThai"].ToString()
                    ));
                }

               
                reader.Close();
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


        public List<int> GetHocSinhChuaDiemDanh()
        {
            List<int> result = new List<int>();
            string query = @"
                SELECT hs.MaHocSinh
                FROM HOCSINH hs
                INNER JOIN HOCSINH_LOP hsl ON hs.MaHocSinh = hsl.MaHS
                WHERE NOT EXISTS (
                    SELECT 1 FROM ĐIEMDANH dd
                    WHERE dd.MaHS = hs.MaHocSinh AND dd.NgayDiemDanh = CAST(GETDATE() AS DATE)
                );";

            SqlDataReader reader = MyExecuteReader(query, CommandType.Text);
            while (reader.Read())
            {
                result.Add(reader.GetInt32(0));
            }
            reader.Close();
            return result;
        }

        public bool InsertDiemDanhVangMat(int maHS)
        {
            string query = @"
                INSERT INTO ĐIEMDANH (MaHS, NgayDiemDanh, TrangThai)
                VALUES (@MaHS, CAST(GETDATE() AS DATE), N'Vắng mặt')";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@MaHS", maHS)
            };

            int affected = MyExecuteNonQuery(query, CommandType.Text, parameters);
            return affected > 0;
        }

        public List<AbsentStudentDTO> LayDanhSachHocSinhVang()
        {
            List<AbsentStudentDTO> list = new List<AbsentStudentDTO>();
            string proc = "sp_ThongBaoHocSinhVangHomNay";


            using (SqlDataReader reader = MyExecuteReader(proc, CommandType.StoredProcedure))
            {
                while (reader.Read())
                {
                    var hs = new AbsentStudentDTO
                    {
                        MaHocSinh = reader["MaHocSinh"].ToString(),
                        TenHocSinh = reader["TenHocSinh"].ToString(),
                        MaLop = reader["MaLop"].ToString(),
                        TenLop = reader["TenLop"].ToString(),
                        MaGiaoVien = reader["MaGiaoVien"].ToString(),
                        TenGiaoVien = reader["TenGiaoVien"].ToString(),
                        Email = reader["Email"].ToString(),
                        NgayVang = Convert.ToDateTime(reader["NgayDiemDanh"])
                    };

                    list.Add(hs);
                }

                reader.Close();

            }

            return list;
        }

    }
}
