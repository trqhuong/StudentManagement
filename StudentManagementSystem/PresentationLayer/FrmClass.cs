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
    public partial class FrmClass : Form
    {
        private string cnn = "Data Source=.;Initial Catalog=QLHocSinh;Integrated Security=True";
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
        }

        private void LoadClass()
        {
            dgvClass.AutoGenerateColumns = true;//tự động sinh cột
            dgvClass.DataSource = classBUS.GetDanhSachLop();//lấy danh sách lớp từ lớp BUS
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
            int siSo = int.Parse(txtCNumber.Text);
            string gvQuanLi = txtCTID.Text;

            int maLop = (int)dgvClass.CurrentRow.Cells["MaLop"].Value;

            //Tao doi tuong ClassDTO để cap nhat
            ClassDTO clas = new ClassDTO(maLop, tenLop, "", gvQuanLi, siSo);
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
    }
}
