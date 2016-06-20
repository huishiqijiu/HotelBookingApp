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
    public class RoomService : IRoomService
    {
        IRoomRepo _repo;
        public RoomService(IRoomRepo repo)
        {
            _repo = repo;
        }
        public RoomModel GetRoomById(int id)
        {
            return new RoomModel(_repo.GetRoomById(id));
        }
    }
}
