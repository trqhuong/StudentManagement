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
        public bool AddClass(ClassDTO clas)
        {
            return classDAO.AddClass(clas)>0;
        }
        public bool UpdateClass(ClassDTO clas)
        {
            return classDAO.UpdateClass(clas) > 0;
        }
        public bool DeleteClass(int maLop)
        {
            return classDAO.DeleteClass(maLop);
        }
        public List<ClassDTO> GetDanhSachLopTheoTrangThai()
        {
            return classDAO.GetAllLopHocTheoTrangThai();
        }
    }
}
