using BookHotel.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Services.IServices
{
    public interface IUserService
    {
        UserModel GetUser(string mail);

        UserModel GetUserById(int id);
    }
}
