using CarRental.Models;

namespace CarRental.Repositories
{
    public interface IRentersRepository
    {
        Task<IEnumerable<Renter>> GetAllRenters();
        Task<Renter> GetSingleRenter(int id);
        Task CreateRenter(Renter car);
        Task UpdateRenter(Renter car);
        Task DeleteRenter(int id);

    }
}
