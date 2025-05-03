using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class InputScoreBUS
    {
        private InputScoreDAO inputBUS = new InputScoreDAO();
        public List<SubjectDTO> GetAssignmentSubject()
        {
            return inputBUS.GetAssignmentSubject();
        }
        public List<ClassDTO> GetAssignmentClass(int subject_id)
        {
            return inputBUS.GetAssignmentClass(subject_id);
        }
        public List<StudentsDTO> GetStudentInClass(int class_id)
        {
            return inputBUS.GetStudentInClass(class_id);
        }
        public List<ScoreDTO> GetScore(int class_id, int subject_id)
        {
            return inputBUS.GetScore(class_id,subject_id);
        }

        public bool SaveScore (ScoreDTO score)
        {
             return inputBUS.SaveScore(score);
        }

    }
}
