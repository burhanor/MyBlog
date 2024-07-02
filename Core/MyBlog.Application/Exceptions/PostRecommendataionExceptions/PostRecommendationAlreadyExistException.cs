using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.PostRecommendataionExceptions
{
	public class PostRecommendationAlreadyExistException:ApplicationException
	{
		public PostRecommendationAlreadyExistException() : base(Const.PostRecommendation.POST_RECOMMENDATION_ALREADY_EXISTS)
		{

		}
		public PostRecommendationAlreadyExistException(string message) : base(message)
		{
		}
	}
}
