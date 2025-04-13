using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace PresentationLayer
{
    public partial class FrmSubject : Form
    {
        private string cnn = "Data Source=.;Initial Catalog=QLHocSinh;Integrated Security=True";
        private SubjectBUS subjectBUS = new SubjectBUS();
        public FrmSubject()
        {
            InitializeComponent();
            LoadSubjects();
        }
        private void FrmSubject_Load(object sender, EventArgs e)
        {
            dgvSubject.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Chọn cả hàng
            dgvSubject.MultiSelect = false; // Không cho phép chọn nhiều hàng
            ResetForm();
            txtSID.Enabled = false; // Không cho phép sửa mã môn học
        }
        private void LoadSubjects()
        {
            dgvSubject.AutoGenerateColumns=true;
            dgvSubject.DataSource=subjectBUS.GetAllSubject();
            ResetForm();
            dgvSubject.ClearSelection(); // Xóa lựa chọn trong DataGridView
            dgvSubject.CurrentCell = null; // Bỏ chọn ô hiện tại
        }
        private void ResetForm()
        {
            // Tắt sự kiện SelectionChanged để tránh tự động điền lại dữ liệu
            dgvSubject.SelectionChanged -= dgvSubject_SelectionChanged; 
            txtSID.Text=string.Empty;
            txtSName.Text = string.Empty;
            dgvSubject.ClearSelection(); // Xóa lựa chọn trong DataGridView
            dgvSubject.SelectionChanged += dgvSubject_SelectionChanged; // Bật lại sự kiện
            
        }
        private void dgvSubject_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvSubject.SelectedRows.Count==0)
            {
                return;
            }
            DataGridViewRow row = dgvSubject.SelectedRows[0];

            txtSID.Text = row.Cells["MaMH"].Value.ToString();
            txtSName.Text = row.Cells["TenMH"].Value.ToString();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSID.Text))
                {
                    if (string.IsNullOrEmpty(txtSName.Text))
                    {
                        MessageBox.Show("Vui lòng nhập tên môn học", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    SubjectDTO subject = new SubjectDTO(txtSName.Text);
                    bool success = subjectBUS.AddSubject(subject);
                    if (success)
                    {
                        MessageBox.Show("Thêm môn học thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSName.Clear();
                        LoadSubjects();
                    }
                    else
                    {
                        MessageBox.Show("Thêm môn học thất bại. Kiểm tra tên có thể đã tồn tại hoặc lỗi CSDL.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mã môn học đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if(dgvSubject.CurrentCell==null)
            {
                MessageBox.Show("Vui lòng chọn môn học để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //lay du lieu tu cac o tren form
            string tenMH = txtSName.Text;

            int maMH=(int)dgvSubject.CurrentRow.Cells["MaMH"].Value;

            SubjectDTO subject = new SubjectDTO(maMH, tenMH);
            if(subjectBUS.UpdateSubject(subject))
            {
                MessageBox.Show("Cập nhật môn học thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSubjects();
            }
            else
            {
                MessageBox.Show("Cập nhật môn học thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvSubject.CurrentCell == null)
            {
                MessageBox.Show("Vui lòng chọn môn học để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa môn học này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int maMH =int.Parse(txtSID.Text);
                if (subjectBUS.DeleteSubject(maMH))
                {
                    MessageBox.Show("Xóa môn học thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSubjects();
                }
                else
                {
                    MessageBox.Show("Xóa môn học thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
