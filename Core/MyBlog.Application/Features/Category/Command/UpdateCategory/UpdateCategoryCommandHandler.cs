using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Exceptions.CategoryExceptions;
using MyBlog.Application.Features.Category.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Category.Command.UpdateCategory
{
	public class UpdateCategoryCommandHandler : BaseHandler<Domain.Entities.Category>, IRequestHandler<UpdateCategoryCommandRequest, ResponseContainer<UpdateCategoryCommandResponse>>
	{
		private readonly CategoryRules categoryRules;

		public UpdateCategoryCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,CategoryRules categoryRules) : base(uow, mapper, httpContextAccessor)
		{
			this.categoryRules = categoryRules;
		}

		public async Task<ResponseContainer<UpdateCategoryCommandResponse>> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<UpdateCategoryCommandResponse> response=new();
			await categoryRules.DisplayOrderMustBePositive(request.DisplayOrder);
			Domain.Entities.Category? category = await readRepository.GetAsync(m => m.Id == request.Id, cancellationToken: cancellationToken);
			await categoryRules.CategoryNotFound(category);
			bool isExist = await readRepository.ExistAsync(m => m.Name == request.Name && m.ParentId == request.ParentId && m.Id != request.Id, cancellationToken: cancellationToken);
			await categoryRules.CategoryAlreadyExists(isExist);
			await categoryRules.CategoryParentCannotBeSame(request.Id,request.ParentId);
			bool urlIsExist = await readRepository.ExistAsync(m => m.Url == request.Url && m.Id != request.Id, cancellationToken: cancellationToken);
			await categoryRules.UrlMustBeUnique(urlIsExist);
			await CheckCircularReference(request.Id,request.ParentId,cancellationToken);

			string parentName = string.Empty;
			if (request.ParentId != 0)
			{
				Domain.Entities.Category? parentCategory = await readRepository.GetAsync(m => m.Id == request.ParentId, cancellationToken: cancellationToken);
				await categoryRules.ParentCategoryNotFound(parentCategory);
				parentName = parentCategory.Name;
			}

			await writeRepository.UpdateAsync(mapper.Map<Domain.Entities.Category,UpdateCategoryCommandRequest>(request));
			await uow.SaveChangesAsync(cancellationToken);

			response.Success = true;
			response.Data= new UpdateCategoryCommandResponse { ParentName = parentName };
			return response;
		}

		private async ValueTask CheckCircularReference(int categoryId,int parentId,CancellationToken cancellationToken)
		{
			if (parentId != 0)
			{
				IList<Tuple<int, int>> categoryAndParentIds = await readRepository.GetAllAsyncAs(select: m => new Tuple<int, int>(m.Id, m.ParentId), cancellationToken: cancellationToken);
				categoryAndParentIds??=[];
				int currentParentId = parentId;
				List<int> parentIds= [categoryId];
				while (currentParentId != 0)
				{
					currentParentId = categoryAndParentIds.FirstOrDefault(m => m.Item1 == currentParentId)?.Item2 ?? 0;
					if (parentIds.Contains(currentParentId))
						throw new CategoryCircularReferenceException();
					parentIds.Add(currentParentId);
				}
			}
			await ValueTask.CompletedTask;
		}

		

		
	}
}
