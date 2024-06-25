using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.CommonExceptions
{
	public class DisplayOrderCannotBeNegativeException:ApplicationException
	{
        public DisplayOrderCannotBeNegativeException():base(Const.Exception.DISPLAY_ORDER_MUST_BE_GREATER_THAN_ZERO)
        {
            
        }
        public DisplayOrderCannotBeNegativeException(string message):base(message)  
        {
            
        }
    }
}
