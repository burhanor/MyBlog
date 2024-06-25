using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.CategoryExceptions
{
	public class CategoryParentCannotBeSameException:ApplicationException
	{
		public CategoryParentCannotBeSameException():base(Const.Category.CATEGORY_PARENT_CANNOT_BE_SAME)
		{
			
		}
		public CategoryParentCannotBeSameException(string message):base(message)
		{
			
		}
	}
}
