using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class AbsentStudentDTO
    {
        public string MaHocSinh { get; set; }
        public string TenHocSinh { get; set; }
        public string Email { get; set; }
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public string MaGiaoVien { get; set; }
        public string TenGiaoVien { get; set; }
        public DateTime Ngay1 { get; set; }
        public DateTime Ngay2 { get; set; }
    }
}
