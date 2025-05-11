using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class SubjectBUS
    {
        private SubjectDAO subjectDAO= new SubjectDAO();
        public List<SubjectDTO> GetAllSubject()
        {
            return subjectDAO.GetAllSubject();
        }
        public bool AddSubject(SubjectDTO subject)
        {
            return subjectDAO.AddSubject(subject)>0;
        }
        public bool UpdateSubject(SubjectDTO subject)
        {
            return subjectDAO.UpdateSubject(subject)>0;
        }
        public bool DeleteSubject(int subject)
        {
            return subjectDAO.DeleteSubject(subject);
        }
        public List<SubjectDTO> GetAssignmentSubject()
        {
            return subjectDAO.GetAssignmentSubject();
        }
        public List<SubjectDTO> GetSubjectNoSchedule(int class_id)
        {
            return subjectDAO.GetSubjectNoSchedule(class_id);
        }
    }
}
