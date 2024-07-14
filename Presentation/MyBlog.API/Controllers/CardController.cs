using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.API.Extensions;
using MyBlog.Application.Features.Card.Command.CreateCard;
using MyBlog.Application.Features.Card.Command.DeleteCard;
using MyBlog.Application.Features.Card.Command.UpdateCard;
using MyBlog.Application.Features.Card.Queries.GetCard;
using MyBlog.Application.Features.Card.Queries.GetCards;
using MyBlog.Application.Models;
using MyBlog.Application.Models.Card;

namespace MyBlog.API.Controllers
{
	[Authorize]
	[Asp.Versioning.ApiVersion(1)]
	[Route("api/v{v:apiVersion}/[controller]")]
	[ApiController]
	public class CardController : ControllerBase
	{
		private readonly IMediator mediator;

		public CardController(IMediator mediator)
		{
			this.mediator = mediator;
		}

		[HttpGet("{id}")]
		[AllowAnonymous]
		public async Task<IActionResult> GetCard([FromRoute] int id)
		{
			return await this.GetByIdAsync(mediator, new GetCardQueryRequest(id));
		}
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> GetCards([FromQuery] GetCardsQueryRequest request)
		{
			return await this.GetAsync(mediator, request);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCard([FromForm] CardModel model)
		{
			return await this.CreateAsync<CreateCardCommandRequest, ResponseContainer<CreateCardCommandResponse>>(mediator, model.ToCreateCommandRequest());
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCard([FromRoute] int id)
		{
			return await this.DeleteAsync(mediator, new DeleteCardCommandRequest(id));
		}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCard([FromForm] CardModel model, [FromRoute] int id)
		{
			return await this.UpdateAsync<UpdateCardCommandRequest, ResponseContainer<UpdateCardCommandResponse>>(mediator, model.ToUpdateCommandRequest(id));
		}

	}
}
