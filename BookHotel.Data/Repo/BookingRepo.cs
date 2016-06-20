using BookHotel.Data.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Data.Repo
{
    public class BookingRepo : IBookingRepo
    {
        IRoomRepo _roomRepo;
        public BookingRepo(IRoomRepo roomRepo)
        {
            _roomRepo = roomRepo;
        }
        HotelBookingEntities db = new HotelBookingEntities();
        public void AddBooking(Booking b)
        {
            db.Bookings.Add(b);
            db.SaveChanges();
        }

        public void DeleteBooking(int id)
        {
            Booking b = db.Bookings.FirstOrDefault(x => x.Id == id);
            db.Bookings.Remove(b);
            db.SaveChanges();
        }

        public Booking GetBooking(int id)
        {
            return db.Bookings.FirstOrDefault(x => x.Id == id);
        }

        public IList<Booking> GetBookings()
        {
            return db.Bookings.ToList();
        }

        public IList<Room> GetAvailableRooms(int bedNumber, DateTime start, DateTime end)
        {
            List<Room> availableRooms = new List<Room>();
            List<Room> roomsWithSameBedNum = db.Rooms.Where(x => x.BedNumber == bedNumber).ToList();
            List<Booking> occupiedRoomsWithSameBedNum = db.Bookings.Where(x => x.NumberOfBeds.ToString().StartsWith(bedNumber.ToString())).ToList();
            List<int> unavailableRoomIds = occupiedRoomsWithSameBedNum.Where(x => start <= x.BookTo && start >= x.BookFrom || x.BookFrom <= end && x.BookFrom >= start).Select(x => x.RoomId).ToList();
            if (unavailableRoomIds.Count() > 0)
            {
                //foreach (int id in unavailableRoomIds)
                //{
                //    availableRooms = roomsWithSameBedNum.Where(x => x.Id != id && !availableRooms.Contains(x) && !unavailableRoomIds.Contains(x.Id)).ToList();
                //}
                List<int> allRoomWithSameBedNrIds = roomsWithSameBedNum.Select(x => x.Id).ToList();
                List<int> availableRoomIds = allRoomWithSameBedNrIds.Except(unavailableRoomIds).ToList();
                foreach (int id in availableRoomIds)
                {
                    Room availableRoom = _roomRepo.GetRoomById(id);
                    availableRooms.Add(availableRoom);
                }
            }
            else
                availableRooms = roomsWithSameBedNum.ToList();
            return availableRooms;
        }

        public void UpdateBooking(int id)
        {
            var booking = db.Bookings.FirstOrDefault(x => x.Id == id);
            booking.Paid = true;
            db.SaveChanges();
        }

        public IList<Booking> GetBookingsByUserId(int id)
        {
            return db.Bookings.Where(x => x.UserId == id).ToList();
        }
    }
}
