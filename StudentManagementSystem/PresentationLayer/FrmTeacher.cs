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
    public partial class FrmTeacher : Form
    {
   
        private TeacherBUS teacherBUS = new TeacherBUS();
        public FrmTeacher()
        {
            InitializeComponent();
            LoadTeachers();
        }
        private void FrmTeacher_Load(object sender, EventArgs e)
        {
            dgvTeacher.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTeacher.MultiSelect = false;
            ResetForm();
            txtTID.ReadOnly = true;//không cho phép sửa mã giáo viên
        }
        private void LoadTeachers()
        {
            dgvTeacher.AutoGenerateColumns = true;
            dgvTeacher.DataSource = teacherBUS.GetAllTeacher();
            ResetForm();
            dgvTeacher.ClearSelection();
            dgvTeacher.CurrentCell = null;
        }
        private void ResetForm()
        {

            dgvTeacher.SelectionChanged -= dgvTeacher_SelectionChanged;

            txtTID.Text = string.Empty;
            txtTName.Text = string.Empty;
            txtTPhone.Text = string.Empty;
            txtTEmail.Text = string.Empty;
            dtDob.Value = DateTime.Now;
            checkNam.Checked = false;
            checkNu.Checked = false;

            dgvTeacher.ClearSelection();

            dgvTeacher.SelectionChanged += dgvTeacher_SelectionChanged; 
        }
        private void dgvTeacher_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTeacher.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow row = dgvTeacher.SelectedRows[0];

            txtTID.Text = row.Cells["MaGV"].Value?.ToString();
            txtTName.Text = row.Cells["TenGV"].Value?.ToString();
            dtDob.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
            txtTPhone.Text = row.Cells["DienThoai"].Value?.ToString();
            txtTEmail.Text = row.Cells["Email"].Value?.ToString();

            string gioiTinh = row.Cells["GioiTinh"].Value?.ToString();
            if (gioiTinh == "Nam")
            {
                checkNam.Checked = true;
                checkNu.Checked = false;
            }
            else
            {
                checkNu.Checked = true;
                checkNam.Checked = false;

            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTID.Text))//kiem tra magv trong => them gv moi
            {
                if (string.IsNullOrEmpty(txtTName.Text))//kiem tra ten gv
                {
                    MessageBox.Show("Vui lòng nhập tên giáo viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTName.Focus();
                    return;
                }

                if (!checkNam.Checked && !checkNu.Checked)
                {
                    MessageBox.Show("Vui lòng chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkNam.Focus();
                    return;
                }

                if (checkNam.Checked && checkNu.Checked)
                {
                    MessageBox.Show("Vui lòng chọn một giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkNam.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtTEmail.Text))
                {
                    MessageBox.Show("Vui lòng email tên giáo viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtTPhone.Text))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTPhone.Focus();
                    return;
                }

                int age = DateTime.Now.Year - dtDob.Value.Year;

                if (dtDob.Value > DateTime.Now.AddYears(-age))
                {
                    age--;
                }


                if ((checkNam.Checked && age > 60 && age < 22) || (checkNu.Checked && age > 55 && age < 22))
                {
                    MessageBox.Show("Tuổi giáo viên không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtDob.Focus();
                    return;
                }
                else
                {
                    TeacherDTO gv = new TeacherDTO(
                        txtTName.Text,
                        dtDob.Value,
                        checkNam.Checked ? "Nam" : "Nữ",
                        txtTPhone.Text,
                        "Đang dạy",
                        txtTEmail.Text
                        );
                    if (teacherBUS.AddTeacher(gv))
                    {

                        MessageBox.Show("Thêm giáo viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtTName.Clear();
                        txtTPhone.Clear();
                        checkNam.Checked = false;
                        checkNu.Checked = false;
                        dtDob.Value = DateTime.Now;


                        LoadTeachers();
                    }
                    else
                    {
                        MessageBox.Show("Thêm giáo viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {

                MessageBox.Show("Không thể thêm giáo viên mới khi đã có mã giáo viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (dgvTeacher.CurrentCell == null || string.IsNullOrEmpty(txtTID.Text))
            {
                MessageBox.Show("Vui lòng chọn giáo viên để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(txtTName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên giáo viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTEmail.Text))
            {
                MessageBox.Show("Vui lòng email tên giáo viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTName.Focus();
                return;
            }

            if (!checkNam.Checked && !checkNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtTPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTPhone.Focus();
                return;
            }

            // Lấy dữ liệu từ form
            int maGV = int.Parse(txtTID.Text);
            string tenGV = txtTName.Text;
            DateTime ngaySinh = dtDob.Value;
            string gioiTinh = checkNam.Checked ? "Nam" : "Nữ";
            string dienThoai = txtTPhone.Text;
            string email = txtTEmail.Text;

            int age = DateTime.Now.Year - ngaySinh.Year;
            if (ngaySinh > DateTime.Now.AddYears(-age)) age--;

            if ((gioiTinh == "Nam" && (age < 22 || age > 60)) || (gioiTinh == "Nữ" && (age < 22 || age > 55)))
            {
                MessageBox.Show("Tuổi giáo viên không hợp lệ. Nam: 22-60 tuổi, Nữ: 22-55 tuổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvTeacher.SelectedRows[0];
            int maTK = Convert.ToInt32(row.Cells["TaiKhoan"].Value);
            string tinhTrang = row.Cells["TinhTrang"].Value?.ToString() ?? "Đang dạy";

            TeacherDTO gv = new TeacherDTO(maGV, tenGV, ngaySinh, gioiTinh, dienThoai, maTK, tinhTrang,email);

            if (teacherBUS.UpdateTeacher(gv))
            {
                MessageBox.Show("Cập nhật giáo viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTeachers();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTID.Text))
            {
                MessageBox.Show("Vui lòng chọn giáo viên cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn cho giáo viên này nghỉ dạy và xóa tài khoản?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int maGV = int.Parse(txtTID.Text);
                bool success = teacherBUS.DeleteTeacher(maGV);

                if (success)
                {
                    MessageBox.Show("Đã cập nhật trạng thái giáo viên và xóa tài khoản.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTeachers();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
