using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MyBlog.Application.Bases;
using MyBlog.Application.Enums;
using MyBlog.Application.Exceptions;
using MyBlog.Application.Extensions;
using MyBlog.Application.Models;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
		private readonly ILogger<LoggingMiddleware> logger;
		private readonly IHttpContextAccessor accessor;

		public ExceptionMiddleware(ILogger<LoggingMiddleware> logger,IHttpContextAccessor accessor)
        {
			this.logger = logger;
			this.accessor = accessor;
		}
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            ExceptionModel exceptionModel = new();
            HttpStatus status = GetStatusCode(ex);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            if (ex.GetType() == typeof(ValidationException))
            {
                IEnumerable<string>? validationException = ((ValidationException)ex).Errors.Select(m => m.ErrorMessage);
                exceptionModel = new ExceptionModel()
                {
                    ValidationErrors = validationException.ToList(),
                    Status = HttpStatus.UnprocessableEntity,
                    Detail = ex.InnerException?.ToString() ?? string.Empty,
                    StackTrace = ex.StackTrace??string.Empty,
                    Message = ex.Message
                };
            }
            exceptionModel= new ExceptionModel()
			{
				Status = status,
				Detail = ex.InnerException?.ToString() ?? string.Empty,
				StackTrace = ex.StackTrace ?? string.Empty,
				Message = ex.Message
			};
            LogModel log = LogModel(context, exceptionModel);
			logger.LogError(log.ToString());
            return context.Response.WriteAsync(exceptionModel.ToString());
        }

        private static HttpStatus GetStatusCode(Exception exception) =>
            exception switch
            {
                BaseException => HttpStatus.InternalServerError,
                BadRequestException => HttpStatus.BadRequest,
                NotFoundException => HttpStatus.NotFound,
                ValidationException => HttpStatus.UnprocessableEntity,
                _ => HttpStatus.InternalServerError
            };


        private LogModel LogModel(HttpContext context,ExceptionModel exceptionModel)
        {
            string request= context.Request.Serialize();
            return new LogModel(context.Response.StatusCode, context.Request?.Method, context.Request?.Path.Value, accessor.GetUserId(), accessor.GetIpAddress(), accessor.GetNickname(), exceptionModel.ToString(), request);
        }

    }
}
