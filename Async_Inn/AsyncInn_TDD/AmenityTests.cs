using System;
using Xunit;
using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Models.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn_TDD
{
    public class AmenityTests
    {

        [Fact]
        public void GetAmenityName()
        {
            Amenities amen = new Amenities();
            amen.ID = 70;
            amen.Name = "Poker";


            Assert.Equal("Poker", amen.Name);
        }
        [Fact]
        public void GetAmenityID()
        {
            Amenities amen = new Amenities();
            amen.ID = 71;
            amen.Name = "Poker";


            Assert.Equal(71, amen.ID);
        }
    

    [Fact]
    public async void CanCreateAmenity()
    {
            /// Can create a new amenity
        DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateAemnity").Options;

        using (AsyncInnDbContext context = new AsyncInnDbContext(options))
        {
            Amenities amen = new Amenities();
            amen.ID = 72;
            amen.Name = "Poker";

            AmenitiesManagementServices amenServices = new AmenitiesManagementServices(context);
            await amenServices.CreateAmenity(amen);

            var result = context.Amenities.FirstOrDefault(ho => ho.ID == amen.ID);

            Assert.Equal(amen, result);
        }

    }
        [Fact]
        public async void CanDeleteAmenity()
        {

            /// can delete an existing amenity
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteAemnity").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities amen = new Amenities();
                amen.ID = 72;
                amen.Name = "Poker";

                AmenitiesManagementServices amenServices = new AmenitiesManagementServices(context);
                await amenServices.CreateAmenity(amen);
                await amenServices.DeleteAmenity(amen.ID);

                var result = context.Amenities.FirstOrDefault(ho => ho.ID == amen.ID);

                Assert.Null(result);
            }

        }
        [Fact]
        public async void CanEdiAmenity()
        {
            /// Can edit an existing amenity
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("UpdateAemnity").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities amen = new Amenities();
                amen.ID = 72;
                amen.Name = "Poker";

                AmenitiesManagementServices amenServices = new AmenitiesManagementServices(context);
                await amenServices.CreateAmenity(amen);

                Amenities upAmen = await amenServices.GetAmenities(amen.ID);
                upAmen.Name = "Black-jack";

                await amenServices.UpdateAmenity(upAmen);

                var result = context.Amenities.FirstOrDefault(ho => ho.ID == amen.ID);

                Assert.Equal("Black-jack", result.Name);
            }

        }
    }
}
