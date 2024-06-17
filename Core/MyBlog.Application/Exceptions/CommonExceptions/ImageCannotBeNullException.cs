using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.CommonExceptions
{
	public class ImageCannotBeNullException:BaseException
	{
        public ImageCannotBeNullException():base(Const.Exception.IMAGE_CANNOT_BE_NULL)
        {
            
        }
    }
}
