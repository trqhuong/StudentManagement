using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class ScheduleDTO
    {
        public int MaGV { get; set; }
        public int MaLop { get; set; }
        public int MaMH { get; set; }

        public ScheduleDTO(int maGV, int maLop, int maMH)
        {
            MaGV = maGV;
            MaLop = maLop;
            MaMH = maMH;
        }
    }
}
