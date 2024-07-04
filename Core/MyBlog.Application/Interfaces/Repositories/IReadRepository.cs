using Microsoft.EntityFrameworkCore.Query;
using MyBlog.Domain.Commons;
using System.Linq.Expressions;

namespace MyBlog.Application.Interfaces.Repositories
{
	public interface IReadRepository<T> where T : class, IEntityBase, new()
	{
		IQueryable<T> GetQuery(Expression<Func<T, bool>>? predicate = null, bool enableTracking = false);
		Task<TType> GetAsync<TType>(Expression<Func<T, TType>> select, Expression<Func<T, bool>> predicate, bool enableTracking = false, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, CancellationToken cancellationToken = default) where TType : class, new();
		Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool enableTracking = false, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, CancellationToken cancellationToken = default);

		Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, bool enableTracking = false, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, int? currentPage = null, int? pageSize = null, CancellationToken cancellationToken = default);
		Task<IList<TType>> GetAllAsyncAs<TType>(Expression<Func<T, TType>> select, Expression<Func<T, bool>>? predicate = null, bool enableTracking = false, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, int? currentPage = null, int? pageSize = null, CancellationToken cancellationToken = default);
		Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default);
		Task<long> LongCountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default);
		Task<bool> ExistAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
		Task<bool> UniqueAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

	}
}
