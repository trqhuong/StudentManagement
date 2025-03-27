using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class UsersDTO
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string LoaiTaiKhoan { get; set; }

        public UsersDTO() { }
        public UsersDTO(string tenDangNhap, string matKhau, string loaiTaiKhoan)
        {
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            LoaiTaiKhoan = loaiTaiKhoan;
        }
    }
}
