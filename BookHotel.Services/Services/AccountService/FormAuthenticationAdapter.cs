using BookHotel.Data;
using BookHotel.Services.IServices.IAccountService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace BookHotel.Services.Services.AccountService
{
    public class FormAuthenticationAdapter : IFormsAuthenticationAdapter
    {
        public void DoAuth(User username)
        {
            FormsAuthentication.SetAuthCookie(username.Email, false);
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}
