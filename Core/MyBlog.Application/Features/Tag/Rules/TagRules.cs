using MyBlog.Application.Commons.Rules;
using MyBlog.Application.Exceptions.TagExceptions;
using MyBlog.Application.Exceptions.CommonExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Tag.Rules
{
	public class TagRules:CommonRules
	{
		public async ValueTask TagNotFound(Domain.Entities.Tag? tag)
		{
			if (tag == null || tag.Id == 0)
			{
				throw new TagNotFoundException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask TagAlreadyExists(Domain.Entities.Tag? tag)
		{
			if (tag != null && tag.Id != 0)
			{
				throw new TagAlreadyExistException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask TagAlreadyExists(bool isExist)
		{
			if (isExist)
			{
				throw new TagAlreadyExistException();
			}
			await ValueTask.CompletedTask;
		}
		public async ValueTask DisplayOrderMustBePositive(int displayOrder)
		{
			if (displayOrder < 0)
				throw new DisplayOrderCannotBeNegativeException();
			await ValueTask.CompletedTask;
		}

	}
}
