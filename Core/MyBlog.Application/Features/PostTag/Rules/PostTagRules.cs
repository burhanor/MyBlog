using MyBlog.Application.Commons.Rules;
using MyBlog.Application.Exceptions.PostTagExceptions;

namespace MyBlog.Application.Features.PostTag.Rules
{
	public class PostTagRules:CommonRules
	{
		public async ValueTask PostTagNotFound(Domain.Entities.PostTag? postTag)
		{
			if (postTag == null || postTag.TagId == 0)
			{
				throw new PostTagNotFoundException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask PostTagAlreadyExists(Domain.Entities.PostTag? postTag)
		{
			if (postTag != null && postTag.TagId != 0)
			{
				throw new PostTagAlreadyExistException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask PostTagAlreadyExists(bool isExist)
		{
			if (isExist)
			{
				throw new PostTagAlreadyExistException();
			}
			await ValueTask.CompletedTask;
		}
	}
}
