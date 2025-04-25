using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class AttendanceBUS
    {
        private AttendanceDAO diemDanh = new AttendanceDAO();

        public bool DiemDanhHocSinh(AttendanceDTO dto)
        {
            return diemDanh.InsertDiemDanh(dto);
        }

        public List<AttendanceDTO> GetAllAttendance()
        {
            return diemDanh.GetAllAttendance(); 
        }
    }
}
