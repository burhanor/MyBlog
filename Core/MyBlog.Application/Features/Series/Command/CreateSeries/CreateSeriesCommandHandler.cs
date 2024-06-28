using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Features.Series.Rules;
using MyBlog.Application.Features.Series.Command.CreateSeries;
using MyBlog.Application.Features.Series.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Application.Helpers;
using MyBlog.Domain.Views;
using MyBlog.Application.Consts;

namespace MyBlog.Application.Features.Series.Command.CreateSeries
{
	public class CreateSeriesCommandHandler : BaseHandler<Domain.Entities.Series>, IRequestHandler<CreateSeriesCommandRequest, ResponseContainer<CreateSeriesCommandResponse>>
	{
		private readonly SeriesRules seriesRules;
		private readonly ImageHelper imageHelper;

		public CreateSeriesCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,SeriesRules seriesRules,ImageHelper imageHelper) : base(uow, mapper, httpContextAccessor)
		{
			this.seriesRules = seriesRules;
			this.imageHelper = imageHelper;
		}

		public async Task<ResponseContainer<CreateSeriesCommandResponse>> Handle(CreateSeriesCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<CreateSeriesCommandResponse> response = new();
			bool seriesAlreadyExists = await readRepository.ExistAsync(m => m.Title == request.Title && m.AuthorId == userId, cancellationToken: cancellationToken);
			await seriesRules.SeriesAlreadyExists(seriesAlreadyExists);

			bool urlIsExist = await readRepository.ExistAsync(m => m.Url == request.Url, cancellationToken: cancellationToken);
			await seriesRules.UrlMustBeUnique(urlIsExist);
			await seriesRules.ValidateImage(request.HeaderImage);
			await seriesRules.ValidateImage(request.ThumbnailImage);
			ImageResponseModel headerImageResponse = await imageHelper.CreateImage(request.HeaderImage, Domain.Enums.ImageType.SeriesHeader, cancellationToken);
			ImageResponseModel thumbnailImageResponse = await imageHelper.CreateImage(request.ThumbnailImage, Domain.Enums.ImageType.SeriesThumbnail, cancellationToken);
			Domain.Entities.Series series = mapper.Map<Domain.Entities.Series, CreateSeriesCommandRequest>(request);
			series.AuthorId = userId;
			await writeRepository.AddAsync(series, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
		
			IList<Domain.Entities.SeriesImage> seriesImage = [];
			seriesImage.Add(new()
			{
				ImageId = headerImageResponse.ImageId,
				SeriesId = series.Id,
			});
			seriesImage.Add(new()
			{
				ImageId = thumbnailImageResponse.ImageId,
				SeriesId = series.Id,
			});
			await uow.GetWriteRepository<Domain.Entities.SeriesImage>().AddRangeAsync(seriesImage, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			//TODO: Add AuthorName to SeriesSummary
			if (series.Id > 0)
			{
				response.Success = true;
				response.Data = await uow.GetReadRepository<SeriesSummary>().GetAsync(select: m => new CreateSeriesCommandResponse
				{
					Id = m.Id,
					AuthorName = m.AuthorName,
					HeaderPath = m.HeaderPath,
					IsPublished = m.IsPublished,
					PublishedDate = m.PublishedDate,
					Summary = m.Summary,
					ThumbnailPath = m.ThumbnailPath,
					Title = m.Title,
					Url = m.Url,
					AuthorPath = m.AuthorPath
				}, predicate: m => m.Id == series.Id, cancellationToken: cancellationToken);
				response.Message= Const.Series.SERIES_CREATED;
			}
			return response;
		}
	}
}
