using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class LoginBUS
    {
        private UsersDAO taiKhoanDAO = new UsersDAO();

        public UsersDTO DangNhap(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            return taiKhoanDAO.GetTaiKhoan(username, password);
        }
    }
}
