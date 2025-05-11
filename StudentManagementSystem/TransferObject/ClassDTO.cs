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
        public int Khoi { get; set; }
        public string NamHoc { get; set; }
        public string GVQuanLi { get; set; }
        public int SiSo { get; set; }

        public ClassDTO() { }

        public ClassDTO(int maLop, string tenLop)
        {
            MaLop = maLop;
            TenLop = tenLop;
        }
        public ClassDTO(int maLop, string tenLop, int khoi)
        {
            MaLop = maLop;
            TenLop = tenLop;
            Khoi = khoi;
        }
        public ClassDTO(int maLop, string tenLop,int khoi, string namHoc, string gvQuanLi, int siSo)
        {
            MaLop = maLop;
            TenLop = tenLop;
            Khoi = khoi;
            NamHoc = namHoc;
            GVQuanLi = gvQuanLi;
            SiSo = siSo;
        }

        public ClassDTO(string tenLop,int khoi, string namHoc, string gvQuanLi, int siSo)
        {
            TenLop = tenLop;
            Khoi = Khoi;
            NamHoc = namHoc;
            GVQuanLi = gvQuanLi;
            SiSo = siSo;
        }
    }
}
