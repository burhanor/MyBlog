using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Interfaces.Functions;
using MyBlog.Application.Interfaces.Repositories;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Domain.Enums;
using MyBlog.Persistence.Contexts;
using MyBlog.Persistence.Functions;
using MyBlog.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Persistence.UnitOfWork
{
	public class Uow(BlogDbContext dbContext) : IUow
	{
		private readonly BlogDbContext dbContext = dbContext;

		public async ValueTask DisposeAsync()
		{
			await dbContext.DisposeAsync();

		}



		IReadRepository<T> IUow.GetReadRepository<T>() => new ReadRepository<T>(dbContext);
		IWriteRepository<T> IUow.GetWriteRepository<T>() => new WriteRepository<T>(dbContext);
		public async Task<int> SaveChangesAsync(CancellationToken cancellationToken) => await dbContext.SaveChangesAsync(cancellationToken);
		public int SaveChanges() => dbContext.SaveChanges();
		#region Transaction

		public async Task BeginTransactionAsync(CancellationToken cancellationToken = default) => await dbContext.Database.BeginTransactionAsync(cancellationToken);
		public async Task CommitTransactionAsync(CancellationToken cancellationToken = default) => await dbContext.Database.CommitTransactionAsync(cancellationToken);
		public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default) => await dbContext.Database.RollbackTransactionAsync(cancellationToken);

		public IScalarFunction GetScalarFunction()=> new ScalarFunctions(dbContext);
		
		#endregion



	}
}
