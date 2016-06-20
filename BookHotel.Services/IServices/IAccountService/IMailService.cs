using BookHotel.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Services.IServices.IAccountService
{
    public interface IMailService
    {
        void EmailOfDeletedUnpaidBooking(string mail, DateTime bookFrom, DateTime bookTo);
    }
}
