using System.Linq.Expressions;

namespace LMS_DATA_SERVICE.IRepository;

public interface IGenericRepository<T> where T : class
{
	// Get all entities
	Task<IEnumerable<T>> All();

	// Get specific  entity based on Id
	Task<T> GetById(Guid id);

	// Add a new entity
	Task<bool> Add(T entity);

	// Delete an entity
	Task<bool> Delete(Guid id, string userId);

	// Update an entity or add if it does not exist
	Task<bool> Upsert(T entity);

	void Include(Expression<Func<T, object>> navigationProperty);
}
