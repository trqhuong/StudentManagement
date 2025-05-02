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

        
            List<UsersDTO> users = taiKhoanDAO.GetTaiKhoan(username, password);

            
            if (users == null || users.Count == 0)
                return null;

            // Nếu tìm thấy tài khoản, trả về đối tượng người dùng đầu tiên
            return users.FirstOrDefault();
        }

        public void ChangeStatus (string username)
        {
            taiKhoanDAO.ChangeStatus(username);
        }

        public bool KiemTraUsernameDaTonTai(string username)
        {
       
            if (string.IsNullOrWhiteSpace(username))
                return false;

            return taiKhoanDAO.KiemTraUsernameTonTai(username);
        }

        public string LayEmailTheoUsername(string username)
        {
            return taiKhoanDAO.LayEmailTheoUsername(username);
        }
        public bool UpdateMatKhau(string username, string newPassword)
        {
            return taiKhoanDAO.UpdateMatKhau(username, newPassword);
        }


    }
}
