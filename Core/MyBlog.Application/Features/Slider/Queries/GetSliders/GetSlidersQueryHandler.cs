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

namespace MyBlog.Application.Features.Slider.Queries.GetSliders
{
	public class GetSlidersQueryHandler : BaseHandler,IRequestHandler<GetSlidersQueryRequest,ResponseContainer<IList<GetSlidersQueryResponse>>>	
	{
		public GetSlidersQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor) : base(uow, mapper, httpContextAccessor)
		{
		}

		public async Task<ResponseContainer<IList<GetSlidersQueryResponse>>> Handle(GetSlidersQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<IList<GetSlidersQueryResponse>> response = new();
			IList<SliderSummary> sliders = [];
			if (request.IsNullOrEmpty())
			{
				sliders = await uow.GetReadRepository<SliderSummary>().GetAllAsync(cancellationToken: cancellationToken);
			}
			else
			{
				request.PageSize ??= 10;
				request.PageNumber ??= 1;
				IQueryable<SliderSummary> query = uow.GetReadRepository<SliderSummary>().GetQuery();
				if (!string.IsNullOrEmpty(request.Search))
					query = query.Where(x => x.Title.Contains(request.Search) || x.Content.Contains(request.Search) || x.Url.Contains(request.Search));
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
				sliders = query.Take(request.PageSize.Value).ToList();

			}

			response.Data = mapper.Map<GetSlidersQueryResponse, SliderSummary>(sliders);
			return response;

		}
	}
}
