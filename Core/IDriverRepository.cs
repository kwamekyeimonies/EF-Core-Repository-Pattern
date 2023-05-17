using Formula.App.Models;

namespace Formula.App.Core{
    public interface IDriverRepository : IGenericRepository<Driver>
    {
        Task<Driver?> GetDriverId(Guid driverId);
    }
}