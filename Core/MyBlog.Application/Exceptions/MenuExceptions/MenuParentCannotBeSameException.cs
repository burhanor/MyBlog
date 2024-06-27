using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.MenuExceptions
{
	public class MenuParentCannotBeSameException : ApplicationException
	{
		public MenuParentCannotBeSameException() : base(Const.Menu.MENU_PARENT_CANNOT_BE_SAME) { }
		public MenuParentCannotBeSameException(string message) : base(message)
		{
		}
	}
}
