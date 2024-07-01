using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
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

namespace MyBlog.Application.Features.Post.Queries.GetPost
{
	public class GetPostQueryHandler : BaseHandler, IRequestHandler<GetPostQueryRequest, ResponseContainer<GetPostQueryResponse>>
	{
		private readonly PostRules postRules;

		public GetPostQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,PostRules postRules) : base(uow, mapper, httpContextAccessor)
		{
			this.postRules = postRules;
		}

		public async Task<ResponseContainer<GetPostQueryResponse>> Handle(GetPostQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<GetPostQueryResponse> response = new();
			PostSummary posts = await uow.GetReadRepository<PostSummary>().GetAsync(m => m.Id == request.Id, cancellationToken: cancellationToken);
			if (posts != null && posts.Id > 0)
			{
				response.Success = true;
				response.Data = mapper.Map<GetPostQueryResponse, PostSummary>(posts);
			}
			return response;
		}
	}
}
