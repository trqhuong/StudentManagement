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
    public partial class FrmYear_Semester: Form
    {
        private SchoolYearBUS yearBUS = new SchoolYearBUS();
        private SemesterBUS semesterBUS = new SemesterBUS();
        public FrmYear_Semester()
        {
            InitializeComponent();
        }

        private void btEnd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn kết thúc học kỳ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool result = semesterBUS.EndSemester();
                if (result)
                {
                    MessageBox.Show("Kết thúc học kỳ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Kết thúc học kỳ thất bại!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            loadData();
        }

        private void FrmYear_Semester_Load(object sender, EventArgs e)
        {
            loadData();
        }
        public void loadData()
        {
            List<SchoolYearDTO> years = yearBUS.GetAllSchoolYears();
            List<SemesterDTO> semesters = semesterBUS.GetAllHocKy();
            dgvYear.DataSource = years;
            dgvYear.Columns["NamHienThi"].Visible = false;
            dgvSemester.DataSource = semesters;
            // Hiển thị năm học có trạng thái true
            lbYear.Text = "";
            foreach (var y in years)
            {
                if (y.TrangThai == true)
                {
                    lbYear.Text = "Năm học: " + y.NamBatDau + "-" + y.NamKetThuc;
                    break;
                }
            }
            // Hiển thị học kỳ có trạng thái true
            lbSemester.Text = "";
            foreach (var s in semesters)
            {
                if (s.TrangThai == true)
                {
                    lbSemester.Text = "Học kỳ: " + s.SoHocKy;
                    break;
                }
            }
        }

    }
}
