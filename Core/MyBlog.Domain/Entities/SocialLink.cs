using MyBlog.Domain.Commons;
using MyBlog.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Entities
{
	public class SocialLink:EntityBase
	{
        public SocialMediaType SocialMediaType { get; set; }
        public int AuthorId { get; set; }
        public string Url { get; set; }
        public Author Author { get; set; }
    }
}
