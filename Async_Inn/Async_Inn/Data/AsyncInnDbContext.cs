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
            ///modelBuilder.Entity<>

          /// modelBuilder.Entity<CourseEnrollments>().HasKey(ce => new { ce.CourseID, ce.StudentID });

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
