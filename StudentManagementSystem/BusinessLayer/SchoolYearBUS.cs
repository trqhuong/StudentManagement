using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class SchoolYearBUS
    {
        private SchoolYearDAO dao = new SchoolYearDAO();

        public List<SchoolYearDTO> GetAllSchoolYears()
        {
            return dao.GetAllSchoolYears();
        }
    }
}
