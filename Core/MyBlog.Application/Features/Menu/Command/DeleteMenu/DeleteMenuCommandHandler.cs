using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Features.Menu.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;

namespace MyBlog.Application.Features.Menu.Command.DeleteMenu
{
	public class DeleteMenuCommandHandler : BaseHandler<Domain.Entities.Menu>, IRequestHandler<DeleteMenuCommandRequest, ResponseContainer<Unit>>
	{
		private readonly MenuRules menuRules;

		public DeleteMenuCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,MenuRules menuRules) : base(uow, mapper, httpContextAccessor)
		{
			this.menuRules = menuRules;
		}

		public async Task<ResponseContainer<Unit>> Handle(DeleteMenuCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<Unit> response = new();
			Domain.Entities.Menu? menu = await readRepository.GetAsync(m => m.Id == request.Id, cancellationToken: cancellationToken);
			await menuRules.MenuNotFound(menu);
			bool hasChild = await readRepository.ExistAsync(m => m.ParentId == request.Id, cancellationToken: cancellationToken);
			await menuRules.MenuHasChild(hasChild);
			await writeRepository.DeleteAsync(menu, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			response.Success = true;
			return response;
		}
	}
}
