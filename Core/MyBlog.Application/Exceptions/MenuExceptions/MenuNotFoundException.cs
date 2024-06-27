using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.MenuExceptions
{
	public class MenuNotFoundException : ApplicationException
	{
		public MenuNotFoundException() : base(Const.Menu.MENU_NOT_FOUND) { }
		public MenuNotFoundException(string message) : base(message)
		{
		}
	}
}
