using VehicleData.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace VehicleData.Infrastructure.Context
{
    public class VehicleStoreDbContext : DbContext
    {
        public VehicleStoreDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }
        
    }
}
