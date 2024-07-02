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

namespace MyBlog.Application.Features.PostCategory.Queries.GetPostCategories
{
	public class GetPostCategoriesQueryHandler : BaseHandler, IRequestHandler<GetPostCategoriesQueryRequest, ResponseContainer<IList<GetPostCategoriesQueryResponse>>>
	{
		public GetPostCategoriesQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor) : base(uow, mapper, httpContextAccessor)
		{
		}

		public async Task<ResponseContainer<IList<GetPostCategoriesQueryResponse>>> Handle(GetPostCategoriesQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<IList<GetPostCategoriesQueryResponse>> response = new();
			return response;
		}
	}
}
