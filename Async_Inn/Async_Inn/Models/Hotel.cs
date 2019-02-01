using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please provide hotel name")]
        [Display(Name = "Hotel Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide a hotel address")]
        [Display(Name = "Hotel Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please provide a hotel phone number")]
        [Display(Name = "Hotel Phone Number")]
        [Phone]
        public string Phone { get; set; }

        public ICollection<HotelRoom> Rooms { get; set; }
        public ICollection<Amenities> Amenities { get; set; }

        /// <summary>
        /// Navigation properties
        /// </summary>
        public HotelRoom HotelRoom { get; set; }
    }
}
