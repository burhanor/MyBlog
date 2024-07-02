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

namespace MyBlog.Application.Features.PostCategory.Command.UpdatePostCategory
{
	public class UpdatePostCategoryCommandHandler : BaseHandler<Domain.Entities.PostCategory>, IRequestHandler<UpdatePostCategoryCommandRequest, ResponseContainer<UpdatePostCategoryCommandResponse>>
	{
		private readonly PostCategoryRules postCategoryRules;

		public UpdatePostCategoryCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,PostCategoryRules postCategoryRules) : base(uow, mapper, httpContextAccessor)
		{
			this.postCategoryRules = postCategoryRules;
		}

		public async Task<ResponseContainer<UpdatePostCategoryCommandResponse>> Handle(UpdatePostCategoryCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<UpdatePostCategoryCommandResponse> response = new();
			return response;
		}
	}
}
