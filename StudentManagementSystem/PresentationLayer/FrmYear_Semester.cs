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
    public partial class FrmYear_Semester: Form
    {
        private EndSemesterBUS endsemester = new EndSemesterBUS();
        public FrmYear_Semester()
        {
            InitializeComponent();
        }

        private void btEnd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn kết thúc học kỳ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool result = endsemester.EndSemester();
                if (result)
                {
                    MessageBox.Show("Kết thúc học kỳ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Kết thúc học kỳ thất bại!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
