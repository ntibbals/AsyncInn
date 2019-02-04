using System;
using Xunit;
using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Models.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn_TDD
{
    public class RoomTests
    {
        [Fact]
        public void GetRoomLayout()
        {
            Room room = new Room();
            room.ID = 7;
            room.Name = "Hawks";
            room.Layout = Layouts.OneBedroom;

            Assert.Equal( Layouts.OneBedroom, room.Layout);
        }

        [Fact]
        public void GetRoomName()
        {
            Room room = new Room();
            room.ID = 58;
            room.Name = "Hawks";
            room.Layout = Layouts.OneBedroom;

            Assert.Equal("Hawks", room.Name);
        }

        [Fact]
        public void GetRoomID()
        {
            Room room = new Room();
            room.ID = 59;
            room.Name = "Hawks";
            room.Layout = Layouts.OneBedroom;

            Assert.Equal(7, room.ID);
        }

        [Fact]
        public async void CanCreateRoom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Room room = new Room();
                room.ID = 60;
                room.Name = "Hawks";
                room.Layout = Layouts.OneBedroom;

                RoomManagementServices roomService = new RoomManagementServices(context);

                await roomService.CreateRoom(room);

                var result = context.Room.FirstOrDefault(ho => ho.ID == room.ID);

                Assert.Equal(room, result);
            }
        }

        [Fact]
        public async void CanDeleteRoom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Room room = new Room();
                room.ID = 61;
                room.Name = "Hawks";
                room.Layout = Layouts.OneBedroom;

                RoomManagementServices roomService = new RoomManagementServices(context);

                await roomService.CreateRoom(room);
                await roomService.DeleteRoom(room.ID);

                var result = context.Room.FirstOrDefault(ho => ho.ID == room.ID);

                Assert.Null(result);
            }
        }

        [Fact]
        public async void CanEditRoom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("UpdateRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Room room = new Room();
                room.ID = 62;
                room.Name = "Hawks";
                room.Layout = Layouts.OneBedroom;

                RoomManagementServices roomService = new RoomManagementServices(context);

                await roomService.CreateRoom(room);

                Room upRoom = await roomService.GetRooms(room.ID);

                upRoom.Layout = Layouts.TwoBedroom;

                await roomService.UpdateRooms(upRoom);

                var result = context.Room.FirstOrDefault(ho => ho.ID == room.ID);

                Assert.Equal(Layouts.TwoBedroom, result.Layout);
            }
        }

    }
}
