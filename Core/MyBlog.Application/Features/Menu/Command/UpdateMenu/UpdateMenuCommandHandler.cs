using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Exceptions.MenuExceptions;
using MyBlog.Application.Features.Menu.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;

namespace MyBlog.Application.Features.Menu.Command.UpdateMenu
{
	public class UpdateMenuCommandHandler : BaseHandler<Domain.Entities.Menu>, IRequestHandler<UpdateMenuCommandRequest, ResponseContainer<UpdateMenuCommandResponse>>
	{
		private readonly MenuRules menuRules;

		public UpdateMenuCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,MenuRules menuRules) : base(uow, mapper, httpContextAccessor)
		{
			this.menuRules = menuRules;
		}

		public async Task<ResponseContainer<UpdateMenuCommandResponse>> Handle(UpdateMenuCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<UpdateMenuCommandResponse> response = new();
			await menuRules.DisplayOrderMustBePositive(request.DisplayOrder);
			Domain.Entities.Menu? menu = await readRepository.GetAsync(m => m.Id == request.Id, cancellationToken: cancellationToken);
			await menuRules.MenuNotFound(menu);
			bool isExist = await readRepository.ExistAsync(m => m.Name == request.Name && m.ParentId == request.ParentId && m.Id != request.Id, cancellationToken: cancellationToken);
			await menuRules.MenuAlreadyExists(isExist);
			await menuRules.MenuParentCannotBeSame(request.Id, request.ParentId);

			await CheckCircularReference(request.Id, request.ParentId, cancellationToken);

			string parentName = string.Empty;
			if (request.ParentId != 0)
			{
				Domain.Entities.Menu? parentMenu = await readRepository.GetAsync(m => m.Id == request.ParentId, cancellationToken: cancellationToken);
				await menuRules.ParentMenuNotFound(parentMenu);
				parentName = parentMenu.Name;
			}
			Domain.Entities.Menu newRecord = mapper.Map<Domain.Entities.Menu, UpdateMenuCommandRequest>(request);
			await writeRepository.UpdateAsync(newRecord);
			await uow.SaveChangesAsync(cancellationToken);

			response.Success = true;
			response.Data = mapper.Map<UpdateMenuCommandResponse,Domain.Entities.Menu>(newRecord);
			response.Data.ParentMenuName = parentName;
			return response;
		}

		private async ValueTask CheckCircularReference(int menuId, int parentId, CancellationToken cancellationToken)
		{
			if (parentId != 0)
			{
				IList<Tuple<int, int>> menuAndParentIds = await readRepository.GetAllAsyncAs(select: m => new Tuple<int, int>(m.Id, m.ParentId), cancellationToken: cancellationToken);
				menuAndParentIds ??= [];
				int currentParentId = parentId;
				List<int> parentIds = [menuId];
				while (currentParentId != 0)
				{
					currentParentId = menuAndParentIds.FirstOrDefault(m => m.Item1 == currentParentId)?.Item2 ?? 0;
					if (parentIds.Contains(currentParentId))
						throw new MenuCircularReferenceException();
					parentIds.Add(currentParentId);
				}
			}
			await ValueTask.CompletedTask;
		}

	}
}
