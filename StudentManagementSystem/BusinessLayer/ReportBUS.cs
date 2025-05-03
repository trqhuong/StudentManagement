using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class ReportBUS
    {
        private ReportDAO report = new ReportDAO();
        public List<ReportDTO> ThongKeTyLeDat(int maMon, int hocKy, int namHoc)
        {

            var thongKeList = report.ThongKeTyLeDat(maMon, hocKy, namHoc);
            return thongKeList;
        }
    }
}
