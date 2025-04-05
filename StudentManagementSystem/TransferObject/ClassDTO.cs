using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class ClassDTO
    {
        public int MaLop { get; set; }
        public string TenLop { get; set; }
        public string NamHoc { get; set; }
        public string GVQuanLi { get; set; }
        public int SiSo { get; set; }

        public ClassDTO() { }

        public ClassDTO(int maLop, string tenLop, string namHoc, string gvQuanLi, int siSo)
        {
            MaLop = maLop;
            TenLop = tenLop;
            NamHoc = namHoc;
            GVQuanLi = gvQuanLi;
            SiSo = siSo;
        }
    }
}
