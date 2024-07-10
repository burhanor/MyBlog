using MediatR;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;

namespace MyBlog.Application.Features.Menu.Queries.GetMenu
{
	public class GetMenuQueryRequest:IRequest<ResponseContainer<GetMenuQueryResponse>>,IId
	{
        public GetMenuQueryRequest()
        {
            
        }
        public GetMenuQueryRequest(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
	}
}
