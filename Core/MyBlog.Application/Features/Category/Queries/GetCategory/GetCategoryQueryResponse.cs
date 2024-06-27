using MyBlog.Application.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Category.Queries.GetCategory
{
	public class GetCategoryQueryResponse:CategoryModel
	{
        public int Id { get; set; }
        public string ParentCategoryName { get; set; }=string.Empty;
    }
}
