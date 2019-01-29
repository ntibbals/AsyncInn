using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options): base(options)
        {

        }

        /// <summary>
        /// While creating model, able to set key creations, informaiton you need to know about while db is being constructed
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRoom>().HasKey(hr => new { hr.HotelID, hr.RoomNumber });
            modelBuilder.Entity<RoomAmenities>().HasKey(ra => new { ra.AmenitiesID, ra.RoomID });

            /// modelBuilder.Entity<CourseEnrollments>().HasKey(ce => new { ce.CourseID, ce.StudentID });
            modelBuilder.Entity<Amenities>().HasData(
                new Amenities
                {
                    ID = 1,
                    Name = "Pool"
                },
                new Amenities
                {
                    ID = 2,
                    Name = "Continental Breakfast"
                },
                new Amenities
                {
                    ID = 3,
                    Name = "Valet"
                },
                new Amenities
                {
                    ID = 4,
                    Name = "Open Bar"
                },
                new Amenities
                {
                    ID = 5,
                    Name = "Hot Tub"
                }
                );
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 10,
                    Name = "Queene Anne",
                    Address = "215",
                    Phone = "999-999-9999"
                },
                new Hotel
                {
                    ID = 11,
                    Name = "Ballard",
                    Address = "315",
                    Phone = "888-888-8888"
                },
                new Hotel
                {
                    ID = 12,
                    Name = "Cap City",
                    Address = "415",
                    Phone = "777-777-7777"
                },
                new Hotel
                {
                    ID = 13,
                    Name = "Sodo",
                    Address = "515",
                    Phone = "666-666-6666"
                },
                new Hotel
                {
                    ID = 14,
                    Name = "Fremont",
                    Address = "615",
                    Phone = "555-555-5555"
                }
            );
            modelBuilder.Entity<Room>().HasData(
            new Room
            {
                ID = 21,
                Name = "Bowie",
                Layout = Layouts.OneBedroom
            },
            new Room
            {
                ID = 31,
                Name = "Freddy",
                Layout = Layouts.Studio
            },
            new Room
            {
                ID = 41,
                Name = "Elton",
                Layout = Layouts.TwoBedroom
            },
                        new Room
            {
                ID = 51,
                Name = "Queen",
                Layout = Layouts.OneBedroom
            },
            new Room
            {
                ID = 61,
                Name = "Stix",
                Layout = Layouts.Studio
            },
            new Room
            {
                ID = 71,
                Name = "Zeplin",
                Layout = Layouts.TwoBedroom
            }
            );


        }
        /// Tables
        /// utilizes db set, ensure public creates tables in database
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<HotelRoom> HotelRoom{ get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }


    }
}
