using BookHotel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Services.Model
{
    public class BookingModel
    {
        public BookingModel(Booking b)
        {
            Id = b.Id;
            UserId = b.UserId;
            NumberOfBeds = b.NumberOfBeds;
            Paid = b.Paid;
            RegisteredDate = b.RegisteredDate;
            Price = b.Price;
            BookFrom = b.BookFrom;
            BookTo = b.BookTo;
            RoomId = b.RoomId;
        }
        public BookingModel()
        {

        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int NumberOfBeds { get; set; }
        public bool Paid { get; set; }
        public DateTime RegisteredDate { get; set; }
        public decimal Price { get; set; }
        public DateTime BookFrom { get; set; }
        public DateTime BookTo { get; set; }
        public int RoomId { get; set; }

        public Booking GetRepoBooking()
        {
            return new Booking
            {
                Id = Id,
                UserId = UserId,
                NumberOfBeds = NumberOfBeds,
                Paid = Paid,
                RegisteredDate = RegisteredDate,
                Price = Price,
                BookFrom = BookFrom,
                BookTo = BookTo,
                RoomId = RoomId
            };
        }
    }
}
