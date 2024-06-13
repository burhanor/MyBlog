using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
	public class WriteRepository<T>(DbContext dbContext):IWriteRepository<T> where T : class, IEntityBase, new()
	{
		private DbSet<T> Table { get=>dbContext.Set<T>();}
		public async Task AddAsync(T entity, CancellationToken cancellationToken) => await Table.AddAsync(entity, cancellationToken);
		public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken) => await Table.AddRangeAsync(entities, cancellationToken);

		public async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken) => await Task.Run(() => Table.UpdateRange(entities), cancellationToken);
		public async Task BulkUpdateAsync(Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCall, Expression<Func<T, bool>>? predicate = null) => _ = predicate == null ? await Table.ExecuteUpdateAsync(setPropertyCall) : await Table.Where(predicate).ExecuteUpdateAsync(setPropertyCall);
		public async Task UpdateAsync(T entity)
		{
			EntityEntry<T> entry = dbContext.Entry(entity);
			if (entry.State == EntityState.Detached)
				Table.Attach(entity);
			entry.State = EntityState.Modified;
			await Task.CompletedTask;
		}
		public async Task DeleteAsync(T entity, CancellationToken cancellationToken) => await Task.Run(() => Table.Remove(entity),cancellationToken);
		public async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken) => await Task.Run(() => Table.RemoveRange(entities),cancellationToken);
		public async Task DeleteAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) => await Table.Where(predicate).ExecuteDeleteAsync(cancellationToken: cancellationToken);
	
	}
}
