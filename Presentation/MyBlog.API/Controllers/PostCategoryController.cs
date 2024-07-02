using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.API.Extensions;
using MyBlog.Application.Features.PostCategory.Command.CreatePostCategory;
using MyBlog.Application.Features.PostCategory.Command.DeletePostCategory;
using MyBlog.Application.Features.PostCategory.Queries.GetPostCategories;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Models;
using MyBlog.Application.Models.PostCategory;

namespace MyBlog.API.Controllers
{
	[Authorize]
	[Asp.Versioning.ApiVersion(1)]
	[Route("api/v{v:apiVersion}/post")]
	[ApiController]
	public class PostCategoryController : ControllerBase
	{
		private readonly IMediator mediator;
		private readonly IMyMapper mapper;

		public PostCategoryController(IMediator mediator, IMyMapper mapper)
		{
			this.mediator = mediator;
			this.mapper = mapper;
		}

	
		[HttpGet("{postId}/categories")]
		[AllowAnonymous]
		public async Task<IActionResult> GetPostCategories([FromRoute] int postId)
		{
			GetPostCategoriesQueryRequest request = new() { PostId = postId };
			return await this.GetAsync(mediator, request);
		}


		[HttpPost("{postId}/categories")]
		public async Task<IActionResult> CreatePostCategory([FromRoute] int postId, [FromForm] int categoryId )
		{
			PostCategoryModel request= new() { CategoryId = categoryId, PostId = postId };
			return await this.CreateAsync<CreatePostCategoryCommandRequest, ResponseContainer<CreatePostCategoryCommandResponse>>(mediator, mapper.Map<CreatePostCategoryCommandRequest, PostCategoryModel>(request));
		}

		[HttpDelete("{postId}/categories/{categoryId}")]
		public async Task<IActionResult> DeletePostCategory([FromRoute] int postId, [FromRoute] int categoryId)
		{
			return await this.DeleteAsync(mediator, new DeletePostCategoryCommandRequest { CategoryId = categoryId,PostId= postId });
		}
	


	}
}
