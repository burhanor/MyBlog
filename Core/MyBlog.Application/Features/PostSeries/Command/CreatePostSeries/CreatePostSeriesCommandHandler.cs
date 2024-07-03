using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Features.Post.Rules;
using MyBlog.Application.Features.PostSeries.Rules;
using MyBlog.Application.Features.Series.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostSeries.Command.CreatePostSeries
{
	public class CreatePostSeriesCommandHandler : BaseHandler<Domain.Entities.PostSeries>, IRequestHandler<CreatePostSeriesCommandRequest, ResponseContainer<CreatePostSeriesCommandResponse>>
	{
		private readonly PostRules postRules;
		private readonly PostSeriesRules postSeriesRules;
		private readonly SeriesRules seriesRules;

		public CreatePostSeriesCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,PostRules postRules,PostSeriesRules postSeriesRules,SeriesRules seriesRules) : base(uow, mapper, httpContextAccessor)
		{
			this.postRules = postRules;
			this.postSeriesRules = postSeriesRules;
			this.seriesRules = seriesRules;
		}

		public async Task<ResponseContainer<CreatePostSeriesCommandResponse>> Handle(CreatePostSeriesCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<CreatePostSeriesCommandResponse> response= new();
			await postSeriesRules.DisplayOrderMustBePositive(request.DisplayOrder);
			bool postIsExists = await uow.GetReadRepository<Domain.Entities.Post>().ExistAsync(m => m.Id == request.PostId, cancellationToken: cancellationToken);
			await postRules.PostNotFound(postIsExists);
			bool seriesIsExists = await uow.GetReadRepository<Domain.Entities.Series>().ExistAsync(m => m.Id == request.SeriesId, cancellationToken: cancellationToken);
			await seriesRules.SeriesNotFound(seriesIsExists);
			bool postSeriesIsExists = await readRepository.ExistAsync(m => m.SeriesId == request.SeriesId && m.PostId == request.PostId, cancellationToken);
			await postSeriesRules.PostSeriesAlreadyExists(postSeriesIsExists);
			Domain.Entities.PostSeries postSeries = mapper.Map<Domain.Entities.PostSeries,CreatePostSeriesCommandRequest>(request);
			await writeRepository.AddAsync(postSeries, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			response.Success = true;
			response.Message=Const.PostSeries.POST_SERIES_CREATED;
			response.Data = await uow.GetReadRepository<PostSeriesSummary>().GetAsync(predicate: m => m.SeriesId == request.SeriesId && m.PostId==request.PostId, select: m => new CreatePostSeriesCommandResponse {
			
				Summary = m.Summary,
				ThumbnailPath = m.ThumbnailPath,
				Title = m.Title,
				Url = m.Url,
				AuthorPath = m.AuthorPath,
				AuthorName = m.AuthorName,
				DisplayOrder = m.DisplayOrder,
				PostId = m.PostId,
				SeriesId = m.SeriesId
			}, cancellationToken: cancellationToken);
			return response;
		}
	}
}
