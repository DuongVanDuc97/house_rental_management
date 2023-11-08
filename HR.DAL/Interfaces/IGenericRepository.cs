using HR.DAL.Entities;
using HR.DAL.Specifications;

namespace HR.DAL.Interfaces;

public interface IGenericRepository<T> where T : class
{
	Task<T> GetByIdAsync(int id);
	Task<List<T>> ListAllAsync();
	Task<T> GetEntityWithSpec(ISpecification<T> spec);
	Task<List<T>> ListAsync(ISpecification<T> spec);
	Task AddRangeAsync(List<T> entities);
	Task<int> CountAsync(ISpecification<T> spec);
	Task<bool> Exists(int id);
	Task<T> AddAsync(T entity);
	Task<T> UpdateAsync(T entity);
	Task DeleteAsync(int id);
}
