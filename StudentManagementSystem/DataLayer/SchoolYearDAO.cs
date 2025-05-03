using System;
using System.Collections.Generic;
using System.Data;
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
                DataTable dt = MyExecuteReader(query, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    years.Add(new SchoolYearDTO(
                        Convert.ToInt32(row["MaNH"]),
                        Convert.ToInt32(row["NamBatDau"]),
                        Convert.ToInt32(row["NamKetThuc"])
                    ));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy năm học: " + ex.Message);
            }

            return years;
        }

    }
}
