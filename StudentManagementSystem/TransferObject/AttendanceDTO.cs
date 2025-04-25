using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class AttendanceDTO
    {
        public int MaDiemDanh { get; set; }
        public DateTime NgayDiemDanh { get; set; }
        public string TrangThai { get; set; }
        public int MaHS { get; set; }
        public AttendanceDTO(int maDiemDanh, int maHS, DateTime ngayDiemDanh, string trangThai)
        {
            MaDiemDanh = maDiemDanh;
            MaHS = maHS;
            NgayDiemDanh = ngayDiemDanh;
            TrangThai = trangThai;
        }
        public AttendanceDTO( int maHS, DateTime ngayDiemDanh, string trangThai)
        {
         
            MaHS = maHS;
            NgayDiemDanh = ngayDiemDanh;
            TrangThai = trangThai;
        }
    }
}
