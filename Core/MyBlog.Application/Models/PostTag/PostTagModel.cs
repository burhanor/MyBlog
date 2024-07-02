using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Models.PostTag
{
	public class PostTagModel
	{
		public int PostId { get; set; }
		public int TagId { get; set; }
		public bool IsHidden { get; set; }

	}
}
