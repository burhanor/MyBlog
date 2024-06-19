using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Features.Author.Command.CreateAuthor;
using MyBlog.Application.Features.Author.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Author.Command.DeleteAuthor
{
	public class DeleteAuthorCommandHandler : BaseHandler<Domain.Entities.Author>, IRequestHandler<DeleteAuthorCommandRequest, ResponseContainer<Unit>>
	{
		private readonly AuthorRules authorRules;

		public DeleteAuthorCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,AuthorRules authorRules) : base(uow, mapper, httpContextAccessor)
		{
			this.authorRules = authorRules;
		}

		public async Task<ResponseContainer<Unit>> Handle(DeleteAuthorCommandRequest request, CancellationToken cancellationToken)
		{
			Domain.Entities.Author? author = await readRepository.GetAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
			await authorRules.UserNotFound(author);
			await writeRepository.DeleteAsync(author, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			return new ResponseContainer<Unit> { Success = true, Message = Const.Author.AUTHOR_DELETED };
		}
	}
}
