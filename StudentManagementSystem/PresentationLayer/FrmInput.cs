﻿using BusinessLayer;
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

namespace PresentationLayer
{
    public partial class FrmInput: Form
    {
        private SubjectBUS subjectBUS = new SubjectBUS();
        private ClassBUS classBUS = new ClassBUS();
        private StudentsBUS studentsBUS = new StudentsBUS();
        private ScoreBUS inputScore = new ScoreBUS();
        public FrmInput()
        {
            InitializeComponent();
        }

        private void FrmInput_Load(object sender, EventArgs e)
        {
            List<SubjectDTO> subjects = subjectBUS.GetAssignmentSubject();
            // Thêm dòng đầu tiên "Chọn môn học"
            subjects.Insert(0, new SubjectDTO(0, "Chọn môn học"));
            // Gán dữ liệu vào ComboBox
            cbbSubject.DataSource = subjects;
            cbbSubject.DisplayMember = "TenMH";
            cbbSubject.ValueMember = "MaMH";
        }

        public void designData()
        {
            dgvScore.Columns.Clear();
            //thiết kế column
            dgvScore.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaHS", DataPropertyName = "MaHS", HeaderText = "MaHS", Width = 10 });
            dgvScore.Columns.Add(new DataGridViewTextBoxColumn { Name = "STT", DataPropertyName = "STT", HeaderText = "STT", Width = 30 });
            dgvScore.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenHocSinh", DataPropertyName = "TenHocSinh", HeaderText = "Họ và tên", Width = 250 });
            dgvScore.Columns.Add(new DataGridViewTextBoxColumn { Name = "Diem15P", DataPropertyName = "DiemSo1", HeaderText = "Điểm 15 phút", Width = 100 });
            dgvScore.Columns.Add(new DataGridViewTextBoxColumn { Name = "Diem1T", DataPropertyName = "DiemSo2", HeaderText = "Điểm 1 tiết", Width = 100 });
            dgvScore.Columns.Add(new DataGridViewTextBoxColumn { Name = "DiemThi", DataPropertyName = "DiemSo3", HeaderText = "Điểm Thi", Width = 100 });
            dgvScore.Columns.Add(new DataGridViewImageColumn { Name = "Edit", HeaderText = "Sửa", Width = 40, Image = Properties.Resources.edit, ImageLayout = DataGridViewImageCellLayout.Zoom });
            dgvScore.Columns["MaHS"].Visible = false;
            // Font & màu
            dgvScore.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvScore.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvScore.DefaultCellStyle.BackColor = Color.White;
            dgvScore.EnableHeadersVisualStyles = false;
            dgvScore.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvScore.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            // Căn giữa header
            dgvScore.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // Không cho chỉnh sửa
            dgvScore.ReadOnly = true;
            // Giãn cột cho vừa
            dgvScore.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Không cho thêm/sửa/xoá dòng
            dgvScore.AllowUserToAddRows = false;
            dgvScore.AllowUserToDeleteRows = false;
            dgvScore.AllowUserToOrderColumns = false;
            // Không cho chọn nhiều
            dgvScore.MultiSelect = false;
        }

        public void resetForm()
        {
            txtHoTen.Text = "";
            txtDiem15P.Text = "";
            txtDiem1T.Text = "";
            txtDiemThi.Text = "";
        }

