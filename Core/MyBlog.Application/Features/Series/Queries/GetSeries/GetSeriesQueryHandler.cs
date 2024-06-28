using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Extensions;
using MyBlog.Application.Features.Slider.Queries.GetSliders;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Series.Queries.GetSeries
{
	public class GetSeriesQueryHandler : BaseHandler, IRequestHandler<GetSeriesQueryRequest, ResponseContainer<IList<GetSeriesQueryResponse>>>
	{
		public GetSeriesQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor) : base(uow, mapper, httpContextAccessor)
		{
		}

		public async Task<ResponseContainer<IList<GetSeriesQueryResponse>>> Handle(GetSeriesQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<IList<GetSeriesQueryResponse>> response = new();
			IList<SeriesSummary> series = [];
			if (request.IsNullOrEmpty())
			{
				series = await uow.GetReadRepository<SeriesSummary>().GetAllAsync(cancellationToken: cancellationToken);
			}
			else
			{
				request.PageSize ??= 10;
				request.PageNumber ??= 1;
				IQueryable<SeriesSummary> query = uow.GetReadRepository<SeriesSummary>().GetQuery();
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
				series = query.Take(request.PageSize.Value).ToList();

			}

			response.Data = mapper.Map<GetSeriesQueryResponse, SeriesSummary>(series);
			return response;
		}
	}
}
