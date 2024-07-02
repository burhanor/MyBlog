using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Features.PostCategory.Rules;
using MyBlog.Application.Features.Series.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostCategory.Command.DeletePostCategory
{
	public class DeletePostCategoryCommandHandler : BaseHandler<Domain.Entities.PostCategory>, IRequestHandler<DeletePostCategoryCommandRequest, ResponseContainer<Unit>>
	{
		private readonly PostCategoryRules postCategoryRules;

		public DeletePostCategoryCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,PostCategoryRules postCategoryRules) : base(uow, mapper, httpContextAccessor)
		{
			this.postCategoryRules = postCategoryRules;
		}

		public async Task<ResponseContainer<Unit>> Handle(DeletePostCategoryCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<Unit> response = new();
			Domain.Entities.PostCategory? postCategories = await readRepository.GetAsync(m => m.CategoryId == request.CategoryId && m.PostId==request.PostId, cancellationToken: cancellationToken);
			await postCategoryRules.PostCategoryNotFound(postCategories);
			await writeRepository.DeleteAsync(postCategories, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			response.Success = true;
			response.Message = Const.PostCategory.POST_CATEGORY_DELETED;
			return response;
		}
	}
}
