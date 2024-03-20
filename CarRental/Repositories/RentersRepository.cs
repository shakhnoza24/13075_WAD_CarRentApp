using CarRental.Data;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repositories
{
    public class CarsRepository : ICarsRepository

    {
        private readonly CarRentalDbContext _dbContext;

        public CarsRepository(CarRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Car>> GetAllCars()
        {
            var cars = await _dbContext.Cars.ToListAsync();
            return cars;
        }

        public async Task<Car> GetSingleCar(int id)
        {
            return await _dbContext.Cars.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task CreateCar(Car car)
        {
            await _dbContext.Cars.AddAsync(car);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCar(int id)
        {
            var car = await _dbContext.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (car != null)
            {
                _dbContext.Cars.Remove(car);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateCar(Car car)
        {
            _dbContext.Entry(car).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
