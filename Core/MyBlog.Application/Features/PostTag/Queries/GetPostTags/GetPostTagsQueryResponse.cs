using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostTag.Queries.GetPostTags
{
	public class GetPostTagsQueryResponse
	{
		public string TagName { get; set; } = string.Empty; 
		public string Url { get; set; } = string.Empty;


	}
}
