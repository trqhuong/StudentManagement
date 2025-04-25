using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;
using BusinessLayer;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextFont = iTextSharp.text.Font;
using System.IO;
using System.Diagnostics;

namespace PresentationLayer
{

    public partial class FrmExport : Form
    {
        private ExportScoreBUS exportBUS = new ExportScoreBUS();
        List<DisplayScoreDTO> displayList = new List<DisplayScoreDTO>();


        public FrmExport()
        {
            InitializeComponent();
        }

        private void FrmExport_Load(object sender, EventArgs e)
        {
            //năm học
            List<SchoolYearDTO> years = exportBUS.GetSchoolYear();
            years.Insert(0, new SchoolYearDTO(0, 0, 0));
            cbbSchoolYear.DataSource = years;
            cbbSchoolYear.DisplayMember = "NamHienThi";
            cbbSchoolYear.ValueMember = "MaNH";
            //môn học
            List<SubjectDTO> subjects = exportBUS.GetAssignmentSubject(1);
            subjects.Insert(0, new SubjectDTO(0, "Chọn môn học"));
            cbbSubject.DataSource = subjects;
            cbbSubject.DisplayMember = "TenMH";
            cbbSubject.ValueMember = "MaMH";
            designData();
        }
        public void designData()
        {
            if (dgvExport.Columns.Count == 0)
            {
                //thiết kế column
                dgvExport.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaHS", DataPropertyName = "MaHS", HeaderText = "MaHS", Width = 50 });
                dgvExport.Columns.Add(new DataGridViewTextBoxColumn { Name = "STT", DataPropertyName = "STT", HeaderText = "STT", Width = 50 });
                dgvExport.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenHocSinh", DataPropertyName = "TenHocSinh", HeaderText = "Họ và tên", Width = 250 });
                dgvExport.Columns.Add(new DataGridViewTextBoxColumn { Name = "DiemTBHK1", DataPropertyName = "DiemSo1", HeaderText = "ĐTB HK1", Width = 100 });
                dgvExport.Columns.Add(new DataGridViewTextBoxColumn { Name = "DiemTBHK2", DataPropertyName = "DiemSo2", HeaderText = "ĐTB HK2", Width = 100 });
                dgvExport.Columns.Add(new DataGridViewTextBoxColumn { Name = "DiemTBCaNam", DataPropertyName = "DiemSo3", HeaderText = "ĐTB Cả Năm", Width = 100 });
                dgvExport.Columns["MaHS"].Visible = false;
                // Font & màu
                dgvExport.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                dgvExport.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
                dgvExport.DefaultCellStyle.BackColor = Color.White;
                dgvExport.EnableHeadersVisualStyles = false;
                dgvExport.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
                dgvExport.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                // Căn giữa header
                dgvExport.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                // Không cho chỉnh sửa
                dgvExport.ReadOnly = true;
                // Giãn cột cho vừa
                dgvExport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                // Không cho thêm/sửa/xoá dòng
                dgvExport.AllowUserToAddRows = false;
                dgvExport.AllowUserToDeleteRows = false;
                dgvExport.AllowUserToOrderColumns = false;
            }
        }

        private void cbbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvExport.DataSource = null;
            designData();
            if (int.TryParse(cbbSchoolYear.SelectedValue?.ToString(), out int year_id) && year_id > 0)
            {
                if (int.TryParse(cbbSubject.SelectedValue?.ToString(), out int subject_id) && subject_id > 0)
                {
                    //lấy danh sách các lớp
                    List<ClassDTO> classes = exportBUS.GetAssignmentClass(1, subject_id, year_id);
                    classes.Insert(0, new ClassDTO(0, "Chọn lớp"));
                    cbbClass.DataSource = classes;
                    cbbClass.DisplayMember = "TenLop";
                    cbbClass.ValueMember = "MaLop";
                }
            }
            else
            {
                cbbClass.DataSource = null;
            }
        }

