using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class ClassBUS
    {
        private ClassDAO classDAO = new ClassDAO();

        public List<ClassDTO> GetAllClass()
        {
            return classDAO.GetAllClass();
        }
        public bool AddClass(ClassDTO clas)
        {
            return classDAO.AddClass(clas)>0;
        }
        public bool UpdateClass(ClassDTO clas)
        {
            return classDAO.UpdateClass(clas) > 0;
        }
        public bool DeleteClass(int maLop)
        {
            return classDAO.DeleteClass(maLop);
        }
        public List<ClassDTO> GetClassTeacher()
        {
            return classDAO.GetClassTeacher();
        }
        public List<ClassDTO> GetAssignmentClass(int subject_id)
        {
            return classDAO.GetAssignmentClass(subject_id);
        }
        public List<ClassDTO> GetAssignmentClass(int subject_id, int year)
        {
            return classDAO.GetAssignmentClass(subject_id, year);
        }
        public ClassDTO GetClassById(int class_id)
        {
            return classDAO.GetClassById(class_id);
        }
    }
}