        public void showScore(int class_id, int subject_id)
        {
            List<StudentsDTO> students = studentsBUS.GetStudentByClass(class_id);
            List<ScoreDTO> scores = inputScore.GetScore(class_id, subject_id);
            // Gộp 2 danh sách lại theo MaHocSinh
            var displayList = students.Select((s, index) => {
                var score = scores.FirstOrDefault(sc => sc.MaHS == s.MaHS);
                return new DisplayScoreDTO
                {
                    MaHS = s.MaHS,
                    STT = index + 1,
                    TenHocSinh = s.TenHS,
                    DiemSo1 = score?.Diem15P ?? 0,
                    DiemSo2 = score?.Diem1T ?? 0,
                    DiemSo3 = score?.DiemThi ?? 0
                };
            }).ToList();
            dgvScore.DataSource = displayList;
        }
        private void AllowDecimalOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (char.IsControl(e.KeyChar)){return;}
            if (char.IsDigit(e.KeyChar)){return;}
            if (e.KeyChar == '.')
            {
                if (textBox.Text.Contains('.'))
                {
                    e.Handled = true;
                    return;
                }
                if (textBox.SelectionStart == 0 )
                {
                    e.Handled = true;
                    return;
                }
                return;
            }
            e.Handled = true;
        }

        private void cbbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvScore.DataSource = null;
            designData();
            if (cbbSubject.SelectedValue != null && int.TryParse(cbbSubject.SelectedValue?.ToString(), out int subject_id) && subject_id > 0)
            {
                List<ClassDTO> classes = classBUS.GetAssignmentClass(subject_id);
                // Thêm dòng đầu tiên "Chọn lớp"
                classes.Insert(0, new ClassDTO(0, "Chọn lớp"));
                // Gán dữ liệu vào ComboBox
                cbbClass.DataSource = classes;
                cbbClass.DisplayMember = "TenLop";
                cbbClass.ValueMember = "MaLop";
            }
            else
            {
                cbbClass.DataSource = null;
            }
        }

        private void cbbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetForm();
            if (cbbClass.SelectedValue != null && int.TryParse(cbbClass.SelectedValue?.ToString(), out int class_id) && class_id > 0)
            {
                if (int.TryParse(cbbSubject.SelectedValue.ToString(), out int subject_id))
                {
                    showScore(class_id, subject_id);
                }
            }
            else
            {
                dgvScore.DataSource = null;
                designData();
            }    
        }

        private void dgvScore_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvScore.Columns[e.ColumnIndex].Name == "Edit")
            {
                DataGridViewRow row = dgvScore.Rows[e.RowIndex];
                txtHoTen.Text = row.Cells["TenHocSinh"].Value?.ToString();
                txtDiem15P.Text = row.Cells["Diem15P"].Value?.ToString();
                txtDiem1T.Text = row.Cells["Diem1T"].Value?.ToString();
                txtDiemThi.Text = row.Cells["DiemThi"].Value?.ToString();
                dgvScore.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            int class_id = Convert.ToInt32(cbbClass.SelectedValue);
            int subject_id = Convert.ToInt32(cbbSubject.SelectedValue);
            float Diem15P = string.IsNullOrWhiteSpace(txtDiem15P.Text) ? 0 : float.Parse(txtDiem15P.Text);
            float Diem1T = string.IsNullOrWhiteSpace(txtDiem1T.Text) ? 0 : float.Parse(txtDiem1T.Text);
            float DiemThi = string.IsNullOrWhiteSpace(txtDiemThi.Text) ? 0 : float.Parse(txtDiemThi.Text);
            if (Diem15P < 0 || Diem15P > 10 || Diem1T < 0 || Diem1T > 10 || DiemThi < 0 || DiemThi > 10)
            {
                MessageBox.Show("Điểm phải nằm trong khoảng từ 0 đến 10!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dgvScore.SelectedRows.Count == 0)
                return;
            DataGridViewRow row = dgvScore.SelectedRows[0];
            int student_id = 0;
            if (row.DataBoundItem is DisplayScoreDTO selectedStudent)
            {
                student_id = selectedStudent.MaHS;
            
            }
            ScoreDTO score = new ScoreDTO(class_id, student_id, subject_id, Diem15P, Diem1T, DiemThi);
            bool result = inputScore.SaveScore(score);
            if (result)
                MessageBox.Show("Đã cập nhật điểm thành công ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Lưu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //load lại điểm
            resetForm();
            showScore(class_id, subject_id);
        }
    }
}
