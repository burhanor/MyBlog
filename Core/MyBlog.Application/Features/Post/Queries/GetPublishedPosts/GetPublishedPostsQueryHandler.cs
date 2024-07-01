using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Extensions;
using MyBlog.Application.Features.Post.Queries.GetPosts;
using MyBlog.Application.Features.Post.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Post.Queries.GetPublishedPosts
{
	public class GetPublishedPostsQueryHandler : BaseHandler, IRequestHandler<GetPublishedPostsQueryRequest, ResponseContainer<IList<GetPublishedPostsQueryResponse>>>
	{
		private readonly PostRules postRules;

		public GetPublishedPostsQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,PostRules postRules) : base(uow, mapper, httpContextAccessor)
		{
			this.postRules = postRules;
		}

		public async Task<ResponseContainer<IList<GetPublishedPostsQueryResponse>>> Handle(GetPublishedPostsQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<IList<GetPublishedPostsQueryResponse>> response= new();
			IList<PostSummary> posts = [];
			if (request.IsNullOrEmpty())
			{
				posts = await uow.GetReadRepository<PostSummary>().GetAllAsync(cancellationToken: cancellationToken);
			}
			else
			{
				request.PageSize ??= 10;
				request.PageNumber ??= 1;
				IQueryable<PostSummary> query = uow.GetReadRepository<PostSummary>().GetQuery();
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
				posts = query.Take(request.PageSize.Value).ToList();

			}

			response.Data = mapper.Map<GetPublishedPostsQueryResponse, PostSummary>(posts);
			return response;
		}
	}
}
