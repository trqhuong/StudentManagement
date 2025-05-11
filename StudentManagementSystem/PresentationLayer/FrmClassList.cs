using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using TransferObject;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PresentationLayer
{
    public partial class FrmClassList: Form
    {
        private ClassBUS classBUS = new ClassBUS();
        private StudentsBUS studentsBUS = new StudentsBUS();
        public FrmClassList()
        {
            InitializeComponent();
        }

        private void FrmClassList_Load(object sender, EventArgs e)
        {
            List<ClassDTO> classList = classBUS.GetClassTeacher();
            // Thêm dòng đầu tiên "Chọn lớp"
            classList.Insert(0, new ClassDTO(0, "Chọn lớp"));
            // Gán dữ liệu vào ComboBox
            cbbClass.DataSource = classList;
            cbbClass.DisplayMember = "TenLop";
            cbbClass.ValueMember = "MaLop";
            dgvClassList.AutoGenerateColumns = false;
            dgvClassList.Columns.Clear();
            //thiết kế column
            dgvClassList.Columns.Add(new DataGridViewTextBoxColumn { Name = "STT", HeaderText = "STT", Width = 50 });
            dgvClassList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenHS", HeaderText = "Họ và tên", Width = 150 });
            dgvClassList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GioiTinh", HeaderText = "Giới tính", Width = 70 });
            dgvClassList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NgaySinh", HeaderText = "Ngày sinh", Width = 100, DefaultCellStyle = { Format = "dd/MM/yyyy" } });
            dgvClassList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TinhTrang", HeaderText = "Tình trạng", Width = 100 });
            dgvClassList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "QRCodePath", HeaderText = "QR Code Path", Width = 230 });
            // Font & màu
            dgvClassList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvClassList.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvClassList.DefaultCellStyle.BackColor = Color.White;
            dgvClassList.EnableHeadersVisualStyles = false;
            dgvClassList.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvClassList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Căn giữa header
            dgvClassList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Không cho chỉnh sửa
            dgvClassList.ReadOnly = true;

            // Giãn cột cho vừa
            dgvClassList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Không cho thêm/sửa/xoá dòng
            dgvClassList.AllowUserToAddRows = false;
            dgvClassList.AllowUserToDeleteRows = false;
            dgvClassList.AllowUserToOrderColumns = false;

        }

        private void cbbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbClass.SelectedValue != null && int.TryParse(cbbClass.SelectedValue.ToString(), out int maLop) && maLop > 0)
            {
                List<StudentsDTO> students = studentsBUS.GetStudentByClass(maLop);
                dgvClassList.DataSource = students;
                txtClassSize.Text = students.Count.ToString();
                for (int i = 0; i < dgvClassList.Rows.Count; i++)
                {
                    dgvClassList.Rows[i].Cells["STT"].Value = i + 1;
                }
            }
            else
                dgvClassList.DataSource = null;
        }

    }
}
