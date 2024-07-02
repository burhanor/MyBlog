using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.PostCategoryExceptions
{
	public class PostCategoryAlreadyExistException:ApplicationException
	{
        public PostCategoryAlreadyExistException():base(Const.PostCategory.POST_CATEGORY_ALREADY_EXISTS)
        {
            
        }
        public PostCategoryAlreadyExistException(string message):base(message)
		{
		}
	}
}
