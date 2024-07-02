using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.PostRecommendataionExceptions
{
	public class PostRecommendationNotFoundException:ApplicationException
	{
        public PostRecommendationNotFoundException():base(Const.PostRecommendation.POST_RECOMMENDATION_NOT_FOUND)
        {
            
        }
        public PostRecommendationNotFoundException(string message):base(message)
		{
		}
	}
}
