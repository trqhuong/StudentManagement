using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using DataLayer;

namespace BusinessLayer
{
    public class ExportScoreBUS
    {
        private ExportScoreDAO exportDAO = new ExportScoreDAO();
        public List<SubjectDTO> GetAssignmentSubject()
        {
            return exportDAO.GetAssignmentSubject();
        }
        public List<ClassDTO> GetAssignmentClass(int subject_id, int year_id)
        {
            return exportDAO.GetAssignmentClass(subject_id, year_id);
        }
        public List<SchoolYearDTO> GetSchoolYear()
        {
            return exportDAO.GetSchoolYear();
        }
        public List<StudentsDTO> GetStudentInClass(int class_id)
        {
            return exportDAO.GetStudentInClass(class_id);
        }
        public List<AverageScoreDTO> ExportScore( int subject_id, int class_id, int year_id)
        {
            return exportDAO.ExportScore(subject_id, class_id, year_id);
        }
    }
}
