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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PresentationLayer
{
    public partial class FrmLogin : Form
    {
        private LoginBUS taiKhoanBUS = new LoginBUS();
        public string Username { get; set; }
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void lbCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = checkShowPass.Checked ? '\0' : '*';
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            UsersDTO taiKhoan = taiKhoanBUS.DangNhap(username, password);

            if (taiKhoan != null) // Nếu tài khoản tồn tại
            {
                this.DialogResult = DialogResult.OK;
                FrmMain.Username = username;
                this.Hide();
                //taiKhoanBUS.ChangeStatus(taiKhoan.TenDangNhap);
                if (taiKhoan.LoaiTaiKhoan == "Admin")
                {
                    FrmMain frmMain = new FrmMain();
                    frmMain.ShowDialog();
                }
                else if (taiKhoan.LoaiTaiKhoan == "Giáo viên")
                {
             
                    FrmMainTeacher frmMainTeacher = new FrmMainTeacher();
                    frmMainTeacher.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("UserName or Password incorrect", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
