using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class TeacherDTO
    {
        public int MaGV { get; set; }
        public string TenGV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DienThoai { get; set; }
        public string TinhTrang { get; set; }
        public int TaiKhoan { get; set; }
        public string Email { get; set; }
        public TeacherDTO(int maGV, string tenGV)
        {
            MaGV = maGV;
            TenGV = tenGV;
        }
        public TeacherDTO(int maGV, string tenGV, DateTime ngaySinh, string gioiTinh, string dienThoai)
        {
            MaGV = maGV;
            TenGV = tenGV;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            DienThoai = dienThoai;
        }
        public TeacherDTO(int maGiaoVien, string tenGiaoVien, DateTime ngaySinh, string gioiTinh, string dienThoai, int taiKhoan, string tinhTrang, string email)
        {
            MaGV = maGiaoVien;
            TenGV = tenGiaoVien;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            DienThoai = dienThoai;
            TaiKhoan = taiKhoan;
            TinhTrang = tinhTrang;
            Email = email;
        }

        // Dùng để thêm giáo viên (lúc này chưa có MaGV)
        public TeacherDTO(string tenGiaoVien, DateTime ngaySinh, string gioiTinh, string dienThoai, string tinhTrang,string email)
        {
            TenGV = tenGiaoVien;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            DienThoai = dienThoai;
            TinhTrang = tinhTrang;
            Email = email;
        }

    }
}
