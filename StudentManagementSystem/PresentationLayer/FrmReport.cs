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
using System.Windows.Forms.DataVisualization.Charting;
using TransferObject;

namespace PresentationLayer
{
    public partial class FrmReport : Form
    {
        private ReportBUS thongKeBUS = new ReportBUS();
        private SubjectBUS subjectBUS = new SubjectBUS();
        private SemesterBUS semesterBUS = new SemesterBUS();
        private SchoolYearBUS schoolYearBUS = new SchoolYearBUS();

        public FrmReport()
        {

            InitializeComponent();
            LoadData();
        }


        private void LoadData()
        {
            var listMonHoc = subjectBUS.GetAllSubject();

            if (listMonHoc != null && listMonHoc.Count > 0)
            {
                cbbSubject.DataSource = listMonHoc;
                cbbSubject.DisplayMember = "TenMH";
                cbbSubject.ValueMember = "MaMH";

            }
            else
            {
                MessageBox.Show("Không có môn học nào để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            cbbSemester.Items.Clear();
            cbbSemester.Items.Add("1");
            cbbSemester.Items.Add("2");
            cbbSemester.SelectedIndex = 0;


            List<SchoolYearDTO> listSchoolYear = schoolYearBUS.GetAllSchoolYears();
            cbbYear.DataSource = listSchoolYear;
            cbbYear.DisplayMember = "NamHienThi";
            cbbYear.ValueMember = "MaNH";

        }
        private void LoadChartData(List<ReportDTO> reportData)
        {
            // Xóa dữ liệu cũ trong biểu đồ
            chartReport.Series.Clear();
            chartReport.ChartAreas.Clear();

            // Thêm ChartArea mới vào biểu đồ
            ChartArea chartArea = new ChartArea();
            chartReport.ChartAreas.Add(chartArea);

            // Tạo một Series để chứa dữ liệu
            Series series = new Series("% Tỷ lệ đạt");
            series.ChartType = SeriesChartType.Column; // Biểu đồ thanh ngang

            // Thêm dữ liệu vào Series
            foreach (var item in reportData)
            {
                series.Points.AddXY(item.TenLop, item.TyLeDat);
            }

            // Thêm Series vào biểu đồ
            chartReport.Series.Add(series);

            // Cấu hình trục Y
            chartReport.ChartAreas[0].AxisY.Maximum = 100;
            chartReport.ChartAreas[0].AxisY.Minimum = 0;
            chartReport.ChartAreas[0].AxisY.LabelStyle.Angle = 0; // <-- Thêm dòng này

            // Nếu muốn đẹp hơn: chỉnh khoảng cách nhãn trục Y
            chartReport.ChartAreas[0].AxisY.Interval = 20;
            chartReport.ChartAreas[0].AxisY.LabelStyle.Format = "{0}%";

        }

        private void btReport_Click(object sender, EventArgs e)
        {
            int maMon = Convert.ToInt32(cbbSubject.SelectedValue);
            int hocKy = Convert.ToInt32(cbbSemester.SelectedItem.ToString());
            int namHoc = Convert.ToInt32(cbbYear.SelectedValue);

            var reportData = thongKeBUS.ThongKeTyLeDat(maMon, hocKy, namHoc);

            // Đổ dữ liệu vào biểu đồ
            LoadChartData(reportData);
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {

        }
    }
}
