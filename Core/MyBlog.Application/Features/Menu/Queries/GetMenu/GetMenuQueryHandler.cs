using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Views;

namespace MyBlog.Application.Features.Menu.Queries.GetMenu
{
	public class GetMenuQueryHandler : BaseHandler,IRequestHandler<GetMenuQueryRequest, ResponseContainer<GetMenuQueryResponse>>
	{
		public GetMenuQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor) : base(uow, mapper, httpContextAccessor)
		{
		}

		public async Task<ResponseContainer<GetMenuQueryResponse>> Handle(GetMenuQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<GetMenuQueryResponse> response = new();
			MenuWithParentName menu = await uow.GetReadRepository<MenuWithParentName>().GetAsync(m => m.Id == request.Id, cancellationToken: cancellationToken);
			if (menu != null && menu.Id > 0)
			{
				response.Success = true;
				response.Data = mapper.Map<GetMenuQueryResponse, MenuWithParentName>(menu);
			}
			return response;
		}
	}
}
