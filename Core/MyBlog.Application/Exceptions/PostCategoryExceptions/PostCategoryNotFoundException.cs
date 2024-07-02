using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.PostCategoryExceptions
{
	public class PostCategoryNotFoundException:ApplicationException
	{
		public PostCategoryNotFoundException() : base(Const.PostCategory.POST_CATEGORY_NOT_FOUND)
		{

		}
		public PostCategoryNotFoundException(string message) : base(message)
		{
		}
	}
}
