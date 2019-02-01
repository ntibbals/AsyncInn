﻿using Async_Inn.Data;
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
            _context.rooms.Add(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHotel(int id)
        {
            Hotel hotel = _context.rooms.FirstOrDefault(ho => ho.ID == id);
            _context.rooms.Remove(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotels(int id)
        {
            return await _context.rooms.FirstOrDefaultAsync(ho => ho.ID == id);
        }

        public async Task UpdateHotel(Hotel hotel)
        {
             _context.rooms.Update(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            var hotels = await _context.rooms.ToListAsync();

            foreach (Hotel ho in hotels)
            {
                ho.Rooms = await _context.HotelRoom.Where(ro => ro.HotelID == ho.ID).ToListAsync();
            }
            var rooms = _context.HotelRoom.Include(h => h.Hotel).Include(h => h.Room);

            return  await _context.rooms.ToListAsync();
        }

        public async Task DeleteHotel(Hotel hotel)
        {
            _context.rooms.Remove(hotel);
            await _context.SaveChangesAsync();
        }
    }
}
