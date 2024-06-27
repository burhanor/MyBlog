using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.API.Extensions;
using MyBlog.Application.Features.Menu.Command.CreateMenu;
using MyBlog.Application.Features.Menu.Command.DeleteMenu;
using MyBlog.Application.Features.Menu.Command.UpdateMenu;
using MyBlog.Application.Features.Menu.Queries.GetMenu;
using MyBlog.Application.Features.Menu.Queries.GetMenus;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Models;
using MyBlog.Application.Models.Menu;

namespace MyBlog.API.Controllers
{
	[Authorize]
	[Asp.Versioning.ApiVersion(1)]
	[Route("api/v{v:apiVersion}/[controller]")]
	[ApiController]
	public class MenuController : ControllerBase
	{
		private readonly IMediator mediator;
		private readonly IMyMapper mapper;

		public MenuController(IMediator mediator, IMyMapper mapper)
		{
			this.mediator = mediator;
			this.mapper = mapper;
		}

		[HttpGet("{id}")]
		[AllowAnonymous]
		public async Task<IActionResult> GetMenu([FromRoute] int id)
		{
			return await this.GetByIdAsync(mediator, new GetMenuQueryRequest { Id = id });
		}
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> GetMenus([FromQuery] GetMenusQueryRequest request)
		{
			return await this.GetAsync(mediator, request);
		}


		[HttpPost]
		public async Task<IActionResult> CreateMenu([FromForm] MenuModel request)
		{
			return await this.CreateAsync<CreateMenuCommandRequest, ResponseContainer<CreateMenuCommandResponse>>(mediator, mapper.Map<CreateMenuCommandRequest, MenuModel>(request));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteMenu([FromRoute] int id)
		{
			return await this.DeleteAsync(mediator, new DeleteMenuCommandRequest { Id = id });
		}
		[HttpPost("{id}")]
		public async Task<IActionResult> UpdateMenu([FromForm] MenuModel request, [FromRoute] int id)
		{
			return await this.UpdateAsync<UpdateMenuCommandRequest, ResponseContainer<UpdateMenuCommandResponse>>(mediator, mapper.Map<UpdateMenuCommandRequest, MenuModel>(request), id);
		}


	}
}
