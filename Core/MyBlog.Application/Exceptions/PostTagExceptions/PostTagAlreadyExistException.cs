using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.PostTagExceptions
{
	public class PostTagAlreadyExistException:ApplicationException
	{
		public PostTagAlreadyExistException() : base(Const.PostTag.POST_TAG_ALREADY_EXISTS)
		{

		}
		public PostTagAlreadyExistException(string message) : base(message)
		{
		}
	}
}
