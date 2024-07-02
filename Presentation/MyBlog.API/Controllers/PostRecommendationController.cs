using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.API.Extensions;
using MyBlog.Application.Features.Post.Queries.GetPosts;
using MyBlog.Application.Features.PostRecommendation.Command.CreatePostRecommendation;
using MyBlog.Application.Features.PostRecommendation.Command.DeletePostRecommendation;
using MyBlog.Application.Features.PostRecommendation.Queries.GetPostRecommendations;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Models;

namespace MyBlog.API.Controllers
{
	[Authorize]
	[Asp.Versioning.ApiVersion(1)]
	[Route("api/v{v:apiVersion}/post")]
	[ApiController]
	public class PostRecommendationController : ControllerBase
	{
		private readonly IMediator mediator;
		private readonly IMyMapper mapper;

		public PostRecommendationController(IMediator mediator, IMyMapper mapper)
		{
			this.mediator = mediator;
			this.mapper = mapper;
		}

		[HttpGet("recommendations")]
		[AllowAnonymous]
		public async Task<IActionResult> GetPostRecommendations([FromQuery] GetPostRecommendationsQueryRequest request)
		{
			return await this.GetAsync(mediator, request);
		}

		[HttpPost("{postId}/recommendations")]
		public async Task<IActionResult> CreatePostRecommendation([FromRoute] int postId,[FromForm] int displayOrder)
		{
			CreatePostRecommendationCommandRequest request = new() { PostId = postId, DisplayOrder = displayOrder };
			return await this.CreateAsync<CreatePostRecommendationCommandRequest, ResponseContainer<CreatePostRecommendationCommandResponse>>(mediator, request);
		}

		[HttpDelete("{postId}/recommendations")]
		public async Task<IActionResult> DeletePostRecommendation([FromRoute] int postId)
		{
			return await this.DeleteAsync(mediator, new DeletePostRecommendationCommandRequest { Id=postId });
		}



	}
}
