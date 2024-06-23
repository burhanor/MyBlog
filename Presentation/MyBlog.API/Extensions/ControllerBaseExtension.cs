using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.Interfaces;
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

		public static async Task<IActionResult> UpdateAsync<TRequest, TResponse>(this ControllerBase controller, IMediator mediator, TRequest request, int id) where TRequest : class, IId, new()
		{
			request.Id = id;
			return await CreateOrUpdateAsync<TRequest, TResponse>(controller, mediator, request);
		}


		public static async Task<IActionResult> DeleteAsync<T>(this ControllerBase controller, IMediator mediator, T request)
		{
			if (request == null)
				return controller.NoContent();
			await mediator.Send(request);
			return controller.NoContent();
		}
		public static async Task<IActionResult> GetByIdAsync<TRequest>(this ControllerBase controller, IMediator mediator, TRequest request)
		{
			if (request == null)
				return controller.NotFound();
			var response = await mediator.Send(request);
			if (response == null)
				return controller.NotFound();
			return controller.Ok(response);
		}

		public static async Task<IActionResult> GetAsync<TRequest>(this ControllerBase controller, IMediator mediator, TRequest request)
		{
			if (request == null)
				return controller.NotFound();
			return controller.Ok(await mediator.Send(request));
		}


	}
}
