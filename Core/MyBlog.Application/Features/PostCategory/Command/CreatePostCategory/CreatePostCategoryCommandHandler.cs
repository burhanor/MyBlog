using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
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

		public CreatePostCategoryCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,PostCategoryRules postCategoryRules) : base(uow, mapper, httpContextAccessor)
		{
			this.postCategoryRules = postCategoryRules;
		}

		public async Task<ResponseContainer<CreatePostCategoryCommandResponse>> Handle(CreatePostCategoryCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<CreatePostCategoryCommandResponse> response = new();
			return response;
		}
	}
}
