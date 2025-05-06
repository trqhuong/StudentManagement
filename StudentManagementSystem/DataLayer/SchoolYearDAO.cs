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
    public class SchoolYearDAO : DataProvider
    {
        public List<SchoolYearDTO> GetAllSchoolYears()
        {
            List<SchoolYearDTO> years = new List<SchoolYearDTO>();
            string query = "SELECT MaNH, NamBatDau, NamKetThuc FROM NAMHOC";

            try
            {
                SqlDataReader reader = MyExecuteReader(query, CommandType.Text);

                while (reader.Read())
                {
                    years.Add(new SchoolYearDTO(
                        Convert.ToInt32(reader["MaNH"]),
                        Convert.ToInt32(reader["NamBatDau"]),
                        Convert.ToInt32(reader["NamKetThuc"])
                    ));
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy năm học: " + ex.Message);
            }

            return years;
        }


    }
}
