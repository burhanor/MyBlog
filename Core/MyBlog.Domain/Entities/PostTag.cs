using MyBlog.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Entities
{
	public class PostTag:IEntityBase
	{
        public int PostId { get; set; }
        public int TagId { get; set; }
        public Post Post { get; set; }
        public Tag Tag { get; set; }

    }
}
