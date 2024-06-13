using Microsoft.Extensions.DependencyInjection;
using MyBlog.Application.Interfaces.AutoMapper;

namespace MyBlog.Mapper
{
	public static class Registration
	{
		public static void AddMapperLayer(this IServiceCollection services)
		{
			services.AddSingleton<IMyMapper, AutoMapper.Mapper>();
		}
	}
}
