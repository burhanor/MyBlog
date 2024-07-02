using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Models.PostRecommendation
{
	public class RecommendationResponseModel
	{
		public string Title { get; set; } = string.Empty;
		public string Url { get; set; } = string.Empty;
		public string Image { get; set; } = string.Empty;
	}
}
