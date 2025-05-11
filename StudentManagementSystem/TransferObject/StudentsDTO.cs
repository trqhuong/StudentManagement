using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class StudentsDTO
    {
        public int MaHS { get; set; }
        public string TenHS { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string TinhTrang { get; set; }
        public string QRCodePath { get; set; }
        public string TenLop { get; set; }

        public StudentsDTO(int maHocSinh, string tenHocSinh, DateTime ngaySinh, string gioiTinh, string tinhTrang, string qRCodePath, string tenLop)
        {
            MaHS = maHocSinh;
            TenHS = tenHocSinh;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            TinhTrang = tinhTrang;
            QRCodePath = qRCodePath;
            TenLop = tenLop;
        }

        public StudentsDTO(int maHocSinh, string tenHocSinh, DateTime ngaySinh, string gioiTinh, string tinhTrang, string qRCodePath)
        {
            MaHS = maHocSinh;
            TenHS = tenHocSinh;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            TinhTrang = tinhTrang;
            QRCodePath = qRCodePath;
        }
        public StudentsDTO(int maHocSinh, string tenHocSinh, DateTime ngaySinh, string gioiTinh)
        {
            MaHS = maHocSinh;
            TenHS = tenHocSinh;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
        }
        public StudentsDTO(int maHocSinh, string tenHocSinh)
        {
            MaHS = maHocSinh;
            TenHS = tenHocSinh;
        }
        public StudentsDTO( string tenHS, DateTime ngaySinh, string gioiTinh, string tinhTrang, string qRImage, string tenLop)
        {
          
            TenHS = tenHS;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            TinhTrang = tinhTrang;
            QRCodePath = qRImage;
            TenLop = tenLop;
        }
    }
}
