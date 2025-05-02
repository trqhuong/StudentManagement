using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class OTP : Form
    {
        private string expectedOtp;
        private string username;

        public OTP(string otp, string username)
        {
            InitializeComponent();
            expectedOtp = otp;
            this.username = username;
        }
        private void btSend_Click(object sender, EventArgs e)
        {
            if (txtOTP.Text.Trim() == expectedOtp)
            {
                // Hiển thị thông báo và kiểm tra người dùng có nhấn OK không
                DialogResult result = MessageBox.Show("Xác thực thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    this.Hide();
                    
                    ChangePassword frmChange = new ChangePassword(username);
                    frmChange.ShowDialog();
                    
                }
            }
            else
            {
                MessageBox.Show("Sai mã OTP!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        
                this.Hide() ;
                ForgotPassword forgotForm = new ForgotPassword();
                forgotForm.ShowDialog();
                
            }
        }


    }
}
