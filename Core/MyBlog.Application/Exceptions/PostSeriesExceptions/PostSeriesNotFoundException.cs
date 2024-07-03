using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.PostSeriesExceptions
{
	public class PostSeriesNotFoundException:ApplicationException
	{
		public PostSeriesNotFoundException() : base(Const.PostSeries.POST_SERIES_NOT_FOUND)
		{

		}
		public PostSeriesNotFoundException(string message) : base(message)
		{
		}
	}
}
