using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class SchoolYearDTO
    {
        public int MaNH { get; set; }
        public int NamBatDau { get; set; }
        public int NamKetThuc { get; set; }
        public int TrangThai { get; set; }

        public SchoolYearDTO(int maNH, int namBatDau, int namKetThuc)
        {
            MaNH = maNH;
            NamBatDau = namBatDau;
            NamKetThuc = namKetThuc;
        }
        public string NamHienThi
        {
            get
            {
                if (MaNH == 0) return "Chọn năm học";
                return $"{NamBatDau}-{NamKetThuc}";
            }
        }
    }
}
