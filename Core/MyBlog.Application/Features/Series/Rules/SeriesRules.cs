using MyBlog.Application.Commons.Rules;
using MyBlog.Application.Exceptions.PostExceptions;
using MyBlog.Application.Exceptions.SeriesExceptions;

namespace MyBlog.Application.Features.Series.Rules
{
	public class SeriesRules :CommonRules
	{
		public async ValueTask SeriesNotFound(Domain.Entities.Series? series)
		{
			if (series == null || series.Id == 0)
			{
				throw new SeriesNotFoundException();
			}
			await ValueTask.CompletedTask;
		}
		public async ValueTask SeriesNotFound(bool isExist)
		{
			if (!isExist)
			{
				throw new SeriesNotFoundException();
			}
			await ValueTask.CompletedTask;
		}
		public async ValueTask SeriesAlreadyExists(Domain.Entities.Series? series)
		{
			if (series != null && series.Id != 0)
			{
				throw new SeriesAlreadyExistException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask SeriesAlreadyExists(bool isExist)
		{
			if (isExist)
			{
				throw new SeriesAlreadyExistException();
			}
			await ValueTask.CompletedTask;
		}
	}
}
