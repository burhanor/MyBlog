using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.API.Extensions;
using MyBlog.Application.Features.Author.Command.ChangeAvatar;
using MyBlog.Application.Features.Author.Command.ChangePassword;
using MyBlog.Application.Features.Author.Command.CreateAuthor;
using MyBlog.Application.Features.Author.Command.DeleteAuthor;
using MyBlog.Application.Features.Author.Command.UpdateAuthor;
using MyBlog.Application.Features.Author.Queries.GetAuthor;
using MyBlog.Application.Features.Author.Queries.GetAuthors;
using MyBlog.Application.Models;
using MyBlog.Application.Models.Author;

namespace MyBlog.API.Controllers
{
	[Authorize]
	[Asp.Versioning.ApiVersion(1)]
	[Route("api/v{v:apiVersion}/[controller]")]
	[ApiController]
	public class AuthorController : ControllerBase
	{
		private readonly IMediator mediator;

		public AuthorController(IMediator mediator)
		{
			this.mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAuthor([FromForm] AuthorModel model)
		{
			return await this.CreateAsync<CreateAuthorCommandRequest, ResponseContainer<CreateAuthorCommandResponse>>(mediator, model.ToCreateCommandRequest());
		}


		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAuthor([FromRoute]int id,[FromForm] AuthorModel model)
		{
			return await this.UpdateAsync<UpdateAuthorCommandRequest, ResponseContainer<UpdateAuthorCommandResponse>>(mediator, model.ToUpdateCommandRequest(id));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAuthor([FromRoute] int id)
		{
			return await this.DeleteAsync(mediator, new DeleteAuthorCommandRequest(id));
		}


		[HttpPut]
		[Route("change-password")]
		public async Task<IActionResult> ChangePassword(string password)
		{
			return await this.UpdateAsync<ChangePasswordCommandRequest, ResponseContainer<ChangePasswordCommandResponse>>(mediator, new ChangePasswordCommandRequest(password));
		}

		[HttpPut]
		[Route("change-avatar")]
		public async Task<IActionResult> ChangeAvatar(IFormFile image)
		{
			return await this.UpdateAsync<ChangeAvatarCommandRequest, ResponseContainer<ChangeAvatarCommandResponse>>(mediator, new ChangeAvatarCommandRequest(image));
		}


		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> GetAuthors([FromQuery] GetAuthorsQueryRequest request)
		{
			request ??= new();
			return await this.GetAsync(mediator, request);
		}

		[HttpGet("{id}")]
		[AllowAnonymous]
		public async Task<IActionResult> GetAuthor([FromRoute] int id)
		{
			GetAuthorQueryRequest request = new(id);
			return await this.GetByIdAsync(mediator, request);
		}

	}
}
