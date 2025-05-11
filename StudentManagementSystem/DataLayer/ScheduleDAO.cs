using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class ScheduleDAO: DataProvider
    {
        public bool SaveSchedule(List<ScheduleDTO> schedules)
        {
            bool allSuccess = true;
            foreach (var schedule in schedules)
            {
                string sql = @" INSERT INTO PHANCONG (MaGV, MaLop, MaMH) VALUES (@MaGV, @MaLop, @MaMH) ";
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@MaGV", schedule.MaGV),
                    new SqlParameter("@MaLop", schedule.MaLop),
                    new SqlParameter("@MaMH", schedule.MaMH)
                };
                try
                {
                    int rowsAffected = MyExecuteNonQuery(sql, CommandType.Text, parameters);
                    if (rowsAffected <= 0)
                    {
                        allSuccess = false;
                    }
                }
                catch (Exception)
                {
                    allSuccess = false;
                }
            }
            return allSuccess;
        }
    }

}
