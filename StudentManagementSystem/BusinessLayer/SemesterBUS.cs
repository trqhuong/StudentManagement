using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class SemesterBUS
    {
        private SemesterDAO semesterDAO = new SemesterDAO();

        public List<SemesterDTO> GetAllHocKy()
        {
            return semesterDAO.GetAllHocKy();
        }
        public bool EndSemester()
        {
            return semesterDAO.EndSemester();
        }
    }
}
