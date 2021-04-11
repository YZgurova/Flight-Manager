using Flight_Manager.Data.Models;
using Flight_Manager.Models.Flights;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Manager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
       // internal IList<FlightViewModel> Flights;
        public DbSet<Flight> Flights { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Flight>(flight =>
            {
                flight.HasMany(f => f.Reservations)
                .WithOne(r => r.Flight)
                .HasForeignKey(r => r.FlightId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            base.OnModelCreating(builder);
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
