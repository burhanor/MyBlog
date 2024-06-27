using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.TagExceptions
{
	public class TagNotFoundException:ApplicationException
	{
        public TagNotFoundException():base(Const.Tag.TAG_NOT_FOUND)
        {
            
        }
        public TagNotFoundException(string message):base(message)
		{
			
		}
    }
}
