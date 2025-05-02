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

namespace PresentationLayer
{
    public partial class ChangePassword : Form
    {
         LoginBUS loginBUS = new LoginBUS();
        private string username;
        public ChangePassword(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void btCheck_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPass.Text.Trim();
            string confirmPassword = txtConfirm.Text.Trim();

            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mật khẩu mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
         
            try
            {
                bool kq = loginBUS.UpdateMatKhau(username, newPassword);

                if (kq)
                {
                    MessageBox.Show("Cập nhật mật khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    FrmLogin frmLogin = new FrmLogin();
                    frmLogin.ShowDialog();
                  
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
