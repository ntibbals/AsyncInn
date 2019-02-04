using System;
using Xunit;
using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Models.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Async_Inn.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AsyncInn_TDD
{
    public class HotelRoomTests
    {
        [Fact]
        public void GetRoomNumber()
        {
            // get hotel room number
            HotelRoom hoRoom = new HotelRoom();
            hoRoom.HotelID = 80;
            hoRoom.RoomNumber = 77;
            hoRoom.RoomID = 81;
            hoRoom.Rate = 350;
            hoRoom.PetFriendly = true;

            Assert.Equal(77, hoRoom.RoomNumber);
        }

        [Fact]
        public void ValidatePetFriendly()
        {
            /// check boolean on pet friendly true
            HotelRoom hoRoom = new HotelRoom();
            hoRoom.HotelID = 80;
            hoRoom.RoomNumber = 77;
            hoRoom.RoomID = 81;
            hoRoom.Rate = 350;
            hoRoom.PetFriendly = true;

            Assert.True(hoRoom.PetFriendly);
        }

        [Fact]
        public async void CanCreateHotelRoom()
        {

            /// Can create a new hotel room
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateHotelRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                HotelRoom hoRoom = new HotelRoom();
                hoRoom.HotelID = 80;
                hoRoom.RoomNumber = 77;
                hoRoom.RoomID = 81;
                hoRoom.Rate = 350;
                hoRoom.PetFriendly = true;

                HotelRoomController hotController = new HotelRoomController(context);
                await hotController.Create(hoRoom);

                var result = context.HotelRoom.FirstOrDefault(ho => ho.HotelID == hoRoom.HotelID && ho.RoomNumber == hoRoom.RoomNumber);

                Assert.Equal(hoRoom, result);
            }
        }

        [Fact]
        public async void CanDeleteRoom()
        {

            /// Can delete a hotel room
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteHotelRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                HotelRoom hoRoom = new HotelRoom();
                hoRoom.HotelID = 80;
                hoRoom.RoomNumber = 77;
                hoRoom.RoomID = 81;
                hoRoom.Rate = 350;
                hoRoom.PetFriendly = true;

                HotelRoomController hotController = new HotelRoomController(context);
                await hotController.Create(hoRoom);

                await hotController.DeleteConfirmed(hoRoom.HotelID, hoRoom.RoomNumber);

                var result = context.HotelRoom.FirstOrDefault(ho => ho.HotelID == hoRoom.HotelID && ho.RoomNumber == hoRoom.RoomNumber);

                Assert.Null( result);
            }
        }

        [Fact]
        public async void CanUpdateHotelRoom()
        {

            /// Can update an existing hotel room
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("UpdateHotelRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                HotelRoom hoRoom = new HotelRoom();
                hoRoom.HotelID = 90;
                hoRoom.RoomNumber = 87;
                hoRoom.RoomID = 81;
                hoRoom.Rate = 350;
                hoRoom.PetFriendly = true;

                HotelRoomController hotController = new HotelRoomController(context);
                await hotController.Create(hoRoom);

                HotelRoom upRoom = hoRoom;
                upRoom.HotelID = 90;
                upRoom.RoomNumber = 87;
                upRoom.RoomID = 81;
                upRoom.Rate = 250;
                upRoom.PetFriendly = true;

                await hotController.Edit(90, 87, upRoom);

                var result = await context.HotelRoom.FirstOrDefaultAsync(ho => ho.HotelID == hoRoom.HotelID && ho.RoomNumber == hoRoom.RoomNumber);

                Assert.Equal(250, result.Rate);
            }
        }

    }
}
