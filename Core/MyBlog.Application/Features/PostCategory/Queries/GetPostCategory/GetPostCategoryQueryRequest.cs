using MediatR;
using MyBlog.Application.Models;
using MyBlog.Application.Models.PostCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostCategory.Queries.GetPostCategory
{
	public class GetPostCategoryQueryRequest:PostCategoryModel,IRequest<ResponseContainer<GetPostCategoryQueryResponse>>	
	{

	}
}
