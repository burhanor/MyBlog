using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.CommonExceptions
{
	public class UrlMustBeUniqeuException:ApplicationException
	{
        public UrlMustBeUniqeuException():base(Const.Exception.URL_MUST_BE_UNIQUE)
        {
            
        }
        public UrlMustBeUniqeuException(string message):base(message)   
        {
            
        }
    }
}
