using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class TeacherSubjectDTO
    {
        public int MaGV { get; set; }
        public int MaMH { get; set; }

        public TeacherSubjectDTO(int maGV, int maMH)
        {
            MaGV = maGV;
            MaMH = maMH;
        }
    }
}
