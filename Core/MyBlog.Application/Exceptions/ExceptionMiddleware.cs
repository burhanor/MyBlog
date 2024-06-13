using FluentValidation;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Enums;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions
{
	public class ExceptionMiddleware : IMiddleware
	{
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
			HttpStatus status = GetStatusCode(ex);
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)status;
			if (ex.GetType()==typeof(ValidationException))
			{
				IEnumerable<string>? validationException = ((ValidationException)ex).Errors.Select(m => m.ErrorMessage);
				return context.Response.WriteAsync(new ExceptionModel()
				{
					ValidationErrors = validationException.ToList(),
					Status = HttpStatus.UnprocessableEntity,
					Detail = ex.InnerException?.ToString() ?? "",
					Message = ex.Message
				}.ToString());
			}
			return context.Response.WriteAsync(new ExceptionModel()
			{
				Status = status,
				Detail = ex.InnerException?.ToString() ?? "",
				Message = ex.Message
			}.ToString());
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

	}
}
