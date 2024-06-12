using MyBlog.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Entities
{
	public class PostImage:IEntityBase
	{
        public int PostId { get; set; }
        public int ImageId { get; set; }
        public Post Post { get; set; }
        public Image Image { get; set; }
    }
}
