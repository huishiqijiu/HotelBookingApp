using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Data.IRepo
{
    public interface IBookingRepo
    {
        IList<Booking> GetBookings();
        Booking GetBooking(int id);
        void DeleteBooking(int id);
        void AddBooking(Booking b);
        void UpdateBooking(int id);
        IList<Room> GetAvailableRooms(int bedNumber, DateTime start, DateTime end);
        IList<Booking> GetBookingsByUserId(int id);
    }
}
