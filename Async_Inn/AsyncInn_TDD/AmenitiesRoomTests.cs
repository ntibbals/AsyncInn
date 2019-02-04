using System;
using Xunit;
using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Models.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Async_Inn.Controllers;

namespace AsyncInn_TDD
{
    public class AmenitiesRoomTests
    {
        [Fact]
        public void GetAmenitiesID()
        {
            // get amenities ID number
            RoomAmenities amenRoom = new RoomAmenities();
            amenRoom.AmenitiesID = 3;
            amenRoom.RoomID = 23;

            Assert.Equal(3, amenRoom.AmenitiesID);
        }

        [Fact]
        public void GetAmenitiesRoomID()
        {
            /// can get amenities room id
            RoomAmenities amenRoom = new RoomAmenities();
            amenRoom.AmenitiesID = 3;
            amenRoom.RoomID = 23;

            Assert.Equal(23, amenRoom.RoomID);
        }

        [Fact]
        public async void CanCreateRoomAmenities()
        {

            /// Can create a new room amenity
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateRoomAmenities").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                RoomAmenities amenRoom = new RoomAmenities();
                amenRoom.AmenitiesID = 3;
                amenRoom.RoomID = 23;

                RoomAmenitiesController amenController = new RoomAmenitiesController(context);
                await amenController.Create(amenRoom);

                var result = context.RoomAmenities.FirstOrDefault(ho => ho.AmenitiesID == amenRoom.AmenitiesID && ho.RoomID == amenRoom.RoomID);

                Assert.Equal(amenRoom, result);
            }
        }

        [Fact]
        public async void CanDeleteRoomAmenity()
        {

            /// Can delete a room amenity
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteRoomAmenities").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                RoomAmenities amenRoom = new RoomAmenities();
                amenRoom.AmenitiesID = 3;
                amenRoom.RoomID = 23;

                RoomAmenities amenRoom2 = new RoomAmenities();
                amenRoom2.AmenitiesID = 33;
                amenRoom2.RoomID = 53;


                RoomAmenitiesController amenController = new RoomAmenitiesController(context);
                await amenController.Create(amenRoom);


                await amenController.Delete2(amenRoom);

                var result = context.RoomAmenities.FirstOrDefault(ho => ho.AmenitiesID == 3  && ho.RoomID == 23);

                Assert.Null(result);
            }
        }


    }
}
