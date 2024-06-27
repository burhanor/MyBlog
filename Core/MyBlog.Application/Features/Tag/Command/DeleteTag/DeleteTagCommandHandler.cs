using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Features.Category.Rules;
using MyBlog.Application.Features.Tag.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Tag.Command.DeleteTag
{
	public class DeleteTagCommandHandler : BaseHandler<Domain.Entities.Tag>, IRequestHandler<DeleteTagCommandRequest, ResponseContainer<Unit>>
	{
		private readonly TagRules tagRules;

		public DeleteTagCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,TagRules tagRules) : base(uow, mapper, httpContextAccessor)
		{
			this.tagRules = tagRules;
		}

		public async Task<ResponseContainer<Unit>> Handle(DeleteTagCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<Unit> response= new();
			Domain.Entities.Tag? tag = await readRepository.GetAsync(m => m.Id == request.Id, cancellationToken: cancellationToken);
			await tagRules.TagNotFound(tag);
			await writeRepository.DeleteAsync(tag, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			response.Success = true;
			return response;
		}
	}
}
