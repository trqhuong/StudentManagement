using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Student_ClassDTO
    {
        public int MaHS { get; set; }
        public int MaLop { get; set; }

        public Student_ClassDTO(int maHS, int maLop)
        {
            MaHS = maHS;
            MaLop = maLop;
        }
    }
}
