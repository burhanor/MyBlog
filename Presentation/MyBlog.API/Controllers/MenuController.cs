using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.API.Extensions;
using MyBlog.Application.Features.Menu.Command.CreateMenu;
using MyBlog.Application.Features.Menu.Command.DeleteMenu;
using MyBlog.Application.Features.Menu.Command.UpdateMenu;
using MyBlog.Application.Features.Menu.Queries.GetMenu;
using MyBlog.Application.Features.Menu.Queries.GetMenus;
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
		public MenuController(IMediator mediator)
		{
			this.mediator = mediator;
		}

		[HttpGet("{id}")]
		[AllowAnonymous]
		public async Task<IActionResult> GetMenu([FromRoute] int id)
		{
			return await this.GetByIdAsync(mediator, new GetMenuQueryRequest(id));
		}
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> GetMenus([FromQuery] GetMenusQueryRequest request)
		{
			return await this.GetAsync(mediator, request);
		}


		[HttpPost]
		public async Task<IActionResult> CreateMenu([FromForm] MenuModel model)
		{
			return await this.CreateAsync<CreateMenuCommandRequest, ResponseContainer<CreateMenuCommandResponse>>(mediator, model.ToCreateCommandRequest());
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteMenu([FromRoute] int id)
		{
			return await this.DeleteAsync(mediator, new DeleteMenuCommandRequest(id));
		}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateMenu([FromForm] MenuModel model, [FromRoute] int id)
		{
			return await this.UpdateAsync<UpdateMenuCommandRequest, ResponseContainer<UpdateMenuCommandResponse>>(mediator, model.ToUpdateCommandRequest(id));
		}


	}
}
