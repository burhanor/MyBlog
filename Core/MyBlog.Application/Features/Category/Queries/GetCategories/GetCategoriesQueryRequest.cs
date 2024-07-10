using MediatR;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Category.Queries.GetCategories
{
	public class GetCategoriesQueryRequest:FilterModel,IRequest<ResponseContainer<IList<GetCategoriesQueryResponse>>>
	{
	}
}
