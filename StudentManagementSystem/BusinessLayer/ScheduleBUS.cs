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

        public List<ClassDTO> GetAllClass()
        {
            return scheduleDAO.GetAllClass();
        }
        public List<SubjectDTO> GetSubject(int class_id)
        {
            return scheduleDAO.GetSubject(class_id);
        }
        public List<TeacherDTO> GetTeacher(int subject_id)
        {
            return scheduleDAO.GetTeacher(subject_id);
        }
        public bool SaveSchedule(List<ScheduleDTO> schedules)
        {
            return scheduleDAO.SaveSchedule(schedules);
        }

    }
}
