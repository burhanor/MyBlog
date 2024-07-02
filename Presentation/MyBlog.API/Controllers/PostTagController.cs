using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.API.Extensions;
using MyBlog.Application.Features.PostTag.Command.CreatePostTag;
using MyBlog.Application.Features.PostTag.Command.DeletePostTag;
using MyBlog.Application.Features.PostTag.Queries.GetPostTags;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Models.PostTag;
using MyBlog.Application.Models;

namespace MyBlog.API.Controllers
{
	[Authorize]
	[Asp.Versioning.ApiVersion(1)]
	[Route("api/v{v:apiVersion}/post")]
	[ApiController]
	public class PostTagController : ControllerBase
	{
		private readonly IMediator mediator;
		private readonly IMyMapper mapper;

		public PostTagController(IMediator mediator, IMyMapper mapper)
		{
			this.mediator = mediator;
			this.mapper = mapper;
		}


		[HttpGet("{postId}/tags")]
		[AllowAnonymous]
		public async Task<IActionResult> GetPostTags([FromRoute] int postId)
		{
			GetPostTagsQueryRequest request = new() { PostId = postId };
			return await this.GetAsync(mediator, request);
		}


		[HttpPost("{postId}/tags")]
		public async Task<IActionResult> CreatePostTag([FromRoute] int postId, [FromForm] int tagId)
		{
			PostTagModel request = new() { TagId = tagId, PostId = postId };
			return await this.CreateAsync<CreatePostTagCommandRequest, ResponseContainer<CreatePostTagCommandResponse>>(mediator, mapper.Map<CreatePostTagCommandRequest, PostTagModel>(request));
		}

		[HttpDelete("{postId}/tags/{tagId}")]
		public async Task<IActionResult> DeletePostTag([FromRoute] int postId, [FromRoute] int tagId)
		{
			return await this.DeleteAsync(mediator, new DeletePostTagCommandRequest { TagId = tagId, PostId = postId });
		}



	}
}
