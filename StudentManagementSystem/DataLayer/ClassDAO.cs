using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransferObject;

namespace DataLayer
{
    public class ClassDAO : DataProvider
    {

        public List<ClassDTO> GetAllLopHoc()
        {
            List<ClassDTO> lopHoc = new List<ClassDTO>();
            string query = "SELECT * FROM LOPHOC";

            try
            {
                SqlDataReader reader = MyExecuteReader(query, CommandType.Text);

                while (reader.Read())
                {
                    lopHoc.Add(new ClassDTO(
                        Convert.ToInt32(reader["MaLop"]),
                        reader["TenLop"].ToString(),
                        reader["NamHoc"].ToString(),
                        reader["GVQuanLi"].ToString(),
                        Convert.ToInt32(reader["SiSo"])
                    ));
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách lớp: " + ex.Message);
            }

            return lopHoc;
        }
        public int AddClass(ClassDTO classDTO)
        {
            string query = @"INSERT INTO LOPHOC (TenLop, NamHoc, GVQuanLi, SiSo)
                             VALUES (@TenLop, (SELECT TOP 1 MaNH FROM NAMHOC WHERE TrangThai = 1), @GVQuanLi, @SiSo);
                             SELECT SCOPE_IDENTITY();";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@TenLop", classDTO.TenLop),
                new SqlParameter("@GVQuanLi", classDTO.GVQuanLi),
                new SqlParameter("@SiSo", classDTO.SiSo)
            };

            try
            {
                object result = MyExecuteScalar(query, CommandType.Text, parameters);
                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm lớp học: " + ex.Message);
                return -1;
            }
        }

        public int UpdateClass(ClassDTO classDTO)
        {
            string query = @"UPDATE LOPHOC 
                             SET TenLop = @TenLop, 
                                 NamHoc = (SELECT TOP 1 MaNH FROM NAMHOC WHERE TrangThai = 1), 
                                 GVQuanLi = @GVQuanLi, 
                                 SiSo = @SiSo
                             WHERE MaLop = @MaLop;";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@MaLop", classDTO.MaLop),
                new SqlParameter("@TenLop", classDTO.TenLop),
                new SqlParameter("@GVQuanLi", classDTO.GVQuanLi),
                new SqlParameter("@SiSo", classDTO.SiSo)
            };

            try
            {
                return MyExecuteNonQuery(query, CommandType.Text, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật lớp học: " + ex.Message);
                return -1;
            }
        }
        public bool DeleteClass(int maLop)
        {
            string query = "DELETE FROM LOPHOC WHERE MaLop = @MaLop";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@MaLop", maLop)
            };

            try
            {
                int rowsAffected = MyExecuteNonQuery(query, CommandType.Text, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa lớp học: " + ex.Message);
                return false;
            }
        }


        public List<ClassDTO> GetAllLopHocTheoTrangThai()
        {
            List<ClassDTO> lopHoc = new List<ClassDTO>();

            string query = @"
                    SELECT lh.*
                    FROM LOPHOC lh
                    WHERE lh.NamHoc IN (
                        SELECT DISTINCT hk.NamHoc
                        FROM HOCKY hk
                        WHERE hk.TrangThai = 1
                    )";

            try
            {
                SqlDataReader reader = MyExecuteReader(query, CommandType.Text);
                while (reader.Read())
                {
                    lopHoc.Add(new ClassDTO(
                        Convert.ToInt32(reader["MaLop"]),
                        reader["TenLop"].ToString(),
                        reader["NamHoc"].ToString(),
                        reader["GVQuanLi"].ToString(),
                        Convert.ToInt32(reader["SiSo"])
                    ));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return lopHoc;
        }
    }
}