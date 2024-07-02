using MyBlog.Application.Commons.Rules;
using MyBlog.Application.Exceptions.PostCategoryExceptions;
using MyBlog.Application.Exceptions.PostExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostCategory.Rules
{
	public class PostCategoryRules:CommonRules
	{
		public async ValueTask PostCategoryNotFound(Domain.Entities.PostCategory? postCategory)
		{
			if (postCategory == null || postCategory.CategoryId == 0)
			{
				throw new PostCategoryNotFoundException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask PostCategoryAlreadyExists(Domain.Entities.PostCategory? postCategory)
		{
			if (postCategory != null && postCategory.CategoryId != 0)
			{
				throw new PostCategoryAlreadyExistException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask PostCategoryAlreadyExists(bool isExist)
		{
			if (isExist)
			{
				throw new PostCategoryAlreadyExistException();
			}
			await ValueTask.CompletedTask;
		}
	}
}
