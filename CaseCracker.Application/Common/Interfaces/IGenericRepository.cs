namespace CaseCracker.Application.Common.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    IQueryable<T> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity, params string[] excludeProperties);
    Task DeleteAsync(T entity);
}