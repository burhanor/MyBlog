using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Models.Series
{
	public class SeriesModel
	{
		public string Title { get; set; } = string.Empty;
		public string Summary { get; set; } = string.Empty;
		public string Url { get; set; } = string.Empty;
		public DateTime? PublishedDate { get; set; }
		public bool IsPublished { get; set; }
		public IFormFile? HeaderImage { get; set; }
		public IFormFile? ThumbnailImage { get; set; }

	}
}
