using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Models.PostTag
{
	public class PostTagResponseModel
	{
		public string TagName { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
	}
}
