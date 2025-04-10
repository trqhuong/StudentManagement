using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class ClassListBUS
    {
        private ClassListDAO classList = new ClassListDAO();

        public List<ClassDTO> GetClassTeacher(int teacherID)
        {
            return classList.GetClassTeacher(teacherID);
        }

        public List<StudentsDTO> GetAllStudent(int classID)
        {
            return classList.GetAllStudent(classID);
        }
    }
}
