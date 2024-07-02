using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostCategory.Queries.GetPostCategories
{
	public class GetPostCategoriesQueryResponse
	{
		public string CategoryName { get; set; } = string.Empty; 
		public string Url { get; set; } = string.Empty;

	}
}
