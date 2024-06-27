using MediatR;
using MyBlog.Application.Models;
using MyBlog.Application.Models.Menu;

namespace MyBlog.Application.Features.Menu.Command.CreateMenu
{
	public class CreateMenuCommandRequest:MenuModel,IRequest<ResponseContainer<CreateMenuCommandResponse>>
	{
	}
}
