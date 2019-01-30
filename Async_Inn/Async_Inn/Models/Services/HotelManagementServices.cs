using Async_Inn.Data;
using Async_Inn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Services
{
    public class HotelManagementServices : IHotelManager
    {
        public AsyncInnDbContext _context { get; }

        public HotelManagementServices(AsyncInnDbContext context)
        {
            _context = context;
        }
        public Task CreateAmenity(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteHotel(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> GetHotels()
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> GetHotels(int ID)
        {
            throw new NotImplementedException();
        }

        public Task UpdateHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}
