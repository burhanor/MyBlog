using MediatR;
using MyBlog.Application.Models;
using MyBlog.Application.Models.PostCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostCategory.Queries.GetPostCategories
{
	public class GetPostCategoriesQueryRequest:IRequest<ResponseContainer<IList<GetPostCategoriesQueryResponse>>>
	{
        public GetPostCategoriesQueryRequest()
        {
            
        }
        public GetPostCategoriesQueryRequest(int postId)
		{
			PostId = postId;
		}

		public int PostId { get; set; }
    }
}
