using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.API.Extensions;
using MyBlog.Application.Features.Author.Queries.GetAuthors;
using MyBlog.Application.Features.Category.Command.CreateCategory;
using MyBlog.Application.Features.Category.Command.DeleteCategory;
using MyBlog.Application.Features.Category.Command.UpdateCategory;
using MyBlog.Application.Features.Category.Queries.GetCategories;
using MyBlog.Application.Features.Category.Queries.GetCategory;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Models;
using MyBlog.Application.Models.Category;

namespace MyBlog.API.Controllers
{
	[Authorize]
	[Asp.Versioning.ApiVersion(1)]
	[Route("api/v{v:apiVersion}/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly IMediator mediator;
		private readonly IMyMapper mapper;

		public CategoryController(IMediator mediator, IMyMapper mapper)
		{
			this.mediator = mediator;
			this.mapper = mapper;
		}

		[HttpGet("{id}")]
		[AllowAnonymous]
		public async Task<IActionResult> GetCategory([FromRoute] int id)
		{
			return await this.GetByIdAsync(mediator, new GetCategoryQueryRequest { Id = id });
		}
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> GetCategories([FromQuery] GetCategoriesQueryRequest request)
		{
			return await this.GetAsync(mediator, request);
		}


		[HttpPost]
		public async Task<IActionResult> CreateCategory([FromForm] CategoryModel request)
		{
			return await this.CreateAsync<CreateCategoryCommandRequest, ResponseContainer<CreateCategoryCommandResponse>>(mediator, mapper.Map<CreateCategoryCommandRequest, CategoryModel>(request));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCategory([FromRoute] int id)
		{
			return await this.DeleteAsync(mediator, new DeleteCategoryCommandRequest { Id = id });
		}
		[HttpPost("{id}")]
		public async Task<IActionResult> UpdateCategory([FromForm] CategoryModel request, [FromRoute] int id)
		{
			return await this.UpdateAsync<UpdateCategoryCommandRequest, ResponseContainer<UpdateCategoryCommandResponse>>(mediator, mapper.Map<UpdateCategoryCommandRequest, CategoryModel>(request), id);
		}
	}
}
