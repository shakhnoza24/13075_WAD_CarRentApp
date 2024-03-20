using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Data
{
    public class CarRentalDbContext : DbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Renter> Renters { get; set; }
    }
}
