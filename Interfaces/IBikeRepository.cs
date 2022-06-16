using bike_backend.Models;

namespace bike_backend.Interfaces;

public interface IBikeRepository
{
    public Task<IEnumerable<Bike>> GetAllBikes();
    public Task<Bike> CreateBike(Bike bike);
    public Task<Bike> GetBike(int bikeId);
    public Task<Bike> UpdateBike(Bike bike);
    public void DeleteBike(int bikeId);
}