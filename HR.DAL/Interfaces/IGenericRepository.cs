using HR.DAL.Entities;

namespace HR.DAL.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
	Task<T> GetByIdAsync(int id);
	Task<IReadOnlyList<T>> ListAllAsync();
	void Add(T entity);
	void Update(T entity);
	void Delete(T entity);
}