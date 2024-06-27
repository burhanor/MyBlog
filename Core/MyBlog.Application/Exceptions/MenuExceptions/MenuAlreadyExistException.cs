using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.MenuExceptions
{
	public class MenuAlreadyExistException:ApplicationException
	{
		public MenuAlreadyExistException() : base(Const.Menu.MENU_ALREADY_EXISTS) { }
		public MenuAlreadyExistException(string message):base(message)
		{
		}
	}
}
