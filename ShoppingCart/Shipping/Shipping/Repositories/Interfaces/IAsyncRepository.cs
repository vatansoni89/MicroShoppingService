namespace Shipping.Repositories.Interfaces
{
    public interface IAsyncRepository<T>
    {
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
