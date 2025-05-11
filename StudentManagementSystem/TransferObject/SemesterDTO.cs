using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class SemesterDTO
    {
        public int MaHK { get; set; }
        public int SoHocKy { get; set; }
        public int NamHoc { get; set; }
        public bool TrangThai { get; set; }

        public SemesterDTO() { }
        public SemesterDTO(int maHK, int soHocKy, int namHoc)
        {
            MaHK = maHK;
            SoHocKy = soHocKy;
            NamHoc = namHoc;
        }
        public SemesterDTO(int maHK, int soHocKy, int namHoc, bool trangThai)
        {
            MaHK = maHK;
            SoHocKy = soHocKy;
            NamHoc = namHoc;
            TrangThai = trangThai;
        }
    }
}
