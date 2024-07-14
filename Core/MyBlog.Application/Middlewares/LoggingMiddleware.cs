using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MyBlog.Application.Extensions;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyBlog.Application.Middlewares
{
	public class LoggingMiddleware : IMiddleware
	{
		//private readonly RequestDelegate _next;
		private readonly ILogger<LoggingMiddleware> _logger;
		private readonly IHttpContextAccessor httpContextAccessor;

		public LoggingMiddleware( ILogger<LoggingMiddleware> logger,IHttpContextAccessor httpContextAccessor)
		{
			
			_logger = logger;
			this.httpContextAccessor = httpContextAccessor;
		}
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			var originalBodyStream = context.Response.Body;
			using var responseBody = new MemoryStream();
			context.Response.Body = responseBody;
		
			await next(context);

			context.Response.Body.Seek(0, SeekOrigin.Begin);
			string? responseLog =  await new StreamReader(context.Response.Body).ReadToEndAsync();

			string? requestLog = context.Request.Serialize();
			context.Response.Body.Seek(0, SeekOrigin.Begin);
			LogModel logModel = new(context.Response.StatusCode, context.Request?.Method, context.Request?.Path.Value, httpContextAccessor.GetUserId(), httpContextAccessor.GetIpAddress(), httpContextAccessor.GetNickname(), responseLog, requestLog);

			Log(logModel);
			await responseBody.CopyToAsync(originalBodyStream);
		}

		private void Log(LogModel log)
		{
			
			_logger.Log(GetLogType(log.StatusCode), log.ToString());
		}

		private LogLevel GetLogType(int statusCode)
		{
			LogLevel logLevel = LogLevel.Information;
			switch (statusCode)
			{
				case 200:
					break;
				case 201:
					break;
				case 401:
					logLevel=LogLevel.Error;
					break;
				case 403:
					logLevel = LogLevel.Warning;
					break;
				default:
					break;
			}
			return logLevel;
		}

	
	}
}
