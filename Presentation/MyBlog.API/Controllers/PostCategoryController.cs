using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.API.Extensions;
using MyBlog.Application.Features.PostCategory.Command.CreatePostCategory;
using MyBlog.Application.Features.PostCategory.Command.DeletePostCategory;
using MyBlog.Application.Features.PostCategory.Queries.GetPostCategories;
using MyBlog.Application.Models;

namespace MyBlog.API.Controllers
{
	[Authorize]
	[Asp.Versioning.ApiVersion(1)]
	[Route("api/v{v:apiVersion}/post")]
	[ApiController]
	public class PostCategoryController : ControllerBase
	{
		private readonly IMediator mediator;

		public PostCategoryController(IMediator mediator)
		{
			this.mediator = mediator;
		}

	
		[HttpGet("{postId}/categories")]
		[AllowAnonymous]
		public async Task<IActionResult> GetPostCategories([FromRoute] int postId)
		{
			return await this.GetAsync(mediator, new GetPostCategoriesQueryRequest(postId));
		}

		[HttpPost("{postId}/categories")]
		public async Task<IActionResult> CreatePostCategory([FromRoute] int postId, [FromForm] int categoryId )
		{
			CreatePostCategoryCommandRequest request = new(categoryId,postId);
			return await this.CreateAsync<CreatePostCategoryCommandRequest, ResponseContainer<CreatePostCategoryCommandResponse>>(mediator, request);
		}

		[HttpDelete("{postId}/categories/{categoryId}")]
		public async Task<IActionResult> DeletePostCategory([FromRoute] int postId, [FromRoute] int categoryId)
		{
			return await this.DeleteAsync(mediator, new DeletePostCategoryCommandRequest(postId,categoryId));
		}
	


	}
}
