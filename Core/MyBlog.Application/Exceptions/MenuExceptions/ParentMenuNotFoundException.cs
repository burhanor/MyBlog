using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.MenuExceptions
{
	public class ParentMenuNotFoundException : ApplicationException
	{
		public ParentMenuNotFoundException() : base(Const.Menu.PARENT_MENU_NOT_FOUND) { }
		public ParentMenuNotFoundException(string message) : base(message)
		{
		}
	}
}
