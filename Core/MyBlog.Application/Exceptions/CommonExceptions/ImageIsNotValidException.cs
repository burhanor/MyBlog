using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.CommonExceptions
{
	public class ImageIsNotValidException:BaseException
	{
        public ImageIsNotValidException():base(Const.Exception.IMAGE_IS_NOT_VALID)
        {
            
        }
    }
}
