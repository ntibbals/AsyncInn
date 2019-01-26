using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
    public class HotelRoom
    {
        public Hotel HotelID { get; set; }
        public Room RoomID { get; set; }
        public Room ID { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }

        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
