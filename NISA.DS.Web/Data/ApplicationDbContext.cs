using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NISA.DS.Entities;
using NISA.DS.Web.Models.Rockets;
using NISA.DS.Web.Models.Astronauts;
using NISA.DS.Web.Models.TripTypes;
using Microsoft.AspNetCore.Identity;

namespace NISA.DS.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
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

    }
}