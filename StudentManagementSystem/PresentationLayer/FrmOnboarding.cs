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
    public partial class FrmOnboarding : Form
    {
        public FrmOnboarding()
        {
            InitializeComponent();
        }

        private void timerPanel_Tick(object sender, EventArgs e)
        {
            pn2.Width += 6;
            if (pn2.Width >= 800)
            {
                timerPanel.Stop();

                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Show();
                this.Hide();
            }
        }
    }
}
