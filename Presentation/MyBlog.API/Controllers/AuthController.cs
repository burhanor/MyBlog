using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBlog.API.Extensions;
using MyBlog.Application.Features.Auth.Command.Login;
using MyBlog.Application.Features.Auth.Command.Register;
using MyBlog.Application.Models;
using MyBlog.Application.Models.Auth;

namespace MyBlog.API.Controllers
{
	[Asp.Versioning.ApiVersion(1)]
	[Route("api/v{v:apiVersion}/[action]")]
	[ApiController]

	//Kullanıcı girişi ve kaydı için kullanılacak controller
	public class AuthController : ControllerBase
	{
		private readonly IMediator mediator;

		public AuthController(IMediator mediator)
        {
			this.mediator = mediator;
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterModel model)
		{
			return await this.CreateAsync<RegisterCommandRequest, ResponseContainer<UnitModel>>(mediator, model.ToCommandRequest());
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginModel model)
		{
			return await this.CreateAsync<LoginCommandRequest, ResponseContainer<LoginModel>>(mediator, model.ToCommandRequest());
		}	
	
	}
}
