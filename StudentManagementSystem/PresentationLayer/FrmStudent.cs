using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using TransferObject;

namespace PresentationLayer
{
    public partial class FrmStudent : Form
    {
        private StudentsBUS studentsBUS = new StudentsBUS();
        private ClassBUS classBUS = new ClassBUS();
        private string cnn = "Data Source=.;Initial Catalog=QLHocSinh;Integrated Security=True";

        public FrmStudent()
        {
            InitializeComponent();
            LoadHocSinh();
            LoadLopHoc();
           
        }
        private void LoadLopHoc()
        {
            List<ClassDTO> danhSachLop = classBUS.GetDanhSachLop();
            cbbClass.DataSource = danhSachLop;
            cbbClass.DisplayMember = "TenLop";
            cbbClass.ValueMember = "MaLop";
        }
        private void FrmStudent_Load(object sender, EventArgs e)
        {

            dgvStudent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudent.MultiSelect = false;
            ResetForm();
            txtSID.ReadOnly = true;
        }
        private void LoadHocSinh()
        {
 
            dgvStudent.DataSource = studentsBUS.GetAllHocSinh();
            ResetForm();
            dgvStudent.ClearSelection();
            dgvStudent.CurrentCell = null;


        }
      
        private void ResetForm()
        {
            // Tắt sự kiện SelectionChanged để tránh tự động điền lại dữ liệu
            dgvStudent.SelectionChanged -= dgvStudent_SelectionChanged;

            txtSID.Text = string.Empty;
            txtSName.Text = string.Empty;
            dtDob.Value = DateTime.Now;
            checkNam.Checked = false;
            checkNu.Checked = false;
            cbbClass.SelectedIndex = -1;
            picQR.Image = null;

            dgvStudent.ClearSelection();

            // Bật lại sự kiện SelectionChanged
            dgvStudent.SelectionChanged += dgvStudent_SelectionChanged;


        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSID.Text))
            {

                if (string.IsNullOrWhiteSpace(txtSName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên học sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbbClass.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!checkNam.Checked && !checkNu.Checked)
                {
                    MessageBox.Show("Vui lòng chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (checkNam.Checked && checkNu.Checked)
                {
                    MessageBox.Show("Chỉ được chọn một giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int age = DateTime.Now.Year - dtDob.Value.Year;

                if (age < 16 || age > 18)
                {
                    MessageBox.Show("Độ tuổi hợp lệ từ 16 -> 18 tuổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    StudentsDTO hs = new StudentsDTO(
                                                      txtSName.Text,
                                                      dtDob.Value,
                                                      checkNam.Checked ? "Nam" : "Nữ",
                                                      "Đang học",
                                                      null, cbbClass.Text);

                    int idLop = Convert.ToInt32(cbbClass.SelectedValue);

                    if (studentsBUS.AddStudent(hs, idLop))
                    {
                        MessageBox.Show("Thêm học sinh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSName.Clear();
                        checkNam.Checked = false;
                        checkNu.Checked = false;
                        cbbClass.SelectedIndex = 0;
                        LoadHocSinh();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            } else { MessageBox.Show("Học sinh đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (dgvStudent.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một học sinh để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string tenHS = txtSName.Text;
            DateTime ngaySinh = dtDob.Value;
            string gioiTinh = checkNam.Checked ? "Nam" : "Nữ";
            string qrPath = dgvStudent.CurrentRow.Cells["QRCodePath"].Value?.ToString();
            string tenLop = cbbClass.Text;

            int maHS = (int)dgvStudent.CurrentRow.Cells["MaHS"].Value;

            StudentsDTO hs = new StudentsDTO(maHS, tenHS, ngaySinh, gioiTinh, "Đang học", qrPath, tenLop);

         
            if (studentsBUS.UpdateHocSinh(hs))
            {
                MessageBox.Show("Cập nhật học sinh thành công!");
                LoadHocSinh(); 
            }
            else
            {
                MessageBox.Show("Lỗi! Không thể cập nhật học sinh.");
            }
        }

        private void btCreateQR_Click(object sender, EventArgs e)
        {

            if (dgvStudent.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một học sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvStudent.SelectedRows[0];

            string qrPath = row.Cells["QRCodePath"].Value?.ToString();
            if (!string.IsNullOrEmpty(qrPath))
            {
                MessageBox.Show("Học sinh này đã có mã QR!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; 
            }

            if (row.Cells["MaHS"].Value == null || row.Cells["TenHS"].Value == null)
            {
                MessageBox.Show("Thông tin học sinh không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int maHS = Convert.ToInt32(row.Cells["MaHS"].Value);  
            string tenHS = row.Cells["TenHS"].Value.ToString();  

           
            StudentsBUS studentBUS = new StudentsBUS();
            qrPath = studentBUS.GenerateQRCode(maHS, tenHS, picQR); 

            if (!string.IsNullOrEmpty(qrPath))
            {
                // Cập nhật đường dẫn vào DataGridView
                row.Cells["QRCodePath"].Value = qrPath;

                MessageBox.Show("Mã QR đã được tạo và lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Làm mới DataGridView để hiển thị dữ liệu mới
                dgvStudent.Refresh();
            }
            else
            {
                MessageBox.Show("Lỗi khi lưu mã QR vào cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvStudent_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudent.SelectedRows.Count == 0)
                return;

         


            DataGridViewRow row = dgvStudent.SelectedRows[0];


            txtSID.Text = row.Cells["MaHS"].Value?.ToString();
            txtSName.Text = row.Cells["TenHS"].Value?.ToString();
            dtDob.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
            cbbClass.Text = row.Cells["TenLop"].Value?.ToString();

            
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
            // Kiểm tra và hiển thị mã QR
            string qrPath = row.Cells["QRCodePath"].Value?.ToString();

            if (!string.IsNullOrEmpty(qrPath) && File.Exists(qrPath))
            {
                picQR.Image = Image.FromFile(qrPath);
            }
            else
            {
                picQR.Image = null;
            }

        }
        private void btReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

       
        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudent.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một học sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            int maHS = Convert.ToInt32(dgvStudent.CurrentRow.Cells["MaHS"].Value);

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa học sinh này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (studentsBUS.DeleteHocSinh(maHS) && studentsBUS.Check_TinhTrang(maHS))
                {
                    MessageBox.Show("Xóa học sinh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHocSinh(); 
                }
                else
                {
                    MessageBox.Show("Xóa học sinh thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
        }

        private void txtSID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
