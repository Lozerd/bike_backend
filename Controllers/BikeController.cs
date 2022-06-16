using bike_backend.Databases;
using bike_backend.Databases.Repositories;
using bike_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bike_backend.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class BikeController : ControllerBase
    {
        private BikeRepository _bikeRepository;
        private ILogger<BikeController> _logger;


        public BikeController(ILogger<BikeController> logger)
        {
            _bikeRepository = new BikeRepository(new MySqlDbContext(new DbContextOptions<MySqlDbContext>()));
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Bike>> Get()
        {
            return await _bikeRepository.GetAllBikes();
        }

        [HttpGet("{id}", Name = "Get")]
        public Task<Bike> Get(int id)
        {
            return _bikeRepository.GetBike(id);
        }

        [HttpPost]
        public async Task<Bike> Post(Bike bike)
        {
            return await _bikeRepository.CreateBike(bike);
        }

        [HttpPut("{id}")]
        public async Task<Bike> Put(Bike bike)
        {
            return await _bikeRepository.UpdateBike(bike);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bikeRepository.DeleteBike(id);
        }
    }
}