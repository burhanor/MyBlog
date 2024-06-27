using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Bases;
using MyBlog.Application.Extensions;
using MyBlog.Application.Features.Author.Queries.GetAuthors;
using MyBlog.Application.Features.Category.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MyBlog.Application.Features.Category.Queries.GetCategories
{
	public class GetCategoriesQueryHandler : BaseHandler<Domain.Entities.Category>, IRequestHandler<GetCategoriesQueryRequest, ResponseContainer<IList<GetCategoriesQueryResponse>>>
	{

		public GetCategoriesQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor) : base(uow, mapper, httpContextAccessor)
		{
		}

		public async Task<ResponseContainer<IList<GetCategoriesQueryResponse>>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<IList<GetCategoriesQueryResponse>> response = new() { Data= [] };
			IList<CategoryWithParentName> categories = [];
			if (request.IsNullOrEmpty())
			{
				categories = await uow.GetReadRepository<CategoryWithParentName>().GetAllAsync(cancellationToken: cancellationToken);
			}
			else
			{
				request.PageSize ??= 10;
				request.PageNumber ??= 1;
				IQueryable<CategoryWithParentName> query = uow.GetReadRepository<CategoryWithParentName>().GetQuery();
				if (!string.IsNullOrEmpty(request.Search))
					query = query.Where(x => x.Name.Contains(request.Search) || x.Url.Contains(request.Search));
				if (!string.IsNullOrEmpty(request.OrderBy))
				{
					switch (request.OrderBy)
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
				categories = query.Take(request.PageSize.Value).ToList();
				
			}

			response.Data = mapper.Map<GetCategoriesQueryResponse, CategoryWithParentName>(categories);
			return response;
		}
	}
}
