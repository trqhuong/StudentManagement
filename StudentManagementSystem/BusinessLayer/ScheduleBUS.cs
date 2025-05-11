using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using TransferObject;

namespace BusinessLayer
{
    public class ScheduleBUS
    {
        private ScheduleDAO scheduleDAO = new ScheduleDAO();
        public bool SaveSchedule(List<ScheduleDTO> schedules)
        {
            return scheduleDAO.SaveSchedule(schedules);
        }

    }
}
