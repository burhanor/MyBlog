using MyBlog.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Entities
{
	public class Post:EntityBase
	{
		public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string HtmlContent { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
		public int AuthorId { get; set; }
        public DateTime? PublishDate { get; set; }
        public bool IsPublished { get; set; }
        public Author Author { get; set; }
        public ICollection<PostCategory> PostCategories { get; set; }
        public ICollection<PostTag> PostTags { get; set; }
        public ICollection<PostSeries> PostSeries { get; set; }
        public ICollection<PostImage> PostImages { get; set; }
        public ICollection<PostView> PostViews { get; set; }
        public PostRecommendation PostRecommendation { get; set; }

    }
}
