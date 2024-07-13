using Microsoft.AspNetCore.Builder;
using MyBlog.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Middlewares
{
	public static class ConfigureMiddleware
	{
		public static void ConfigureMiddlewares(this IApplicationBuilder app)
		{
			app.UseMiddleware<ExceptionMiddleware>();
			app.UseMiddleware<LoggingMiddleware>();
		}

	}
}
