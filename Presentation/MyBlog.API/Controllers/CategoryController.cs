using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.API.Extensions;
using MyBlog.Application.Features.Category.Command.CreateCategory;
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

		[HttpPost]
		public async Task<IActionResult> CreateCategory([FromForm] CategoryModel request)
		{
			return await this.CreateAsync<CreateCategoryCommandRequest, ResponseContainer<CreateCategoryCommandResponse>>(mediator, mapper.Map<CreateCategoryCommandRequest, CategoryModel>(request));
		}
	}
}
