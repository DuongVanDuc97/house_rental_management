using HR.DAL.Data;
using HR.DAL.Entities;
using HR.DAL.Interfaces;
using HR.DAL.Specifications;
using Microsoft.EntityFrameworkCore;

namespace HR.DAL.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
	private readonly ApplicationDbContext _context;
	private readonly DbSet<T> _dbSet;

	public GenericRepository(ApplicationDbContext context)
	{
		_context = context;
		_dbSet = _context.Set<T>();

	}
	
	public async Task<T> GetByIdAsync(int id)
	{
		return await _dbSet.FindAsync(id);
	}

	public async Task<List<T>> ListAllAsync()
	{
		return await _dbSet.ToListAsync();
	}

	public async Task<T> AddAsync(T entity)
	{
		var addedEntity = (await _dbSet.AddAsync(entity)).Entity;
		await _context.SaveChangesAsync();

		return addedEntity;
	}

	public async Task AddRangeAsync(List<T> entities)
	{
		await _context.AddRangeAsync(entities);
		await _context.SaveChangesAsync();
	}

	public async Task<bool> Exists(int id)
	{
		var entity = await GetByIdAsync(id);
		return entity != null;
	}


	public async Task DeleteAsync(int id)
	{
		var entity = await GetByIdAsync(id);
		_dbSet.Remove(entity);
		await _context.SaveChangesAsync();
	}
	
	public async Task<T> UpdateAsync(T entity)
	{
		_dbSet.Update(entity);
		_context.Entry(entity).State = EntityState.Modified;
		await _context.SaveChangesAsync();

		return entity;
	}
	
	public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
	{
		return await ApplySpecification(spec).FirstOrDefaultAsync();
	}
	
	public async Task<List<T>> ListAsync(ISpecification<T> spec)
	{
		return await ApplySpecification(spec).ToListAsync();
	}
	
	public async Task<int> CountAsync(ISpecification<T> spec)
	{
		return await ApplySpecification(spec).CountAsync();
	}
	
	private IQueryable<T> ApplySpecification(ISpecification<T> spec)
	{
		return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
	}
}