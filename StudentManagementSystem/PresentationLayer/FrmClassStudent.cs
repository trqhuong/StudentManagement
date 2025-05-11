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
    public partial class FrmClassStudent: Form
    {
        private StudentsBUS studentsBUS = new StudentsBUS();
        private ClassBUS classBUS = new ClassBUS();
        private int class_id;
        public FrmClassStudent(int id)
        {
            class_id = id;
            InitializeComponent();
        }

        private void FrmClassStudent_Load(object sender, EventArgs e)
        {
            ClassDTO classes = classBUS.GetClassById(class_id);
            lbLop.Text = "Lớp: " + classes.TenLop;
            loadData();
        }
        public void loadData()
        {
            var filtered = studentsBUS.GetStudentNoClass(class_id).Select(s => new
            {
                s.MaHS,
                s.TenHS,
                s.NgaySinh,
                s.GioiTinh
            }).ToList();
            dgvStudent.DataSource = filtered;
            if (dgvStudent.Columns["Add"] == null)
            {
                DataGridViewImageColumn btnUpDate = new DataGridViewImageColumn();
                btnUpDate.Name = "Add";
                btnUpDate.HeaderText = "Thêm";
                btnUpDate.Width = 70;
                btnUpDate.Image = Properties.Resources.add;
                btnUpDate.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgvStudent.Columns.Add(btnUpDate);
            }
        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStudent.Columns[e.ColumnIndex].Name == "Add")
            {
                int student_id = Convert.ToInt32(dgvStudent.Rows[e.RowIndex].Cells["MaHS"].Value);
                if (MessageBox.Show("Bạn có chăc muốn thêm học sinh này vào lớp ?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (studentsBUS.AddStudentInClass(class_id, student_id))
                    {
                        MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    return;
                
            }
        }
    }
}
