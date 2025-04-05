using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class ClassBUS
    {
        private ClassDAO classDAO = new ClassDAO();

        public List<ClassDTO> GetDanhSachLop()
        {
            return classDAO.GetAllLopHoc();
        }
    }
}
