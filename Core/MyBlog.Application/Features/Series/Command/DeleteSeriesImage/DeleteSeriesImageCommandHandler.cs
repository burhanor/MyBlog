using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Features.Series.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Series.Command.DeleteSeriesImage
{
	public class DeleteSeriesImageCommandHandler : BaseHandler<Domain.Entities.SeriesImage>, IRequestHandler<DeleteSeriesImageCommandRequest, ResponseContainer<Unit>>
	{
		private readonly SeriesRules seriesRules;

		public DeleteSeriesImageCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,SeriesRules seriesRules) : base(uow, mapper, httpContextAccessor)
		{
			this.seriesRules = seriesRules;
		}

		public async Task<ResponseContainer<Unit>> Handle(DeleteSeriesImageCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<Unit> response = new();
			bool seriesIsExist= await uow.GetReadRepository<Domain.Entities.Series>().ExistAsync(m => m.Id == request.SeriesId,cancellationToken);
			await seriesRules.SeriesNotFound(seriesIsExist);
			int imageId = uow.GetScalarFunction().GetSeriesImageId(request.SeriesId, request.ImageType);
			if (imageId>0)
			{
				await writeRepository.DeleteAsync(m => m.ImageId == imageId && m.SeriesId == request.SeriesId, cancellationToken);
				await uow.SaveChangesAsync(cancellationToken);
			}
			response.Success = true;
			response.Message=Const.SeriesImages.POST_SERIES_IMAGE_DELETED;
			return response;
		}
	}
}
