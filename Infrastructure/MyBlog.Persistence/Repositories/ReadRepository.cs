using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MyBlog.Application.Interfaces.Repositories;
using MyBlog.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Persistence.Repositories
{
	public class ReadRepository<T>(DbContext dbContext) : IReadRepository<T> where T : class, IEntityBase, new()
	{
		private readonly DbContext dbContext = dbContext;
		private DbSet<T> Table { get => dbContext.Set<T>(); }
		public IQueryable<T> GetQuery(Expression<Func<T, bool>>? predicate = null, bool enableTracking = false)
		{
			IQueryable<T> query = Table;
			if (!enableTracking)
				query = query.AsNoTracking();
			if (predicate != null)
				query = query.Where(predicate);
			return query;
		}

		public async Task<TType> GetAsync<TType> (Expression<Func<T, TType>> select, Expression<Func<T, bool>> predicate,  bool enableTracking = false, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, CancellationToken cancellationToken = default)
		where TType : class, new()
		{
			IQueryable<T> query = Table;
			if (!enableTracking)
				query = query.AsNoTracking();
			if (include != null)
				query = include(query);
			return await query.Where(predicate).Select(select).FirstOrDefaultAsync(cancellationToken)??new();
		}

		public async Task<T> GetAsync( Expression<Func<T, bool>> predicate, bool enableTracking = false, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, CancellationToken cancellationToken = default)
	
		{
			IQueryable<T> query = Table;
			if (!enableTracking)
				query = query.AsNoTracking();
			if (include != null)
				query = include(query);
			return await query.Where(predicate).FirstOrDefaultAsync(cancellationToken) ?? new();
		}

		public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, bool enableTracking = false, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, int? currentPage = null, int? pageSize = null, CancellationToken cancellationToken = default)
		{
			IQueryable<T> query = Table;
			if (!enableTracking)
				query = query.AsNoTracking();
			if (predicate != null)
				query = query.Where(predicate);
			if (include != null)
				query = include(query);
			if (orderBy != null)
				query = orderBy(query);
			if (currentPage.HasValue && pageSize.HasValue)
				query = query.Skip((currentPage.Value - 1) * pageSize.Value).Take(pageSize.Value);
			return await query.ToListAsync(cancellationToken);
		}
		public async Task<IList<TType>> GetAllAsyncAs<TType>(Expression<Func<T, TType>> select, Expression<Func<T, bool>>? predicate = null, bool enableTracking = false, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, int? currentPage = null, int? pageSize = null, CancellationToken cancellationToken = default)
		{
			IQueryable<T> query = Table;
			if (!enableTracking)
				query = query.AsNoTracking();
			if (predicate != null)
				query = query.Where(predicate);
			if (include != null)
				query = include(query);
			if (orderBy != null)
				query = orderBy(query);
			if (currentPage.HasValue && pageSize.HasValue)
				query = query.Skip((currentPage.Value - 1) * pageSize.Value).Take(pageSize.Value);
			return await query.Select(select).ToListAsync(cancellationToken);
		}

		public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default) => predicate == null ? await Table.CountAsync(cancellationToken) : await Table.CountAsync(predicate, cancellationToken);
		public async Task<long> LongCountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default) => predicate == null ? await Table.LongCountAsync(cancellationToken) : await Table.LongCountAsync(predicate, cancellationToken);

		public async Task<bool> ExistAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) => await Table.AnyAsync(predicate, cancellationToken);

		public async Task<bool> UniqueAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) => !await ExistAsync(predicate, cancellationToken);

	}
}
