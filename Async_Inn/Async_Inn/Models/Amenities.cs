﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
    public class Amenities
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public RoomAmenities RoomAmenities { get; set; }
    }
}
