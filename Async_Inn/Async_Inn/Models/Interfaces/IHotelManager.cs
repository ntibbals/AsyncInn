using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    interface IHotelManager
    {
        Task CreateAmenity(Hotel hotel);

        Task<Hotel> GetHotels();
        Task<Hotel> GetHotels(int ID);

        Task UpdateHotel(Hotel hotel);

        //void DeleteAmenity(Amenities amenity);
        Task DeleteHotel(int ID);
    }
}
