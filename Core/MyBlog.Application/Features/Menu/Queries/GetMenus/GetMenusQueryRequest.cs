using MediatR;
using MyBlog.Application.Models;

namespace MyBlog.Application.Features.Menu.Queries.GetMenus
{
	public class GetMenusQueryRequest:FilterModel,IRequest<ResponseContainer<IList<GetMenusQueryResponse>>>
	{

	}
}
