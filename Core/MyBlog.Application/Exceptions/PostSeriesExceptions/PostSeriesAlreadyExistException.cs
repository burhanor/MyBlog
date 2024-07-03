using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.PostSeriesExceptions
{
	public class PostSeriesAlreadyExistException:ApplicationException
	{
		public PostSeriesAlreadyExistException() : base(Const.PostSeries.POST_SERIES_ALREADY_EXISTS)
		{

		}
		public PostSeriesAlreadyExistException(string message) : base(message)
		{
		}
	}
}
