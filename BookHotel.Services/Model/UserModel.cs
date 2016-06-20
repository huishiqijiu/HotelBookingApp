using BookHotel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Services.Model
{
    public class UserModel
    {
        public UserModel(User user)
        {
            Id = user.Id;
            Email = user.Email;
            Password = user.Password;
            IsAdmin = user.IsAdmin;
        }
        public UserModel()
        {

        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }




        public User GetRepoUser()
        {
            return new User
            {
                Id = Id,
                Email = Email,
                Password = Password,
                IsAdmin = IsAdmin
            };
        }
    }
}
