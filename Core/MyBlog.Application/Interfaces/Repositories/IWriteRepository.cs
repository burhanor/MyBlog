using Microsoft.EntityFrameworkCore.Query;
using MyBlog.Domain.Commons;
using System.Linq.Expressions;

namespace MyBlog.Application.Interfaces.Repositories
{
	public interface IWriteRepository<T> where T : class, IEntityBase, new()
	{
		Task AddAsync(T entity, CancellationToken cancellationToken);
		Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
		Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
		Task BulkUpdateAsync(Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCall, Expression<Func<T, bool>>? predicate = null);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity, CancellationToken cancellationToken);
		Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
		Task DeleteAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
	}
}
