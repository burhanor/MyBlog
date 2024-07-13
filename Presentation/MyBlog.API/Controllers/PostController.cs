using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.API.Extensions;
using MyBlog.Application.Features.Post.Command.CreatePost;
using MyBlog.Application.Features.Post.Command.CreatePostView;
using MyBlog.Application.Features.Post.Command.DeletePost;
using MyBlog.Application.Features.Post.Command.DeletePostImage;
using MyBlog.Application.Features.Post.Command.UpdatePost;
using MyBlog.Application.Features.Post.Command.UpdatePostImage;
using MyBlog.Application.Features.Post.Queries.GetPost;
using MyBlog.Application.Features.Post.Queries.GetPosts;
using MyBlog.Application.Features.Post.Queries.GetPostViewCount;
using MyBlog.Application.Features.Post.Queries.GetPublishedPosts;
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
		public PostController(IMediator mediator)
		{
			this.mediator = mediator;
		}

		[HttpGet("{id}")]
		[AllowAnonymous]
		public async Task<IActionResult> GetPost([FromRoute] int id)
		{
			return await this.GetByIdAsync(mediator, new GetPostQueryRequest(id));
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
			return await this.CreateAsync<CreatePostCommandRequest, ResponseContainer<CreatePostCommandResponse>>(mediator, request.ToCreateCommandRequest());
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePost([FromRoute] int id)
		{
			return await this.DeleteAsync(mediator, new DeletePostCommandRequest { Id = id });
		}
		[HttpPost("{id}")]
		public async Task<IActionResult> UpdatePost([FromForm] PostModel request, [FromRoute] int id)
		{
			return await this.UpdateAsync<UpdatePostCommandRequest, ResponseContainer<UpdatePostCommandResponse>>(mediator, request.ToUpdateCommandRequest(id), id);
		}

		[HttpPut("{postId}/thumbnail")]
		public async Task<IActionResult> UpdateThumbnailImage([FromRoute] int postId, [FromForm] ImageModel image)
		{
			UpdatePostImageCommandRequest request = new(Domain.Enums.ImageType.PostThumbnail,image.Image);
			return await this.UpdateAsync<UpdatePostImageCommandRequest, ResponseContainer<UpdatePostImageCommandResponse>>(mediator, request, postId);
		}
		[HttpPut("{postId}/header")]
		public async Task<IActionResult> UpdateHeaderImage([FromRoute] int postId, [FromForm] ImageModel image)
		{
			UpdatePostImageCommandRequest request = new(Domain.Enums.ImageType.PostHeader, image.Image);
			return await this.UpdateAsync<UpdatePostImageCommandRequest, ResponseContainer<UpdatePostImageCommandResponse>>(mediator, request, postId);
		}

		[HttpDelete("{postId}/thumbnail")]
		public async Task<IActionResult> DeleteThumbnailImage([FromRoute] int postId)
		{
			return await this.DeleteAsync(mediator, new DeletePostImageCommandRequest(postId, Domain.Enums.ImageType.PostThumbnail));
		}
		[HttpDelete("{postId}/header")]
		public async Task<IActionResult> DeleteHeaderImage([FromRoute] int postId)
		{
			return await this.DeleteAsync(mediator, new DeletePostImageCommandRequest(postId, Domain.Enums.ImageType.PostHeader));
		}

		[HttpPost("{postId}/view")]
		public async Task<IActionResult> CreateViewCount([FromRoute] int postId)
		{
			return await this.CreateAsync<CreatePostViewCommandRequest, ResponseContainer<CreatePostViewCommandResponse>>(mediator, new CreatePostViewCommandRequest(postId));
		}
		[HttpGet("{postId}/view")]
		[AllowAnonymous]
		public async Task<IActionResult> GetPostViewCount([FromRoute] int postId)
		{
			return await this.GetByIdAsync(mediator, new GetPostViewCountQueryRequest(postId));
		}
	}
}
