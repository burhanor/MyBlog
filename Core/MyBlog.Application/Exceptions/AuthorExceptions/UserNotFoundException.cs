using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.AuthorExceptions
{
	public class UserNotFoundException:BaseException
	{
        public UserNotFoundException():base(Const.Author.AUTHOR_NOT_FOUND)
        {
            
        }
    }
}
