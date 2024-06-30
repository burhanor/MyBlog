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
			return response;
		}
	}
}
