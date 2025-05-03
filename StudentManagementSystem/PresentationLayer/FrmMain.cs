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
    public partial class FrmMain : Form
    {
        private LoginBUS taiKhoanBUS = new LoginBUS();
        public static string Username="";
        public FrmMain()
        {
            InitializeComponent();
        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnbody.Controls.Add(currentFormChild);
            pnbody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void lbCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
            taiKhoanBUS.Logout();
        }

        private void btStudent_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmStudent());

        }

        private void btTeacher_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmTeacher());
        }

        private void btClass_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmClass());
        }

        private void btSubject_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmSubject());
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            lbName.Text = Username;
        }

        private void btAttendance_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmAttendance());
        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            taiKhoanBUS.Logout();
            FrmLogin login = new FrmLogin();
            login.Show();
        }

        private void btSchedule_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmSchedule());
        }

        private void btEnd_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmYear_Semester());
        }

        private void btStatistical_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmReport());
        }
    }
}
