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
        public List<SubjectDTO> GetAssignmentSubject(int teacher_id)
        {
            return inputBUS.GetAssignmentSubject(teacher_id);
        }
        public List<ClassDTO> GetAssignmentClass(int teacher_id, int subject_id)
        {
            return inputBUS.GetAssignmentClass(teacher_id, subject_id);
        }
        public List<StudentsDTO> GetStudentInClass(int class_id)
        {
            return inputBUS.GetStudentInClass(class_id);
        }
        public List<ScoreDTO> GetScore(int class_id, int subject_id)
        {
            return inputBUS.GetScore(class_id,subject_id);
        }

        public bool SaveScore (int class_id, int student_id, int subject_id, float student_score15, float student_score1 , float student_score)
        {
            return inputBUS.SaveScore(class_id, student_id, subject_id, student_score15, student_score1, student_score);
        }

    }
}
