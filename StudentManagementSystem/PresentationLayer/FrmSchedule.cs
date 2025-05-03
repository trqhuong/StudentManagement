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
    public partial class FrmSchedule: Form
    {
        private ScheduleBUS scheduleBUS = new ScheduleBUS();
        public FrmSchedule()
        {
            InitializeComponent();
        }

        private void FrmSchedule_Load(object sender, EventArgs e)
        {
            List<ClassDTO> classList = scheduleBUS.GetAllClass();
            // Thêm dòng đầu tiên "Chọn lớp"
            classList.Insert(0, new ClassDTO(0, "Chọn lớp"));
            // Gán dữ liệu vào ComboBox
            cbbClass.DataSource = classList;
            cbbClass.DisplayMember = "TenLop";
            cbbClass.ValueMember = "MaLop";
        }

        private void designData()
        {
            dgvSchedule.Columns.Clear();
            //thiết kế column
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaMH", DataPropertyName = "MaMH", HeaderText = "Mã Môn Học", Width = 100 });
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenMH", DataPropertyName = "TenMH", HeaderText = "Tên Môn Học", Width = 200 });
            dgvSchedule.Columns.Add(new DataGridViewComboBoxColumn { Name = "GV", HeaderText = "Chọn giáo viên", Width = 250 });
            // Font & màu
            dgvSchedule.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvSchedule.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvSchedule.DefaultCellStyle.BackColor = Color.White;
            dgvSchedule.EnableHeadersVisualStyles = false;
            dgvSchedule.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvSchedule.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            // Căn giữa header
            dgvSchedule.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // Giãn cột cho vừa
            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Không cho thêm/sửa/xoá dòng
            dgvSchedule.AllowUserToAddRows = false;
            dgvSchedule.AllowUserToDeleteRows = false;
            dgvSchedule.AllowUserToOrderColumns = false;
            // Không cho chọn nhiều
            dgvSchedule.MultiSelect = false;
        }

        private void cbbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            designData();
            if (int.TryParse(cbbClass.SelectedValue.ToString(), out int class_id) && class_id > 0)
            {
                //lấy môn học chưa được phân công
                List<SubjectDTO> subjects = scheduleBUS.GetSubject(class_id);
                dgvSchedule.DataSource = subjects;
                // Gán từng danh sách giáo viên tương ứng cho từng dòng
                foreach (DataGridViewRow row in dgvSchedule.Rows)
                {
                    int subject_id = int.Parse(row.Cells["MaMH"].Value.ToString());
                    List<TeacherDTO> teachers = scheduleBUS.GetTeacher(subject_id);
                    var comboCell = new DataGridViewComboBoxCell();
                    comboCell.DataSource = teachers;
                    comboCell.DisplayMember = "TenGV";
                    comboCell.ValueMember = "MaGV";
                    row.Cells["GV"] = comboCell;
                }
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            List<ScheduleDTO> schedulesToSave = new List<ScheduleDTO>();
            foreach (DataGridViewRow row in dgvSchedule.Rows)
            {
                if (row.Cells["GV"].Value != null)
                {
                    int maMH = int.Parse(row.Cells["MaMH"].Value.ToString());
                    int maGV = int.Parse(row.Cells["GV"].Value.ToString());
                    int maLop = (int)cbbClass.SelectedValue;
                    schedulesToSave.Add(new ScheduleDTO
                        (maGV, maLop, maMH));
                }
            }
            bool result = scheduleBUS.SaveSchedule(schedulesToSave);
            if (result)
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Lưu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // Reset
            cbbClass_SelectedIndexChanged(cbbClass, EventArgs.Empty);
        }
    }
}
