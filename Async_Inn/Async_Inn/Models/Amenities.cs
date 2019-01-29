using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
    public class Amenities
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please provide amenity name")]
        [Display(Name = "Amenity Name")]
        public string Name { get; set; }

        public RoomAmenities RoomAmenities { get; set; }
    }
}
