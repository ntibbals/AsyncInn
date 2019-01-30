using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IHotelManager
    {
        Task CreateHotel(Hotel hotel);

        Task<Hotel> GetHotels(int id);
        Task<IEnumerable<Hotel>> GetHotels();

        Task UpdateHotel(Hotel hotel);

        Task DeleteHotel(int id);
        Task DeleteHotel(Hotel hotel);
    }
}
