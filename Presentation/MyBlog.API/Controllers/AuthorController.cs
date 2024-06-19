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

namespace MyBlog.API.Controllers
{
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
	}
}
