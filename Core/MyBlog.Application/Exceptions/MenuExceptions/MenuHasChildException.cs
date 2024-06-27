using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.MenuExceptions
{
	public class MenuHasChildException : ApplicationException
	{
		public MenuHasChildException() : base(Const.Menu.MENU_HAS_CHILD) { }
		public MenuHasChildException(string message) : base(message)
		{
		}
	}
}
