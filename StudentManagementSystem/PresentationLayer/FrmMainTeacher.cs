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
    public partial class FrmMainTeacher: Form
    {
        public FrmMainTeacher()
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

        private void btList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmClassList());
        }

        private void btInput_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmInput());
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmExport());
        }

        private void lbCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMainTeacher_Load(object sender, EventArgs e)
        {
            lbName.Text = FrmMain.Username;
        }
    }
}
