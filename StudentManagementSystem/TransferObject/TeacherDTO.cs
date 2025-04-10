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

        public TeacherDTO(int maGV, string tenGV, DateTime ngaySinh, string gioiTinh, string dienThoai)
        {
            MaGV = maGV;
            TenGV = tenGV;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            DienThoai = dienThoai;
        }

    }
}
