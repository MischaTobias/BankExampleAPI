namespace Application.Interfaces.Generic;

public interface IGenericRepository<T> where T : class
{
    ValueTask<T> CreateAsync(T entity);
    ValueTask<IEnumerable<T>> GetAllAsync();
    ValueTask<T> GetByIdAsync(int id);
    ValueTask UpdateAsync(T entity);
    ValueTask DeleteAsync(T entity);
}
