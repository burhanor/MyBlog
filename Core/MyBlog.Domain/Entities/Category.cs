using MyBlog.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Entities
{
	public class Category:EntityBase
	{
		public string Name { get; set; } = string.Empty;
        public int ParentId { get; set; }
        public int DisplayOrder { get; set; }
        public string Url { get; set; } = string.Empty;
		public string IconContent { get; set; } = string.Empty;
        public ICollection<PostCategory> PostCategories { get; set; }
    }
}
