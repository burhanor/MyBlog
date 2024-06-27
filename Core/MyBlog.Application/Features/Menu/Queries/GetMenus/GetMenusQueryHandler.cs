using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Extensions;
using MyBlog.Application.Features.Menu.Queries.GetMenus;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Views;

namespace MyBlog.Application.Features.Menu.Queries.GetMenus
{
	public class GetMenusQueryHandler : BaseHandler, IRequestHandler<GetMenusQueryRequest, ResponseContainer<IList<GetMenusQueryResponse>>>
	{
		public GetMenusQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor) : base(uow, mapper, httpContextAccessor)
		{
		}

		public async Task<ResponseContainer<IList<GetMenusQueryResponse>>> Handle(GetMenusQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<IList<GetMenusQueryResponse>> response= new();
			IList<MenuWithParentName> cards = [];
			if (request.IsNullOrEmpty())
			{
				cards = await uow.GetReadRepository<MenuWithParentName>().GetAllAsync(cancellationToken: cancellationToken);
			}
			else
			{
				request.PageSize ??= 10;
				request.PageNumber ??= 1;
				IQueryable<MenuWithParentName> query = uow.GetReadRepository<MenuWithParentName>().GetQuery();
				if (!string.IsNullOrEmpty(request.Search))
					query = query.Where(x => x.Name.Contains(request.Search)  || x.Url.Contains(request.Search));
				if (!string.IsNullOrEmpty(request.OrderBy))
				{
					switch (request.OrderBy.ToLowerInvariant())
					{
						case "asc":
							query = query.OrderBy(x => x.Name);
							break;
						case "desc":
							query = query.OrderByDescending(x => x.Name);
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

			response.Data = mapper.Map<GetMenusQueryResponse, MenuWithParentName>(cards);
			return response;	
		}
	}
}
