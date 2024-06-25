using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.CategoryExceptions
{
	public class ParentCategoryNotFoundException:ApplicationException
	{
        public ParentCategoryNotFoundException():base(Const.Category.PARENT_CATEGORY_NOT_FOUND)
        {
            
        }
        public ParentCategoryNotFoundException(string message):base(message)
        {
            
        }
    }
}
