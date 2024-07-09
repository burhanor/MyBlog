using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Post.Queries.GetPostViewCount
{
	public class GetPostViewCountQueryHandler : BaseHandler, IRequestHandler<GetPostViewCountQueryRequest, ResponseContainer<GetPostViewCountQueryResponse>>
	{
		public GetPostViewCountQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor) : base(uow, mapper, httpContextAccessor)
		{
		}

		public async Task<ResponseContainer<GetPostViewCountQueryResponse>> Handle(GetPostViewCountQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<GetPostViewCountQueryResponse> response = new();
			int viewCount = uow.GetScalarFunction().GetPostViewCount(request.Id);
			response.Success = true;
			response.Data= new GetPostViewCountQueryResponse()
			{
				ViewCount = viewCount
			};
			return response;

		}
	}
}
