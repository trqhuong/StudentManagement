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
        public float Diem15P { get; set; }
        public float Diem1T { get; set; }
        public float DiemThi { get; set; }

        public DisplayScoreDTO() { }

        public DisplayScoreDTO(int maHS, int sTT, string tenHocSinh, float diem15P, float diem1T, float diemThi)
        {
            MaHS = maHS;
            STT = sTT;
            TenHocSinh = tenHocSinh;
            Diem15P = diem15P;
            Diem1T = diem1T;
            DiemThi = diemThi;
        }
    }
}
