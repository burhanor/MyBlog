using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.API.Extensions;
using MyBlog.Application.Features.Post.Command.CreatePost;
using MyBlog.Application.Features.Post.Command.DeletePost;
using MyBlog.Application.Features.Post.Command.UpdatePost;
using MyBlog.Application.Features.Post.Queries.GetPost;
using MyBlog.Application.Features.Post.Queries.GetPosts;
using MyBlog.Application.Features.Post.Queries.GetPublishedPosts;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Models;
using MyBlog.Application.Models.Post;

namespace MyBlog.API.Controllers
{
	[Authorize]
	[Asp.Versioning.ApiVersion(1)]
	[Route("api/v{v:apiVersion}/[controller]")]
	[ApiController]
	public class PostController : ControllerBase
	{
		private readonly IMediator mediator;
		private readonly IMyMapper mapper;

		public PostController(IMediator mediator, IMyMapper mapper)
		{
			this.mediator = mediator;
			this.mapper = mapper;
		}

		[HttpGet("{id}")]
		[AllowAnonymous]
		public async Task<IActionResult> GetPost([FromRoute] int id)
		{
			return await this.GetByIdAsync(mediator, new GetPostQueryRequest { Id = id });
		}
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> GetPosts([FromQuery] GetPostsQueryRequest request)
		{
			return await this.GetAsync(mediator, request);
		}
		[HttpGet("Published")]
		[AllowAnonymous]
		public async Task<IActionResult> GetPublishedPosts([FromQuery] GetPublishedPostsQueryRequest request)
		{
			return await this.GetAsync(mediator, request);
		}

		[HttpPost]
		public async Task<IActionResult> CreatePost([FromForm] PostModel request)
		{
			return await this.CreateAsync<CreatePostCommandRequest, ResponseContainer<CreatePostCommandResponse>>(mediator, mapper.Map<CreatePostCommandRequest, PostModel>(request));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePost([FromRoute] int id)
		{
			return await this.DeleteAsync(mediator, new DeletePostCommandRequest { Id = id });
		}
		[HttpPost("{id}")]
		public async Task<IActionResult> UpdatePost([FromForm] PostModel request, [FromRoute] int id)
		{
			return await this.UpdateAsync<UpdatePostCommandRequest, ResponseContainer<UpdatePostCommandResponse>>(mediator, mapper.Map<UpdatePostCommandRequest, PostModel>(request), id);
		}


	}
}
