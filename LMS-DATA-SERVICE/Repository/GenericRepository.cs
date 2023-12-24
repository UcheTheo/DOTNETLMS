using System.Linq.Expressions;
using LMS_DATA_SERVICE.Data;
using LMS_DATA_SERVICE.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LMS_DATA_SERVICE.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
	protected LMSDbContext _context;
	internal DbSet<T> dbSet;
	protected readonly ILogger _logger;

	public GenericRepository(LMSDbContext context,  ILogger logger)
	{
		_context = context;
		dbSet = context.Set<T>();
		_logger = logger;
	}

	public virtual async Task<IEnumerable<T>> All()
	{
		return await dbSet.ToListAsync();
	}

	public async Task<T> GetById(Guid id)
	{
		return await dbSet.FindAsync(id);
	}

	public async Task<bool> Add(T entity)
	{
		await dbSet.AddAsync(entity);
		return true;
	}

	public Task<bool> Delete(Guid id, string userId)
	{
		throw new NotImplementedException();
	}

	public Task<bool> Upsert(T entity)
	{
		throw new NotImplementedException();
	}

	public void Include(Expression<Func<T, object>> navigationProperty)
	{
		dbSet.Include(navigationProperty);
	}

}
