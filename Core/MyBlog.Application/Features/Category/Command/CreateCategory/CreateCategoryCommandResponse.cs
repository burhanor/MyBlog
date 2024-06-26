using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Category.Command.CreateCategory
{
	public class CreateCategoryCommandResponse
	{
        public int Id { get; set; }
		public string ParentName { get; set; } = string.Empty;
	}
}
