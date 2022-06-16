using bike_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace bike_backend.Databases;

public class MySqlDbContext : DbContext
{
    public DbSet<Bike> Bikes { get; set; }
    public DbSet<BikeType> BikeTypes { get; set; }

    public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
    {
    }
}