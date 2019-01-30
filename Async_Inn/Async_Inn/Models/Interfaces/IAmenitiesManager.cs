using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IAmenitiesManager
    {
        Task CreateAmenity(Amenities amenity);

        Task<IEnumerable<Amenities>> GetAmenities();
        Task<Amenities> GetAmenities(int ID);

        Task UpdateAmenity(Amenities amenity);


        Task DeleteAmenity(int ID);
        Task DeleteAmenity(Amenities amenity);
    }
}
