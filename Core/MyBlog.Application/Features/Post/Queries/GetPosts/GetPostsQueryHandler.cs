using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Features.Post.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
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
			return response;
		}
	}
}
