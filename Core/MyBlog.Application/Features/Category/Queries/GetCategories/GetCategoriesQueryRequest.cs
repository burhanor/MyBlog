using MediatR;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Category.Queries.GetCategories
{
	public class GetCategoriesQueryRequest:IRequest<ResponseContainer<IList<GetCategoriesQueryResponse>>>
	{
		public int? PageSize { get; set; }
		public int? PageNumber { get; set; }
		public string? Search { get; set; }
		public string? OrderBy { get; set; }
	}
}
