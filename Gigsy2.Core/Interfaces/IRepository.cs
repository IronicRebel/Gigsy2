namespace Gigsy2.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id); // Changed to Guid since you're using Guid as primary key
        Task<T> GetByLookupGuidAsync(Guid guid); // Method to find by lookup GUID
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}