using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Features.Menu.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;

namespace MyBlog.Application.Features.Menu.Command.CreateMenu
{
	public class CreateMenuCommandHandler : BaseHandler<Domain.Entities.Menu>, IRequestHandler<CreateMenuCommandRequest, ResponseContainer<CreateMenuCommandResponse>>
	{
		private readonly MenuRules menuRules;

		public CreateMenuCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,MenuRules menuRules) : base(uow, mapper, httpContextAccessor)
		{
			this.menuRules = menuRules;
		}

		public async Task<ResponseContainer<CreateMenuCommandResponse>> Handle(CreateMenuCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<CreateMenuCommandResponse> response = new();
			await menuRules.DisplayOrderMustBePositive(request.DisplayOrder);
			Domain.Entities.Menu? menu = await readRepository.GetAsync(m => m.Name == request.Name && m.ParentId == request.ParentId, cancellationToken: cancellationToken);
			await menuRules.MenuAlreadyExists(menu);
	

			string parentName = string.Empty;
			if (request.ParentId != 0)
			{
				Domain.Entities.Menu? parentMenu = await readRepository.GetAsync(m => m.Id == request.ParentId, cancellationToken: cancellationToken);
				await menuRules.ParentMenuNotFound(parentMenu);
				parentName = parentMenu.Name;
			}

			menu = mapper.Map<Domain.Entities.Menu, CreateMenuCommandRequest>(request);
			await writeRepository.AddAsync(menu, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			response.Data = mapper.Map<CreateMenuCommandResponse, Domain.Entities.Menu>(menu);
			response.Data.ParentMenuName=parentName;	
			response.Success = true;

			return response;
		}
	}
}
