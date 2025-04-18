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
        private ExportScoreDAO exportBUS = new ExportScoreDAO();
        public List<SubjectDTO> GetAssignmentSubject(int teacher_id)
        {
            return exportBUS.GetAssignmentSubject(teacher_id);
        }
        public List<ClassDTO> GetAssignmentClass(int teacher_id, int subject_id, int year_id)
        {
            return exportBUS.GetAssignmentClass(teacher_id, subject_id, year_id);
        }
        public List<SchoolYearDTO> GetSchoolYear()
        {
            return exportBUS.GetSchoolYear();
        }
        public List<StudentsDTO> GetStudentInClass(int class_id)
        {
            return exportBUS.GetStudentInClass(class_id);
        }
        public List<AverageScoreDTO> ExportScore( int subject_id, int class_id, int year_id)
        {
            return exportBUS.ExportScore(subject_id, class_id, year_id);
        }
    }
}
