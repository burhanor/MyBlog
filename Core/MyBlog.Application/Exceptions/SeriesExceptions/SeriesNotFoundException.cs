using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.SeriesExceptions
{
	public class SeriesNotFoundException :ApplicationException
	{
		public SeriesNotFoundException() :base(Const.Series.SERIES_NOT_FOUND)
		{
			
		}
		public SeriesNotFoundException(string message) : base(message)
		{
		}
	}
}
