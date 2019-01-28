﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Layouts Layout { get; set; }

        public ICollection<RoomAmenities> RoomAmenities { get; set; }
        public ICollection<HotelRoom> HotelRoom { get; set; }

    }

    public enum Layouts
    {
        Studio = 0,
        OneBedroom = 1,
        TwoBedroom = 2
    }
}
