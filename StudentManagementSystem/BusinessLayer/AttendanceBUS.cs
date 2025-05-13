using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        public List<int> GetDanhSachHocSinhChuaDiemDanh()
        {
            return diemDanh.GetHocSinhChuaDiemDanh();
        }

        public void KetThucDiemDanh()
        {
            var danhSachHS = diemDanh.GetHocSinhChuaDiemDanh();

            foreach (int maHS in danhSachHS)
            {
                diemDanh.InsertDiemDanhVangMat(maHS);
            }
        }


        public List<AbsentStudentDTO> LayHocSinhVang()
        {
            return diemDanh.LayDanhSachHocSinhVang();
        }

        public void GuiMailThongBaoTheoDanhSach()
        {
            var danhSach = LayHocSinhVang();

            // Nhóm theo GVCN
            var nhomTheoGVCN = danhSach
                .GroupBy(hs => new { hs.Email, hs.TenGiaoVien })
                .ToList();

            foreach (var group in nhomTheoGVCN) // nhóm hs theo GVCN
            {
                string emailGVCN = group.Key.Email;
                string tenGV = group.Key.TenGiaoVien;



                StringBuilder bodyBuilder = new StringBuilder();
                bodyBuilder.AppendLine($"Kính gửi Thầy/Cô {tenGV},");

                string tenLop = group.First().TenLop;// lấy tên lớp của hs đầu tiên trong group
                bodyBuilder.AppendLine($"Danh sách học sinh lớp {tenLop} vắng mặt ngày {DateTime.Now:dd/MM/yyyy}:");

                foreach (var hs in group)
                {
                    bodyBuilder.AppendLine($"- {hs.TenHocSinh} (Lớp: {hs.TenLop}) - Ngày nghỉ: {hs.NgayVang:dd/MM/yyyy}");
                }

                bodyBuilder.AppendLine("\nTrân trọng.");

                // Gửi mail
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("quynhhuongtran314@gmail.com");
                    mail.To.Add(emailGVCN);
                    mail.Subject = "Thông báo học sinh vắng hôm nay";
                    mail.Body = bodyBuilder.ToString();

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.Credentials = new NetworkCredential("quynhhuongtran314@gmail.com", "eeppxloexxkryxzd");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);

                    Console.WriteLine($"Đã gửi email đến GVCN: {emailGVCN}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi gửi email tới {emailGVCN}: {ex.Message}");
                }
            }
        }

    }
}
