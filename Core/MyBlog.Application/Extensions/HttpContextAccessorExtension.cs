using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Extensions
{
	public static class HttpContextAccessorExtension
	{

		public static int GetUserId(this IHttpContextAccessor accessor) 
		{
			if (accessor.HttpContext!=null && accessor.HttpContext.User.Identity != null)
				return accessor.HttpContext.User.Identity.IsAuthenticated ? Convert.ToInt32(accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value) : 0;
			return 0;
		}
		public static string GetIpAddress(this IHttpContextAccessor accessor)
		{
			return accessor.HttpContext?.Connection.RemoteIpAddress?.ToString()??string.Empty;
		}
		public static string GetNickname(this IHttpContextAccessor accessor)
		{
			return accessor.HttpContext?.User.Identity?.Name??string.Empty;
		}
	}
}
