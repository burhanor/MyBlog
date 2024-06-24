using MyBlog.Application.Features.Author.Queries.GetAuthors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Extensions
{
	public static class GetAuthorsQueryRequestExtension
	{
		public static bool IsNullOrEmpty(this GetAuthorsQueryRequest request)
		{
			if (request == null)
				return true;
			return request.PageSize == null && request.PageNumber == null && request.OrderBy == null && request.Search == null;
			
		}
	}
}
