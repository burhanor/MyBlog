using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.API.Extensions;
using MyBlog.Application.Features.Slider.Command.CreateSlider;
using MyBlog.Application.Features.Slider.Command.DeleteSlider;
using MyBlog.Application.Features.Slider.Command.UpdateSlider;
using MyBlog.Application.Features.Slider.Queries.GetSlider;
using MyBlog.Application.Features.Slider.Queries.GetSliders;
using MyBlog.Application.Models;
using MyBlog.Application.Models.Slider;

namespace MyBlog.API.Controllers
{
	[Authorize]
	[Asp.Versioning.ApiVersion(1)]
	[Route("api/v{v:apiVersion}/[controller]")]
	[ApiController]
	public class SliderController : ControllerBase
	{
		private readonly IMediator mediator;

		public SliderController(IMediator mediator)
		{
			this.mediator = mediator;
		}

		[HttpGet("{id}")]
		[AllowAnonymous]
		public async Task<IActionResult> GetSlider([FromRoute] int id)
		{
			return await this.GetByIdAsync(mediator, new GetSliderQueryRequest(id));
		}
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> GetSliders([FromQuery] GetSlidersQueryRequest request)
		{
			return await this.GetAsync(mediator, request);
		}


		[HttpPost]
		public async Task<IActionResult> CreateSlider([FromForm] SliderModel request)
		{
			return await this.CreateAsync<CreateSliderCommandRequest, ResponseContainer<CreateSliderCommandResponse>>(mediator, request.ToCreateCommandRequest());
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSlider([FromRoute] int id)
		{
			return await this.DeleteAsync(mediator, new DeleteSliderCommandRequest(id));
		}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateSlider([FromForm] SliderModel request, [FromRoute] int id)
		{
			return await this.UpdateAsync<UpdateSliderCommandRequest, ResponseContainer<UpdateSliderCommandResponse>>(mediator, request.ToUpdateCommandRequest(id));
		}

	}
}
