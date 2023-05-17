using Formula.App.Database;
using Formula.App.Models;
using Formula.App.Core;
using Microsoft.EntityFrameworkCore;

namespace Formula.App.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(ApiDbContext context, ILogger logger) : base(context, logger)
        {

        }

        public override async Task<IEnumerable<Driver>> AllByAsync()
        {
            try
            {
                return await _context.Drivers.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Driver?> GetDriverId(Guid driverId)
        {
            try
            {
                return await _context.Drivers.AsNoTracking().FirstOrDefaultAsync(dx => dx.DriverNumber == driverId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}