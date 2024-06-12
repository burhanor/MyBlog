using MyBlog.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Entities
{
	public class Series:EntityBase
	{
		public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public string Url { get; set; } = string.Empty;
        public DateTime? PublishedDate { get; set; }
        public bool IsPublished { get; set; }
        public ICollection<PostSeries> PostSeries { get; set; }
        public ICollection<SeriesImage> SeriesImages { get; set; }
        public Author Author { get; set; }
    }
}
