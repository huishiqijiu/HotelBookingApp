using BookHotel.Services.IServices;
using BookHotel.Services.IServices.IAccountService;
using BookHotel.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace BookHotel.Services.Services.AccountService
{
    public class MailService : IMailService
    {
        IUserService _userService;
        public MailService(IUserService userService)
        {
            _userService = userService;
        }
        public void EmailOfDeletedUnpaidBooking(string mail, DateTime bookFrom, DateTime bookTo)
        {
            
            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
                {
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress("huishi0709@gmail.com");
                    message.To.Add(mail);
                    message.Body = "Your booking at Nackademin Hotel starting from " + bookFrom.ToShortDateString() + 
                        " and end at " + bookTo.ToShortDateString() +" has been cancelled today, since no payment has been received 10 days after registration.";
                    message.Subject = "Your Booking at Nackademin Hotel";
                    client.UseDefaultCredentials = false;
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Credentials = new System.Net.NetworkCredential("huishi0709@gmail.com", "593010sh");
                    client.Send(message);
                    message = null;

                }
            }
            catch (SmtpFailedRecipientsException sfrEx)
            {
                // TODO: Handle exception
                // When email could not be delivered to all receipients.
                throw sfrEx;
            }
            catch (SmtpException sEx)
            {
                // TODO: Handle exception
                // When SMTP Client cannot complete Send operation.
                throw sEx;
            }
        }
    }
}
