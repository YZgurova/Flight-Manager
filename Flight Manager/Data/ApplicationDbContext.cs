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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
