using BookHotel.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Services.IServices
{
    public interface IRoomService
    {
        RoomModel GetRoomById(int id);
    }
}
