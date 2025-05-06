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
            try
            {
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);

                while (reader.Read())
                {
                    SemesterDTO hk = new SemesterDTO
                    {
                        MaHK = Convert.ToInt32(reader["MaHK"]),
                        SoHocKy = Convert.ToInt32(reader["SoHocKy"]),
                        NamHoc = Convert.ToInt32(reader["NamHoc"]),
                        TrangThai = Convert.ToBoolean(reader["TrangThai"])
                    };

                    list.Add(hk);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return list;
        }

    }
}
