using BookHotel.Data.IRepo;
using BookHotel.Services.IServices;
using BookHotel.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepository;
        public UserService(IUserRepo userRepository)
        {
            _userRepository = userRepository;
        }
        
        public UserModel GetUser(string mail)
        {
            var u = _userRepository.GetUser(mail);
            var i = new UserModel();
            i.Id = u.Id;
            i.Email = u.Email;
            i.Password = u.Password;
            i.IsAdmin = u.IsAdmin;
            return i;
        }

        public UserModel GetUserById(int id)
        {
            return new UserModel(_userRepository.GetUserById(id));
        }
    }
}
