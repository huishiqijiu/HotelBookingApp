using BookHotel.Data.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Data.Repo
{
    public class UserRepo : IUserRepo
    {
        HotelBookingEntities db = new HotelBookingEntities();
        public User GetUser(string mail)
        {
            User u = db.Users.FirstOrDefault(x => x.Email == mail);
            return u;
        }

        public User GetUserById(int id)
        {
            return db.Users.FirstOrDefault(x => x.Id == id);
        }

        public User SaveUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
