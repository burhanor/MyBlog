using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.PostExceptions
{
	public class PostAlreadyExistException:ApplicationException
	{
		public PostAlreadyExistException():base(Const.Post.POST_ALREADY_EXISTS)
		{
			
		}
		public PostAlreadyExistException(string message):base(message)
		{
			
		}
	}
}
