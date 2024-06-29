using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Features.Series.Rules;
using MyBlog.Application.Helpers;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Series.Command.UpdateSeries
{
	public class UpdateSeriesCommandHandler : BaseHandler<Domain.Entities.Series>, IRequestHandler<UpdateSeriesCommandRequest, ResponseContainer<UpdateSeriesCommandResponse>>
	{
		private readonly SeriesRules seriesRules;
		private readonly ImageHelper imageHelper;

		public UpdateSeriesCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,SeriesRules seriesRules,ImageHelper imageHelper) : base(uow, mapper, httpContextAccessor)
		{
			this.seriesRules = seriesRules;
			this.imageHelper = imageHelper;
		}

		public async Task<ResponseContainer<UpdateSeriesCommandResponse>> Handle(UpdateSeriesCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<UpdateSeriesCommandResponse> response = new();
			Domain.Entities.Series? series = await readRepository.GetAsync(m => m.Id == request.Id,include:m=>m.Include(s=>s.SeriesImages).ThenInclude(s=>s.Image), cancellationToken: cancellationToken);
			await seriesRules.SeriesNotFound(series);
			bool isExist = await readRepository.ExistAsync(m => m.Title == request.Title && m.AuthorId==userId && m.Id != request.Id, cancellationToken);
			await seriesRules.SeriesAlreadyExists(isExist);
			int headerImageId = series.SeriesImages.FirstOrDefault(s => s.Image.ImageType == Domain.Enums.ImageType.SeriesHeader)?.ImageId ?? 0;
			int thumbnailImageId = series.SeriesImages.FirstOrDefault(s => s.Image.ImageType == Domain.Enums.ImageType.SeriesThumbnail)?.ImageId ?? 0;
			if (request.HeaderImage!=null)
			{
				await seriesRules.ValidateImage(request.HeaderImage);	
				ImageResponseModel headerImageResponse = await imageHelper.CreateOrUpdateImage(request.HeaderImage, Domain.Enums.ImageType.SeriesHeader,headerImageId, cancellationToken);
				headerImageId = headerImageResponse.ImageId;
			}
			if (request.ThumbnailImage!=null)
			{
				await seriesRules.ValidateImage(request.ThumbnailImage);
				ImageResponseModel thumbnailImageResponse = await imageHelper.CreateOrUpdateImage(request.ThumbnailImage, Domain.Enums.ImageType.SeriesThumbnail,thumbnailImageId, cancellationToken);
				thumbnailImageId = thumbnailImageResponse.ImageId;

			}
			List<Domain.Entities.SeriesImage> seriesImages = [];
			if (headerImageId>0)
				seriesImages.Add(new() { ImageId = headerImageId, SeriesId = series.Id });
			if (thumbnailImageId > 0)
				seriesImages.Add(new() { ImageId = thumbnailImageId, SeriesId = series.Id });

			await uow.BeginTransactionAsync();
			await uow.GetWriteRepository<Domain.Entities.SeriesImage>().DeleteAsync(m=>m.SeriesId==series.Id, cancellationToken);
			if (seriesImages.Count>0)
				await uow.GetWriteRepository<Domain.Entities.SeriesImage>().AddRangeAsync(seriesImages,cancellationToken);
			series = mapper.Map<Domain.Entities.Series, UpdateSeriesCommandRequest>(request);
			series.AuthorId = userId;
			await writeRepository.UpdateAsync(series);
			await uow.SaveChangesAsync(cancellationToken);
			await uow.CommitTransactionAsync();
			response.Success = true;
			response.Message = Const.Series.SERIES_UPDATED;
			SeriesSummary seriesSummary = await uow.GetReadRepository<SeriesSummary>().GetAsync(m => m.Id == series.Id, cancellationToken: cancellationToken); 
			response.Data = mapper.Map<UpdateSeriesCommandResponse,SeriesSummary>(seriesSummary);
			return response;
		}
	}
}
