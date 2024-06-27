using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Features.Category.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Category.Queries.GetCategory
{
	public class GetCategoryQueryHandler : BaseHandler, IRequestHandler<GetCategoryQueryRequest, ResponseContainer<GetCategoryQueryResponse>>
	{
		public GetCategoryQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor) : base(uow, mapper, httpContextAccessor)
		{
		}

		public async Task<ResponseContainer<GetCategoryQueryResponse>> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<GetCategoryQueryResponse> response = new();
			CategoryWithParentName category = await uow.GetReadRepository<CategoryWithParentName>().GetAsync(m => m.Id == request.Id, cancellationToken: cancellationToken);
			if (category!=null && category.Id>0)
			{
				response.Success = true;
				response.Data = mapper.Map<GetCategoryQueryResponse, CategoryWithParentName>(category);
			}
			return response;

		}
	}
}
