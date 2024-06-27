using MyBlog.Application.Bases;
using MyBlog.Application.Exceptions.CommonExceptions;
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
	}
}
