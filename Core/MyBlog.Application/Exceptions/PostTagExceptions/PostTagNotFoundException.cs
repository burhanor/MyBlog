using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.PostTagExceptions
{
	public class PostTagNotFoundException:ApplicationException
	{
		public PostTagNotFoundException() : base(Const.PostTag.POST_TAG_NOT_FOUND)
		{

		}
		public PostTagNotFoundException(string message) : base(message)
		{
		}
	}
}
