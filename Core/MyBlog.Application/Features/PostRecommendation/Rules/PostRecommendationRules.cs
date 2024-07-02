using MyBlog.Application.Commons.Rules;
using MyBlog.Application.Exceptions.PostRecommendataionExceptions;

namespace MyBlog.Application.Features.PostRecommendationRecommendation.Rules
{
	public class PostRecommendationRules : CommonRules
	{
		public async ValueTask PostRecommendationNotFound(Domain.Entities.PostRecommendation? post)
		{
			if (post == null || post.PostId == 0)
			{
				throw new PostRecommendationNotFoundException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask PostRecommendationNotFound(bool isExist)
		{
			if (!isExist)
			{
				throw new PostRecommendationNotFoundException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask PostRecommendationAlreadyExists(Domain.Entities.PostRecommendation? post)
		{
			if (post != null && post.PostId != 0)
			{
				throw new PostRecommendationAlreadyExistException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask PostRecommendationAlreadyExists(bool isExist)
		{
			if (isExist)
			{
				throw new PostRecommendationAlreadyExistException();
			}
			await ValueTask.CompletedTask;
		}
	}
}
