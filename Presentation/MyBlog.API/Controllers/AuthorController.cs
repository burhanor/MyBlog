using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBlog.API.Extensions;
using MyBlog.Application.Features.Auth.Command.Login;
using MyBlog.Application.Features.Author.Command.CreateAuthor;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Models.Auth;
using MyBlog.Application.Models;
using MyBlog.Application.Models.Author;

namespace MyBlog.API.Controllers
{
	[Asp.Versioning.ApiVersion(1)]
	[Route("api/v{v:apiVersion}/[action]")]
	[ApiController]
	public class AuthorController : ControllerBase
	{
		private readonly IMediator mediator;
		private readonly IMyMapper mapper;

		public AuthorController(IMediator mediator,IMyMapper mapper)
        {
			this.mediator = mediator;
			this.mapper = mapper;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAuthor([FromForm] AuthorModel request)
		{
			return await this.CreateAsync<CreateAuthorCommandRequest, ResponseContainer<CreateAuthorCommandResponse>>(mediator, mapper.Map<CreateAuthorCommandRequest,AuthorModel>(request));
		}
    }
}
