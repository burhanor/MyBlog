using MyBlog.Application.Features.Category.Queries.GetCategory;
using MyBlog.Application.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Category.Queries.GetCategories
{
	public class GetCategoriesQueryResponse : GetCategoryQueryResponse
	{
        public int Id { get; set; }
    }
}
