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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PresentationLayer
{
    public partial class FrmClass : Form
    {
        private ClassBUS classBUS = new ClassBUS();
        public FrmClass()
        {
            InitializeComponent();
            LoadClass();
        }
        private void FrmClass_Load(object sender, EventArgs e)
        {
            dgvClass.SelectionMode=DataGridViewSelectionMode.FullRowSelect;
            dgvClass.MultiSelect=false;//ko cho chọn nhiều dòng
            ResetForm();
            txtCID.ReadOnly = true;
            cbbGrade.Items.Add(10);
            cbbGrade.Items.Add(11);
            cbbGrade.Items.Add(12);
            cbbGrade.SelectedItem = 10;
        }

        private void LoadClass()
        {
            dgvClass.AutoGenerateColumns = true;//tự động sinh cột
            dgvClass.DataSource = classBUS.GetAllClass();//lấy danh sách lớp từ lớp BUS
            if (dgvClass.Columns["Update"] == null)
            {
                DataGridViewImageColumn btnUpDate = new DataGridViewImageColumn();
                btnUpDate.Name = "Update";
                btnUpDate.HeaderText = "Sửa";
                btnUpDate.Width = 70;
                btnUpDate.Image = Properties.Resources.edit;
                btnUpDate.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgvClass.Columns.Add(btnUpDate);
            }
            ResetForm();//đặt lại form
            dgvClass.ClearSelection();
            dgvClass.CurrentCell = null;
        }

        private void ResetForm()
        {
            dgvClass.SelectionChanged += dgvClass_SelectionChanged;

            txtCID.Text=string.Empty;
            txtCName.Text=string.Empty;
            txtCNumber.Text=string.Empty;
            txtCTID.Text=string.Empty;
            cbbGrade.SelectedItem = 10;
            dgvClass.ClearSelection();
            dgvClass.SelectionChanged -= dgvClass_SelectionChanged;
        }
        private void dgvClass_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvClass.SelectedRows.Count==0)
            {
                return;
            }

            DataGridViewRow row = dgvClass.SelectedRows[0];
            txtCID.Text = row.Cells["MaLop"].Value.ToString();
            txtCName.Text = row.Cells["TenLop"].Value.ToString();
            txtCNumber.Text = row.Cells["SiSo"].Value.ToString();
            txtCTID.Text = row.Cells["GvQuanLi"].Value.ToString();
            cbbGrade.SelectedItem = Convert.ToInt32(row.Cells["Khoi"].Value);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCID.Text))
            {
                if (string.IsNullOrWhiteSpace(txtCName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên lớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtCNumber.Text) || !int.TryParse(txtCNumber.Text, out int siSo))
                {
                    MessageBox.Show("Vui lòng nhập sĩ số hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtCTID.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên giáo viên quản lý", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng ClassDTO để thêm lớp mới
                ClassDTO clas = new ClassDTO(
                    txtCName.Text,
                    (Convert.ToInt32(cbbGrade.SelectedItem)),
                    "", // để trống vì lấy từ bảng NAMHOC trong DAO
                    txtCTID.Text,
                    txtCNumber.Text != "" ? int.Parse(txtCNumber.Text) : 0
                );
                if(classBUS.AddClass(clas))
                {
                    MessageBox.Show("Thêm lớp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadClass();
                }
                else
                {
                    MessageBox.Show("Thêm lớp không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("Lớp đã tồn tại (có mã), không thể thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if(dgvClass.CurrentCell== null)
            {
                MessageBox.Show("Vui lòng chọn lớp để cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //lay du lieu tu o nhap lieu
            string tenLop = txtCName.Text;
            int khoi = Convert.ToInt32(cbbGrade.SelectedItem);
            int siSo = int.Parse(txtCNumber.Text);
            string gvQuanLi = txtCTID.Text;

            int maLop = (int)dgvClass.CurrentRow.Cells["MaLop"].Value;

            //Tao doi tuong ClassDTO để cap nhat
            ClassDTO clas = new ClassDTO(maLop, tenLop, khoi, "", gvQuanLi, siSo);
            if (classBUS.UpdateClass(clas))
            {
                MessageBox.Show("Cập nhật lớp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadClass();
            }
            else
            {
                MessageBox.Show("Cập nhật lớp không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtCID.Text))
            {
                MessageBox.Show("Vui lòng chọn lớp để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa lớp này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int maLop = int.Parse(txtCID.Text);
                bool success = classBUS.DeleteClass(maLop);
                if (success)
                {
                    MessageBox.Show("Xóa lớp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadClass();
                }
                else
                {
                    MessageBox.Show("Xóa lớp không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void dgvClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClass.Columns[e.ColumnIndex].Name == "Update")
            {
                int class_id = Convert.ToInt32(dgvClass.Rows[e.RowIndex].Cells["MaLop"].Value);
                FrmClassStudent management = new FrmClassStudent(class_id);
                management.ShowDialog();
                LoadClass();
            }
        }
    }
}
