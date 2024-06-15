using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.API.Extensions;
using MyBlog.Application.Features.Auth.Command.Register;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Models;

namespace MyBlog.API.Controllers
{
	[ApiVersion(1)]
	[Route("api/v{v:apiVersion}/[controller]")]
	[ApiController]

	//Kullanıcı girişi ve kaydı için kullanılacak controller
	public class AuthController : ControllerBase
	{
		private readonly IMediator mediator;
		private readonly IMyMapper mapper;

		public AuthController(IMediator mediator,IMyMapper mapper)
        {
			this.mediator = mediator;
			this.mapper = mapper;
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterModel model)
		{
			return await this.CreateAsync<RegisterCommandRequest, ResponseContainer<UnitModel>>(mediator, mapper.Map<RegisterCommandRequest, RegisterModel>(model));
		}

	
	}
}
