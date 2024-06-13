using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Application.Interfaces.Repositories;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Persistence.Contexts;
using MyBlog.Persistence.Repositories;
using MyBlog.Persistence.UnitOfWork;

namespace MyBlog.Persistence
{
	public static class Registration
	{
		public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<BlogDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("MSSQLConnection"));
			});
			services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
			services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
			services.AddScoped<IUow, Uow>();

		}
	}
}
