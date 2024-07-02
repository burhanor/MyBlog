using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Features.Category.Rules;
using MyBlog.Application.Features.Post.Rules;
using MyBlog.Application.Features.PostCategory.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostCategory.Command.CreatePostCategory
{
	public class CreatePostCategoryCommandHandler : BaseHandler<Domain.Entities.PostCategory>, IRequestHandler<CreatePostCategoryCommandRequest, ResponseContainer<CreatePostCategoryCommandResponse>>
	{
		private readonly PostCategoryRules postCategoryRules;
		private readonly PostRules postRules;
		private readonly CategoryRules categoryRules;

		public CreatePostCategoryCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,PostCategoryRules postCategoryRules,PostRules postRules,CategoryRules categoryRules) : base(uow, mapper, httpContextAccessor)
		{
			this.postCategoryRules = postCategoryRules;
			this.postRules = postRules;
			this.categoryRules = categoryRules;
		}

		public async Task<ResponseContainer<CreatePostCategoryCommandResponse>> Handle(CreatePostCategoryCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<CreatePostCategoryCommandResponse> response = new();
			bool postIsExist = await uow.GetReadRepository<Domain.Entities.Post>().ExistAsync(x => x.Id == request.PostId,cancellationToken);
			await postRules.PostNotFound(postIsExist);
			Domain.Entities.Category category = await uow.GetReadRepository<Domain.Entities.Category>().GetAsync(predicate:x => x.Id == request.CategoryId,cancellationToken:cancellationToken,select:m=>new Domain.Entities.Category
			{
				Name=m.Name,
				Id=request.CategoryId
			});
			await categoryRules.CategoryNotFound(category);
			bool postCategoryIsExist = await readRepository.ExistAsync(m => m.PostId == request.PostId && m.CategoryId == request.CategoryId, cancellationToken);
			await postCategoryRules.PostCategoryAlreadyExists(postCategoryIsExist);
			Domain.Entities.PostCategory postCategory = mapper.Map<Domain.Entities.PostCategory, CreatePostCategoryCommandRequest>(request);
			await writeRepository.AddAsync(postCategory, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			response.Success = true;
			response.Message = Const.PostCategory.POST_CATEGORY_CREATED;
			response.Data=new CreatePostCategoryCommandResponse
			{
				CategoryName = category.Name ,
			};

			return response;
		}
	}
}
