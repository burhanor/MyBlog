using MyBlog.Application.Commons.Rules;
using MyBlog.Application.Exceptions.PostRecommendataionExceptions;
using MyBlog.Application.Exceptions.PostSeriesExceptions;

namespace MyBlog.Application.Features.PostSeries.Rules
{
	public class PostSeriesRules:CommonRules
	{
		public async ValueTask PostSeriesNotFound(Domain.Entities.PostSeries? postSeries)
		{
			if (postSeries == null || postSeries.PostId == 0)
			{
				throw new PostSeriesNotFoundException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask PostSeriesNotFound(bool isExist)
		{
			if (!isExist)
			{
				throw new PostSeriesNotFoundException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask PostSeriesAlreadyExists(Domain.Entities.PostSeries? postSeries)
		{
			if (postSeries != null && postSeries.PostId != 0)
			{
				throw new PostSeriesAlreadyExistException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask PostSeriesAlreadyExists(bool isExist)
		{
			if (isExist)
			{
				throw new PostRecommendationAlreadyExistException();
			}
			await ValueTask.CompletedTask;
		}
	}
}
