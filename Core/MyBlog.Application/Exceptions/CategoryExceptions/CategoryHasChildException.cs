using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.CategoryExceptions
{
	public class CategoryHasChildException:ApplicationException
	{
        public CategoryHasChildException():base(Const.Category.CATEGORY_HAS_CHILD)
        {
            
        }
        public CategoryHasChildException(string message):base(message)
        {
            
        }
    }
}
