using BookHotel.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookHotelMVC.ViewModels
{
    public class MyBookingsViewModel
    {
        public IList<BookingModel> DeletableBookings { get; set; }
        public IList<BookingModel> UnDeletableBookings { get; set; }
    }
}