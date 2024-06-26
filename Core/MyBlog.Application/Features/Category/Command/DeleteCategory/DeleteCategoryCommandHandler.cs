using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Features.Category.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Category.Command.DeleteCategory
{
	public class DeleteCategoryCommandHandler : BaseHandler<Domain.Entities.Category>, IRequestHandler<DeleteCategoryCommandRequest, ResponseContainer<DeleteCategoryCommandResponse>>
	{
		private readonly CategoryRules categoryRules;

		public DeleteCategoryCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,CategoryRules categoryRules) : base(uow, mapper, httpContextAccessor)
		{
			this.categoryRules = categoryRules;
		}

		public async Task<ResponseContainer<DeleteCategoryCommandResponse>> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<DeleteCategoryCommandResponse> response = new();
			Domain.Entities.Category? category = await readRepository.GetAsync(m => m.Id == request.Id, cancellationToken: cancellationToken);
			await categoryRules.CategoryNotFound(category);
			bool hasChild = await readRepository.ExistAsync(m => m.ParentId == request.Id, cancellationToken: cancellationToken);
			await categoryRules.CategoryHasChild(hasChild);
			await writeRepository.DeleteAsync(category, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			response.Success = true;
			return response;
		}
	}
}
