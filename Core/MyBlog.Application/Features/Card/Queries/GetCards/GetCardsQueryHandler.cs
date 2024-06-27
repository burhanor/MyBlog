using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Extensions;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Views;

namespace MyBlog.Application.Features.Card.Queries.GetCards
{
	public class GetCardsQueryHandler : BaseHandler, IRequestHandler<GetCardsQueryRequest, ResponseContainer<IList<GetCardsQueryResponse>>>
	{
		public GetCardsQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor) : base(uow, mapper, httpContextAccessor)
		{
		}

		public async Task<ResponseContainer<IList<GetCardsQueryResponse>>> Handle(GetCardsQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<IList<GetCardsQueryResponse>> response= new();
			IList<CardSummary> cards = [];
			if (request.IsNullOrEmpty())
			{
				cards = await uow.GetReadRepository<CardSummary>().GetAllAsync(cancellationToken: cancellationToken);
			}
			else
			{
				request.PageSize ??= 10;
				request.PageNumber ??= 1;
				IQueryable<CardSummary> query = uow.GetReadRepository<CardSummary>().GetQuery();
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
				cards = query.Take(request.PageSize.Value).ToList();

			}

			response.Data = mapper.Map<GetCardsQueryResponse, CardSummary>(cards);
			return response;
		}
	}
}
