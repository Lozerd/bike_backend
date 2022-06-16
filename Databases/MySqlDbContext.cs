using bike_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;

namespace bike_backend.Databases;

public class MySqlDbContext : DbContext
{
    public DbSet<Bike> Bikes { get; set; }
    public DbSet<BikeType> BikeTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration;
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.Development.json")
                    .Build();
            }
            else
            {
                configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
            }
            
            var connectionString = configuration.GetConnectionString("MySqlContext");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            // optionsBuilder.UseMySql(ServerVersion.AutoDetect(connectionString));
        }
    }

    public MySqlDbContext()
    {
        
    }
    public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
    {
    }
}