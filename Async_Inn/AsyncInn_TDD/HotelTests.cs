using System;
using Xunit;
using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Models.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn_TDD
{
    public class HotelTests
    {


        [Fact]
        public void GetHotelName()
        {
            Hotel hotel = new Hotel();
            hotel.ID = 3;
            hotel.Name = "Sea-Town";
            hotel.Address = "456";
            hotel.Phone = "206-777-7777";

            Assert.Equal("Sea-Town", hotel.Name);
        }
        [Fact]
        public void GetHotelID()
        {
            Hotel hotel = new Hotel();
            hotel.ID = 3;
            hotel.Name = "Sea-Town";
            hotel.Address = "456";
            hotel.Phone = "206-777-7777";

            Assert.Equal(3, hotel.ID);
        }
        [Fact]
        public void GetHotelAddress()
        {
            Hotel hotel = new Hotel();
            hotel.ID = 3;
            hotel.Name = "Sea-Town";
            hotel.Address = "456";
            hotel.Phone = "206-777-7777";

            Assert.Equal("456", hotel.Address);
        }
        [Fact]
        public void GetHotelPhone()
        {
            Hotel hotel = new Hotel();
            hotel.ID = 3;
            hotel.Name = "Sea-Town";
            hotel.Address = "456";
            hotel.Phone = "206-777-7777";

            Assert.Equal("206-777-7777", hotel.Phone);
        }
        [Fact]
        public async void CanCreateHotel()
        {

            /// Can create a new hotel
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.ID = 3;
                hotel.Name = "Sea-Town";
                hotel.Address = "456";
                hotel.Phone = "206-777-7777";

                HotelManagementServices hotelServices = new HotelManagementServices(context);
                await hotelServices.CreateHotel(hotel);

                var result = context.Hotel.FirstOrDefault(ho => ho.ID == hotel.ID);

                Assert.Equal(hotel, result);
            }
        }
        [Fact]
        public async void CanDeleteHotel()
        {
            /// can delete an existing hotel
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.ID = 3;
                hotel.Name = "Sea-Town";
                hotel.Address = "456";
                hotel.Phone = "206-777-7777";

                HotelManagementServices hotelServices = new HotelManagementServices(context);
                await hotelServices.CreateHotel(hotel);

                await hotelServices.DeleteHotel(hotel.ID);

                var result = context.Hotel.FirstOrDefault(ho => ho.ID == hotel.ID);

                Assert.Null(result);
            }

        }

        [Fact]
        public async void CanEditHotel()
        {
            /// Can update an existing hotel
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.ID = 3;
                hotel.Name = "Sea-Town";
                hotel.Address = "456";
                hotel.Phone = "206-777-7777";

                HotelManagementServices hotelServices = new HotelManagementServices(context);
                await hotelServices.CreateHotel(hotel);

                Hotel newHotel = await hotelServices.GetHotels(hotel.ID);
                newHotel.Name = "Chi-Town";
                await hotelServices.UpdateHotel(newHotel);

                var result = context.Hotel.FirstOrDefault(ho => ho.ID == hotel.ID);

                Assert.Equal("Chi-Town", result.Name);
            }

        }
    }
}
