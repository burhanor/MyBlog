using MyBlog.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Entities
{
	public class Tag:EntityBase
	{
		public string Name { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
		public string Url { get; set; } = string.Empty;
        public bool IsHidden { get; set; }

        public ICollection<PostTag> PostTags { get; set; }
    }
}
