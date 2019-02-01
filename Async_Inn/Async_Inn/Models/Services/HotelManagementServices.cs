using Async_Inn.Data;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        public async Task CreateHotel(Hotel hotel)
        {
            _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHotel(int id)
        {
            Hotel hotel = _context.Hotel.FirstOrDefault(ho => ho.ID == id);
            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotels(int id)
        {
            return await _context.Hotel.FirstOrDefaultAsync(ho => ho.ID == id);
        }

        public async Task UpdateHotel(Hotel hotel)
        {
             _context.Hotel.Update(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            var hotels = await _context.Hotel.ToListAsync();

            foreach (Hotel ho in hotels)
            {
                ho.Rooms = await _context.HotelRoom.Where(ro => ro.HotelID == ho.ID).ToListAsync();
            }
            var rooms = _context.HotelRoom.Include(h => h.Hotel).Include(h => h.Room);

            return  hotels;
        }

        public async Task DeleteHotel(Hotel hotel)
        {
            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();
        }
    }
}
