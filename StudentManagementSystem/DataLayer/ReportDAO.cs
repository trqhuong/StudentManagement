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

            // Truy vấn SQL cho stored procedure
            string sql = "sp_ThongKeTyLeDat"; // Tên của stored procedure

            // Tạo các tham số cho stored procedure
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@maMon", maMon),
                new SqlParameter("@hocKy", hocKy),
                new SqlParameter("@namHoc", namHoc)
            };

            // Sử dụng MyExecuteReader từ DataProvider để gọi stored procedure và nhận về DataTable
            DataTable dt = new DataProvider().MyExecuteReader(sql, CommandType.StoredProcedure, parameters);

            // Duyệt qua DataTable và tạo các đối tượng ReportDTO
            foreach (DataRow row in dt.Rows)
            {
                ReportDTO tk = new ReportDTO();
                tk.Lop = Convert.ToInt32(row["MaLop"]);
                tk.TenLop = row["TenLop"].ToString();
                tk.SiSo = Convert.ToInt32(row["SiSo"]);
                tk.SoLuongDat = Convert.ToInt32(row["SoLuongDat"]);
                tk.TyLeDat = Math.Round(100.0 * tk.SoLuongDat / tk.SiSo, 2);
                list.Add(tk);
            }

            return list;
        }



    }
}
