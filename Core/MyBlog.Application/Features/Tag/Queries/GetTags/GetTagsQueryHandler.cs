using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Extensions;
using MyBlog.Application.Features.Category.Queries.GetCategories;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Tag.Queries.GetTags
{
	public class GetTagsQueryHandler : BaseHandler<Domain.Entities.Tag>, IRequestHandler<GetTagsQueryRequest, ResponseContainer<IList<GetTagsQueryResponse>>>
	{
		public GetTagsQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor) : base(uow, mapper, httpContextAccessor)
		{
		}

		public async Task<ResponseContainer<IList<GetTagsQueryResponse>>> Handle(GetTagsQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<IList<GetTagsQueryResponse>> response = new();
			IList<Domain.Entities.Tag> tags = [];
			if (request.IsNullOrEmpty())
			{
				tags = await uow.GetReadRepository<Domain.Entities.Tag>().GetAllAsync(cancellationToken: cancellationToken);
			}
			else
			{
				request.PageSize ??= 10;
				request.PageNumber ??= 1;
				IQueryable<Domain.Entities.Tag> query = uow.GetReadRepository<Domain.Entities.Tag>().GetQuery();
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
				tags = query.Take(request.PageSize.Value).ToList();

			}

			response.Data = mapper.Map<GetTagsQueryResponse, Domain.Entities.Tag>(tags);


			return response;
		}
	}
}
