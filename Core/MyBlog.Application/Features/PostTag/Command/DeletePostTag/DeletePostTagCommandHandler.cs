using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Features.PostTag.Command.DeletePostTag;
using MyBlog.Application.Features.PostTag.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.Repositories;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostTag.Command.DeletePostTag
{
	public class DeletePostTagCommandHandler : BaseHandler<Domain.Entities.PostTag>, IRequestHandler<DeletePostTagCommandRequest, ResponseContainer<Unit>>
	{
		private readonly PostTagRules postTagRules;

		public DeletePostTagCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor, PostTagRules postTagRules) : base(uow, mapper, httpContextAccessor)
		{
			this.postTagRules = postTagRules;
		}

		public async Task<ResponseContainer<Unit>> Handle(DeletePostTagCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<Unit> response = new();
			Domain.Entities.PostTag? postCategories = await readRepository.GetAsync(m => m.TagId == request.TagId && m.PostId == request.PostId, cancellationToken: cancellationToken);
			await postTagRules.PostTagNotFound(postCategories);
			await writeRepository.DeleteAsync(postCategories, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			response.Success = true;
			response.Message = Const.PostTag.POST_TAG_DELETED;
			return response;
		}
	}
}
