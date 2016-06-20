using BookHotel.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookHotelMVC.ViewModels
{
    public class AdminViewModel
    {
        public IList<BookingModel> PaidBookings { get; set; }
        public IList<BookingModel> UnpaidBookings { get; set; }
        //public string userEmail { get; set; }
    }
}