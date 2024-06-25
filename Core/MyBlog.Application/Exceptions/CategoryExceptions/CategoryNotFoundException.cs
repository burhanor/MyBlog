using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.CategoryExceptions
{
	public class CategoryNotFoundException:ApplicationException
	{
      
        public CategoryNotFoundException():base(Const.Category.CATEGORY_NOT_FOUND)
        {
            
        }
		public CategoryNotFoundException(string message):base(message)
		{

		}
	}
}
