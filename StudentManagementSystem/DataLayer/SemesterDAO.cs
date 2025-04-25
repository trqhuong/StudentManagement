using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class SemesterDAO
    {
        private string cnn = "Data Source=.;Initial Catalog=QLHocSinhTest;Integrated Security=True";

        public List<SemesterDTO> GetAllHocKy()
        {
            List<SemesterDTO> list = new List<SemesterDTO>();

            using (SqlConnection conn = new SqlConnection(cnn))
            {
                conn.Open();
                string sql = "SELECT MaHK, SoHocKy, NamHoc, TrangThai FROM HOCKY";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SemesterDTO hk = new SemesterDTO();
                    hk.MaHK = reader.GetInt32(0);
                    hk.SoHocKy = reader.GetInt32(1);
                    hk.NamHoc = reader.GetInt32(2);
                    hk.TrangThai = reader.GetBoolean(3);

                    list.Add(hk);
                }
            }

            return list;
        }
    }
}
