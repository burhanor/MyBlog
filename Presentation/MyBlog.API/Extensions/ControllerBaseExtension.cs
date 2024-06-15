using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.Models;

namespace MyBlog.API.Extensions
{
	public static class ControllerBaseExtension
	{

		private static async Task<IActionResult> CreateOrUpdateAsync<TRequest, TResponse>(this ControllerBase controller, IMediator mediator, TRequest request)
		{
			if (request == null)
				return controller.NotFound();
			var response = await mediator.Send(request);
			if (response == null)
				return controller.NotFound();
			return controller.Ok(response);
		}

		public static async Task<IActionResult> CreateAsync<TRequest, TResponse>(this ControllerBase controller, IMediator mediator, TRequest request) => await CreateOrUpdateAsync<TRequest, TResponse>(controller, mediator, request);

		public static async Task<IActionResult> CreateAsync<TRequest>(this ControllerBase controller, IMediator mediator, TRequest request) => await CreateOrUpdateAsync<TRequest, Unit>(controller, mediator, request);



	}
}
