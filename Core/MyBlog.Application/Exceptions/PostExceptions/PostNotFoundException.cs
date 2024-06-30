using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.PostExceptions
{
	public class PostNotFoundException:ApplicationException
	{
        public PostNotFoundException():base(Const.Post.POST_NOT_FOUND)
        {
            
        }
        public PostNotFoundException(string message):base(message)
		{
			
		}
    }
}
