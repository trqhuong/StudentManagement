using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EndSemesterBUS
    {
        private EndSemesterDAO endSemesterDAO = new EndSemesterDAO();
        public bool EndSemester()
        {
            return endSemesterDAO.EndSemester();
        }
    }
}
