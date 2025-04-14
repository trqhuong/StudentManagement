using BusinessLayer;
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
        private InputScoreBUS inputScore = new InputScoreBUS();
        public FrmInput()
        {
            InitializeComponent();
        }

        private void FrmInput_Load(object sender, EventArgs e)
        {
            List<SubjectDTO> subjects = inputScore.GetAssignmentSubject(1);
            // Thêm dòng đầu tiên "Chọn môn học"
            subjects.Insert(0, new SubjectDTO(0, "Chọn môn học"));
            // Gán dữ liệu vào ComboBox
            cbbSubject.DataSource = subjects;
            cbbSubject.DisplayMember = "TenMH";
            cbbSubject.ValueMember = "MaMH";
            //thiết kế column
            dgvScore.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaHS", DataPropertyName = "MaHS", HeaderText = "MaHS", Width = 50 });
            dgvScore.Columns.Add(new DataGridViewTextBoxColumn { Name = "STT", DataPropertyName = "STT", HeaderText = "STT", Width = 50 });
            dgvScore.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenHocSinh", DataPropertyName = "TenHocSinh", HeaderText = "Họ và tên", Width = 250 });
            dgvScore.Columns.Add(new DataGridViewTextBoxColumn { Name = "Diem15P", DataPropertyName = "Diem15P", HeaderText = "Điểm 15 phút", Width = 100 });
            dgvScore.Columns.Add(new DataGridViewTextBoxColumn { Name = "Diem1T", DataPropertyName = "Diem1T", HeaderText = "Điểm 1 tiết", Width = 100 });
            dgvScore.Columns.Add(new DataGridViewTextBoxColumn { Name = "DiemThi", DataPropertyName = "DiemThi", HeaderText = "Điểm Thi", Width = 100 });
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
            List<StudentsDTO> students = inputScore.GetStudentInClass(class_id);
            List<ScoreDTO> scores = inputScore.GetScore(class_id, subject_id);
            // Gộp 2 danh sách lại theo MaHocSinh
            var displayList = students.Select((s, index) => {
                var score = scores.FirstOrDefault(sc => sc.MaHS == s.MaHS);
                return new DisplayScoreDTO
                {
                    MaHS = s.MaHS,
                    STT = index + 1,
                    TenHocSinh = s.TenHS,
                    Diem15P = score?.Diem15P ?? 0,
                    Diem1T = score?.Diem1T ?? 0,
                    DiemThi = score?.DiemThi ?? 0
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
            if (cbbSubject.SelectedValue != null && int.TryParse(cbbSubject.SelectedValue?.ToString(), out int subject_id) && subject_id > 0)
            {
                List<ClassDTO> classes = inputScore.GetAssignmentClass(1, subject_id);
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
            }    
        }

        private void dgvScore_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvScore.SelectedRows.Count == 0)
                return;
            DataGridViewRow row = dgvScore.SelectedRows[0];
            txtHoTen.Text = row.Cells["TenHocSinh"].Value?.ToString();
            txtDiem15P.Text = row.Cells["Diem15P"].Value?.ToString();
            txtDiem1T.Text = row.Cells["Diem1T"].Value?.ToString();
            txtDiemThi.Text = row.Cells["DiemThi"].Value?.ToString();
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
            inputScore.SaveScore(class_id, student_id, subject_id, Diem15P, Diem1T, DiemThi);
            MessageBox.Show("Đã cập nhật điểm thành công ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //load lại điểm
            resetForm();
            showScore(class_id, subject_id);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
