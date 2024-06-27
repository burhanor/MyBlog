using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Exceptions.CommonExceptions;
using MyBlog.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Commons.Rules
{
	public class CommonRules:BaseRules
	{
		public  ValueTask UrlMustBeUnique(bool urlIsExists)
		{
			if (urlIsExists)
				throw new UrlMustBeUniqeuException();
			return ValueTask.CompletedTask;
		}
		public async ValueTask DisplayOrderMustBePositive(int displayOrder)
		{
			if (displayOrder < 0)
				throw new DisplayOrderCannotBeNegativeException();
			await ValueTask.CompletedTask;
		}
		public async ValueTask ValidateImage(IFormFile? file)
		{

			if (file == null)
				throw new ImageCannotBeNullException();
			if (!file.IsImage())
				throw new ImageIsNotValidException();
			await ValueTask.CompletedTask;
		}
	}
}
