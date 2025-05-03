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

        //public UsersDTO DangNhap(string username, string password)
        //{
        //    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        //        return null;

        //    return taiKhoanDAO.GetTaiKhoan(username, password);
        //}

        public UsersDTO DangNhap(string username, string password)
        {
        
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

        
            List<UsersDTO> users = taiKhoanDAO.GetTaiKhoan(username, password);

            
            if (users == null || users.Count == 0)
                return null;

            // Nếu tìm thấy tài khoản, trả về đối tượng người dùng đầu tiên
            return users.FirstOrDefault();
        }
        public void Login (string username)
        {
            taiKhoanDAO.Login(username);
        }
        public void Logout()
        {
            taiKhoanDAO.Logout();
        }
    }
}
