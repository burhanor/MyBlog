using MyBlog.Application.Commons.Rules;
using MyBlog.Application.Exceptions.CardExceptions;
using MyBlog.Application.Exceptions.PostExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Post.Rules
{
	public class PostRules:CommonRules
	{

		public async ValueTask PostNotFound(Domain.Entities.Post? post)
		{
			if (post == null || post.Id == 0)
			{
				throw new PostNotFoundException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask PostNotFound(bool isExist)
		{
			if (!isExist)
			{
				throw new PostNotFoundException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask PostAlreadyExists(Domain.Entities.Post? post)
		{
			if (post != null && post.Id != 0)
			{
				throw new PostAlreadyExistException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask PostAlreadyExists(bool isExist)
		{
			if (isExist)
			{
				throw new PostAlreadyExistException();
			}
			await ValueTask.CompletedTask;
		}

	}
}
