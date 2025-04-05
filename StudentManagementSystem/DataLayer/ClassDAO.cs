using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class ClassDAO
    {
        private string cnn = "Data Source=.;Initial Catalog=QLHocSinh;Integrated Security=True";
        public List<ClassDTO> GetAllLopHoc()
        {
            List<ClassDTO> lopHoc = new List<ClassDTO>();

            using (SqlConnection conn = new SqlConnection(cnn))
            {
                conn.Open();
                string query = "SELECT * FROM LOPHOC";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

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

            }
            return lopHoc;
        }

       
    }
}
