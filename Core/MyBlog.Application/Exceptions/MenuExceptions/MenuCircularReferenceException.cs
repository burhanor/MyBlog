using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.MenuExceptions
{
	public class MenuCircularReferenceException : ApplicationException
	{
		public MenuCircularReferenceException() : base(Const.Menu.MENU_CIRCULAR_REFERENCE) { }
		public MenuCircularReferenceException(string message) : base(message)
		{
		}
	}
}
