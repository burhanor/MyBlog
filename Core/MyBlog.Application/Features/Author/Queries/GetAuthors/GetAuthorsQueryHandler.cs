using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Bases;
using MyBlog.Application.Extensions;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Author.Queries.GetAuthors
{
	public class GetAuthorsQueryHandler : BaseHandler,IRequestHandler<GetAuthorsQueryRequest, ResponseContainer<IList<GetAuthorsQueryResponse>>>
	{
		public GetAuthorsQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor) : base(uow, mapper, httpContextAccessor)
		{
		}

		public async Task<ResponseContainer<IList<GetAuthorsQueryResponse>>> Handle(GetAuthorsQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<IList<GetAuthorsQueryResponse>> response = new();
			if (request.IsNullOrEmpty()) {
				response.Data = await uow.GetReadRepository<AuthorSummary>().GetAllAsync(cancellationToken:cancellationToken,select:m=>new GetAuthorsQueryResponse
				{
					AuthorType = m.AuthorType,
					EmailAddress = m.EmailAddress,
					Id = m.Id,
					NickName = m.NickName,
					Path = m.Path,
					Summary = m.Summary
				});
			}
			else
			{
				request.PageSize ??= 10;
				request.PageNumber ??= 1;
				IQueryable<AuthorSummary> query = uow.GetReadRepository<AuthorSummary>().GetQuery();
				if (!string.IsNullOrEmpty(request.Search))
					query = query.Where(x => x.EmailAddress.Contains(request.Search) || x.NickName.Contains(request.Search) || x.Summary.Contains(request.Search));
				if (!string.IsNullOrEmpty(request.OrderBy))
				{
					switch (request.OrderBy)
					{
						case "asc":
							query = query.OrderBy(x => x.EmailAddress);
							break;
						case "desc":
							query = query.OrderByDescending(x => x.EmailAddress);
							break;
						default:
							break;
					}
				}
				if (request.PageNumber <= 0)
					request.PageNumber = 1;
				query = query.Skip((request.PageNumber.Value - 1) * request.PageSize.Value);
				response.Data = await query.Take(request.PageSize.Value).Select(m => new GetAuthorsQueryResponse
				{
					AuthorType = m.AuthorType,
					EmailAddress = m.EmailAddress,
					Id = m.Id,
					NickName = m.NickName,
					Path = m.Path,
					Summary = m.Summary
				}).ToListAsync(cancellationToken);
			}
		

			return response;
		}
	}
}
