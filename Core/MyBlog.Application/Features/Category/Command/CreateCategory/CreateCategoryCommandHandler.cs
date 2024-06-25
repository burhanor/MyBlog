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

namespace MyBlog.Application.Features.Category.Command.CreateCategory
{
	public class CreateCategoryCommandHandler : BaseHandler<Domain.Entities.Category>, IRequestHandler<CreateCategoryCommandRequest, ResponseContainer<CreateCategoryCommandResponse>>
	{
		private readonly CategoryRules categoryRules;

		public CreateCategoryCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,CategoryRules categoryRules) : base(uow, mapper, httpContextAccessor)
		{
			this.categoryRules = categoryRules;
		}

		public async Task<ResponseContainer<CreateCategoryCommandResponse>> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<CreateCategoryCommandResponse> response = new();
			await categoryRules.DisplayOrderMustBePositive(request.DisplayOrder);
			Domain.Entities.Category? category = await readRepository.GetAsync(m => m.Name == request.Name && m.ParentId == request.ParentId, cancellationToken: cancellationToken);
			await categoryRules.CategoryAlreadyExists(category);
			if (request.ParentId != 0)
			{
				Domain.Entities.Category? parentCategory = await readRepository.GetAsync(m => m.Id == request.ParentId, cancellationToken: cancellationToken);
				await categoryRules.ParentCategoryNotFound(parentCategory);
			}
		    category = mapper.Map<Domain.Entities.Category,CreateCategoryCommandRequest>(request);
			await writeRepository.AddAsync(category, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			response.Data = new CreateCategoryCommandResponse { Id = category.Id };
			response.Success = true;
			return response;
		}
	}
}
