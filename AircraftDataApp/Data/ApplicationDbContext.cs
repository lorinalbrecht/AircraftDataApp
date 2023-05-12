using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AircraftDataApp.Models;

namespace AircraftDataApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AircraftDataApp.Models.Aircraft>? Aircraft { get; set; }
        public DbSet<AircraftDataApp.Models.Airline>? Airline { get; set; }
        public DbSet<AircraftDataApp.Models.AircraftType>? AircraftType { get; set; }
        public DbSet<AircraftDataApp.Models.Airport>? Airport { get; set; }
        public DbSet<AircraftDataApp.Models.Aircraft_Airport>? Aircraft_Airport { get; set; }
    }
}