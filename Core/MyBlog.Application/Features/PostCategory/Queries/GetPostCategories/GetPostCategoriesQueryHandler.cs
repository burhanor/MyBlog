using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Application.Features.Post.Rules;

namespace MyBlog.Application.Features.PostCategory.Queries.GetPostCategories
{
	public class GetPostCategoriesQueryHandler : BaseHandler, IRequestHandler<GetPostCategoriesQueryRequest, ResponseContainer<IList<GetPostCategoriesQueryResponse>>>
	{
		private readonly PostRules postRules;

		public GetPostCategoriesQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,PostRules postRules) : base(uow, mapper, httpContextAccessor)
		{
			this.postRules = postRules;
		}

		public async Task<ResponseContainer<IList<GetPostCategoriesQueryResponse>>> Handle(GetPostCategoriesQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<IList<GetPostCategoriesQueryResponse>> response = new();
			bool postIsExist = await uow.GetReadRepository<Domain.Entities.Post>().ExistAsync(x => x.Id == request.PostId, cancellationToken);
			await postRules.PostNotFound(postIsExist);
			IList<Domain.Entities.PostCategory> postCategories = await uow.GetReadRepository<Domain.Entities.PostCategory>().GetAllAsync(predicate: x => x.PostId == request.PostId,include:m=>m.Include(s=>s.Category), cancellationToken: cancellationToken);
			response.Success = true;
			response.Data = postCategories.Select(m => new GetPostCategoriesQueryResponse
			{
				CategoryName=m.Category.Name,
			}).ToList();
			return response;
		}
	}
}
