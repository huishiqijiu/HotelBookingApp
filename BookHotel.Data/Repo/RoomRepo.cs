using BookHotel.Data.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Data.Repo
{
    public class RoomRepo : IRoomRepo
    {
        HotelBookingEntities db = new HotelBookingEntities();
        public Room GetRoomById(int id)
        {
            return db.Rooms.FirstOrDefault(x => x.Id == id);
        }
    }
}
