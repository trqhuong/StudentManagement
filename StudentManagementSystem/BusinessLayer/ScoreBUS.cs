using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class ScoreBUS
    {
        private ScoreDAO scoreDAO = new ScoreDAO();
        public List<ScoreDTO> GetScore(int class_id, int subject_id)
        {
            return scoreDAO.GetScore(class_id,subject_id);
        }
        public bool SaveScore (ScoreDTO score)
        {
             return scoreDAO.SaveScore(score);
        }
        public List<AverageScoreDTO> ExportScore(int subject_id, int class_id)
        {
            return scoreDAO.ExportScore(subject_id, class_id);
        }
    }
}
