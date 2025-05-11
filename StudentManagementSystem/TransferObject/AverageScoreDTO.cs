using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class AverageScoreDTO
    {
        public int MaHocSinh { get; set; }
        public float DiemTBHK1 { get; set; }
        public float DiemTBHK2 { get; set; }
        public float DiemTBCaNam { get; set; }

        public AverageScoreDTO(int maHocSinh, float dTB)
        {
            MaHocSinh = maHocSinh;
            DiemTBCaNam = dTB;
        }
        public AverageScoreDTO(int maHocSinh, float dTBHK1, float dTBHK2, float dTB)
        {
            MaHocSinh = maHocSinh;
            DiemTBHK1 = dTBHK1;
            DiemTBHK2 = dTBHK2;
            DiemTBCaNam = dTB;
        }
    }
}
