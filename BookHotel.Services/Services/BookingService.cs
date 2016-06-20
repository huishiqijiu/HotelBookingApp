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
    public class BookingService : IBookingService
    {
        IBookingRepo _repo;
        public BookingService(IBookingRepo repo)
        {
            _repo = repo;
        }
        public void AddBooking(BookingModel b)
        {
            _repo.AddBooking(b.GetRepoBooking());
        }

        public void DeleteBooking(int id)
        {
            _repo.DeleteBooking(id);
        }

        public BookingModel GetBooking(int id)
        {
            var b = _repo.GetBooking(id);
            BookingModel bm = new BookingModel();
            bm.Id = b.Id;
            bm.NumberOfBeds = b.NumberOfBeds;
            bm.Paid = b.Paid;
            bm.Price = b.Price;
            bm.RegisteredDate = b.RegisteredDate;
            bm.UserId = b.UserId;
            bm.BookFrom = b.BookFrom;
            bm.BookTo = b.BookTo;
            bm.RoomId = b.RoomId;
            return bm;
        }

        public IList<BookingModel> GetBookings()
        {
            return _repo.GetBookings().Select(x => new BookingModel(x)).ToList();
        }

        public void UpdateBooking(int id)
        {
            _repo.UpdateBooking(id);
        }
        public IList<RoomModel> GetAvailableRooms(int bedNumber, DateTime start, DateTime end)
        {
            return _repo.GetAvailableRooms(bedNumber, start, end).Select(x => new RoomModel(x)).ToList();
        }

        public IList<BookingModel> GetBookingsByUserId(int id)
        {
            return _repo.GetBookingsByUserId(id).Select(x=>new BookingModel(x)).ToList();
        }
    }
}
