using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class MyDatabaseContext : DbContext
    {
        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<FlightData>().Property(d => d.FlightId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //modelBuilder.Entity<FlightData>().HasKey(e => new { e.FlightId });
            //modelBuilder.Entity<FlightData>().Property(a => a.FlightId).ValueGeneratedNever();
            //modelBuilder.Entity<FlightBookingDetail>().Property(a => a.FlightId).ValueGeneratedNever();
            //modelBuilder.Entity<FlightData>(builder => 
            //{
            //    builder.HasNoKey();
            //    builder.ToTable("FlightData");
            //});
            //modelBuilder.Entity<FlightBookingDetail>(builder =>
            //{
            //    builder.HasNoKey();
            //    builder.ToTable("FlightBookingDetail");
            //});

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<FlightData> FlightDetails { get; set; }
        public DbSet<FlightBookingDetail> FlightBookingDetail { get; set; }

    }
}
