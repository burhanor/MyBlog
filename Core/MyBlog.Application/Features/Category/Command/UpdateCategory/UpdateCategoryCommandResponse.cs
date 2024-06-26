using MyBlog.Application.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Category.Command.UpdateCategory
{
	public class UpdateCategoryCommandResponse
	{
		public string ParentName { get; set; } = string.Empty;
	}
}
