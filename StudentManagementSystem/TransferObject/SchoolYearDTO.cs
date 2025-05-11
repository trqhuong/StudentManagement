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
        public bool TrangThai { get; set; }

        public SchoolYearDTO() { }
        public SchoolYearDTO(int maNH, int namBatDau, int namKetThuc)
        {
            MaNH = maNH;
            NamBatDau = namBatDau;
            NamKetThuc = namKetThuc;
        }
        public SchoolYearDTO(int maNH, int namBatDau, int namKetThuc, bool trangThai)
        {
            MaNH = maNH;
            NamBatDau = namBatDau;
            NamKetThuc = namKetThuc;
            TrangThai = trangThai;
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
