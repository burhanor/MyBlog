using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.API.Extensions;
using MyBlog.Application.Features.PostSeries.Command.CreatePostSeries;
using MyBlog.Application.Features.PostSeries.Command.DeletePostSeries;
using MyBlog.Application.Features.PostSeries.Queries.GetPostSeries;
using MyBlog.Application.Models;

namespace MyBlog.API.Controllers
{
	[Authorize]
	[Asp.Versioning.ApiVersion(1)]
	[Route("api/v{v:apiVersion}/series")]
	[ApiController]
	public class PostSeriesController : ControllerBase
	{
		private readonly IMediator mediator;

		public PostSeriesController(IMediator mediator)
		{
			this.mediator = mediator;
		}

		[HttpGet("{seriesId}/posts")]
		[AllowAnonymous]
		public async Task<IActionResult> GetPostSeriess([FromRoute] int seriesId, [FromQuery] GetPostSeriesQueryRequest request)
		{
			request.SeriesId = seriesId;
			return await this.GetAsync(mediator, request);
		}

		[HttpPost("{seriesId}/posts/{postId}")]
		public async Task<IActionResult> CreatePostSeries([FromRoute] int seriesId, [FromRoute] int postId, [FromForm] int displayOrder)
		{
			CreatePostSeriesCommandRequest request = new(postId,seriesId,displayOrder);
			return await this.CreateAsync<CreatePostSeriesCommandRequest, ResponseContainer<CreatePostSeriesCommandResponse>>(mediator, request);
		}

		[HttpDelete("{seriesId}/posts")]
		public async Task<IActionResult> DeletePostSeries([FromRoute] int seriesId, [FromRoute] int postId)
		{
			return await this.DeleteAsync(mediator, new DeletePostSeriesCommandRequest(postId,seriesId));
		}



	}
}
