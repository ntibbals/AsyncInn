using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
    public class HotelRoom
    {
        [Required(ErrorMessage = "Please provide a hotel id")]
        public int HotelID { get; set; }
        [Required(ErrorMessage = "Please provide a number for the room")]
        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }
        public int RoomID { get; set; }
        [Required(ErrorMessage = "Please provide a rate for the room")]
        [Display(Name = "Room Rate")]
        [Range(0, 999.99)]
        public decimal Rate { get; set; }
        [Required(ErrorMessage = "Please confirm if the room is pet friendly")]
        [Display(Name = "Pet Friendly")]
        public bool PetFriendly { get; set; }

        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
