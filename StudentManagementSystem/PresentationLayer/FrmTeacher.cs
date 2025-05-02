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
            dgvTeacher.DataSource = teacherBUS.GetAllTeacher();//gán dữ liệu giáo viên vào datagridview
            ResetForm();
            dgvTeacher.ClearSelection();
            dgvTeacher.CurrentCell = null;
        }
        private void ResetForm()
        {
            // Tắt sự kiện SelectionChanged để tránh tự động điền lại dữ liệu
            dgvTeacher.SelectionChanged -= dgvTeacher_SelectionChanged;

            txtTID.Text = string.Empty;
            txtTName.Text = string.Empty;
            txtTPhone.Text = string.Empty;
            dtDob.Value = DateTime.Now;
            checkNam.Checked = false;
            checkNu.Checked = false;

            dgvTeacher.ClearSelection();

            dgvTeacher.SelectionChanged += dgvTeacher_SelectionChanged; // Bật lại sự kiện
        }
        private void dgvTeacher_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTeacher.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow row = dgvTeacher.SelectedRows[0];
            // Lấy dữ liệu từ dòng đã chọn và điền vào các ô nhập liệu
            txtTID.Text = row.Cells["MaGV"].Value?.ToString();
            txtTName.Text = row.Cells["TenGV"].Value?.ToString();
            dtDob.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
            txtTPhone.Text = row.Cells["DienThoai"].Value?.ToString();

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
                    return;//dung chuong trinh neu khong nhap ten
                }

                //kiem tra gioi tinh
                if (!checkNam.Checked && !checkNu.Checked)
                {
                    MessageBox.Show("Vui lòng chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkNam.Focus();
                    return;
                }
                //khong duoc chon ca 2 gioi tinh
                if (checkNam.Checked && checkNu.Checked)
                {
                    MessageBox.Show("Vui lòng chọn một giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkNam.Focus();
                    return;
                }
                //kiem tra dien thoai
                if (string.IsNullOrEmpty(txtTPhone.Text))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTPhone.Focus();
                    return;
                }

                int age = DateTime.Now.Year - dtDob.Value.Year;//tinh tuoi dua vao ngay sinh

                if (dtDob.Value > DateTime.Now.AddYears(-age))//chưa tới sinh nhật năm nay thì trừ đi 1 tuổi
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
                        "Đang dạy"
                        );
                    if (teacherBUS.AddTeacher(gv))
                    {
                        // Thêm giáo viên thành công
                        MessageBox.Show("Thêm giáo viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Xóa dữ liệu trong các ô nhập liệu
                        txtTName.Clear();
                        txtTPhone.Clear();
                        checkNam.Checked = false;
                        checkNu.Checked = false;
                        dtDob.Value = DateTime.Now;

                        // Tải lại danh sách giáo viên
                        LoadTeachers();
                    }
                    else
                    {
                        // Thêm giáo viên thất bại
                        MessageBox.Show("Thêm giáo viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Nếu đã có mã giáo viên thì không cho phép thêm giáo viên mới
                MessageBox.Show("Không thể thêm giáo viên mới khi đã có mã giáo viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (dgvTeacher.CurrentCell == null)//ktra xem co dong nao dang duoc chon hong
            {
                MessageBox.Show("Vui lòng chọn giáo viên để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //lay du lieu tu cac o nhap lieu
            string tenGV = txtTName.Text;
            DateTime ngaySinh = dtDob.Value;
            string gioiTinh = checkNam.Checked ? "Nam" : "Nữ";
            string dienThoai = txtTPhone.Text;

            //lay maGV va taikhoan tu dong dang duoc chon tron datagridview
            int maGV = (int)dgvTeacher.CurrentRow.Cells["MaGV"].Value;
            int taiKhoan = (int)dgvTeacher.CurrentRow.Cells["TaiKhoan"].Value;
            string tinhTrang = "Đang dạy";

            //Tao doi tuong gv (DTO) de chua du lieu can cap nhat
            TeacherDTO gv = new TeacherDTO(maGV, tenGV, ngaySinh, gioiTinh, dienThoai, taiKhoan, tinhTrang);

            if (teacherBUS.UpdateTeacher(gv))
            {
                MessageBox.Show("Cập nhật giáo viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTeachers();// tai lai danh sach giao vien
            }
            else
            {
                MessageBox.Show("Cập nhật giáo viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    LoadTeachers(); // Hàm này chị dùng để load lại DataGridView
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
