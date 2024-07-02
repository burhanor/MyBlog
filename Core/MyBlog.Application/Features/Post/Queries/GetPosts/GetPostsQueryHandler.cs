using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Extensions;
using MyBlog.Application.Features.Post.Rules;
using MyBlog.Application.Features.Post.Queries.GetPost;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Post.Queries.GetPosts
{
	public class GetPostsQueryHandler : BaseHandler, IRequestHandler<GetPostsQueryRequest, ResponseContainer<IList<GetPostsQueryResponse>>>
	{
		private readonly PostRules postRules;

		public GetPostsQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,PostRules postRules) : base(uow, mapper, httpContextAccessor)
		{
			this.postRules = postRules;
		}

		public async Task<ResponseContainer<IList<GetPostsQueryResponse>>> Handle(GetPostsQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<IList<GetPostsQueryResponse>> response= new();
			IList<PostSummary> posts = [];
			if (request.IsNullOrEmpty())
			{
				posts = await uow.GetReadRepository<PostSummary>().GetAllAsyncAs(predicate:m=>m.IsPublished,select:m=>new PostSummary
				{
					IsPublished=m.IsPublished,
					AuthorName=m.AuthorName,
					AuthorPath=m.AuthorPath,
					Id=m.Id,
					HeaderPath=m.HeaderPath,
					PublishDate=m.PublishDate,
					Summary=m.Summary,
					ThumbnailPath=m.ThumbnailPath,
					Title=m.Title,
					Url=m.Url
				},cancellationToken: cancellationToken);
			}
			else
			{
				request.PageSize ??= 10;
				request.PageNumber ??= 1;
				IQueryable<PostSummary> query = uow.GetReadRepository<PostSummary>().GetQuery().Where(m=>m.IsPublished);
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

			response.Data = mapper.Map<GetPostsQueryResponse, PostSummary>(posts);
			return response;
		}
	}
}
