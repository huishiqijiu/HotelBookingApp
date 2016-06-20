using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Data.IRepo
{
    public interface IRoomRepo
    {
        Room GetRoomById(int id);
    }
}
