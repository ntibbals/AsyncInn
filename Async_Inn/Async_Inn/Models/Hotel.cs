using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        /// <summary>
        /// Navigation properties
        /// </summary>
        public HotelRoom HotelRoom { get; set; }
    }
}
