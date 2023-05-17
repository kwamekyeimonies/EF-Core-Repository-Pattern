namespace Formula.App.Core
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> AllByAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<bool> AddByAsync(T entity);
        Task<bool> UpdateByAsync(T entity);
        Task<bool> DeleteByAsync(T entity);
    }
}