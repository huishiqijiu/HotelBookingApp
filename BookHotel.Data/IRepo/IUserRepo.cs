using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Data.IRepo
{
    public interface IUserRepo
    {
        User GetUser(string mail);
        User GetUserById(int id);

        User SaveUser(User user);
        bool UpdateUser(User user);

    }
}
