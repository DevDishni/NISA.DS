using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NISA.DS.Entities;
using NISA.DS.Web.Models.Rockets;
using NISA.DS.Web.Models.Astronauts;

namespace NISA.DS.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Astronaut> Astronauts { get; set; }
        public DbSet<Rocket> Rockets { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<TripType> TripTypes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<NISA.DS.Web.Models.Rockets.RocketListViewModel>? RocketListViewModel { get; set; }
        public DbSet<NISA.DS.Web.Models.Astronauts.AstronautListViewModel>? AstronautListViewModel { get; set; }
    }
}