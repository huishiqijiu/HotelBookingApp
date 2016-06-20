using BookHotel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHotel.Services.Model
{
    public class RoomModel
    {
        public RoomModel(Room r)
        {
            Id = r.Id;
            BedNumber = r.BedNumber;
            Price = r.Price;
            Number = r.Number;
        }
        public RoomModel()
        {

        }

        public int Id { get; set; }
        public int BedNumber { get; set; }
        public decimal Price { get; set; }
        public int Number { get; set; }




        public Room GetRepoUser()
        {
            return new Room
            {
                Id = Id,
                BedNumber = BedNumber,
                Price = Price,
                Number = Number
            };
        }
    }
}
