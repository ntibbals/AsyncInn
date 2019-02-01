using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
    public class Room
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please provide a room name")]
        [Display(Name = "Room Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please select a layout")]
        [Display(Name = "Room Layout")]
        public Layouts Layout { get; set; }

        public ICollection<RoomAmenities> RoomID { get; set; }
        public ICollection<HotelRoom> Hotels { get; set; }

    }

    public enum Layouts
    {
        Studio = 0,
        OneBedroom = 1,
        TwoBedroom = 2
    }
}
