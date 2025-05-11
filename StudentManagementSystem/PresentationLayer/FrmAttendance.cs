using AForge.Video;
using AForge.Video.DirectShow;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;
using ZXing;

namespace PresentationLayer
{
    public partial class FrmAttendance : Form
    {
        private FilterInfoCollection thongTinThietBi;
        private VideoCaptureDevice cam;
        private bool daQuetQR = false;
        private AttendanceBUS diemDanh = new AttendanceBUS();
        public FrmAttendance()
        {
            InitializeComponent();
            LoadData();
            thongTinThietBi = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in thongTinThietBi)
            {
                cbbThietBi.Items.Add(device.Name);
            }
            cbbThietBi.SelectedIndex = 0;
        }
        private void LoadData()
        {
            dgvDiemDanh.DataSource = diemDanh.GetAllAttendance();
       
        }
        private void btScanQR_Click(object sender, EventArgs e)
        {
            if (cam != null && cam.IsRunning)
            {
                SafeStopCamera();
                Thread.Sleep(500); // chờ một chút để cam cũ dừng xong hẳn
            }

            cam = new VideoCaptureDevice(thongTinThietBi[cbbThietBi.SelectedIndex].MonikerString);
            cam.NewFrame += camFrame;
            cam.Start();

            daQuetQR = false;
            btScanQR.Enabled = false;
            btStopQR.Enabled = true;
        }

        private void camFrame(object sender, NewFrameEventArgs e)
        {
            if (daQuetQR) return; // Không xử lý nếu đã quét

            Bitmap bitmap = (Bitmap)e.Frame.Clone();
            BarcodeReader read = new BarcodeReader();
            var ketQua = read.Decode(bitmap);

            if (ketQua != null)
            {
                daQuetQR = true; // Đánh dấu là đã quét để ngăn quét lại

                this.Invoke(new MethodInvoker(delegate () 
                {
                    string qrText = ketQua.ToString();
                    int maHS;
                    string[] qrParts = qrText.Split('_');

                    if (qrParts.Length > 0 && int.TryParse(qrParts[0], out maHS))
                    {
                        StudentsBUS hsBUS = new StudentsBUS();
                        StudentsDTO hs = hsBUS.GetHocSinhById(maHS);
                  

                        if (hs != null)
                        {
                            if (!hsBUS.Check_TinhTrang(maHS))
                            {
                                MessageBox.Show("Học sinh này không còn học. Không thể điểm danh!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            txtSID.Text = hs.MaHS.ToString();
                            txtSName.Text = hs.TenHS;
                            txtClass.Text = hs.tenLop;
                            dtDob.Text = hs.NgaySinh.ToShortDateString();
                            checkNam.Checked = hs.GioiTinh == "Nam";
                            checkNu.Checked = hs.GioiTinh == "Nữ";

                            AttendanceDTO attendance = new AttendanceDTO(
                                hs.MaHS,
                                DateTime.Now,
                                "Có mặt"
                            );

                            AttendanceBUS attendanceBUS = new AttendanceBUS();
                            bool isDiemDanh = attendanceBUS.DiemDanhHocSinh(attendance);



                            if (isDiemDanh)
                            {
                                MessageBox.Show("Điểm danh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();
                                //SafeStopCamera();
                            }
                            else
                            {
                                MessageBox.Show("Điểm danh thất bại hoặc học sinh đã điểm danh rồi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //SafeStopCamera();
                            }
                        }
                        else
                        {
                           
                            MessageBox.Show("Không tìm thấy học sinh trong hệ thống.");
                        }
                    }
                    else
                    {
                       
                        MessageBox.Show("Mã QR không hợp lệ.");
                    }
                }));
            }

            picQR.Image = bitmap;
        }
        private void ResetForm()
        {
            txtSID.Text = string.Empty;
            txtSName.Text = string.Empty;
            dtDob.Value = DateTime.Now;
            checkNam.Checked = false;
            checkNu.Checked = false;
            txtClass.Text = null;

        }
        private void SafeStopCamera()
        {
            // Giữ lại camera hiện tại để đảm bảo không bị "cam mới" ghi đè
            var currentCam = cam;

            Task.Run(() => //tạo 1 task chạy ngầm, xử lý dừng cam mà ko làm chậm tới giao diện
            {
                if (currentCam != null && currentCam.IsRunning)
                {
                    currentCam.SignalToStop();    // Gửi yêu cầu dừng camera
                    currentCam.WaitForStop();     // Chờ camera dừng hoàn toàn
                    currentCam.NewFrame -= camFrame; // Gỡ bỏ event xử lý ảnh
                }

                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(() => //kiểm tra có phải đang ở thread phụ hay không
                    {
                        picQR.Image = null;
                        daQuetQR = false;
                        btScanQR.Enabled = true;
                        btStopQR.Enabled = false;
                        ResetForm();
                    }));
                }
            });

            // cam gán null ở ngoài (tránh bị null trước khi Task xử lý xong)
            cam = null;
        }
   

        private void btStopQR_Click(object sender, EventArgs e)
        {
           SafeStopCamera();
        }

        private void FrmAttendance_Load(object sender, EventArgs e)
        {

        }

        private void btEnd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn kết thúc điểm danh?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {

                    diemDanh.KetThucDiemDanh();

                    MessageBox.Show("Đã cập nhật trạng thái vắng mặt cho học sinh chưa điểm danh.");


                    diemDanh.GuiMailThongBaoTheoDanhSach();

                    MessageBox.Show("Đã gửi email thông báo đến GVCN danh sách học sinh vắng 2 ngày liên tiếp.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }

                LoadData();
            }
        }
    }
}
