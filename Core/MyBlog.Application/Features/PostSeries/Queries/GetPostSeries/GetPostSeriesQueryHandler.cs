using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Extensions;
using MyBlog.Application.Features.PostRecommendation.Queries.GetPostRecommendations;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostSeries.Queries.GetPostSeries
{
	public class GetPostSeriesQueryHandler : BaseHandler, IRequestHandler<GetPostSeriesQueryRequest, ResponseContainer<IList<GetPostSeriesQueryResponse>>>
	{
		public GetPostSeriesQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor) : base(uow, mapper, httpContextAccessor)
		{
		}

		public async Task<ResponseContainer<IList<GetPostSeriesQueryResponse>>> Handle(GetPostSeriesQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<IList<GetPostSeriesQueryResponse>> response = new();
			IList<GetPostSeriesQueryResponse> postSeries = [];
			if (request.IsNullOrEmpty())
			{
				postSeries = await uow.GetReadRepository<PostSeriesSummary>().GetAllAsyncAs(predicate: m=>m.SeriesId==request.SeriesId, select: m => new GetPostSeriesQueryResponse
				{
					ThumbnailPath = m.ThumbnailPath,
					Summary = m.Summary,
					Title = m.Title,
					Url = m.Url,
					SeriesId = m.SeriesId,
					PostId = m.PostId,
					DisplayOrder = m.DisplayOrder,
					AuthorName = m.AuthorName,
					AuthorPath = m.AuthorPath
				}, cancellationToken: cancellationToken);
			}
			else
			{
				request.PageSize ??= 10;
				request.PageNumber ??= 1;
				IQueryable<PostSeriesSummary> query = uow.GetReadRepository<PostSeriesSummary>().GetQuery().Where(m => m.SeriesId == request.SeriesId);
				if (!string.IsNullOrEmpty(request.Search))
					query = query.Where(x => x.Title.Contains(request.Search) || x.Summary.Contains(request.Search) || x.Url.Contains(request.Search));
				if (!string.IsNullOrEmpty(request.OrderBy))
				{
					switch (request.OrderBy.ToLowerInvariant())
					{
						case "asc":
							query = query.OrderBy(x => x.Title);
							break;
						case "desc":
							query = query.OrderByDescending(x => x.Title);
							break;
						default:
							break;
					}
				}
				if (request.PageNumber <= 0)
					request.PageNumber = 1;
				query = query.Skip((request.PageNumber.Value - 1) * request.PageSize.Value);
				postSeries = query.Take(request.PageSize.Value).Select(m => new GetPostSeriesQueryResponse
				{
					ThumbnailPath = m.ThumbnailPath,
					Summary = m.Summary,
					Title = m.Title,
					Url = m.Url,
					SeriesId = m.SeriesId,
					PostId = m.PostId,
					DisplayOrder = m.DisplayOrder,
					AuthorName = m.AuthorName,
					AuthorPath = m.AuthorPath
				}).ToList();

			}
			response.Success = true;
			response.Data = postSeries;
			return response;
		}
	}
}
