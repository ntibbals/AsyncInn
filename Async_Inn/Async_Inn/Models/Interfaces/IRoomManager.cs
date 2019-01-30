using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IRoomManager
    {
        Task CreateRoom(Room room);

        Task<Room> GetRoom(int id);
        Task<IEnumerable<Room>> GetRooms();

        Task UpdateRooms(Room room);

 
        Task DeleteRoom(int id);
    }
}
