using MediatR;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;

namespace MyBlog.Application.Features.Menu.Queries.GetMenu
{
	public class GetMenuQueryRequest:IRequest<ResponseContainer<GetMenuQueryResponse>>,IId
	{
		public int Id { get; set; }
	}
}
