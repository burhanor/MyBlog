using MyBlog.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Entities
{
	public class PostRecommendation:IEntityBase
	{
        public int PostId { get; set; }
        public int DisplayOrder { get; set; }
        public Post Post { get; set; }
    }
}
