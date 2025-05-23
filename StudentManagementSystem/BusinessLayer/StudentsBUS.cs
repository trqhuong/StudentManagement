﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using QRCoder;
using TransferObject;

namespace BusinessLayer
{
    public class StudentsBUS
    {
        private StudentsDAO studentDAO = new StudentsDAO();

        public List<StudentsDTO> GetAllHocSinh()
        {
            return studentDAO.GetAllHocSinh();
        }
        public StudentsDTO GetHocSinhById(int maHS)
        {
            return studentDAO.GetHocSinhById(maHS);
        }
        public int AddStudent(StudentsDTO hs,  int id)
        {
            return studentDAO.AddStudent(hs, id) ;
        }

        public string GenerateQRCode(int maHS, string tenHS, PictureBox picQR)
        {

            string qrText = $"{maHS}_{tenHS}"; // Nội dung mã QR

            // Đường dẫn lưu ảnh QR
            string folderPath = @"D:\StudentManagement\QR_Codes\";
            string fileName = $"{maHS}_{tenHS}.png";
            string filePath = Path.Combine(folderPath, fileName);

            
            if (File.Exists(filePath))
            {
             
                picQR.Image = Image.FromFile(filePath);
                return filePath; 
            }

            // Tạo mã QR mới nếu không tồn tại
            QRCoder.QRCodeGenerator qr = new QRCoder.QRCodeGenerator();
            QRCodeData maQR = qr.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.H);
            QRCoder.QRCode anh = new QRCoder.QRCode(maQR);

           
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

         
            anh.GetGraphic(10).Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

            // Cập nhật đường dẫn vào CSDL
            bool isUpdated = studentDAO.UpdateQRCode(maHS, filePath);

            picQR.Image = Image.FromFile(filePath);

            return isUpdated ? filePath : null;


        }

        public bool UpdateHocSinh(StudentsDTO hs)
        {
            return studentDAO.UpdateStudent(hs);
        }

        public bool DeleteHocSinh(int hs)
        {

            return studentDAO.DeleteStudent(hs);
        }
        public bool Check_TinhTrang(int maHS)
        {
            string status = studentDAO.getTinhTrang(maHS);

  
            if (status == "Đang học")
            {
                return true;
            }
            return false;
        }
        public List<StudentsDTO> GetStudentByClass(int classID)
        {
            return studentDAO.GetStudentByClass(classID);
        }
        public List<StudentsDTO> GetStudentNoClass(int classID)
        {
            return studentDAO.GetStudentNoClass(classID);
        }
        public bool AddStudentInClass(int class_id, int student_id)
        {
            return studentDAO.AddStudentInClass(class_id, student_id);
        }
    }
}