        private void cbbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvExport.DataSource = null;
            designData();
            if (int.TryParse(cbbSubject.SelectedValue?.ToString(), out int year_id) && year_id > 0)
            {
                if (int.TryParse(cbbSchoolYear.SelectedValue?.ToString(), out int subject_id) && subject_id > 0)
                {
                    //lấy danh sách các lớp
                    List<ClassDTO> classes = exportBUS.GetAssignmentClass(1, subject_id, year_id);
                    classes.Insert(0, new ClassDTO(0, "Chọn lớp"));
                    cbbClass.DataSource = classes;
                    cbbClass.DisplayMember = "TenLop";
                    cbbClass.ValueMember = "MaLop";
                }
            }
            else
            {
                cbbClass.DataSource = null;
            }
        }

        private void cbbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(cbbClass.SelectedValue?.ToString(), out int class_id) && class_id > 0)
            {
                int subject_id = Convert.ToInt32(cbbSubject.SelectedValue);
                int year_id = Convert.ToInt32(cbbSchoolYear.SelectedValue);
                List<AverageScoreDTO> averagescores = exportBUS.ExportScore(subject_id, class_id, year_id);
                List<StudentsDTO> students = exportBUS.GetStudentInClass(class_id);
                // Gộp 2 danh sách lại theo MaHocSinh
                displayList = students.Select((s, index) =>
                {
                    var score = averagescores.FirstOrDefault(sc => sc.MaHocSinh == s.MaHS);
                    return new DisplayScoreDTO
                    {
                        MaHS = s.MaHS,
                        STT = index + 1,
                        TenHocSinh = s.TenHS,
                        DiemSo1 = score?.DiemTBHK1 ?? 0,
                        DiemSo2 = score?.DiemTBHK2 ?? 0,
                        DiemSo3 = score?.DiemTBCaNam ?? 0
                    };
                }).ToList();
                dgvExport.DataSource = displayList;
            }
            else
            {
                dgvExport.DataSource = null;
                designData();
            }
        }
        public void ExportToPDF(List<DisplayScoreDTO> displayList, string class_name, string year_name, string subject_name)
        {
            string filePath = $@"D:\Project\StudentManagement\ExportScore\{class_name}_{year_name}_{subject_name}.pdf";

            Document doc = new Document(PageSize.A4, 36, 36, 36, 36);

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                PdfWriter.GetInstance(doc, fs);
                doc.Open();
                // Font Unicode hỗ trợ tiếng Việt
                BaseFont bf = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextFont titleFont = new iTextFont(bf, 18, iTextFont.BOLD, BaseColor.BLUE);
                iTextFont headerFont = new iTextFont(bf, 12, iTextFont.BOLD);
                iTextFont contentFont = new iTextFont(bf, 12);
                // Tiêu đề
                string reportTitle = $"BÁO CÁO TỔNG KẾT\nLớp: {class_name}   Năm học: {year_name}   Môn: {subject_name}";
                Paragraph title = new Paragraph(reportTitle, titleFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 20
                };
                doc.Add(title);
                // Bảng
                PdfPTable table = new PdfPTable(5)
                {
                    WidthPercentage = 100
                };
                table.SetWidths(new float[] { 1, 4, 2, 2, 2 });
                // Header bảng
                string[] headers = { "STT", "Tên Học Sinh", "Điểm TB HK1", "Điểm TB HK2", "Điểm TB Cả Năm" };
                foreach (string header in headers)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(header, headerFont))
                    {
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        BackgroundColor = new BaseColor(230, 230, 230)
                    };
                    table.AddCell(cell);
                }
                // Dữ liệu bảng
                foreach (var item in displayList)
                {
                    double diem1 = item.DiemSo1;
                    double diem2 = item.DiemSo2;
                    double diemCaNam = item.DiemSo3;
                    table.AddCell(new PdfPCell(new Phrase(item.STT.ToString(), contentFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                    table.AddCell(new PdfPCell(new Phrase(item.TenHocSinh, contentFont)));
                    table.AddCell(new PdfPCell(new Phrase(diem1.ToString("0.0"), contentFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                    table.AddCell(new PdfPCell(new Phrase(diem2.ToString("0.0"), contentFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                    table.AddCell(new PdfPCell(new Phrase(diemCaNam.ToString("0.0"), contentFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                }
                doc.Add(table);
                // Footer ngày và chữ ký
                Paragraph footer = new Paragraph($"\nNgày: {DateTime.Now:dd/MM/yyyy}", contentFont)
                {
                    Alignment = Element.ALIGN_RIGHT,
                    SpacingBefore = 30,
                    SpacingAfter = 50
                };
                doc.Add(footer);
                Paragraph signature = new Paragraph("Giáo viên: ________________________", contentFont)
                {
                    Alignment = Element.ALIGN_RIGHT
                };
                doc.Add(signature);
                doc.Close();
                MessageBox.Show("File lưu tại " + filePath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            if (dgvExport.DataSource != null)
            {
                string subject_name = cbbSubject.Text;
                string class_name = cbbClass.Text;
                string year_name = cbbSchoolYear.Text;
                ExportToPDF(displayList, class_name, year_name, subject_name);
            }
            return;
        }
    }
}
