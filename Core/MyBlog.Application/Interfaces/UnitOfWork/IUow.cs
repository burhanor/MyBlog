using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Interfaces.Repositories;
using MyBlog.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Interfaces.UnitOfWork
{
	public interface IUow:IAsyncDisposable
	{
		IReadRepository<T> GetReadRepository<T>() where T:class,IEntityBase,new();
		IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();
		Task BeginTransactionAsync(CancellationToken cancellationToken = default);
		Task CommitTransactionAsync(CancellationToken cancellationToken = default);
		Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
		int SaveChanges();
	}
}
