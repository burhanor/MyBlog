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

namespace MyBlog.Application.Features.PostCategory.Queries.GetPostCategory
{
	public class GetPostCategoryQueryHandler : BaseHandler, IRequestHandler<GetPostCategoryQueryRequest, ResponseContainer<GetPostCategoryQueryResponse>>
	{
		public GetPostCategoryQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor) : base(uow, mapper, httpContextAccessor)
		{
		}

		public async Task<ResponseContainer<GetPostCategoryQueryResponse>> Handle(GetPostCategoryQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<GetPostCategoryQueryResponse> response = new();
			return response;
		}
	}
}
