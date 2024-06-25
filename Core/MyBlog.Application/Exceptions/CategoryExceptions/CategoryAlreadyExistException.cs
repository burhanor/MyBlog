using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.CategoryExceptions
{
	public class CategoryAlreadyExistException:ApplicationException
	{
        public CategoryAlreadyExistException():base(Const.Category.CATEGORY_ALREADY_EXISTS)
        {
            
        }
        public CategoryAlreadyExistException(string message):base(message)
        {
            
        }
    }
}
