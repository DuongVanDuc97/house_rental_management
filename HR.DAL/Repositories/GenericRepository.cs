using HR.DAL.Data;
using HR.DAL.Entities;
using HR.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HR.DAL.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
	private readonly ApplicationDbContext _context;

	public GenericRepository(ApplicationDbContext context)
	{
		_context = context;
	}
	
	public async Task<T> GetByIdAsync(int id)
	{
		return await _context.Set<T>().FindAsync(id);
	}

	public async Task<IReadOnlyList<T>> ListAllAsync()
	{
		return await _context.Set<T>().ToListAsync();
	}

	public void Add(T entity)
	{
		_context.Set<T>().Add(entity);
	}

	public void Update(T entity)
	{
		_context.Set<T>().Attach(entity);
		_context.Entry(entity).State = EntityState.Modified;
	}

	public void Delete(T entity)
	{
		_context.Set<T>().Remove(entity);
	}
}