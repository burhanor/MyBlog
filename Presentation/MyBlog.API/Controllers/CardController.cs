using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.API.Extensions;
using MyBlog.Application.Features.Card.Command.CreateCard;
using MyBlog.Application.Features.Card.Command.DeleteCard;
using MyBlog.Application.Features.Card.Command.UpdateCard;
using MyBlog.Application.Features.Card.Queries.GetCard;
using MyBlog.Application.Features.Card.Queries.GetCards;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Models.Card;
using MyBlog.Application.Models;

namespace MyBlog.API.Controllers
{
	[Authorize]
	[Asp.Versioning.ApiVersion(1)]
	[Route("api/v{v:apiVersion}/[controller]")]
	[ApiController]
	public class CardController : ControllerBase
	{
		private readonly IMediator mediator;
		private readonly IMyMapper mapper;

		public CardController(IMediator mediator, IMyMapper mapper)
		{
			this.mediator = mediator;
			this.mapper = mapper;
		}

		[HttpGet("{id}")]
		[AllowAnonymous]
		public async Task<IActionResult> GetCard([FromRoute] int id)
		{
			return await this.GetByIdAsync(mediator, new GetCardQueryRequest { Id = id });
		}
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> GetCards([FromQuery] GetCardsQueryRequest request)
		{
			return await this.GetAsync(mediator, request);
		}


		[HttpPost]
		public async Task<IActionResult> CreateCard([FromForm] CardModel request)
		{
			return await this.CreateAsync<CreateCardCommandRequest, ResponseContainer<CreateCardCommandResponse>>(mediator, mapper.Map<CreateCardCommandRequest, CardModel>(request));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCard([FromRoute] int id)
		{
			return await this.DeleteAsync(mediator, new DeleteCardCommandRequest { Id = id });
		}
		[HttpPost("{id}")]
		public async Task<IActionResult> UpdateCard([FromForm] CardModel request, [FromRoute] int id)
		{
			return await this.UpdateAsync<UpdateCardCommandRequest, ResponseContainer<UpdateCardCommandResponse>>(mediator, mapper.Map<UpdateCardCommandRequest, CardModel>(request), id);
		}

	}
}
