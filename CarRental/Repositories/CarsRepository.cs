using CarRental.Data;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Repositories
{
    public class RentersRepository : IRentersRepository

    {
        private readonly CarRentalDbContext _dbContext;

        public RentersRepository(CarRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Renter>> GetAllRenters()
        {
            var renters = await _dbContext.Renters.ToListAsync();
            return renters;
        }

        public async Task<Renter> GetSingleRenter(int id)
        {
            return await _dbContext.Renters.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task CreateRenter(Renter renter)
        {
            await _dbContext.Renters.AddAsync(renter);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRenter(int id)
        {
            var renter = await _dbContext.Renters.FirstOrDefaultAsync(r => r.Id == id);
            if (renter != null)
            {
                _dbContext.Renters.Remove(renter);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateRenter(Renter renter)
        {
            _dbContext.Entry(renter).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
