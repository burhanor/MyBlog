using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions
{
	public class ExceptionMiddleware : IMiddleware
	{
		public Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			throw new NotImplementedException();
		}
	}
}
