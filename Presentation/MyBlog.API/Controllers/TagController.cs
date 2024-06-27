using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.API.Extensions;
using MyBlog.Application.Features.Tag.Command.CreateTag;
using MyBlog.Application.Features.Tag.Command.DeleteTag;
using MyBlog.Application.Features.Tag.Command.UpdateTag;
using MyBlog.Application.Features.Tag.Queries.GetTags;
using MyBlog.Application.Features.Tag.Queries.GetTag;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Models.Tag;
using MyBlog.Application.Models;

namespace MyBlog.API.Controllers
{
	[Authorize]
	[Asp.Versioning.ApiVersion(1)]
	[Route("api/v{v:apiVersion}/[controller]")]
	[ApiController]
	public class TagController : ControllerBase
	{
		private readonly IMediator mediator;
		private readonly IMyMapper mapper;

		public TagController(IMediator mediator, IMyMapper mapper)
		{
			this.mediator = mediator;
			this.mapper = mapper;
		}

		[HttpGet("{id}")]
		[AllowAnonymous]
		public async Task<IActionResult> GetTag([FromRoute] int id)
		{
			return await this.GetByIdAsync(mediator, new GetTagQueryRequest { Id = id });
		}
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> GetTags([FromQuery] GetTagsQueryRequest request)
		{
			return await this.GetAsync(mediator, request);
		}


		[HttpPost]
		public async Task<IActionResult> CreateTag([FromForm] TagModel request)
		{
			return await this.CreateAsync<CreateTagCommandRequest, ResponseContainer<CreateTagCommandResponse>>(mediator, mapper.Map<CreateTagCommandRequest, TagModel>(request));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteTag([FromRoute] int id)
		{
			return await this.DeleteAsync(mediator, new DeleteTagCommandRequest { Id = id });
		}
		[HttpPost("{id}")]
		public async Task<IActionResult> UpdateTag([FromForm] TagModel request, [FromRoute] int id)
		{
			return await this.UpdateAsync<UpdateTagCommandRequest, ResponseContainer<UpdateTagCommandResponse>>(mediator, mapper.Map<UpdateTagCommandRequest, TagModel>(request), id);
		}


	}
}
