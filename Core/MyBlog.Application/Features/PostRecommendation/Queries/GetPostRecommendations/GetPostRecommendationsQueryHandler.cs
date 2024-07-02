using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Extensions;
using MyBlog.Application.Features.Post.Queries.GetPosts;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostRecommendation.Queries.GetPostRecommendations
{
	public class GetPostRecommendationsQueryHandler:BaseHandler,IRequestHandler<GetPostRecommendationsQueryRequest,ResponseContainer<IList<GetPostRecommendationsQueryResponse>>>
	{
		public GetPostRecommendationsQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor) : base(uow, mapper, httpContextAccessor)
		{
		}

		public async Task<ResponseContainer<IList<GetPostRecommendationsQueryResponse>>> Handle(GetPostRecommendationsQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<IList<GetPostRecommendationsQueryResponse>> response = new();
			IList<int> postIds = await uow.GetReadRepository<Domain.Entities.PostRecommendation>().GetAllAsyncAs(m=>m.PostId, cancellationToken: cancellationToken);
			IList<GetPostRecommendationsQueryResponse> recommendations = [];
			if (request.IsNullOrEmpty())
			{
				recommendations = await uow.GetReadRepository<PostSummary>().GetAllAsyncAs(predicate: m => m.IsPublished && postIds.Contains(m.Id), select: m => new GetPostRecommendationsQueryResponse
				{
					Title = m.Title,
					Url = m.Url,
					Image=m.HeaderPath
				}, cancellationToken: cancellationToken);
			}
			else
			{
				request.PageSize ??= 10;
				request.PageNumber ??= 1;
				IQueryable<PostSummary> query = uow.GetReadRepository<PostSummary>().GetQuery().Where(m => m.IsPublished && postIds.Contains(m.Id));
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
				recommendations = query.Take(request.PageSize.Value).Select(m=>new GetPostRecommendationsQueryResponse
				{
					Image=m.HeaderPath,
					Title=m.Title,
					Url=m.Url	
				}).ToList();

			}
			response.Success = true;
			response.Data = recommendations;
			return response;
		}
	}
}
