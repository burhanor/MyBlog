using MediatR;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using MyBlog.Application.Models.Menu;

namespace MyBlog.Application.Features.Menu.Command.UpdateMenu
{
	public class UpdateMenuCommandRequest:MenuModel,IRequest<ResponseContainer<UpdateMenuCommandResponse>>,IId	
	{
		public int Id { get; set; }
	}
}
