﻿using Async_Inn.Data;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Services
{
    public class RoomManagementServices : IRoomManager
    {
        public AsyncInnDbContext _context { get; }

        public RoomManagementServices(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateRoom(Room room)
        {
            _context.Room.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(int id)
        {
            Room room = _context.Room.FirstOrDefault(ro => ro.ID == id);
            _context.Room.Remove(room);
            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRooms(int id)
        {
            return await _context.Room.FirstOrDefaultAsync(ro => ro.ID == id);
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            var rooms = await _context.Room.ToListAsync();

            foreach (Room ro in rooms)
            {
                ro.RoomID = await _context.RoomAmenities.Where(am => am.RoomID == ro.ID).ToListAsync(); 
            }

            return rooms;
        }

        public async Task UpdateRooms(Room room)
        {
            _context.Room.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(Room room)
        {
            _context.Room.Remove(room);
            await _context.SaveChangesAsync();
        }
    }
}
