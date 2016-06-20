using BookHotel.Services.IServices;
using BookHotel.Services.IServices.IAccountService;
using BookHotel.Services.Model;
using BookHotelMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookHotelMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IBookingService _bookingService;
        IRoomService _roomService;
        IUserService _userService;
        IMailService _mailService;

        public HomeController(IBookingService bookingService, IRoomService roomService, IUserService userService, IMailService mailService)
        {
            _bookingService = bookingService;
            _roomService = roomService;
            _userService = userService;
            _mailService = mailService;
        }
        // GET: Home
        public ActionResult Index()
       {                          
            
            return View();
        }
        public ActionResult Admin()
        {
            var user = _userService.GetUser(System.Web.HttpContext.Current.User.Identity.Name);
            if (user.IsAdmin == true)
            {
                IList<BookingModel> UnpaidBookingsToDelete = _bookingService.GetBookings().Where(x => x.Paid == false && (DateTime.Today - x.RegisteredDate).TotalDays > 10).ToList();
                foreach (var b in UnpaidBookingsToDelete)
                {
                    _bookingService.DeleteBooking(b.Id);
                    _mailService.EmailOfDeletedUnpaidBooking(user.Email, b.BookFrom, b.BookTo);
                }
                var model = new AdminViewModel
                {
                    PaidBookings = _bookingService.GetBookings().Where(x => x.Paid == true).ToList(),
                    UnpaidBookings = _bookingService.GetBookings().Where(x => x.Paid != true).ToList()
                };
                return View(model);
            }
            else
                return View("NonAdmin");
        }
        public ActionResult Booking()
        {
            BookingModel b = new BookingModel();
            return View(b);
        }
        [HttpPost]
        public ActionResult Booking(BookingModel b)
        {
            if (_bookingService.GetAvailableRooms(b.NumberOfBeds, b.BookFrom, b.BookTo).Count > 0)
            {
                var user = _userService.GetUser(System.Web.HttpContext.Current.User.Identity.Name);
                b.UserId = user.Id;
                b.RegisteredDate = DateTime.Today;
                b.Paid = false;
                List<RoomModel> availableRooms = _bookingService.GetAvailableRooms(b.NumberOfBeds, b.BookFrom, b.BookTo).ToList();

                b.RoomId = availableRooms[0].Id;
                int pricePerRoom = Convert.ToInt32(availableRooms[0].Price);
                b.Price = Convert.ToDecimal(pricePerRoom * (b.BookTo - b.BookFrom).TotalDays);
                _bookingService.AddBooking(b);
                return RedirectToAction("Index");                
            }
            else
                return RedirectToAction("NoRoom");
        }
        [HttpPost]
        public void GetPayment(int id)
        {
            _bookingService.UpdateBooking(id);
            
        }
        public ActionResult MyBookings()
        {
            var user = _userService.GetUser(System.Web.HttpContext.Current.User.Identity.Name);
            var model = new MyBookingsViewModel
            {
                DeletableBookings = _bookingService.GetBookingsByUserId(user.Id).Where(x => (x.BookFrom - DateTime.Today).TotalDays > 10).ToList(),
                UnDeletableBookings = _bookingService.GetBookingsByUserId(user.Id).Where(x => (x.BookFrom - DateTime.Today).TotalDays <= 10).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public void DeleteBooking(int id)
        {
            _bookingService.DeleteBooking(id);

        }
        public ActionResult Test()
        {

            return View();
        }
    }
}