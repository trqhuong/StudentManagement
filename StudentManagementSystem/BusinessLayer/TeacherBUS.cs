using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class TeacherBUS
    {
        private TeacherDAO teacherDAO = new TeacherDAO();
        public List<TeacherDTO> GetAllTeacher()
        {
            return teacherDAO.GetAllTeacher();
        }
        public bool AddTeacher(TeacherDTO gv)
        {
            return teacherDAO.AddTeacher(gv) > 0;
        }
        public bool UpdateTeacher(TeacherDTO gv)
        {
            return teacherDAO.UpdateTeacher(gv) > 0;
        }
        public bool DeleteTeacher(int maGV)
        {
            return teacherDAO.DeleteTeacher(maGV);
        }
        public List<TeacherDTO> GetTeacherBySubject(int subject_id)
        {
            return teacherDAO.GetTeacherBySubject(subject_id);
        }
    }
}
