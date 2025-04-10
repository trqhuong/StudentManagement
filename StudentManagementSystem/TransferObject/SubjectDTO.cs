using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class SubjectDTO
    {
        public int MaMH { get; set; }
        public string TenMH { get; set; }
        public SubjectDTO(int maMH, string tenMH)
        {
            MaMH = maMH;
            TenMH = tenMH;
        }
    }
}
