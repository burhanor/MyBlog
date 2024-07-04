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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Series.Command.UpdateSeriesImage
{
	public class UpdateSeriesImageCommandHandler : BaseHandler<Domain.Entities.SeriesImage>, IRequestHandler<UpdateSeriesImageCommandRequest, ResponseContainer<UpdateSeriesImageCommandResponse>>
	{
		private readonly SeriesRules seriesRules;
		private readonly ImageHelper imageHelper;

		public UpdateSeriesImageCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,SeriesRules seriesRules,ImageHelper imageHelper) : base(uow, mapper, httpContextAccessor)
		{
			this.seriesRules = seriesRules;
			this.imageHelper = imageHelper;
		}

		public async Task<ResponseContainer<UpdateSeriesImageCommandResponse>> Handle(UpdateSeriesImageCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<UpdateSeriesImageCommandResponse> response = new();
			bool seriesIsExist = await uow.GetReadRepository<Domain.Entities.Series>().ExistAsync(m => m.Id == request.Id,cancellationToken);
			await seriesRules.SeriesNotFound(seriesIsExist);
			int imageId = uow.GetScalarFunction().GetSeriesImageId(request.Id, request.ImageType);
			ImageResponseModel imageResponseModel = await imageHelper.CreateOrUpdateImage(request.Image, request.ImageType, imageId, cancellationToken);
			if (imageId == 0)
			{
				await writeRepository.AddAsync(new Domain.Entities.SeriesImage
				{
					ImageId = imageResponseModel.ImageId,
					SeriesId = request.Id,
				},cancellationToken);
				await uow.SaveChangesAsync(cancellationToken);
			}
			response.Success = true;
			response.Message = Const.SeriesImages.POST_SERIES_IMAGE_UPDATED;
			response.Data = new UpdateSeriesImageCommandResponse()
			{
				ImagePath = uow.GetScalarFunction().GetSeriesImagePath(request.Id, request.ImageType)
			};
			return response;
		}
	}
}
