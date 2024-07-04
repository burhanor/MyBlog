﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.API.Extensions;
using MyBlog.Application.Features.Series.Command.CreateSeries;
using MyBlog.Application.Features.Series.Command.DeleteSeries;
using MyBlog.Application.Features.Series.Command.DeleteSeriesImage;
using MyBlog.Application.Features.Series.Command.UpdateSeries;
using MyBlog.Application.Features.Series.Command.UpdateSeriesImage;
using MyBlog.Application.Features.Series.Queries.GetSerie;
using MyBlog.Application.Features.Series.Queries.GetSeries;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Models;
using MyBlog.Application.Models.Series;

namespace MyBlog.API.Controllers
{
	[Authorize]
	[Asp.Versioning.ApiVersion(1)]
	[Route("api/v{v:apiVersion}/[controller]")]
	[ApiController]
	public class SeriesController : ControllerBase
	{
		private readonly IMediator mediator;
		private readonly IMyMapper mapper;

		public SeriesController(IMediator mediator, IMyMapper mapper)
		{
			this.mediator = mediator;
			this.mapper = mapper;
		}

		[HttpGet("{id}")]
		[AllowAnonymous]
		public async Task<IActionResult> GetSerie([FromRoute] int id)
		{
			return await this.GetByIdAsync(mediator, new GetSerieQueryRequest { Id = id });
		}
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> GetSeries([FromQuery] GetSeriesQueryRequest request)
		{
			return await this.GetAsync(mediator, request);
		}


		[HttpPost]
		public async Task<IActionResult> CreateSeries([FromForm] SeriesModel request)
		{
			return await this.CreateAsync<CreateSeriesCommandRequest, ResponseContainer<CreateSeriesCommandResponse>>(mediator, mapper.Map<CreateSeriesCommandRequest, SeriesModel>(request));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSeries([FromRoute] int id)
		{
			return await this.DeleteAsync(mediator, new DeleteSeriesCommandRequest { Id = id });
		}
		[HttpPost("{id}")]
		public async Task<IActionResult> UpdateSeries([FromForm] SeriesModel request, [FromRoute] int id)
		{
			return await this.UpdateAsync<UpdateSeriesCommandRequest, ResponseContainer<UpdateSeriesCommandResponse>>(mediator, mapper.Map<UpdateSeriesCommandRequest, SeriesModel>(request), id);
		}
		[HttpPut("{seriesId}/thumbnail")]
		public async Task<IActionResult> UpdateThumbnailImage([FromRoute] int seriesId,[FromForm] ImageModel image)
		{
			UpdateSeriesImageCommandRequest request= new() { ImageType = Domain.Enums.ImageType.SeriesThumbnail, Image = image.Image };
			return await this.UpdateAsync<UpdateSeriesImageCommandRequest, ResponseContainer<UpdateSeriesImageCommandResponse>>(mediator, request,seriesId);
		}
		[HttpPut("{seriesId}/header")]
		public async Task<IActionResult> UpdateHeaderImage([FromRoute] int seriesId, [FromForm] ImageModel image)
		{
			UpdateSeriesImageCommandRequest request = new() { ImageType = Domain.Enums.ImageType.SeriesHeader, Image = image.Image };
			return await this.UpdateAsync<UpdateSeriesImageCommandRequest, ResponseContainer<UpdateSeriesImageCommandResponse>>(mediator, request, seriesId);
		}

		[HttpDelete("{seriesId}/thumbnail")]
		public async Task<IActionResult> DeleteThumbnailImage([FromRoute] int seriesId)
		{
			return await this.DeleteAsync(mediator, new DeleteSeriesImageCommandRequest { SeriesId = seriesId, ImageType = Domain.Enums.ImageType.SeriesThumbnail });
		}
		[HttpDelete("{seriesId}/header")]
		public async Task<IActionResult> DeleteHeaderImage([FromRoute] int seriesId)
		{
			return await this.DeleteAsync(mediator, new DeleteSeriesImageCommandRequest { SeriesId = seriesId,ImageType=Domain.Enums.ImageType.SeriesHeader });
		}
	}
}
