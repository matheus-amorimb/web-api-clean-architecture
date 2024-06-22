using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces;

public interface IRepository<T> where T: Entity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}