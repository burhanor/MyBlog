using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.API.Extensions;
using MyBlog.Application.Features.PostCategory.Command.CreatePostCategory;
using MyBlog.Application.Features.PostCategory.Command.DeletePostCategory;
using MyBlog.Application.Features.PostCategory.Command.UpdatePostCategory;
using MyBlog.Application.Features.PostCategory.Queries.GetPostCategories;
using MyBlog.Application.Features.PostCategory.Queries.GetPostCategory;
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

		[HttpGet("{postId}/category/{categoryId}")]
		[AllowAnonymous]
		public async Task<IActionResult> GetPostCategory([FromRoute] int postId, [FromRoute] int categoryId)
		{
			return await this.GetByIdAsync(mediator, new GetPostCategoryQueryRequest { CategoryId = categoryId,PostId=postId });
		}
		[HttpGet("category")]
		[AllowAnonymous]
		public async Task<IActionResult> GetPostCategorys([FromQuery] GetPostCategoriesQueryRequest request)
		{
			return await this.GetAsync(mediator, request);
		}


		[HttpPost("category")]
		public async Task<IActionResult> CreatePostCategory([FromForm] PostCategoryModel request)
		{
			return await this.CreateAsync<CreatePostCategoryCommandRequest, ResponseContainer<CreatePostCategoryCommandResponse>>(mediator, mapper.Map<CreatePostCategoryCommandRequest, PostCategoryModel>(request));
		}

		[HttpDelete("{postId}/category/{categoryId}")]
		public async Task<IActionResult> DeletePostCategory([FromRoute] int postId, [FromRoute] int categoryId)
		{
			return await this.DeleteAsync(mediator, new DeletePostCategoryCommandRequest { CategoryId = categoryId,PostId= postId });
		}
		[HttpPost("{postId}/category/{categoryId}")]
		public async Task<IActionResult> UpdatePostCategory([FromForm] PostCategoryModel request, [FromRoute] int postId, [FromRoute] int categoryId)
		{
			return await this.UpdateAsync<UpdatePostCategoryCommandRequest, ResponseContainer<UpdatePostCategoryCommandResponse>>(mediator, mapper.Map<UpdatePostCategoryCommandRequest, PostCategoryModel>(request), postId);
		}


	}
}
