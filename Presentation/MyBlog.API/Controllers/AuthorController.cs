using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBlog.API.Extensions;
using MyBlog.Application.Features.Auth.Command.Login;
using MyBlog.Application.Features.Author.Command.CreateAuthor;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Models.Auth;
using MyBlog.Application.Models;
using MyBlog.Application.Models.Author;
using MyBlog.Application.Features.Author.Command.UpdateAuthor;
using MyBlog.Application.Features.Author.Command.DeleteAuthor;
using Azure.Core;
using MyBlog.Application.Features.Author.Command.ChangePassword;
using Microsoft.AspNetCore.Authorization;
using MyBlog.Application.Features.Author.Command.ChangeAvatar;
using MyBlog.Application.Features.Author.Queries.GetAuthors;
using MyBlog.Application.Features.Author.Queries.GetAuthor;

namespace MyBlog.API.Controllers
{
	[Authorize]
	[Asp.Versioning.ApiVersion(1)]
	[Route("api/v{v:apiVersion}/[controller]")]
	[ApiController]
	public class AuthorController : ControllerBase
	{
		private readonly IMediator mediator;
		private readonly IMyMapper mapper;

		public AuthorController(IMediator mediator, IMyMapper mapper)
		{
			this.mediator = mediator;
			this.mapper = mapper;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAuthor([FromForm] AuthorModel request)
		{
			return await this.CreateAsync<CreateAuthorCommandRequest, ResponseContainer<CreateAuthorCommandResponse>>(mediator, mapper.Map<CreateAuthorCommandRequest, AuthorModel>(request));
		}


		[HttpPost("{id}")]
		public async Task<IActionResult> UpdateAuthor([FromRoute]int id,[FromForm] AuthorModel request)
		{
			return await this.UpdateAsync<UpdateAuthorCommandRequest, ResponseContainer<UpdateAuthorCommandResponse>>(mediator, mapper.Map<UpdateAuthorCommandRequest, AuthorModel>(request),id);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAuthor([FromRoute] int id)
		{
			return await this.DeleteAsync(mediator, new DeleteAuthorCommandRequest { Id = id });
		}


		[HttpPost]
		[Route("change-password")]
		public async Task<IActionResult> ChangePassword(string password)
		{
			ChangePasswordCommandRequest request = new()
			{
				Password = password
			};
			return await this.UpdateAsync<ChangePasswordCommandRequest, ResponseContainer<ChangePasswordCommandResponse>>(mediator,request,0);

		}

		[HttpPost]
		[Route("change-avatar")]
		public async Task<IActionResult> ChangeAvatar(IFormFile image)
		{
			ChangeAvatarCommandRequest request = new()
			{
				Image = image
			};
			return await this.UpdateAsync<ChangeAvatarCommandRequest, ResponseContainer<ChangeAvatarCommandResponse>>(mediator, request, 0);
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
