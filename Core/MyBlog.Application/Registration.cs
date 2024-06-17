using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Application.Bases;
using MyBlog.Application.Behaviors;
using MyBlog.Application.Exceptions;
using MyBlog.Application.Helpers;
using System.Reflection;

namespace MyBlog.Application
{
	public static class Registration
	{

		public static void AddApplicationLayer(this IServiceCollection services)
		{
			Assembly assembly = Assembly.GetExecutingAssembly();	
			services.AddTransient<ExceptionMiddleware>();
			services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(assembly));
			services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));
			services.AddValidatorsFromAssembly(assembly);
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
			services.AddScoped<ImageHelper, ImageHelper>();
		}

		private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services, Assembly assembly, Type type)
		{
			var types = assembly.GetTypes().Where(t => t != type && t.IsSubclassOf(type)).ToList();
			foreach (var t in types)
			{
				services.AddTransient(t);
			}
			return services;
		}

	}
}
