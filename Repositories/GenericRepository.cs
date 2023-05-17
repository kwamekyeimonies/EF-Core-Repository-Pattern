using Formula.App.Core;
using Formula.App.Database;
using Microsoft.EntityFrameworkCore;

namespace Formula.App.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApiDbContext? _context;
        internal DbSet<T>? _dbSet;
        protected readonly ILogger? _logger;

        public GenericRepository(ApiDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            this._dbSet = _context.Set<T>();
        }
        public virtual async Task<bool> AddByAsync(T entity)
        {
            await _dbSet.AddAsync(entity);

            return true;
        }

        public virtual async Task<IEnumerable<T>> AllByAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<bool> DeleteByAsync(T entity)
        {
            _dbSet.Remove(entity);
            return true;
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<bool> UpdateByAsync(T entity)
        {
            _dbSet.Update(entity);

            return true;
        }
    }
}