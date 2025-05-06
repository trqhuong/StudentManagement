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
    public class ReportDAO: DataProvider
    {
        public List<ReportDTO> ThongKeTyLeDat(int maMon, int hocKy, int namHoc)
        {
            List<ReportDTO> list = new List<ReportDTO>();
            string sql = "sp_ThongKeTyLeDat";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@maMon", maMon),
                new SqlParameter("@hocKy", hocKy),
                new SqlParameter("@namHoc", namHoc)
            };

            try
            {
              
                SqlDataReader reader = MyExecuteReader(sql, CommandType.StoredProcedure, parameters);
                while (reader.Read())
                {
                    ReportDTO tk = new ReportDTO
                    {
                        Lop = Convert.ToInt32(reader["MaLop"]),
                        TenLop = reader["TenLop"].ToString(),
                        SiSo = Convert.ToInt32(reader["SiSo"]),
                        SoLuongDat = Convert.ToInt32(reader["SoLuongDat"])
                    };
                    tk.TyLeDat = Math.Round(100.0 * tk.SoLuongDat / tk.SiSo, 2);
                    list.Add(tk);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thống kê tỷ lệ đạt: " + ex.Message);
            }

            return list;
        }


    }
}
