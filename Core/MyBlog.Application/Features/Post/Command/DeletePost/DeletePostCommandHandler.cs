using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Features.Post.Rules;
using MyBlog.Application.Features.Post.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Post.Command.DeletePost
{
	public class DeletePostCommandHandler : BaseHandler<Domain.Entities.Post>, IRequestHandler<DeletePostCommandRequest, ResponseContainer<Unit>>
	{
		private readonly PostRules postRules;

		public DeletePostCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,PostRules postRules) : base(uow, mapper, httpContextAccessor)
		{
			this.postRules = postRules;
		}

		public async Task<ResponseContainer<Unit>> Handle(DeletePostCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<Unit> response= new();
			Domain.Entities.Post? post = await readRepository.GetAsync(m => m.Id == request.Id, cancellationToken: cancellationToken);
			await postRules.PostNotFound(post);
			await writeRepository.DeleteAsync(post, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			response.Success = true;
			response.Message = Const.Post.POST_DELETED;
			return response;
		}
	}
}
