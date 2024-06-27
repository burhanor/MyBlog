using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.TagExceptions
{
	public class TagAlreadyExistException:ApplicationException
	{
        public TagAlreadyExistException():base(Const.Tag.TAG_ALREADY_EXISTS)
		{
			
		}
        public TagAlreadyExistException(string message):base(message)
        {
            
        }
    }
}
