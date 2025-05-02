using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class ForgotPassword : Form
    {
        LoginBUS loginBUS=new LoginBUS();
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void btCheck_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("UserName incorrect", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
     

            if (loginBUS.KiemTraUsernameDaTonTai(username))
            {
                // Sinh OTP ngẫu nhiên
                string otp = new Random().Next(100000, 999999).ToString();

                // Gửi email
                string email = loginBUS.LayEmailTheoUsername(username); // giả định có hàm này
               
                try
                {
                    GuiOTPQuaEmail(email, otp);
                    this.Hide();
                    // Hiện form nhập OTP
                    OTP formOtp = new OTP(otp,username);
                    formOtp.ShowDialog();
              
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi gửi email: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void GuiOTPQuaEmail(string toEmail, string otp)
        {
            
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("quynhhuongtran314@gmail.com");
                mail.To.Add(toEmail);
                mail.Subject = "Mã OTP xác thực của bạn";
                mail.Body = $"Mã OTP của bạn là: {otp}";

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("quynhhuongtran314@gmail.com", "eeppxloexxkryxzd"); // Dùng app password nếu là Gmail
                client.Send(mail);

           
        }

    }
}
