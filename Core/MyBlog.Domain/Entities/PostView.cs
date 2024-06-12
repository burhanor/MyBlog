using MyBlog.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Entities
{
	public class PostView:EntityBase
	{
        public int PostId { get; set; }
        public string IpAddress { get; set; } = string.Empty;
        public DateTime VisitDate { get; set; } = DateTime.Now;
        public Post Post { get; set; }
    }
}
