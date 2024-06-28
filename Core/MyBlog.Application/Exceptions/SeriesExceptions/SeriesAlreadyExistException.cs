using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.SeriesExceptions
{
	public class SeriesAlreadyExistException :ApplicationException
	{
        public SeriesAlreadyExistException() :base(Const.Series.SERIES_ALREADY_EXISTS)
        {
            
        }
        public SeriesAlreadyExistException(string message) : base(message)
		{
		}
	}
}
