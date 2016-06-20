using BookHotel.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BookHotel.Services.IServices.IAccountService
{
    public interface IUserAuthenticationService
    {
        bool UserExists(string username);
        bool Login(string username, string password);
        bool WrongPassword(string username, string password);
        void Logout();
        int RegisterUser(UserModel user);
        UserModel AuthenticationRequest(HttpContextBase context);
        UserModel GetUser(string username);
        bool UpdateUser(UserModel user);
        bool ChangePassword(int id, string password);
    }
}
