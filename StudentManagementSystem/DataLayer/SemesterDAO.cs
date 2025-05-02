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
    public class SemesterDAO : DataProvider
    {


        public List<SemesterDTO> GetAllHocKy()
        {
            List<SemesterDTO> list = new List<SemesterDTO>();


            string sql = "SELECT * FROM HOCKY";

            // Gọi phương thức đọc dữ liệu
            DataTable dt = MyExecuteReader(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                SemesterDTO hk = new SemesterDTO
                {
                    MaHK = Convert.ToInt32(row["MaHK"]),
                    SoHocKy = Convert.ToInt32(row["SoHocKy"]),
                    NamHoc = Convert.ToInt32(row["NamHoc"]),
                    TrangThai = Convert.ToBoolean(row["TrangThai"])
                };

                list.Add(hk);
            }

            return list;
        }

    }
}
