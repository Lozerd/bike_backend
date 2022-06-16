using bike_backend.Interfaces;
using bike_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace bike_backend.Databases.Repositories;

public class BikeRepository : IBikeRepository
{
    private readonly MySqlDbContext _context;

    public BikeRepository(MySqlDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Bike>> GetAllBikes()
    {
        return await _context.Bikes.ToListAsync();
    }

    public async Task<Bike> CreateBike(Bike bike)
    {
        var bikeResult = await _context.Bikes.AddAsync(bike);
        await _context.SaveChangesAsync();
        return bikeResult.Entity;
    }

    public async Task<Bike> GetBike(int bikeId)
    {
        return await _context.Bikes.FirstOrDefaultAsync(b => b.Id == bikeId) ?? new Bike();
    }

    public async Task<Bike> UpdateBike(Bike bike)
    {
        var bikeResult = await _context.Bikes.FirstOrDefaultAsync(b => b.Id == b.Id);

        if (bikeResult != null)
        {
            var fields = bikeResult.GetType().GetProperties();
            foreach (var property in fields)
            {
                property.SetValue(bikeResult, property.GetValue(bike));
            }

            await _context.SaveChangesAsync();
            return bikeResult;
        }

        return bike;
    }

    public async void DeleteBike(int bikeId)
    {
        var bikeResult = await _context.Bikes.FirstOrDefaultAsync(b => b.Id == bikeId);
        if (bikeResult != null)
        {
            _context.Bikes.Remove(bikeResult);
            await _context.SaveChangesAsync();
        }
    }
}