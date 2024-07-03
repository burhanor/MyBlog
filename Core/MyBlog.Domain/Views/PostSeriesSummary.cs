using MyBlog.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Views
{
	public class PostSeriesSummary:IViewBase
	{
        public int PostId { get; set; }
        public int SeriesId { get; set; }
        public int DisplayOrder { get; set; }
        public string Title { get; set; } = string.Empty;
		public string Summary { get; set; } = string.Empty;
		public string ThumbnailPath { get; set; } = string.Empty;
		public string Url { get; set; } = string.Empty;
		public string AuthorName { get; set; } = string.Empty;
		public string AuthorPath { get; set; } = string.Empty;
	}
}
