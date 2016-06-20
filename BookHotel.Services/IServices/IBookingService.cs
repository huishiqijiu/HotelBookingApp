using BookHotel.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Services.IServices
{
    public interface IBookingService
    {
        IList<BookingModel> GetBookings();
        BookingModel GetBooking(int id);
        void DeleteBooking(int id);
        void AddBooking(BookingModel b);
        void UpdateBooking(int id);
        IList<RoomModel> GetAvailableRooms(int bedNumber, DateTime start, DateTime end);
        IList<BookingModel> GetBookingsByUserId(int id);
    }
}
