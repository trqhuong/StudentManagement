using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class DisplayScoreDTO
    {
        public int MaHS { get; set; }
        public int STT { get; set; }
        public string TenHocSinh { get; set; }
        public float DiemSo1 { get; set; }
        public float DiemSo2 { get; set; }
        public float DiemSo3 { get; set; }

        public DisplayScoreDTO() { }

        public DisplayScoreDTO(int maHS, int sTT, string tenHocSinh, float diemSo1, float diemSo2, float diemSo3)
        {
            MaHS = maHS;
            STT = sTT;
            TenHocSinh = tenHocSinh;
            DiemSo1 = diemSo1;
            DiemSo2 = diemSo2;
            DiemSo3 = diemSo3;
        }
    }
}
