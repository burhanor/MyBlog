using MyBlog.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Entities
{
	public class Menu:EntityBase
	{
        public int ParentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string IconContent { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
    }
}
